﻿using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}
