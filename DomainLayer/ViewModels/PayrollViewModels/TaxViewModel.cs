﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class TaxViewModel
    {
        public int TaxId { get; set; } // Primary Key
        [Display(Name = "Minimum Salary")]
        public double MinimumSalary { get; set; }
        [Display(Name = "Maximum Salary")]
        public double MaximumSalary { get; set; }
        [Display(Name = "Tax Rate (%)")]
        public double TaxRate { get; set; } // In percentage
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }

}
