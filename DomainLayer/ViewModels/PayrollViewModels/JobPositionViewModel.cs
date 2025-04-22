using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class JobPositionViewModel
    {
        [Display(Name = "Id")]
        public int JobPositionId { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }

}
