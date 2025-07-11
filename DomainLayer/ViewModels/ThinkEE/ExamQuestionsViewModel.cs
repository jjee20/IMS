
using DomainLayer.Models.ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainLayer.ViewModels.ThinkEE
{

    public class ExamQuestionsViewModel
    {
        public string Question { get; set; }
        public int ExamTopicId { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Answer { get; set; }
        public byte[] Delete { get; set; }

    }

}
