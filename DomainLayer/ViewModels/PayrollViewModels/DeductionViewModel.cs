using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class DeductionViewModel
    {
        [Display(Name = "Id")]
        public int DeductionId { get; set; } // Primary Key
        public string Employee { get; set; }
        [Display(Name = "Deduction Type")]
        public string DeductionType { get; set; }
        [Display(Name = "Date of Deduction")]
        public DateTime DateDeducted { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
