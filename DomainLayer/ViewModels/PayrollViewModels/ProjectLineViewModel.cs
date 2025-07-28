using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.PayrollViewModels
{
    public class ProjectLineViewModel
    {
        public int ProjectLineId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double DiscountPercentage { get; set; }
        public double SubTotal { get; set; }
        public byte[] Delete { get; set; }
    }
}
