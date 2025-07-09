using RavenTech_ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.ThinkEE
{
    public class ReviewTopicViewModel
    {
        public int ReviewTopicId { get; set; }
        public string Code { get; set; } 
        public string Name { get; set; }
        [Display(Name = "")]
        public byte[] Edit { get; set; }
        [Display(Name = "")]
        public byte[] Delete { get; set; }
    }

}
