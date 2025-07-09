
using DomainLayer.Models.ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RavenTech_ThinkEE
{

    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; } = "";

        public DateTime Date { get; set; }
        [ForeignKey("ExamFormat")]
        public int ExamFormatId { get; set; }

        public ExamFormat ExamFormat { get; set; }


        // Navigation
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<ExamResult> Results { get; set; } = new List<ExamResult>();
    }

}
