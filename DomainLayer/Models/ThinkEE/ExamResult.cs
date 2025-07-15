
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using RavenTech_ThinkEE;

namespace DomainLayer.Models.ThinkEE
{

    public class ExamResult
    {
        [Key]
        public int ExamResultId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        [ForeignKey("Examinee")]
        public string ExamineeId { get; set; }

        public ApplicationUser Examinee { get; set; }

        public int Score { get; set; }

        public int TotalPoints { get; set; }
        public ExamStatus ExamStatus { get; set; }
        public DateTime ExamStartTime { get; set; }
        public TimeSpan ExamDuration { get; set; }
        public ICollection<ExamResultChoice> SelectedChoices { get; set; } = new List<ExamResultChoice>();
        [NotMapped]
        public string ExamStatusString => ExamStatus.ToString() ?? DomainLayer.Enums.ExamStatus.NotTaken.ToString();

    }

}
