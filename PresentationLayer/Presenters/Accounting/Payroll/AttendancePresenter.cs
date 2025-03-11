using CsvHelper;
using CsvHelper.Configuration;
using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories.IInventory;
using System.Formats.Asn1;
using System.Globalization;
using Windows.Devices.Usb;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class AttendancePresenter
    {
        public IAttendanceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource AttendanceBindingSource;
        private BindingSource IndividualAttendanceBindingSource;
        private BindingSource EmployeeBindingSource;
        private BindingSource ProjectBindingSource;
        private IEnumerable<AttendanceViewModel> AttendanceList;
        private IEnumerable<IndividualAttendanceViewModel> IndividualAttendanceList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        private IEnumerable<Project> ProjectList;
        public AttendancePresenter(IAttendanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AttendanceBindingSource = new BindingSource();
            IndividualAttendanceBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();
            ProjectBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.SearchEvent += Search;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            _view.ShowAttendanceEvent += ShowAttendance;
            _view.ImportEvent += Import;

            //Load

            LoadAllEmployeeList();
            LoadAllProjectList();
            LoadAllAttendanceList();

            //Source Binding
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
            _view.SetProjectListBindingSource(ProjectBindingSource);
            _view.SetAttendanceListBindingSource(AttendanceBindingSource);

        }

        private void Delete(object? sender, EventArgs e)
        {
            var attendanceVM = (IndividualAttendanceViewModel)IndividualAttendanceBindingSource.Current;

            if (attendanceVM == null)
            {
                _view.Message = "Please select individual attendance. Double click the name you want to check the attendance details";
                return;
            }

            var attendance = _unitOfWork.Attendance.Get(c => c.AttendanceId == attendanceVM.AttendanceId, includeProperties: "Employee", tracked: true);

            _unitOfWork.Attendance.Detach(attendance);
            _unitOfWork.Attendance.Remove(attendance);
            _unitOfWork.Save();

            _view.Message = "Attendance deleted successfully";
            LoadAllIndividualAttendanceList(_view.EmployeeIdFromTextBox);
        }

        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var attendanceVM = (IndividualAttendanceViewModel)IndividualAttendanceBindingSource.Current;

            if (attendanceVM == null)
            {
                _view.Message = "Please select individual attendance. Double click the name you want to check the attendance details";
                return;
            }



            var attendance = _unitOfWork.Attendance.Get(c => c.AttendanceId == attendanceVM.AttendanceId, includeProperties: "Employee,Project");


            _view.AttendanceId = attendance.AttendanceId;
            _view.EmployeeId = attendance.EmployeeId;
            _view.TimeIn = attendance.TimeIn;
            _view.TimeOut = attendance.TimeOut;
            _view.Date = attendance.Date;
            _view.IsPresent = attendance.IsPresent;
            _view.IsHalfDay = attendance.IsHalfDay;
            _view.HoursWorked = attendance.HoursWorked;
            _view.ProjectId = attendance.ProjectId;
        }

        private void Import(object? sender, EventArgs e)
        {
            _unitOfWork.Attendance.AddRange(ImportAttendance());
            _unitOfWork.Save();

            _view.Message = "Attendance imported successfully.";
        }

        public static List<Attendance> ImportAttendance()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Attendance CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName; // Get selected file path
                    return ReadCsv(filePath);
                }
            }

            return new List<Attendance>(); // Return empty list if no file is selected
        }

        private static List<Attendance> ReadCsv(string filePath)
        {
            var attendanceList = new List<Attendance>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Ensure headers exist
                Delimiter = ",", // Define CSV delimiter
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var record = new Attendance
                    {
                        AttendanceId = csv.GetField<int>("AttendanceId"),
                        EmployeeId = csv.GetField<int>("EmployeeId"),
                        Date = csv.GetField<DateTime>("Date"),
                        TimeIn = TimeSpan.Parse(csv.GetField<string>("TimeIn")),
                        TimeOut = TimeSpan.Parse(csv.GetField<string>("TimeOut")),
                        IsPresent = csv.GetField<bool>("IsPresent"),
                        HoursWorked = csv.GetField<double>("HoursWorked")
                    };

                    attendanceList.Add(record);
                }
            }

            return attendanceList;
        }

        private void ShowAttendance(object? sender, DataGridViewCellEventArgs e)
        {
            _view.IsIndividual = true;
            var attendanceVM = (AttendanceViewModel)AttendanceBindingSource.Current;

            if (attendanceVM == null)
            {
                MessageBox.Show("No attendance record selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.EmployeeName = attendanceVM.Employee;
            _view.EmployeeIdFromTextBox = attendanceVM.EmployeeId;
            LoadAllIndividualAttendanceList(attendanceVM.EmployeeId);
            _view.SetIndividualAttendanceListBindingSource(IndividualAttendanceBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsIndividual = false;
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            // Retrieve the specific attendance record based on the _view.AttendanceId
            var model = _unitOfWork.Attendance.Get(c => c.AttendanceId == _view.AttendanceId, tracked: true);

            // If no record exists, create a new instance
            if (model == null) model = new Attendance();
            else _unitOfWork.Attendance.Detach(model);

            // Assign updated values from the view
            model.EmployeeId = _view.EmployeeId;
            model.ProjectId = _view.ProjectId;
            model.TimeIn = _view.TimeIn;
            model.TimeOut = _view.TimeOut;
            model.Date = _view.Date;
            model.IsHalfDay = _view.IsHalfDay;
            model.IsPresent = _view.IsPresent;
            model.HoursWorked = _view.HoursWorked;

            try
            {
                // Validate the model
                new ModelDataValidation().Validate(model);

                if (_view.IsEdit) // Editing existing record
                {
                    _unitOfWork.Attendance.Update(model);
                    _view.Message = "Attendance edited successfully";
                }
                else // Adding a new record
                {
                    _unitOfWork.Attendance.Add(model);
                    _view.Message = "Attendance added successfully";
                }

                // Save changes to the database
                _unitOfWork.Save();
                _view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"Error: {ex.Message}";
            }
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            bool hasDateRange = _view.StartDate != null && _view.EndDate != null;

            AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date);

            if (_view.IsIndividual)
            {
                LoadAllIndividualAttendanceList(_view.EmployeeIdFromTextBox);
            }
            else
            {
                if (!emptyValue || hasDateRange)
                {
                    AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date).Where(c => emptyValue || c.Employee.Contains(_view.SearchValue) || c.Employee.Contains(_view.SearchValue));
                    AttendanceBindingSource.DataSource = AttendanceList;
                }
                else
                {
                    LoadAllAttendanceList();
                }
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "";
            ReportDataSource reportDataSource;
            if (_view.IsIndividual)
            {
                reportFileName = "IndividualAttendanceReport.rdlc";
                reportDataSource = new ReportDataSource("Attendance", IndividualAttendanceList);
            }
            else
            {
                reportFileName = "AttendanceReport.rdlc";
                reportDataSource = new ReportDataSource("Attendance", AttendanceList);
            }


            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllIndividualAttendanceList(_view.EmployeeIdFromTextBox);
            LoadAllAttendanceList();
        }
        private void CleanviewFields()
        {
            LoadAllAttendanceList();
            LoadAllIndividualAttendanceList(_view.EmployeeIdFromTextBox);
        }

        public List<AttendanceViewModel> GetAttendanceSummary(DateTime startDate, DateTime endDate)
        {
            var employees = _unitOfWork.Employee.GetAll(includeProperties: "Attendances,Leaves,Shift,Attendances.Project");
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
                double totalOvertime = attendances.Sum(c => employee.Shift.RegularHours > c.HoursWorked ? 0 : c.HoursWorked - employee.Shift.RegularHours);
                int daysLate = attendances.Count(a => a.TimeIn > shiftStartTime && !a.IsHalfDay);
                int daysEarlyOut = attendances.Count(a => a.TimeOut.Hours < shiftEndTime.Hours && !a.IsHalfDay);
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
        private void LoadAllAttendanceList()
        {
            AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date);
            AttendanceBindingSource.DataSource = AttendanceList.OrderBy(c => c.Employee);//Set data source.
        }
        private void LoadAllIndividualAttendanceList(int id)
        {
            IndividualAttendanceList = Program.Mapper.Map<IEnumerable<IndividualAttendanceViewModel>>(_unitOfWork.Attendance.GetAll(c => c.EmployeeId == id &&
                c.Date.Date >= _view.StartDate.Date && c.Date.Date <= _view.EndDate.Date, includeProperties: "Project,Employee"));
            IndividualAttendanceBindingSource.DataSource = IndividualAttendanceList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
        }
        private void LoadAllProjectList()
        {
            ProjectList = _unitOfWork.Project.GetAll();
            ProjectBindingSource.DataSource = ProjectList;//Set data source.
        }
    }
}
