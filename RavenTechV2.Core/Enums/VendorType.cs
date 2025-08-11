using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
public enum VendorType
{
    [Display(Name = "Unknown")]
    Unknown,

    [Display(Name = "Individual")]
    Individual,

    [Display(Name = "Sole Proprietor")]
    SoleProprietor,

    [Display(Name = "Partnership")]
    Partnership,

    [Display(Name = "Corporation")]
    Corporation,

    [Display(Name = "Cooperative")]
    Cooperative,

    [Display(Name = "Government")]
    Government,

    [Display(Name = "Non-Governmental Organization (NGO)")]
    NGO,

    [Display(Name = "Academic Institution")]
    Academic,

    [Display(Name = "Medical / Hospital")]
    Medical,

    [Display(Name = "Distributor")]
    Distributor,

    [Display(Name = "Wholesaler")]
    Wholesaler,

    [Display(Name = "Retailer")]
    Retailer,

    [Display(Name = "Manufacturer")]
    Manufacturer,

    [Display(Name = "Importer")]
    Importer,

    [Display(Name = "Exporter")]
    Exporter,

    [Display(Name = "Online Seller")]
    OnlineSeller,

    [Display(Name = "Service Provider")]
    ServiceProvider,

    [Display(Name = "Contractor")]
    Contractor,

    [Display(Name = "Others")]
    Others
}
