using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using RavenTech_ERP.Helpers;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class PayrollPresenter
    {
        public IPayrollView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProjectBindingSource;
        private List<PayrollViewModel> PayrollList;
        private IEnumerable<Project> ProjectList;
        private string ProjectName;
        public PayrollPresenter(IPayrollView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProjectBindingSource = new BindingSource();
            PayrollList = new List<PayrollViewModel>();
            //Load

            LoadAllProjectList();
            LoadAllPayrollList();
            _view.PrintPayrollEvent += PrintPayroll;
            _view.PrintPayslipEvent += PrintPayslip;
            _view.SearchEvent += Search;
            _view.IncludeBenefitsEvent += OnIncludeBenefits;
            _view.ProjectEvent += SelectProject;
            _view.AllEvent += SelectAll;

            _view.SetProjectListBindingSource(ProjectBindingSource);
        }

        private void SelectAll(object? sender, EventArgs e)
        {
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date, _view.ProjectId);
            _view.SetPayrollListBindingSource(PayrollList);
        }

        private void SelectProject(object? sender, EventArgs e)
        {
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date, _view.ProjectId);
            _view.SetPayrollListBindingSource(PayrollList);
        }

        private void OnIncludeBenefits(object? sender, EventArgs e)
        {
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date);
            _view.SetPayrollListBindingSource(PayrollList);
        }

        private void PrintPayslip(object? sender, EventArgs e)
        {
            try
            {
                string reportFileName = "PayslipReport.rdlc";
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                var payslip = (PayrollViewModel)_view.DataGrid.SelectedItem;
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
                _view.SetPayrollListBindingSource(PayrollList);

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
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Accounting", "Payroll");
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
                    new ReportParameter("Total", PayrollList.Sum(c => c.NetPay).ToString()),
                    new ReportParameter("Project", ProjectName),
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
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date, _view.ProjectId);
            _view.SetPayrollListBindingSource(PayrollList);
        }

        public List<PayrollViewModel> CalculatePayroll(DateTime startDate, DateTime endDate, int? projectId = 0)
        {
            var employees = _unitOfWork.Employee.Value.GetAll(includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves,Contribution");
            var contributions = _unitOfWork.Contribution.Value.GetAll();
            var project = _unitOfWork.Project.Value.Get(c => c.ProjectId == projectId);
            var projectName = "";
            if(project != null)
                projectName = $"Project: {project.ProjectName}";
            else
            {
                projectName = "Project: All";
            }

            if (!_view.All)
            {
                employees = employees.Where(c => c.Attendances.Any(c => c.ProjectId == projectId));
                ProjectName = projectName;
            }
            else
            {
                ProjectName = projectName;
            }

            var payrollList = new List<PayrollViewModel>();
            
            foreach (var employee in employees.OrderBy(c => c.LastName))
            {
                int totalDays = PayrollHelper.TotalDays(employee.Attendances, startDate, endDate);
                var employeeAttendances = employee.Attendances?.Where(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date) ?? Enumerable.Empty<Attendance>();
                var employeeContributions = employee.Contribution;

                var approvedLeaves = employee.Leaves.Where(a => a.LeaveType != LeaveType.UnpaidLeave && a.Status == Status.Approved);
                double totalPresentWholeDays = employeeAttendances.Count(a => a.IsPresent && !a.IsHalfDay && !PayrollHelper.IsCoveredByLeave(a.Date, approvedLeaves));
                double totalPresentHalfDays = employeeAttendances.Count(a => a.IsPresent && a.IsHalfDay && !PayrollHelper.IsCoveredByLeave(a.Date, approvedLeaves)) * 0.5;
                double totalPresentDays = totalPresentWholeDays + totalPresentHalfDays;
                double regularHours = totalDays * (employee.Shift?.RegularHours ?? 0);
                double hourlyRate = employee.BasicSalary / (totalDays * (employee.Shift?.RegularHours ?? 8));
                double regularPay = totalDays * employee.BasicSalary;
                double overtimeHours = employeeAttendances.Sum(a => Math.Max(0, employee.Shift?.RegularHours > a.HoursWorked ? 0 : a.HoursWorked - (employee.Shift?.RegularHours ?? 8)));
                double overtimePay = overtimeHours * (employee.BasicSalary/employee.Shift?.RegularHours ?? 0);

                double allowancePay = PayrollHelper.CalculateAllowances(employee, startDate, endDate);
                double bonusPay = PayrollHelper.CalculateBonuses(employee, startDate, endDate);
                double deductions = PayrollHelper.CalculateDeductions(employee, startDate, endDate);

                double absentDeductions = PayrollHelper.CalculateAbsentDeductions(totalDays, totalPresentDays, employee.BasicSalary);
                double lateDeductions = PayrollHelper.CalculateLateDeductions(employee, employeeAttendances, hourlyRate);
                double earlyOutDeductions = PayrollHelper.CalculateEarlyOutDeductions(employee, employeeAttendances, hourlyRate);

                double monthlySalary = employee.BasicSalary * PayrollHelper.NonSundays(employee.Attendances, startDate);
                double sssDeduction = _view.IncludeContribution ? employee.isDeducted ? employeeContributions.SSS + employeeContributions.SSSWISP : 0 : 0;
                double pagIbigDeduction = _view.IncludeContribution ? employee.isDeducted ? employeeContributions.PagIbig : 0 : 0;
                double philHealthDeduction = _view.IncludeContribution ? employee.isDeducted ? employeeContributions.PhilHealth : 0 : 0; 
                //double sssDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.SSS, monthlySalary) / 2 : 0 : 0;
                //double pagIbigDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PagIbig, monthlySalary) / 2 : 0 : 0;
                //double philHealthDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PhilHealth, monthlySalary) / 2 : 0 : 0;

                double benefitPay = _view.IncludeBenefits ? PayrollHelper.CalcuLateBenefits(employee) : 0;

                payrollList.Add(new PayrollViewModel
                {
                    Employee = $"{employee.LastName}, {employee.FirstName}",
                    DailyRate = employee.BasicSalary,
                    DaysWorked = totalPresentDays,
                    BasicSalary = Math.Round(regularPay, 0),
                    OvertimePay = Math.Round(overtimePay, 0),
                    Allowances = Math.Round(allowancePay, 0),
                    Benefits = Math.Round(benefitPay, 0),
                    Bonuses = Math.Round(bonusPay, 0),
                    Deductions = Math.Round(deductions, 0),
                    Absent = Math.Round(absentDeductions, 0),
                    LateAndEarly = Math.Round(lateDeductions + earlyOutDeductions, 0),
                    SSSContribution = Math.Round(sssDeduction, 0),
                    PagibigContribution = Math.Round(pagIbigDeduction, 0),
                    PhilHealthContribution = Math.Round(philHealthDeduction, 0),
                });
            }

            return payrollList.OrderBy(c => c.Employee).ToList();
        }
        private void LoadAllProjectList()
        {
            ProjectList = _unitOfWork.Project.Value.GetAll();
            ProjectBindingSource.DataSource = ProjectList;
        }
    }
}
