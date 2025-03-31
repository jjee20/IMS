using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.Models.Accounting.Payroll
{
    public class Project
    {
        [Key]
        [Display(Name = "Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string? Client { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public double? Budget { get; set; }

        public double? Revenue { get; set; }
        public IEnumerable<ProjectLine> ProjectLines { get; set; }
    }
}
