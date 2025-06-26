using RavenTech_ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ThinkEE
{
    public class ReviewTopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } // "REE" or "RME"

        [Required]
        public string Name { get; set; } // "Registered Electrical Engineer" or "Registered Master Electrician"

        public ICollection<ExamTopic> ExamTopics { get; set; } = new List<ExamTopic>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }

}
