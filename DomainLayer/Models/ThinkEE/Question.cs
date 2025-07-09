using RavenTech_ThinkEE;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainLayer.Models.ThinkEE
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        public int Points { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        [ForeignKey("ExamTopic")]
        public int ExamTopicId { get; set; }

        public ExamTopic ExamTopic { get; set; }

        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
    }

}
