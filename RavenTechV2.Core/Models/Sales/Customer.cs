using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales;
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    public string Name { get; set; }
    public CustomerType Type { get; set; }
    public string Address { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [RegularExpression(@"^(\+63|0)9\d{9}$", ErrorMessage = "Invalid Philippine phone number format.")]
    public string Phone { get; set; }
    public ICollection<SalesOrder> SalesOrders { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}
