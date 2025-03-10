using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.ViewModels.Inventory
{
    public class StockViewModel
    {
        public string Product { get; set; }
        public double Qty { get; set; }
    }
}
