using AutoMapper;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.AccountViewModels;
using DomainLayer.ViewModels.Inventory;

namespace ServiceLayer.Services.CommonServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.CustomerType.CustomerTypeName))
                .ReverseMap();
            CreateMap<ApplicationUser, AccountViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Profile.FirstName} {src.Profile.LastName}"))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.ToString()))
                .ReverseMap();
            CreateMap<Branch, BranchViewModel>()
                .ReverseMap();
            CreateMap<Bill, BillViewModel>()
                .ForMember(dest => dest.GoodsReceivedNote, opt => opt.MapFrom(src => src.GoodsReceivedNote.GoodsReceivedNoteName))
                .ForMember(dest => dest.BillType, opt => opt.MapFrom(src => src.BillType.BillTypeName))
                .ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(dest => dest.Shipment, opt => opt.MapFrom(src => src.Shipment.ShipmentName))
                .ForMember(dest => dest.InvoiceType, opt => opt.MapFrom(src => src.InvoiceType.InvoiceTypeName))
                .ReverseMap();
            CreateMap<PaymentReceive, PaymentReceiveViewModel>()
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice.InvoiceName))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ReverseMap();
            CreateMap<PaymentVoucher, PaymentVoucherViewModel>()
                .ForMember(dest => dest.Bill, opt => opt.MapFrom(src => src.Bill.BillName))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.CashBank, opt => opt.MapFrom(src => src.CashBank.CashBankName))
                .ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure.UnitOfMeasureName))
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ReverseMap();
            CreateMap<Warehouse, WarehouseViewModel>()
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderViewModel>()
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.Vendor, opt => opt.MapFrom(src => src.Vendor.VendorName))
                .ForMember(dest => dest.PurchaseType, opt => opt.MapFrom(src => src.PurchaseType.PurchaseTypeName))
                .ReverseMap();
            CreateMap<SalesOrder, SalesOrderViewModel>()
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.SalesType, opt => opt.MapFrom(src => src.SalesType.SalesTypeName))
                .ReverseMap();
            CreateMap<Shipment, ShipmentViewModel>()
                .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(src => src.SalesOrder.SalesOrderName))
                .ForMember(dest => dest.ShipmentType, opt => opt.MapFrom(src => src.ShipmentType.ShipmentTypeName))
                .ForMember(dest => dest.Warehouse, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ReverseMap();
            CreateMap<Vendor, VendorViewModel>()
                .ForMember(dest => dest.VendorType, opt => opt.MapFrom(src => src.VendorType.VendorTypeName))
                .ReverseMap();
            CreateMap<Warehouse, WarehouseViewModel>()
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ReverseMap();
        }
    }
}
