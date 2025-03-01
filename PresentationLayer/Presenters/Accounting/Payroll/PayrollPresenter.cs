using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
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


            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            _view.StartDate = startDate;
            _view.EndDate = endDate;

            LoadAllPayrollList();
            _view.PrintPayrollEvent += PrintPayroll;
            _view.PrintPayslipEvent += PrintPayslip;
            _view.SearchEvent += Search;
            _view.IncludeBenefitsEvent += OnIncludeBenefits;

            _view.SetPayrollListBindingSource(PayrollBindingSource);
        }

        private void OnIncludeBenefits(object? sender, EventArgs e)
        {
            PayrollList = CalculatePayroll(_view.StartDate.Date, _view.EndDate.Date);
            PayrollBindingSource.DataSource = PayrollList;
        }

        private void PrintPayslip(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string reportFileName = "PayslipReport.rdlc";
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                var payslip = (PayrollViewModel)PayrollBindingSource.Current;
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
                            (a.IsRecurring || a.DateGranted.Date >= startDate.Date && a.DateGranted.Date <= endDate.Date))
                .Sum(a => a.Amount) ?? 0;
        }
        private double CalculateBonuses(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Bonuses?
                .Where(b => b.EmployeeId == employee.EmployeeId &&
                            (b.IsOneTime || b.DateGranted.Date >= startDate.Date && b.DateGranted.Date <= endDate.Date))
                .Sum(b => b.Amount) ?? 0;
        }

        private double CalculateDeductions(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Deductions?
                .Where(b => b.EmployeeId == employee.EmployeeId &&
                            b.DateDeducted.Date >= startDate.Date && b.DateDeducted.Date <= endDate.Date)
                .Sum(b => b.Amount) ?? 0;
        }
        private double CalculateContributions(IEnumerable<Contribution> contributions, ContributionType type, double basicSalary)
        {
            var applicableRates = contributions?
                .Where(c => c.ContributionType == type &&
                            c.MinimumLimit <= basicSalary &&
                            c.MaximumLimit >= basicSalary);

            if (applicableRates == null || !applicableRates.Any())
                return 0;

            // Contribution Computation based on Type
            switch (type)
            {
                case ContributionType.SSS:
                    return applicableRates.Sum(c => c.EmployeeRate); // Sum up fixed SSS rates

                case ContributionType.PagIbig:
                    return applicableRates.Sum(c => c.EmployeeRate / 100 * basicSalary); // Pag-IBIG is percentage-based

                case ContributionType.PhilHealth:
                    double computedPhilHealth = applicableRates.Sum(c => c.EmployeeRate / 100 * basicSalary);
                    return basicSalary < 10000 ? 500 : basicSalary > 100000 ? 5000 : computedPhilHealth; // Enforce PhilHealth min/max

                default:
                    return 0;
            }
        }
        private double CalculateLateDeductions(Employee employee, IEnumerable<Attendance> employeeAttendances, double hourlyRate)
        {
            var totalLateDuration = employeeAttendances
                .Where(a => a.TimeIn > employee.Shift?.StartTime) // Only consider late arrivals
                .Aggregate(TimeSpan.Zero, (total, attendance) =>
                    total + (attendance.TimeIn - employee.Shift?.StartTime ?? TimeSpan.Zero));

            double totalLateHours = totalLateDuration.TotalHours;
            double totalLateMinutes = totalLateDuration.TotalMinutes;

            return totalLateHours >= 1
                ? totalLateHours * hourlyRate // Calculate in hours
                : hourlyRate / 60 * totalLateMinutes; // Calculate in minutes
        }

        private double CalculateEarlyOutDeductions(Employee employee, IEnumerable<Attendance> employeeAttendances, double hourlyRate)
        {
            TimeSpan shiftEndTime = employee.Shift?.EndTime ?? TimeSpan.Zero;

            var totalEarlyOutDuration = employeeAttendances
                .Where(a => a.TimeOut < shiftEndTime)
                .Aggregate(TimeSpan.Zero, (total, attendance) =>
                {
                    var earlyOut = shiftEndTime - attendance.TimeOut;
                    return earlyOut > TimeSpan.Zero ? total + earlyOut : total;
                });

            double totalEarlyOutHours = totalEarlyOutDuration.TotalHours;
            return totalEarlyOutHours * hourlyRate;
        }

        private double CalculateAbsentDeductions(int totalDays, int totalPresentDays, double dailyRate)
        {
            // Calculate total absent days
            int totalAbsentDays = Math.Max(0, totalDays - totalPresentDays);

            // Compute absent deductions
            double absentDeductions = totalAbsentDays * dailyRate;

            return absentDeductions;
        }

        private double CalcuLateBenefits(Employee employee)
        {
            return employee.Benefits.Sum(b => b.Amount);
        }
        private bool IsCoveredByLeave(DateTime date, IEnumerable<Leave> approvedLeaves)
        {
            return approvedLeaves.Any(leave => date >= leave.StartDate && date <= leave.EndDate);
        }

        private int TotalDays(DateTime startDate, DateTime endDate)
        {
            int days = 0;
            DateTime currentDate = startDate.Date;

            do
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday) // Exclude Sundays
                {
                    days++;
                }

                currentDate = currentDate.AddDays(1);
            } while (currentDate <= endDate.Date);
            return days;
        }
        private int NonSundays(DateTime startDate)
        {
            int days = 0;
            for (int day = 1; day <= DateTime.DaysInMonth(startDate.Year, startDate.Month); day++)
            {
                DateTime currentDateForMonth = new DateTime(startDate.Year, startDate.Month, day);
                if (currentDateForMonth.DayOfWeek != DayOfWeek.Sunday) // Exclude Sundays
                {
                    days++;
                }
            }
            return days;
        }

        public List<PayrollViewModel> CalculatePayroll(DateTime startDate, DateTime endDate)
        {
            var employees = _unitOfWork.Employee.GetAll(includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves");
            var contributions = _unitOfWork.Contribution.GetAll();

            var payrollList = new List<PayrollViewModel>();
            int totalDays = TotalDays(startDate,endDate);
            
            foreach (var employee in employees.OrderBy(c => c.LastName))
            {
                var employeeAttendances = employee.Attendances?.Where(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date) ?? Enumerable.Empty<Attendance>();

                var approvedLeaves = employee.Leaves.Where(a => a.LeaveType != LeaveType.UnpaidLeave && a.Status == Status.Approved);
                int totalPresentDays = employeeAttendances.Count(a => a.IsPresent && !IsCoveredByLeave(a.Date, approvedLeaves));

                double totalHoursWorked = employeeAttendances.Sum(a => a.HoursWorked);
                double regularHours = totalDays * (employee.Shift?.RegularHours ?? 0);
                double hourlyRate = employee.BasicSalary / (totalDays * (employee.Shift?.RegularHours ?? 8));
                double regularPay = totalDays * employee.BasicSalary;
                double overtimeHours = employeeAttendances.Sum(a => Math.Max(0, a.HoursWorked - (employee.Shift?.RegularHours ?? 0)));
                double overtimePay = overtimeHours * (employee.BasicSalary/employee.Shift?.RegularHours ?? 0);

                double allowancePay = CalculateAllowances(employee, startDate, endDate);
                double bonusPay = CalculateBonuses(employee, startDate, endDate);
                double deductions = CalculateDeductions(employee, startDate, endDate);

                double absentDeductions = CalculateAbsentDeductions(totalDays, totalPresentDays, employee.BasicSalary);
                double lateDeductions = CalculateLateDeductions(employee, employeeAttendances, hourlyRate);
                double earlyOutDeductions = CalculateEarlyOutDeductions(employee, employeeAttendances, hourlyRate);

                double monthlySalary = employee.BasicSalary * NonSundays(startDate);
                double sssDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.SSS, monthlySalary) / 2 : 0 : 0;
                double pagIbigDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PagIbig, monthlySalary) / 2 : 0 : 0;
                double philHealthDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PhilHealth, monthlySalary) / 2 : 0 : 0;

                double benefitPay = _view.IncludeBenefits ? CalcuLateBenefits(employee) : 0;

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

    }
}
