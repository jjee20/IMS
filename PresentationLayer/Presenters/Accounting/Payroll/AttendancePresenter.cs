using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Accounting.Payroll.Upserts;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class AttendancePresenter
    {
        public IAttendanceView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<AttendanceViewModel> AttendanceList;
        public AttendancePresenter(IAttendanceView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.ShowAttendanceEvent += ShowAttendance;
            _view.PrintEvent += Print;

            //Load

            LoadAllAttendanceList();

            //Source Binding
        }

        private void ShowAttendance(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AttendanceViewModel row)
            {
                var entity = _unitOfWork.Employee.Value.Get(
                    c => c.EmployeeId == row.EmployeeId);

                using (var form = new IndividualAttendanceView(_unitOfWork, entity))
                {
                    form.Text = $"{row.Employee} - Attendance";
                    form.StartDate = _view.StartDate.Date;
                    form.EndDate = _view.EndDate.Date;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllAttendanceList();
                    }
                }
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertAttendanceView(_unitOfWork))
            {
                form.Text = "Add Attendance";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllAttendanceList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllAttendanceList(emptyValue);
        }
       
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "AttendanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Attendance", AttendanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllAttendanceList(bool emptyValue = false)
        {
            AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date);

            if (!emptyValue) AttendanceList = AttendanceList.Where(c => c.Employee.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetAttendanceListBindingSource(AttendanceList);
        }
        public List<AttendanceViewModel> GetAttendanceSummary(DateTime startDate, DateTime endDate)
        {
            var employees = _unitOfWork.Employee.Value.GetAll(includeProperties: "Attendances,Leaves,Shift,Attendances.Project");
            var holidays = _unitOfWork.Holiday.Value.GetAll().Where(h => h.EffectiveDate >= startDate && h.EffectiveDate <= endDate).ToList();
            var summaryList = new List<AttendanceViewModel>();

            int totalDays = 0;
            DateTime currentDate = startDate.Date;

            do
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday) // Exclude Sundays
                {
                    totalDays++;
                }

                currentDate = currentDate.AddDays(1);
            } while (currentDate <= endDate.Date);

            foreach (var employee in employees.OrderBy(c => c.LastName))
            {
                var attendances = employee.Attendances
                    .Where(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date)
                    .ToList();

                var approvedLeaves = employee.Leaves
                    .Where(l => l.StartDate.Date <= startDate.Date && l.EndDate.Date >= endDate.Date &&
                     l.LeaveType != LeaveType.UnpaidLeave && l.Status == Status.Approved)
                    .ToList();


                TimeSpan shiftStartTime = (TimeSpan)(employee.Shift?.StartTime);
                TimeSpan shiftEndTime = (TimeSpan)(employee.Shift?.EndTime);

                double daysPresent = attendances.Count(a => a.IsPresent && !a.IsHalfDay && !IsCoveredByLeave(a.Date, approvedLeaves));
                double daysHalfDayPresent = attendances.Count(a => a.IsPresent && a.IsHalfDay && !IsCoveredByLeave(a.Date, approvedLeaves)) * 0.5;
                double totalPresentDays = daysPresent + daysHalfDayPresent;
                double totalOvertime = 0;

                foreach (var att in attendances)
                {
                    if (employee.Shift == null || !att.IsPresent) continue;

                    double workedHours = att.HoursWorked;
                    bool isHoliday = holidays.Any(h => h.EffectiveDate.Date == att.Date.Date);

                    if (isHoliday)
                    {
                        // Holiday rule: Regular hours are 8 AM - 3 PM (7 hours), after 3 PM is overtime
                        TimeSpan holidayCutoff = new TimeSpan(15, 0, 0); // 3:00 PM
                        if (att.TimeOut > holidayCutoff)
                        {
                            totalOvertime += (att.TimeOut - holidayCutoff).TotalHours;
                        }
                    }
                    else
                    {
                        // Normal shift overtime logic
                        double regularHours = employee.Shift.RegularHours;
                        if (workedHours > regularHours)
                            totalOvertime += workedHours - regularHours;
                    }
                }

                int daysLate = attendances.Count(a => a.TimeIn > shiftStartTime && !a.IsHalfDay);
                int daysEarlyOut = 0;

                foreach (var att in attendances)
                {
                    if (!att.IsPresent || att.IsHalfDay) continue;

                    bool isHoliday = holidays.Any(h => h.EffectiveDate.Date == att.Date.Date);

                    TimeSpan expectedOut = isHoliday
                        ? new TimeSpan(15, 0, 0)  // 3:00 PM on holidays
                        : shiftEndTime;           // normal shift end

                    if (att.TimeOut < expectedOut)
                        daysEarlyOut++;
                }

                int daysOnLeave = approvedLeaves.Sum(l => (l.EndDate - l.StartDate).Days + 1);
                double daysAbsent = totalDays > totalPresentDays ? totalDays - (totalPresentDays + daysOnLeave) : 0;

                summaryList.Add(new AttendanceViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    Employee = $"{employee.LastName}, {employee.FirstName}",
                    TotalDays = totalDays,
                    DaysPresent = totalPresentDays,
                    TotalOvertime = totalOvertime,
                    DaysLate = daysLate,
                    DaysEarlyOut = daysEarlyOut,
                    DaysAbsent = daysAbsent,
                    DaysOnLeave = daysOnLeave
                });
            }
            return summaryList.ToList();
        }
        private bool IsCoveredByLeave(DateTime date, IEnumerable<Leave> approvedLeaves)
        {
            return approvedLeaves.Any(leave => date >= leave.StartDate && date <= leave.EndDate);
        }
    }
}
