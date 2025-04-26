using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels
{
    public class AnnuallyPurchasesBreakdownViewModel
    {
        public int Year { get; set; }
        public double Expenses { get; set; }
    }
}
