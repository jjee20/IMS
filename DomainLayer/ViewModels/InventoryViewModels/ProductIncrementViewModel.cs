using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels;
public class ProductIncrementViewModel
{
    public int ProductIncrementId
    {
        get;
        set;
    }
    public DateTime Date
    {
        get;
        set;
    }
    public double Increment
    {
        get;
        set;
    }
    [Display(Name = "")]
    public byte[] Edit
    {
        get; set;
    }
    [Display(Name = "")]
    public byte[] Delete
    {
        get; set;
    }
}
