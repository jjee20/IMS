using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Inventory
{
    public class CustomerViewModel
    {
        [Display(Name = "Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Type")]
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public string Address { get; set; }
    }
}
