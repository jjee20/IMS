﻿using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class PurchaseType 
    {
        [Key]
        [Display(Name = "Id")]
        public int PurchaseTypeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
    }
}
