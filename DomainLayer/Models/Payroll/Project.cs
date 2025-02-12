using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Payroll
{
    public class Project 
    {
        [Key]
        [Display(Name = "Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
