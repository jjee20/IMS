using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels;
public class ProjectLineProductViewModel
{
    public string Name { get; set; }
    public string UOM { get; set; }
    public string Category { get; set; }
    public string Cost { get; set; }
    public double Qty { get; set; }
    public double ActualQty { get; set; }
    public double RemainingQty => Math.Round(Qty - ActualQty,2); 
    public double PercentageQty => Qty == 0 ? 0 : (ActualQty / Qty) * 100;
    public double Amount { get; set; }
    public double ActualAmount { get; set; }
    public double RemainingAmount => Math.Round(Amount - ActualAmount, 2); 
    public double PercentageAmount => Amount == 0 ? 0 : (ActualAmount / Amount) * 100;

}
