using AutoMapper;
using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.AccountViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;

namespace ServiceLayer.Services.CommonServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            #region Inventory
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
            #endregion

            #region Payroll
            CreateMap<Attendance, IndividualAttendanceViewModel>()
                 .ForMember(dest => dest.Project,
                     opt => opt.MapFrom(src => src.Project.ProjectName))
                 .ForMember(dest => dest.Date,
                     opt => opt.MapFrom(src => src.Date.ToShortDateString()))
                 .ForMember(dest => dest.TimeOut,
                    opt => opt.MapFrom(src => src.TimeOut.ToString(@"hh\:mm"))) // Format as "HH:mm"
                 .ForMember(dest => dest.TimeIn,
                    opt => opt.MapFrom(src => src.TimeIn.ToString(@"hh\:mm"))) // Format as "HH:mm"
                 .ForMember(dest => dest.Status,
                     opt => opt.MapFrom(src =>
                         !src.IsPresent
                             ? AttendanceStatus.Absent.ToString()
                             : (src.Employee.Shift == null
                                 ? AttendanceStatus.Present.ToString()
                                 : (src.TimeIn > src.Employee.Shift.StartTime
                                     ? AttendanceStatus.Late.ToString()
                                     : (src.TimeOut < src.Employee.Shift.EndTime
                                         ? AttendanceStatus.EarlyOut.ToString()
                                         : AttendanceStatus.Present.ToString())))))
                 .ReverseMap();

            CreateMap<Allowance, AllowanceViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                 .ForMember(dest => dest.IsRecurring, opt => opt.MapFrom(src => src.IsRecurring.ToString()))
                .ReverseMap();
            CreateMap<Deduction, DeductionViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();
            CreateMap<Employee, EmployeeViewModel>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"))
                 .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                 .ForMember(dest => dest.Shift, opt => opt.MapFrom(src => src.Shift.ShiftName))
                 .ForMember(dest => dest.JobPosition, opt => opt.MapFrom(src => src.JobPosition.Title))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString()))
                 .ForMember(dest => dest.isDeducted, opt => opt.MapFrom(src => src.isDeducted ? "Yes" : "No"))
                .ReverseMap();
            CreateMap<Leave, LeaveViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToShortDateString()))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToShortDateString()))
                .ReverseMap();
            CreateMap<Benefit, BenefitViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();
            CreateMap<Shift, ShiftViewModel>()
                 .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
                 .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")))
                .ReverseMap();
            #endregion
        }
    }
}
