using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class ProjectViewModel
    {
        [Display(Name = "Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double Budget { get; set; } = 0;

        public double Revenue { get; set; } = 0;
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Details { get; set; }
    }
}
