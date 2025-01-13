using DomainLayer.Enums;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters.Payroll
{
    public class PayrollPresenter
    {
        public IPayrollView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PayrollBindingSource;
        private List<PayrollViewModel> PayrollList;
        public PayrollPresenter(IPayrollView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PayrollBindingSource = new BindingSource();
            PayrollList = new List<PayrollViewModel>();
            //Load

            LoadAllPayrollList();
            _view.PrintPayrollEvent += PrintPayroll;
            _view.PrintPayslipEvent += PrintPayslip;
            _view.SearchEvent += Search;

            _view.SetPayrollListBindingSource(PayrollBindingSource);
        }

        private void PrintPayslip(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string reportFileName = "PayslipReport.rdlc";
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                var payslip = (DomainLayer.ViewModels.PayrollViewModels.PayrollViewModel)PayrollBindingSource.Current;
                var payslipList = new []
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

        private void Search(object? sender, EventArgs e)
        {
            try
            {
                // Validate date range
                if (_view.StartDate.Date > _view.EndDate.Date)
                {
                    _view.Message = "Start date must be earlier than or equal to the end date. Result not found.";
                    return;
                }

                // Perform payroll calculation
                PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date);

                // Bind the results to the UI
                PayrollBindingSource.DataSource = PayrollList;

            }
            catch (Exception ex)
            {
                _view.Message = $"An error occurred while processing payroll: {ex.Message}";
            }
        }

        private void PrintPayroll(object? sender, EventArgs e)
        {
            try
            {
                string reportFileName = "PayrollReport.rdlc";
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                if (!File.Exists(reportPath))
                {
                    _view.Message = "Payroll report template not found.";
                    return;
                }

                var localReport = new LocalReport();
                var reportDataSource = new ReportDataSource("Payroll", PayrollList);
                var parameters = new List<ReportParameter>
                {
                    new ReportParameter("PayrollPeriod", $"Payroll Period: {_view.StartDate.ToShortDateString()} to {_view.EndDate.ToShortDateString()}"),
                };
                //localReport.SetParameters(parameters);
                var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
                reportView.ShowDialog();
            }
            catch (Exception ex)
            {
                _view.Message = $"An error occurred while generating the report: {ex.Message}";
            }
        }

        private void LoadAllPayrollList()
        {
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date);
            PayrollBindingSource.DataSource = PayrollList;
        }
        private double CalculateAllowances(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Allowances?
                .Where(a => a.EmployeeId == employee.EmployeeId &&
                            (a.IsRecurring || (a.DateGranted >= startDate && a.DateGranted <= endDate)))
                .Sum(a => a.Amount) ?? 0;
        }
        private double CalculateBonuses(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Bonuses?
                .Where(b => b.EmployeeId == employee.EmployeeId &&
                            (b.IsOneTime || (b.DateGranted >= startDate && b.DateGranted <= endDate)))
                .Sum(b => b.Amount) ?? 0;
        }
        private double CalculateContributions(IEnumerable<Contribution> contributions, ContributionType type, double basicSalary)
        {
            return contributions?
                .Where(c => c.ContributionType == type &&
                            c.MinimumLimit <= basicSalary &&
                            c.MaximumLimit >= basicSalary)
                .Sum(c => c.Rate) ?? 0;
        }

        public List<PayrollViewModel> CalculatePayroll(DateTime startDate, DateTime endDate)
        {
            var employees = _unitOfWork.Employee.GetAll(includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves");
            var contributions = _unitOfWork.Contribution.GetAll();

            var payrollList = new List<PayrollViewModel>();
            int totalDays = (endDate - startDate).Days + 1;

            foreach (var employee in employees)
            {
                var employeeAttendances = employee.Attendances?.Where(a => a.Date >= startDate && a.Date <= endDate) ?? Enumerable.Empty<Attendance>();

                var approvedLeaves = employee.Leaves.Where(a => a.LeaveType != LeaveType.UnpaidLeave && a.Status == Status.Approved);

                double totalHoursWorked = employeeAttendances.Sum(a => a.HoursWorked);
                double regularHours = totalDays * (employee.Shift?.RegularHours ?? 0);
                double hourlyRate = employee.BasicSalary / (totalDays * (employee.Shift?.RegularHours ?? 8));
                double regularPay = totalDays * employee.BasicSalary;
                double overtimeHours = employeeAttendances.Sum(a => Math.Max(0, a.HoursWorked - (employee.Shift?.RegularHours ?? 0)));
                double overtimePay = overtimeHours * (employee.Shift?.OvertimeRate ?? 0);

                double allowancePay = CalculateAllowances(employee, startDate, endDate);
                double bonusPay = CalculateBonuses(employee, startDate, endDate);
                double benefitPay = employee.Benefits?.Sum(b => b.Amount) ?? 0;
                double deductions = employee.Deductions?.Sum(d => d.Amount) ?? 0;

                var totalLateDuration = employeeAttendances
                    .Where(a => a.TimeIn > employee.Shift.StartTime)
                    .Aggregate(TimeSpan.Zero, (total, attendance) => total + employee.Shift.StartTime.Add(TimeSpan.FromMinutes(15)));

                var totalEarlyOutDuration = employeeAttendances
                    .Where(a => a.TimeOut < employee.Shift.EndTime) 
                    .Aggregate(TimeSpan.Zero, (total, attendance) => total + (employee.Shift.EndTime - attendance.TimeOut));


                int totalAbsentDays = totalDays - employeeAttendances.Where(a => a.IsPresent && !IsCoveredByLeave(a.Date, approvedLeaves)).Count();

                double totalLateHours = totalLateDuration.TotalHours;
                double totalLateMinutes = totalLateDuration.TotalMinutes;
                double totalEarlyOutHours = totalEarlyOutDuration.TotalHours;

                double lateDeductions = totalLateHours >= 1
                    ? totalLateHours * hourlyRate // Calculate in hours
                    : (hourlyRate / 60) * totalLateMinutes; // Calculate in minutes

                double earlyOutDeductions = totalEarlyOutHours * hourlyRate;

                double absentDeductions = totalAbsentDays * employee.BasicSalary;

                double sssDeduction = CalculateContributions(contributions, ContributionType.SSS, employee.BasicSalary);
                double pagIbigDeduction = CalculateContributions(contributions, ContributionType.PagIbig, employee.BasicSalary);
                double philHealthDeduction = CalculateContributions(contributions, ContributionType.PhilHealth, employee.BasicSalary) / 2;

                double grossPay = regularPay + overtimePay + allowancePay + bonusPay + benefitPay;
                double totalDeductions = deductions + absentDeductions + lateDeductions + earlyOutDeductions + sssDeduction + pagIbigDeduction + philHealthDeduction + taxDedudction;
                double netPay = grossPay - totalDeductions;

                payrollList.Add(new PayrollViewModel
                {
                    Employee = $"{employee.FirstName} {employee.LastName}",
                    BasicSalary = regularPay,
                    OvertimePay = overtimePay,
                    Allowances = allowancePay,
                    Benefits = _view.IncludeBenefits ? benefitPay : 0,
                    Bonuses = bonusPay,
                    Deductions = deductions,
                    Absent = absentDeductions,
                    LateAndEarly = lateDeductions + earlyOutDeductions,
                    SSSContribution = _view.IncludeContribution ? employee.isDeducted ? sssDeduction : 0 : 0,
                    PagibigContribution = _view.IncludeContribution ? employee.isDeducted ? pagIbigDeduction : 0 : 0,
                    PhilHealthContribution = _view.IncludeContribution ? employee.isDeducted ? philHealthDeduction : 0 : 0,
                    Tax = taxDedudction,
                    TotalDeduction = totalDeductions,
                    GrossPay = grossPay,
                    NetPay = netPay
                });
            }

            return payrollList;
        }
        private bool IsCoveredByLeave(DateTime date, IEnumerable<Leave> approvedLeaves)
        {
            return approvedLeaves.Any(leave => date >= leave.StartDate && date <= leave.EndDate);
        }

    }
}
