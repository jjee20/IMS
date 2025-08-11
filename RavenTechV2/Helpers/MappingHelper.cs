using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.Purchasing;
using RavenTechV2.Core.Models.Purchasing.ViewModels;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;

namespace RavenTechV2.Helpers;
public class MappingHelper : Profile
{
    public MappingHelper()
    {
        CreateMap<Category, CategoryVM>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(c => c.Description ?? "{Needs Updating}" ))
            .ReverseMap();
        CreateMap<Warehouse, WarehouseVM>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(c => c.Description ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(c => c.Branch.Name ?? "{Needs Updating}" ))
            .ReverseMap();
        CreateMap<UnitOfMeasure, UnitOfMeasureVM>()
            .ForMember(dest => dest.Symbol, opt => opt.MapFrom(c => c.Symbol ?? "{Needs Updating}" ))
            .ReverseMap();
        CreateMap<Branch, BranchVM>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(c => c.ContactPerson ?? "{Needs Updating}" ))
            .ReverseMap();
        CreateMap<Customer, CustomerVM>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.SalesOrders,
                opt => opt.MapFrom(c => c.SalesOrders != null && c.SalesOrders.Any()
                    ? c.SalesOrders
                    : new List<SalesOrder>())
                )
            .ForMember(dest => dest.Invoices,
                opt => opt.MapFrom(c => c.Invoices != null && c.Invoices.Any()
                    ? c.Invoices
                    : new List<Invoice>())
                )
            .ReverseMap();
        CreateMap<Invoice, InvoiceVM>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(c => c.Customer.Name ?? "{Needs Updating}"))
            .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(c => c.SalesOrder.SalesOrderNumber ?? "{Needs Updating}"))
                .ReverseMap();
        CreateMap<SalesOrder, SalesOrderVM>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(c => c.Customer.Name ?? "{Needs Updating}"))
                .ReverseMap();
        CreateMap<SalesOrderLine, SalesOrderLineVM>()
            .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(c => c.SalesOrder.SalesOrderNumber ?? "{Needs Updating}"))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(c => c.Product.ProductName ?? "{Needs Updating}"))
                .ReverseMap();

        CreateMap<Vendor, VendorVM>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(c => c.Email ?? "{Needs Updating}" ))
            .ForMember(dest => dest.PurchaseOrders,
                opt => opt.MapFrom(c => c.PurchaseOrders != null && c.PurchaseOrders.Any()
                    ? c.PurchaseOrders
                    : new List<PurchaseOrder>())
                )
            .ForMember(dest => dest.Bills,
                opt => opt.MapFrom(c => c.Bills != null && c.Bills.Any()
                    ? c.Bills
                    : new List<Bill>())
                )
            .ReverseMap();
        CreateMap<Bill, BillVM>()
            .ForMember(dest => dest.Vendor, opt => opt.MapFrom(c => c.Vendor.Name ?? "{Needs Updating}"))
            .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(c => c.PurchaseOrder.PurchaseOrderNumber ?? "{Needs Updating}"))
                .ReverseMap();
        CreateMap<PurchaseOrder, PurchaseOrderVM>()
            .ForMember(dest => dest.Vendor, opt => opt.MapFrom(c => c.Vendor.Name ?? "{Needs Updating}"))
                .ReverseMap();
        CreateMap<PurchaseOrderLine, PurchaseOrderLineVM>()
            .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(c => c.PurchaseOrder.PurchaseOrderNumber ?? "{Needs Updating}"))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(c => c.Product.ProductName ?? "{Needs Updating}"))
                .ReverseMap();
    }
}
