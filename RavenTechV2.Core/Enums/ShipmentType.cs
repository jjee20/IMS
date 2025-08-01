using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
public enum ShipmentType
{
    [Display(Name = "Standard Shipping")]
    Standard,

    [Display(Name = "Express Shipping")]
    Express,

    [Display(Name = "Same-Day Delivery")]
    SameDay,

    [Display(Name = "Customer Pickup")]
    Pickup,

    [Display(Name = "Freight Service")]
    Freight,

    [Display(Name = "International Delivery")]
    International,
    Other
}
