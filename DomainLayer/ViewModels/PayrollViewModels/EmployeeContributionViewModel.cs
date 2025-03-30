using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class EmployeeContributionViewModel
    {
        [Display(Name = "Id")]
        public int EmployeeContributionId { get; set; }
        public string Employee { get; set; }
        public double SSS { get; set; }
        [Display(Name = "SSS-WISP")]
        public double SSSWISP { get; set; }
        [Display(Name = "Pag-ibig")]
        public double PagIbig { get; set; }
        public double PhilHealth { get; set; }
    }
}
