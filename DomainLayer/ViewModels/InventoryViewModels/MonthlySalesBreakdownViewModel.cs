using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels
{
    public class MonthlySalesBreakdownViewModel
    {
        public string Month { get; set; }
        [Display(Name = "Item Sold")]
        public int ItemSold { get; set; }
        public double Sales { get; set; }
        public double Purchases { get; set; }
        [Display(Name = "Profit/Loss")]
        public double ProfitLoss => Sales - Purchases;
    }
}
