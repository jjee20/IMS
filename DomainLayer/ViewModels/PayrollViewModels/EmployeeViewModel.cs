using System.ComponentModel.DataAnnotations;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class EmployeeViewModel
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
        [Display(Name = "Job Position")]
        public string JobPosition { get; set; }
        public string Shift { get; set; }
        [Display(Name = "Is Deducted?")]
        public string isDeducted { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Details { get; set; }

    }
}
