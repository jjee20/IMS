using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.PayrollViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Helpers
{
    public abstract class PayrollHelper
    {
        public static double CalculateHolidayOvertimeHours(IEnumerable<Attendance> attendances, List<Holiday> holidays)
        {
            double overtimeHours = 0;

            foreach (var attendance in attendances)
            {
                bool isHoliday = holidays.Any(h => h.EffectiveDate.Date == attendance.Date.Date);

                if (isHoliday)
                {
                    double holidayRegularCap = 6.0; // 8AM–3PM = 7 hours
                    if (attendance.HoursWorked > holidayRegularCap)
                        overtimeHours += attendance.HoursWorked - holidayRegularCap;
                }
            }

            return overtimeHours;
        }
        public static double CalculateAllowances(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Allowances?
                .Where(a => a.EmployeeId == employee.EmployeeId &&
                            (a.IsRecurring || a.DateGranted.Date >= startDate.Date && a.DateGranted.Date <= endDate.Date))
                .Sum(a => a.Amount) ?? 0;
        }
        public static double CalculateBonuses(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Bonuses?
                .Where(b => b.EmployeeId == employee.EmployeeId &&
                            (b.IsOneTime || b.DateGranted.Date >= startDate.Date && b.DateGranted.Date <= endDate.Date))
                .Sum(b => b.Amount) ?? 0;
        }

        public static double CalculateDeductions(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.Deductions?
                .Where(b => b.EmployeeId == employee.EmployeeId &&
                            b.DateDeducted.Date >= startDate.Date && b.DateDeducted.Date <= endDate.Date)
                .Sum(b => b.Amount) ?? 0;
        }

        public static double CalculateContributions(IEnumerable<Contribution> contributions, ContributionType type, double basicSalary)
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
        public static double CalculateLateDeductions(Employee employee, IEnumerable<Attendance> employeeAttendances, double hourlyRate)
        {

            var totalLateDuration = employeeAttendances
                .Where(a => a.TimeIn > employee.Shift?.StartTime && !a.IsHalfDay) // Only consider late arrivals
                .Aggregate(TimeSpan.Zero, (total, attendance) =>
                    total + (attendance.TimeIn - employee.Shift?.StartTime ?? TimeSpan.Zero));

            double totalLateHours = totalLateDuration.TotalHours;
            double totalLateMinutes = totalLateDuration.TotalMinutes;

            return totalLateHours >= 1
                ? totalLateHours * hourlyRate // Calculate in hours
                : hourlyRate / 60 * totalLateMinutes; // Calculate in minutes
        }

        public static double CalculateEarlyOutDeductions(Employee employee, IEnumerable<Attendance> employeeAttendances, double hourlyRate, List<Holiday> holidays)
        {
            if (employee == null || employeeAttendances == null || holidays == null)
                return 0.0;

            var totalEarlyOutDuration = employeeAttendances
                .Where(a => a.TimeOut != default && !a.IsHalfDay) // Only process if TimeOut is set and not half-day
                .Aggregate(TimeSpan.Zero, (total, attendance) =>
                {
                    bool isHoliday = holidays.Any(h => h.EffectiveDate.Date == attendance.Date.Date);
                    TimeSpan shiftEndTime = isHoliday ? new TimeSpan(15, 0, 0) // 3:00 PM if holiday
                                                       : (employee.Shift?.EndTime ?? TimeSpan.Zero);

                    if (attendance.TimeOut < shiftEndTime)
                    {
                        var earlyOut = shiftEndTime - attendance.TimeOut;
                        if (earlyOut > TimeSpan.Zero)
                            total += earlyOut;
                    }

                    return total;
                });

            double totalEarlyOutHours = totalEarlyOutDuration.TotalHours;
            return totalEarlyOutHours * hourlyRate;
        }

        public static double CalculateAbsentDeductions(double totalDays, double totalPresentDays, double dailyRate)
        {
            // Calculate total absent days
            double totalAbsentDays = Math.Max(0, totalDays - totalPresentDays);

            // Compute absent deductions
            double absentDeductions = totalAbsentDays * dailyRate;

            return absentDeductions;
        }

        public static double CalcuLateBenefits(Employee employee)
        {
            return employee.Benefits.Sum(b => b.Amount);
        }
        public static bool IsCoveredByLeave(DateTime date, IEnumerable<Leave> approvedLeaves)
        {
            return approvedLeaves.Any(leave => date >= leave.StartDate && date <= leave.EndDate);
        }

        public static int TotalDays(IEnumerable<Attendance> attendances, DateTime startDate, DateTime endDate)
        {
            int days = 0;
            DateTime currentDate = startDate.Date;
            do
            {
                var attendance = attendances.Where(c => c.Date.Date == currentDate);
                if (currentDate.DayOfWeek != DayOfWeek.Sunday || attendance.Any()) // Exclude Sundays
                {
                    days++;
                }

                currentDate = currentDate.AddDays(1);
            } while (currentDate <= endDate.Date);
            return days;
        }
        public static int NonSundays(IEnumerable<Attendance> attendances, DateTime startDate)
        {
            int days = 0;
            for (int day = 1; day <= DateTime.DaysInMonth(startDate.Year, startDate.Month); day++)
            {
                var attendance = attendances.Where(c => c.Date.Day == day && c.Date.Month == startDate.Month && c.Date.Year == startDate.Year);
                DateTime currentDateForMonth = new DateTime(startDate.Year, startDate.Month, day);
                if (currentDateForMonth.DayOfWeek != DayOfWeek.Sunday || attendance.Any()) // Exclude Sundays
                {
                    days++;
                }
            }
            return days;
        }
        public static List<PayrollViewModel> 
            CalculatePayroll(IEnumerable<Employee> employees, 
            IEnumerable<Contribution> contributions,
            Project project,
            DateTime startDate, DateTime endDate, List<Holiday> holidays, int? projectId = 0)
        {
            var projectName = "";
            if (project != null)
                projectName = $"Project: {project.ProjectName}";
            else
            {
                projectName = "Project: All";
            }

            var payrollList = new List<PayrollViewModel>();

            foreach (var employee in employees.OrderBy(c => c.LastName))
            {
                int totalDays = TotalDays(employee.Attendances, startDate, endDate);
                var employeeAttendances = employee.Attendances?.Where(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date) ?? Enumerable.Empty<Attendance>();
                var employeeContributions = employee.Contribution;

                var approvedLeaves = employee.Leaves.Where(a => a.LeaveType != LeaveType.UnpaidLeave && a.Status == Status.Approved);
                double totalPresentWholeDays = employeeAttendances.Count(a => a.IsPresent && !a.IsHalfDay && !IsCoveredByLeave(a.Date, approvedLeaves));
                double totalPresentHalfDays = employeeAttendances.Count(a => a.IsPresent && a.IsHalfDay && !IsCoveredByLeave(a.Date, approvedLeaves)) * 0.5;
                double totalPresentDays = totalPresentWholeDays + totalPresentHalfDays;
                double regularHours = totalDays * (employee.Shift?.RegularHours ?? 0);
                double hourlyRate = employee.BasicSalary / (totalDays * (employee.Shift?.RegularHours ?? 8));
                double regularPay = totalDays * employee.BasicSalary;
                double overtimeHours = employeeAttendances.Sum(a => Math.Max(0, employee.Shift?.RegularHours > a.HoursWorked ? 0 : a.HoursWorked - (employee.Shift?.RegularHours ?? 8)));
                double overtimePay = overtimeHours * (employee.BasicSalary / employee.Shift?.RegularHours ?? 0);

                double allowancePay = CalculateAllowances(employee, startDate, endDate);
                double bonusPay = CalculateBonuses(employee, startDate, endDate);
                double deductions = CalculateDeductions(employee, startDate, endDate);

                double absentDeductions = CalculateAbsentDeductions(totalDays, totalPresentDays, employee.BasicSalary);
                double lateDeductions = CalculateLateDeductions(employee, employeeAttendances, hourlyRate);
                double earlyOutDeductions = CalculateEarlyOutDeductions(employee, employeeAttendances, hourlyRate, holidays);

                double sss = (employeeContributions != null) ? employeeContributions.SSS : 0; 
                double sssWisp = (employeeContributions != null) ? employeeContributions.SSSWISP : 0;
                double pagIbig = (employeeContributions != null) ? employeeContributions.PagIbig : 0;
                double philHealth = (employeeContributions != null) ? employeeContributions.PhilHealth : 0;

                double monthlySalary = employee.BasicSalary * NonSundays(employee.Attendances, startDate);
                double sssDeduction = employee.isDeducted ? sss + sssWisp : 0;
                double pagIbigDeduction = employee.isDeducted ? pagIbig : 0;
                double philHealthDeduction = employee.isDeducted ? philHealth : 0;
                //double sssDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.SSS, monthlySalary) / 2 : 0 : 0;
                //double pagIbigDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PagIbig, monthlySalary) / 2 : 0 : 0;
                //double philHealthDeduction = _view.IncludeContribution ? employee.isDeducted ? CalculateContributions(contributions, ContributionType.PhilHealth, monthlySalary) / 2 : 0 : 0;

                double benefitPay = CalcuLateBenefits(employee);

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

        public bool IsHoliday(DateTime date, IEnumerable<Holiday> holidays)
        {
            return holidays.Any(holiday => holiday.EffectiveDate.Date == date.Date);
        }
    }
}
