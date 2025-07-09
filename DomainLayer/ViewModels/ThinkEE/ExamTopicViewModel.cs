using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.ThinkEE;

namespace DomainLayer.ViewModels.ThinkEE
{
    public class ExamTopicViewModel
    {
        public int ExamTopicId { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        public string ReviewTopic { get; set; }
        [Display(Name = "")]
        public byte[] Edit { get; set; }
        [Display(Name = "")]
        public byte[] Delete { get; set; }

    }
}
