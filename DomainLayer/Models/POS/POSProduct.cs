using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.POS
{
    public class POSProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public POSCategory Category { get; set; } 
        public string ImageUrl { get; set; } = string.Empty; // Store image path
    }
}
