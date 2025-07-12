
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

        public DateTime Date { get; set; }
        [ForeignKey("ExamFormat")]
        public int ExamFormatId { get; set; }

        public ExamFormat ExamFormat { get; set; }

        [NotMapped]
        public string DisplayDate => Date.ToString("MMMM d, yyyy");
        [ForeignKey("ExamResult")]
        public int? ExamResultId{ get; set; }

        public ExamResult? ExamResult { get; set; } 
        [ForeignKey("ReviewTopic")]
        public int? ReviewTopicId{ get; set; }

        public ReviewTopic? ReviewTopic { get; set; } 
        // Navigation
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }

}
