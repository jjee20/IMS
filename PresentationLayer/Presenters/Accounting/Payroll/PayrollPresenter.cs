using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Views.UserControls.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Events;
using static ServiceLayer.Services.CommonServices.EventClasses;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class PayrollPresenter
    {
        public IPayrollView _view;
        private readonly IUnitOfWork _unitOfWork;
        
        private BindingSource ProjectBindingSource;
        private List<PayrollViewModel> PayrollVMList;
        private List<DomainLayer.Models.Accounting.Payroll.Payroll> PayrollList;
        private IEnumerable<Project> ProjectList;
        private string ProjectName;
        public PayrollPresenter(IPayrollView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            
            ProjectBindingSource = new BindingSource();
            PayrollVMList = new List<PayrollViewModel>();
            PayrollList = new List<DomainLayer.Models.Accounting.Payroll.Payroll>();
            _view.PrintPayrollEvent -= PrintPayroll;
            _view.SearchEvent -= Search;
            _view.TMonthEvent -= TMonthPayCalculation;
            _view.PrintPaySlipEvent -= PrintPayslip;
            _view.RefreshEvent -= Refresh;
            
            _view.PrintPayrollEvent += PrintPayroll;
            _view.SearchEvent += Search;
            _view.TMonthEvent += TMonthPayCalculation;
            _view.PrintPaySlipEvent += PrintPayslip;
            _view.RefreshEvent += Refresh;

            //Load
            
            RefreshView();
        }

        private void Refresh(object? sender, EventArgs e) => RefreshView();

        private  void RefreshView()
        {
             LoadAllProjectList();
            _view.SetProjectListBindingSource(ProjectBindingSource);
             LoadAllPayrollList(_view.StartDate.Date, _view.EndDate.Date);
        }

        private void PrintPayslip(object sender, CellClickEventArgs e)
        {
            var payslip = e.DataRow.RowData as PayrollViewModel;

            if (payslip != null)
            {
                try
                {
                    string reportFileName = "PayslipReport.rdlc";
                    string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Accounting", "Payroll");
                    string reportPath = Path.Combine(reportDirectory, reportFileName);

                    var payslipList = new[]
                    {
                         payslip
                        };

                    if (!File.Exists(reportPath))
                    {
                        _view.Message = "Payslip report template not found.";
                        return;
                    }

                    var localReport = new LocalReport();
                    var reportDataSource = new ReportDataSource("Payslip", payslipList);
                    var parameters = new List<ReportParameter>
                {
                    new ReportParameter("PayrollPeriod", $"Payslip Period: {_view.StartDate.ToShortDateString()} to {_view.EndDate.ToShortDateString()}"),
                    new ReportParameter("Employee", payslip.Employee),
                    new ReportParameter("DailyRate", payslip.DailyRate.ToString()),
                    new ReportParameter("NoOfDaysWorked", payslip.DaysWorked.ToString()),
                    new ReportParameter("BasicSalary", payslip.BasicSalary.ToString()),
                    new ReportParameter("OvertimePay", payslip.OvertimePay.ToString()),
                    new ReportParameter("Allowances", payslip.Allowances.ToString()),
                    new ReportParameter("Benefits", payslip.Benefits.ToString()),
                    new ReportParameter("Bonuses", payslip.Bonuses.ToString()),
                    new ReportParameter("GrossPay", payslip.GrossPay.ToString()),
                    new ReportParameter("Deductions", payslip.Deductions.ToString()),
                    new ReportParameter("LateAndEarly", payslip.LateAndEarly.ToString()),
                    new ReportParameter("Absent", payslip.Absent.ToString()),
                    new ReportParameter("SSSContribution", payslip.SSSContribution.ToString()),
                    new ReportParameter("PagibigContribution", payslip.PagibigContribution.ToString()),
                    new ReportParameter("PhilHealthContribution", payslip.PhilHealthContribution.ToString()),
                    new ReportParameter("TotalDeduction", payslip.TotalDeduction.ToString()),
                    new ReportParameter("NetPay", payslip.NetPay.ToString()),
                };
                    var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
                    reportView.ShowDialog();
                }
                catch (Exception ex)
                {
                    _view.Message = $"An error occurred while generating the report: {ex.Message}";
                }
            }
        }

        private void TMonthPayCalculation(object? sender, CellClickEventArgs e)
        {
            var rowData = e.DataRow.RowData as PayrollViewModel;
            var employeeName = rowData.Employee.Split(',');
            var employee = _unitOfWork.Employee.Value.Get(c => c.LastName == employeeName[0].Trim() && c.FirstName == employeeName[1].Trim(), includeProperties: "Department,JobPosition,Leaves,Attendances,");
            if (rowData != null)
            {
                using var tmonth = new _Upsert13thMonthView(rowData, _unitOfWork, employee);
                tmonth.ShowDialog();
            }
        }

        private void LoadAllPayrollList(DateTime startDate, DateTime endDate, int? projectId = 0)
        {
            PayrollList.Clear();
            PayrollVMList.Clear();

            var employees =  _unitOfWork.Employee.Value.GetAll(
                     c => c.isActive != false && (c.ContractStartDate.Date <= startDate.Date && c.ContractEndDate.Date >= endDate.Date),
                     includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves,Contribution"
                 );

            var holidayList =  _unitOfWork.Holiday.Value.GetAll(h => h.EffectiveDate.Date >= startDate && h.EffectiveDate.Date <= endDate);
            var holidays = holidayList.ToList();

            if (!_view.All && projectId.HasValue)
            {
                employees = employees.Where(e => e.Attendances.Any(a => a.ProjectId == projectId));
                var project =  _unitOfWork.Project.Value.Get(p => p.ProjectId == projectId);
                ProjectName = $"Project: {project?.ProjectName ?? ""}";
            }
            else
            {
                ProjectName = "Project: All";
            }

            PayrollList = employees.OrderBy(e => e.LastName).Select(employee =>
            {
                var attendances = employee.Attendances?.Where(a => a.Date.Date >= startDate && a.Date.Date <= endDate) ?? Enumerable.Empty<Attendance>();
                var approvedLeaves = employee.Leaves.Where(l => l.LeaveType != LeaveType.UnpaidLeave && l.Status == Status.Approved);
                var contributionsData = employee.Contribution;

                int totalDays = PayrollHelper.TotalDays(employee.Attendances, startDate, endDate);
                double shiftHours = employee.Shift?.RegularHours ?? 8;
                double hourlyRate = employee.BasicSalary /  shiftHours;
                double regularPay = employee.BasicSalary * totalDays;

                double fullDays = attendances.Count(a => a.IsPresent && !a.IsHalfDay && !PayrollHelper.IsCoveredByLeave(a.Date, approvedLeaves));
                double halfDays = attendances.Count(a => a.IsPresent && a.IsHalfDay && !PayrollHelper.IsCoveredByLeave(a.Date, approvedLeaves)) * 0.5;
                double presentDays = fullDays + halfDays;

                double overtimeHours = attendances.Sum(a => Math.Max(0, a.HoursWorked - shiftHours));
                double overtimePay = overtimeHours * hourlyRate;

                double allowancePay = PayrollHelper.CalculateAllowances(employee, startDate, endDate);
                double bonusPay = PayrollHelper.CalculateBonuses(employee, startDate, endDate);
                double benefitPay = _view.IncludeBenefits ? PayrollHelper.CalcuLateBenefits(employee) : 0;
                double otherDeductions = PayrollHelper.CalculateDeductions(employee, startDate, endDate);

                double absentDeduction = PayrollHelper.CalculateAbsentDeductions(totalDays, presentDays, employee.BasicSalary);
                double lateDeduction = PayrollHelper.CalculateLateDeductions(employee, attendances, hourlyRate);
                double earlyOutDeduction = PayrollHelper.CalculateEarlyOutDeductions(employee, attendances, hourlyRate, holidays);
                double totalLateEarly = lateDeduction + earlyOutDeduction;

                double sss = (_view.IncludeContribution && employee.isDeducted)
                    ? (contributionsData?.SSS ?? 0) + (contributionsData?.SSSWISP ?? 0)
                    : 0;
                double pagibig = (_view.IncludeContribution && employee.isDeducted) ? contributionsData?.PagIbig ?? 0 : 0;
                double philHealth = (_view.IncludeContribution && employee.isDeducted) ? contributionsData?.PhilHealth ?? 0 : 0;

                return new DomainLayer.Models.Accounting.Payroll.Payroll
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = $"{employee.LastName}, {employee.FirstName}",
                    StartDate = startDate,
                    EndDate = endDate,
                    DailyRate = employee.BasicSalary,
                    DaysWorked = presentDays,
                    BasicSalary = Math.Round(regularPay, 0),
                    OvertimePay = Math.Round(overtimePay, 0),
                    Allowances = Math.Round(allowancePay, 0),
                    Benefits = Math.Round(benefitPay, 0),
                    Bonuses = Math.Round(bonusPay, 0),
                    Deductions = Math.Round(otherDeductions, 0),
                    Absent = Math.Round(absentDeduction, 0),
                    LateAndEarly = Math.Round(totalLateEarly, 0),
                    SSSContribution = Math.Round(sss, 0),
                    PagibigContribution = Math.Round(pagibig, 0),
                    PhilHealthContribution = Math.Round(philHealth, 0),
                };
            }).ToList();

            PayrollVMList = Program.Mapper.Map<List<PayrollViewModel>>(PayrollList);

            _view.SetPayrollListBindingSource(PayrollVMList.OrderBy(e => e.Employee).ToList());
        }

        private  void Search(object? sender, EventArgs e)
        {
            try
            {
                // Validate date range
                if (_view.StartDate.Date > _view.EndDate.Date)
                {
                    _view.Message = "Start date must be earlier than or equal to the end date. Result not found.";
                    _view.IsSuccessful = false;
                    return;
                }

                 LoadAllPayrollList(_view.StartDate.Date, _view.EndDate.Date, _view.ProjectId);

            }
            catch (Exception ex)
            {
                _view.Message = $"An error occurred while processing payroll: {ex.Message}";
            }
        }

        private  void PrintPayroll(object? sender, EventArgs e)
        {
            foreach (var payroll in PayrollList)
            {
                var existingPayroll =  _unitOfWork.Payroll.Value
                    .Get(p => p.EmployeeId == payroll.EmployeeId && p.StartDate.Date == _view.StartDate.Date && p.EndDate.Date == _view.EndDate.Date);

                if (existingPayroll != null)
                {
                    // Update fields
                    existingPayroll.DailyRate = payroll.DailyRate;
                    existingPayroll.DaysWorked = payroll.DaysWorked;
                    existingPayroll.BasicSalary = payroll.BasicSalary;
                    existingPayroll.OvertimePay = payroll.OvertimePay;
                    existingPayroll.Allowances = payroll.Allowances;
                    existingPayroll.Benefits = payroll.Benefits;
                    existingPayroll.Bonuses = payroll.Bonuses;
                    existingPayroll.LateAndEarly = payroll.LateAndEarly;
                    existingPayroll.Absent = payroll.Absent;
                    existingPayroll.SSSContribution = payroll.SSSContribution;
                    existingPayroll.PagibigContribution = payroll.PagibigContribution;
                    existingPayroll.PhilHealthContribution = payroll.PhilHealthContribution;
                    existingPayroll.Deductions = payroll.Deductions;

                    _unitOfWork.Payroll.Value.Update(existingPayroll); // Use Update
                }
                else
                {
                     _unitOfWork.Payroll.Value.Add(payroll); // Use Add for new records
                }
            }

             _unitOfWork.Save();


            try
            {
                string reportFileName = "PayrollReport.rdlc";
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Accounting", "Payroll");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                if (!File.Exists(reportPath))
                {
                    _view.Message = "Payroll report template not found.";
                    return;
                }

                var localReport = new LocalReport();
                var reportDataSource = new ReportDataSource("Payroll", PayrollVMList);
                var parameters = new List<ReportParameter>
                {
                    new ReportParameter("PayrollPeriod", $"Payroll Period: {_view.StartDate.ToShortDateString()} to {_view.EndDate.ToShortDateString()}"),
                    new ReportParameter("Total", PayrollVMList.Sum(c => c.NetPay).ToString()),
                    new ReportParameter("Project", ProjectName),
                };
                //localReport.SetParameters(parameters);
                using (var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters))
                {
                    reportView.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _view.Message = $"An error occurred while generating the report: {ex.Message}";
            }
        }
        private void LoadAllProjectList()
        {
            ProjectList = _unitOfWork.Project.Value.GetAll();
            ProjectBindingSource.DataSource = ProjectList;
        }
    }
}
