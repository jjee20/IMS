﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.ThinkEE
{

    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }

}
