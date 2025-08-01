using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Enums;

namespace RavenTechV2.Core.Models.Sales.ViewModels;
public class CustomerVM
{
    public int CustomerId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<SalesOrderVM> SalesOrders { get; set; }
    public ICollection<InvoiceVM> Invoices { get; set; }
}
