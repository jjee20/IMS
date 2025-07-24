using RavenTech_ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ThinkEE
{
    public class ExamFormat
    {
        [Key]
        public int ExamFormatId { get; set; }

        [Required]
        public string Name { get; set; } // e.g., Mock Board, Diagnostic, Drill, Weekly Quiz

        public string Description { get; set; }

        public int DefaultDurationMinutes { get; set;} 
        [NotMapped]
        public string DurationText => $"Duration: {DefaultDurationMinutes} minutes";

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
