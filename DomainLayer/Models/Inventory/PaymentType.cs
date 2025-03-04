﻿using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class PaymentType 
    {
        [Key]
        [Display(Name = "Id")]
        public int PaymentTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
    }
}
