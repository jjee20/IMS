using DomainLayer.Enums;
using DomainLayer.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string JobPosition { get; set; }
        public string Shift { get; set; }
        [Display(Name = "Deducted?")]
        public string isDeducted { get; set; }

    }
}
