using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class ProductPullOutLogLineViewModel
    {
        public DateTime DateAdded { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost => UnitCost * Quantity;
        public byte[] Delete { get; set; }
    }
}
