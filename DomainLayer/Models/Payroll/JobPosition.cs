using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Payroll
{
    public class JobPosition 
    {
        [Key]
        [Display(Name ="Id")]
        public int JobPositionId { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
    }

}
