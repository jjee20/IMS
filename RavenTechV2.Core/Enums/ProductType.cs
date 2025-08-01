using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Enums;
using System.ComponentModel.DataAnnotations;

public enum ProductType
{
    [Display(Name = "Undefined")]
    Undefined,

    [Display(Name = "Raw Material")]
    RawMaterial,

    [Display(Name = "Finished Good")]
    FinishedGood,

    [Display(Name = "Consumable")]
    Consumable,

    [Display(Name = "Service")]
    Service,

    [Display(Name = "Digital Product")]
    Digital,

    [Display(Name = "Component")]
    Component,

    [Display(Name = "Accessory")]
    Accessory,

    [Display(Name = "Kit (Set)")]
    Kit,

    [Display(Name = "Bundle")]
    Bundle,

    [Display(Name = "Perishable Good")]
    Perishable,

    [Display(Name = "Non-Perishable Good")]
    NonPerishable,

    [Display(Name = "Equipment")]
    Equipment,

    [Display(Name = "Tool")]
    Tool,

    [Display(Name = "Part")]
    Part,

    [Display(Name = "Packaging Material")]
    Packaging,

    [Display(Name = "Spare Part")]
    SparePart,

    [Display(Name = "Supply")]
    Supply,

    [Display(Name = "Subscription")]
    Subscription,

    [Display(Name = "Rental Item")]
    Rental,

    [Display(Name = "Asset")]
    Asset,

    [Display(Name = "Sample")]
    Sample,

    [Display(Name = "Promotional Item")]
    Promotional,

    [Display(Name = "Hazardous Material")]
    HazardousMaterial,

    [Display(Name = "Software")]
    Software,

    [Display(Name = "Hardware")]
    Hardware,

    [Display(Name = "Chemical")]
    Chemical,

    [Display(Name = "Biological Material")]
    Biological,

    [Display(Name = "Agricultural Product")]
    Agricultural,

    [Display(Name = "Textile")]
    Textile,

    [Display(Name = "Apparel/Clothing")]
    Apparel,

    [Display(Name = "Footwear")]
    Footwear,

    [Display(Name = "Electronic Device")]
    Electronic,

    [Display(Name = "Furniture")]
    Furniture,

    [Display(Name = "Appliance")]
    Appliance,

    [Display(Name = "Stationery")]
    Stationery,

    [Display(Name = "Book")]
    Book,

    [Display(Name = "Food")]
    Food,

    [Display(Name = "Beverage")]
    Beverage,

    [Display(Name = "Medicine")]
    Medicine,

    [Display(Name = "Medical Supply")]
    MedicalSupply,

    [Display(Name = "Vehicle")]
    Vehicle,

    [Display(Name = "Fuel")]
    Fuel,

    [Display(Name = "Construction Material")]
    ConstructionMaterial,

    [Display(Name = "Jewelry")]
    Jewelry,

    [Display(Name = "Cosmetic")]
    Cosmetic,

    [Display(Name = "Toy")]
    Toy,

    [Display(Name = "Gift Item")]
    Gift,

    [Display(Name = "Pet Supply")]
    PetSupply,

    [Display(Name = "Plant")]
    Plant,

    [Display(Name = "Tooling")]
    Tooling,

    [Display(Name = "Industrial Good")]
    IndustrialGood,

    [Display(Name = "Machinery")]
    Machinery,

    [Display(Name = "Safety Equipment")]
    SafetyEquipment,

    [Display(Name = "Office Supply")]
    OfficeSupply,

    [Display(Name = "Cleaning Supply")]
    CleaningSupply,

    [Display(Name = "Personal Care Product")]
    PersonalCare,

    [Display(Name = "Outdoor Equipment")]
    OutdoorEquipment,

    [Display(Name = "Sporting Good")]
    SportingGood,

    [Display(Name = "Art Supply")]
    ArtSupply,

    [Display(Name = "Musical Instrument")]
    MusicalInstrument,

    [Display(Name = "Luggage")]
    Luggage,

    [Display(Name = "Baby Product")]
    BabyProduct,

    [Display(Name = "Gaming Product")]
    GamingProduct,

    [Display(Name = "Luxury Item")]
    Luxury,

    [Display(Name = "Seasonal Product")]
    Seasonal,

    [Display(Name = "Event Ticket")]
    EventTicket,

    [Display(Name = "Subscription Box")]
    SubscriptionBox,

    [Display(Name = "Antique")]
    Antique,

    [Display(Name = "Collectible")]
    Collectible,

    [Display(Name = "Energy Product")]
    EnergyProduct,

    [Display(Name = "Media (CD/DVD/Blu-ray)")]
    Media,

    [Display(Name = "Mobile App")]
    MobileApp,

    [Display(Name = "E-book")]
    Ebook,

    [Display(Name = "Gift Card")]
    GiftCard,

    [Display(Name = "Membership")]
    Membership,

    [Display(Name = "Voucher/Coupon")]
    Voucher,

    [Display(Name = "Insurance")]
    Insurance,

    [Display(Name = "Utility")]
    Utility,

    [Display(Name = "Ticket (Transport)")]
    TransportTicket,

    [Display(Name = "Livestock")]
    Livestock,

    [Display(Name = "Marine Product")]
    MarineProduct,

    [Display(Name = "Metal/Alloy")]
    Metal,

    [Display(Name = "Plastic")]
    Plastic,

    [Display(Name = "Glassware")]
    Glassware,

    [Display(Name = "Paper Product")]
    Paper,

    [Display(Name = "Shoe Care Product")]
    ShoeCare,

    [Display(Name = "Home Decor")]
    HomeDecor,

    [Display(Name = "Lighting")]
    Lighting,

    [Display(Name = "Handicraft")]
    Handicraft,

    [Display(Name = "Souvenir")]
    Souvenir,

    [Display(Name = "Security Product")]
    Security,

    [Display(Name = "Fire Safety")]
    FireSafety,

    [Display(Name = "Solar Product")]
    Solar,

    [Display(Name = "Water Supply Product")]
    WaterSupply,

    [Display(Name = "Recycled Product")]
    Recycled,

    [Display(Name = "Smart Device")]
    SmartDevice,

    [Display(Name = "Drone")]
    Drone,

    [Display(Name = "Educational Material")]
    Educational,

    [Display(Name = "Other")]
    Other
}


