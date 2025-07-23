using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class ProductStockInLogLinesViewModel
    {
        public string DateAdded { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost => UnitCost * Quantity;
    }
}
