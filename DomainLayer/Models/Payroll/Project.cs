using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Payroll
{
    public class Project
    {
        [Key] 
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
