using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
public enum SalesType
{
    Retail,
    Wholesale,
    Online,
    [Display(Name = "Phone Order")]
    PhoneOrder,
    [Display(Name = "Walk-In")]
    WalkIn,
    Distributor,
    Other
}
