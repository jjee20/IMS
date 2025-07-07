
using DomainLayer.Models.Accounts;
using RavenTech_ThinkEE;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.ThinkEE
{

    public class ExamResult
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Examinee")]
        public string ExamineeId { get; set; }

        public ApplicationUser Examinee { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        public int Score { get; set; }

        public int TotalPoints { get; set; }
    }

}
