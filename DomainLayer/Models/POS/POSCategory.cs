﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class POSCategory
    {
        [Key] 
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
