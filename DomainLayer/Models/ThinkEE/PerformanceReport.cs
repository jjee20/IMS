using DomainLayer.Models.Accounts;
using RavenTech_ThinkEE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ThinkEE
{
    public class PerformanceReport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Examinee")]
        public string ExamineeId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public int Score { get; set; }
        public int TotalItems { get; set; }
        public double Accuracy => TotalItems > 0 ? (double)Score / TotalItems : 0;

        public string WeakAreas { get; set; } // e.g., "Power Systems, Machines"
        public string StrongAreas { get; set; }

        public ApplicationUser Examinee { get; set; }
        public Exam Exam { get; set; }
    }

}
