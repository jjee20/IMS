using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels
{
    public class MonthlyPurchasesBreakdownViewModel
    {
        public string Month { get; set; }
        public double Purchases { get; set; }
    }
}
