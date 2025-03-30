using DomainLayer.Models.Accounting.Payroll;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class UserInformationViewModel
    {
        [Display(Name ="Id")]
        public int EmployeeId { get; set; } // Primary Key
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Contact #")]
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Basic Pay")]
        public double BasicSalary { get; set; }
        [Display(Name = "Leave Credits")]
        public double LeaveCredits { get; set; }
        public string Address { get; set; }

        public string Department { get; set; } 
        public string JobPosition { get; set; }
        public string Shift { get; set; }
        [Display(Name = "Deducted?")]
        public string isDeducted { get; set; }

        public IEnumerable<AllowanceViewModel> Allowances { get; set; }
        public IEnumerable<BonusViewModel> Bonuses { get; set; }
        public IEnumerable<BenefitViewModel> Benefits { get; set; }
        public IEnumerable<DeductionViewModel> Deductions { get; set; }
        public IEnumerable<IndividualAttendanceViewModel> Attendances { get; set; }
        public IEnumerable<LeaveViewModel> Leaves { get; set; }
        public EmployeeContributionViewModel Contribution { get; set; }

    }
}
