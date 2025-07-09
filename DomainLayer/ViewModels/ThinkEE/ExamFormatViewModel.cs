using RavenTech_ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.ThinkEE
{
    public class ExamFormatViewModel
    {
        public int ExamFormatId { get; set; }
        public string Name { get; set; } // e.g., Mock Board, Diagnostic, Drill, Weekly Quiz

        public string Description { get; set; }

        public int DefaultDurationMinutes { get; set; } // Time-bound
        [Display(Name = "")]
        public byte[] Edit { get; set; }
        [Display(Name = "")]
        public byte[] Delete { get; set; }
    }
}
