﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class SalesOrderLineViewModel
    {
        public int SalesOrderLineId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product Item")]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        [Display(Name = "Disc %")]
        public double DiscountPercentage { get; set; }
        public double SubTotal { get; set; }
        public byte[] Delete { get; set; }
    }
}
