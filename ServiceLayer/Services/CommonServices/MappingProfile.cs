﻿using AutoMapper;
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
            CreateMap<ProductStockInLog, ProductStockInLogViewModel>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => src.DateAdded.ToLongDateString()))
                .ReverseMap();
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.CustomerType.CustomerTypeName))
                .ReverseMap();
            CreateMap<ApplicationUser, AccountViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Profile.LastName}, {src.Profile.FirstName}"))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.ToString()))
                .ReverseMap();
            CreateMap<Branch, BranchViewModel>()
                .ReverseMap();
            CreateMap<Bill, BillViewModel>()
                .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(src => src.PurchaseOrder.PurchaseOrderName))
                .ForMember(dest => dest.BillType, opt => opt.MapFrom(src => src.BillType.BillTypeName))
                .ForMember(dest => dest.BillDueDate, opt => opt.MapFrom(src => src.BillDueDate.Date.ToLongDateString()))
                .ForMember(dest => dest.BillDate, opt => opt.MapFrom(src => src.BillDate.Date.ToLongDateString()))
                .ReverseMap();
            CreateMap<GoodsReceivedNote, GoodsReceiveNoteViewModel>()
                .ForMember(dest => dest.Warehouse, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(src => src.PurchaseOrder.PurchaseOrderName))
                .ReverseMap();
            CreateMap<GoodsReceivedNote, GoodsReceiveNoteInfoViewModel>()
                .ForMember(dest => dest.Warehouse, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(src => src.PurchaseOrder.PurchaseOrderName))
                .ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(src => src.SalesOrder.SalesOrderName))
                .ForMember(dest => dest.InvoiceType, opt => opt.MapFrom(src => src.InvoiceType.InvoiceTypeName))
                .ReverseMap();
            CreateMap<PaymentReceive, PaymentReceiveViewModel>()
                .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(src => src.SalesOrder.SalesOrderName))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate.Date.ToLongDateString()))
                .ReverseMap();
            CreateMap<PaymentReceive, PaymentReceiveInfoViewModel>()
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate.Date.ToLongDateString()))
                .ReverseMap();
            CreateMap<PaymentVoucher, PaymentVoucherViewModel>()
                .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(src => src.PurchaseOrder.PurchaseOrderName))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.CashBank, opt => opt.MapFrom(src => src.CashBank.CashBankName))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate.Date.ToLongDateString()))
                .ReverseMap();
            CreateMap<PaymentVoucher, PaymentVoucherInfoViewModel>()
                .ForMember(dest => dest.PurchaseOrder, opt => opt.MapFrom(src => src.PurchaseOrder.PurchaseOrderName))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.CashBank, opt => opt.MapFrom(src => src.CashBank.CashBankName))
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate.Date.ToLongDateString()))
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
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.Date.ToLongDateString()))
                .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate.Date.ToLongDateString()))
                .ReverseMap();
            CreateMap<SalesOrderLine, SalesOrderLineViewModel>()
                .ReverseMap();
            CreateMap<SalesOrderLine, SalesOrderLineInfoViewModel>()
                .ReverseMap();
            CreateMap<Shipment, ShipmentViewModel>()
                .ForMember(dest => dest.SalesOrder, opt => opt.MapFrom(src => src.SalesOrder.SalesOrderName))
                .ForMember(dest => dest.ShipmentType, opt => opt.MapFrom(src => src.ShipmentType.ShipmentTypeName))
                .ForMember(dest => dest.Warehouse, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                .ForMember(dest => dest.ShipmentDate, opt => opt.MapFrom(src => src.ShipmentDate.Date.ToLongDateString()))
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
                     opt => opt.MapFrom(src => src.Date.ToLongDateString()))
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
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                 .ForMember(dest => dest.IsRecurring, opt => opt.MapFrom(src => src.IsRecurring.ToString()))
                 .ForMember(dest => dest.DateGranted, opt => opt.MapFrom(src => src.DateGranted.ToLongDateString()))
                .ReverseMap();
            CreateMap<Deduction, DeductionViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                 .ForMember(dest => dest.DateDeducted, opt => opt.MapFrom(src => src.DateDeducted.ToLongDateString()))
                .ReverseMap();
            CreateMap<Benefit, BenefitViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                .ReverseMap();
            CreateMap<Bonus, BonusViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                 .ForMember(dest => dest.DateGranted, opt => opt.MapFrom(src => src.DateGranted.ToLongDateString()))
                .ReverseMap();
            CreateMap<EmployeeContribution, EmployeeContributionViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                .ReverseMap();
            CreateMap<Employee, EmployeeViewModel>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"))
                 .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                 .ForMember(dest => dest.Shift, opt => opt.MapFrom(src => src.Shift.ShiftName))
                 .ForMember(dest => dest.JobPosition, opt => opt.MapFrom(src => src.JobPosition.Title))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToLongDateString()))
                 .ForMember(dest => dest.isDeducted, opt => opt.MapFrom(src => src.isDeducted ? "Yes" : "No"))
                .ReverseMap();
            CreateMap<Employee, UserInformationViewModel>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"))
                 .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                 .ForMember(dest => dest.Shift, opt => opt.MapFrom(src => src.Shift.ShiftName))
                 .ForMember(dest => dest.JobPosition, opt => opt.MapFrom(src => src.JobPosition.Title))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToLongDateString()))
                 .ForMember(dest => dest.isDeducted, opt => opt.MapFrom(src => src.isDeducted ? "Yes" : "No"))
                 .ForMember(dest => dest.Allowances, opt => opt.MapFrom(src => src.Allowances ?? new List<Allowance>()))
                 .ForMember(dest => dest.Leaves, opt => opt.MapFrom(src => src.Leaves ?? new List<Leave>()))
                 .ForMember(dest => dest.Benefits, opt => opt.MapFrom(src => src.Benefits ?? new List<Benefit>()))
                 .ForMember(dest => dest.Deductions, opt => opt.MapFrom(src => src.Deductions ?? new List<Deduction>()))
                 .ForMember(dest => dest.Bonuses, opt => opt.MapFrom(src => src.Bonuses ?? new List<Bonus>()))
                 .ForMember(dest => dest.Attendances, opt => opt.MapFrom(src => src.Attendances ?? new List<Attendance>()))
                 .ForMember(dest => dest.Contribution, opt => opt.MapFrom(src => src.Contribution ?? new EmployeeContribution()))
                .ReverseMap();
            CreateMap<Leave, LeaveViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToLongDateString()))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToLongDateString()))
                .ReverseMap();
            CreateMap<Benefit, BenefitViewModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => $"{src.Employee.LastName}, {src.Employee.FirstName}"))
                .ReverseMap();
            CreateMap<Shift, ShiftViewModel>()
                 .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
                 .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")))
                .ReverseMap();

            CreateMap<Project, ProjectViewModel>()
                .ReverseMap();
            #endregion
            #region Admin

            CreateMap<ApplicationUser, AccountViewModel>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Profile.LastName}, {src.Profile.FirstName}"))
                 .ForMember(dest => dest.TaskRoles, opt => opt.MapFrom(src => string.Join(",",src.TaskRoles)))
                 .ReverseMap();
            #endregion
        }
    }
}
