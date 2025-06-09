using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ThinkEE
{
    public class ExamTopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; } // Mathematics, Engineering Sciences, etc.
        [ForeignKey("ReviewTopic")]
        public int ReviewTopicId { get; set; }
        public ReviewTopic ReviewTopic { get; set; }
        public ICollection <Question> Questions { get; set; }

    }
}
