using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
using System.ComponentModel;

public enum CustomerType
{
    [Description("Regular Customer")]
    Regular,

    [Description("Wholesale Buyer")]
    Wholesale,

    [Description("Corporate Client")]
    Corporate,

    [Description("Government Account")]
    Government,

    [Description("Authorized Distributor")]
    Distributor,

    [Description("Retail Partner")]
    Retailer,

    [Description("Online Buyer")]
    Online,

    [Description("Walk-In Customer")]
    WalkIn,

    [Description("VIP Member")]
    VIP,
    Other
}
