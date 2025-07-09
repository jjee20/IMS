
using DomainLayer.Models.ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainLayer.ViewModels.ThinkEE
{

    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string ExamFormat { get; set; }
        [Display(Name = "")]
        public byte[] Edit { get; set; }
        [Display(Name = "")]
        public byte[] Delete { get; set; }

    }

}
