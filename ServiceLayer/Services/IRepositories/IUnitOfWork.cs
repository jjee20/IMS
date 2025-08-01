﻿using DomainLayer.Models.ThinkEE;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;
using ServiceLayer.Services.IRepositories.IAccounts;
using ServiceLayer.Services.IRepositories.IInventory;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace ServiceLayer.Services.IRepositories
{
    public interface IUnitOfWork
    {
        Lazy<IProductIncrementRepository> ProductIncrement { get; }
        Lazy<IPerformanceReportRepository> PerformanceReport { get; }
        Lazy<IExamResultChoiceRepository> ExamResultChoice { get; }
        Lazy<IExamResultRepository> ExamResult { get; }
        Lazy<IChoiceRepository> Choice { get; }
        Lazy<IQuestionRepository> Question { get; }
        Lazy<IExamRepository> Exam { get; }
        Lazy<IExamFormatRepository> ExamFormat { get; }
        Lazy<IExamTopicRepository> ExamTopic { get; }
        Lazy<IHolidayRepository> Holiday { get; }
        Lazy<IAllowanceRepository> Allowance { get; }
        Lazy<IApplicationUserRepository> ApplicationUser { get; }
        Lazy<IAttendanceRepository> Attendance { get; }
        Lazy<IAuditLogRepository> AuditLog { get; }
        Lazy<IBenefitRepository> Benefit { get; }
        Lazy<IBillRepository> Bill { get; }
        Lazy<IBillTypeRepository> BillType { get; }
        Lazy<IBonusRepository> Bonus { get; }
        Lazy<IBranchRepository> Branch { get; }
        Lazy<ICashBankRepository> CashBank { get; }
        Lazy<IContributionRepository> Contribution { get; }
        Lazy<ICustomerRepository> Customer { get; }
        Lazy<ICustomerTypeRepository> CustomerType { get; }
        Lazy<IDeductionRepository> Deduction { get; }
        Lazy<IDepartmentRepository> Department { get; }
        Lazy<IEmployeeRepository> Employee { get; }
        Lazy<IEmployeeContributionRepository> EmployeeContribution { get; }
        Lazy<IGoodsReceivedNoteRepository> GoodsReceivedNote { get; }
        Lazy<IInvoiceRepository> Invoice { get; }
        Lazy<IInvoiceTypeRepository> InvoiceType { get; }
        Lazy<IJobPositionRepository> JobPosition { get; }
        Lazy<ILeaveRepository> Leave { get; }
        Lazy<INumberSequenceRepository> NumberSequence { get; }
        Lazy<IPaymentReceiveRepository> PaymentReceive { get; }
        Lazy<IPaymentTypeRepository> PaymentType { get; }
        Lazy<IPaymentVoucherRepository> PaymentVoucher { get; }
        Lazy<IPerformanceReviewRepository> PerformanceReview { get; }
        Lazy<IProductRepository> Product { get; }
        Lazy<IProductTypeRepository> ProductType { get; }
        Lazy<IProjectRepository> Project { get; }
        Lazy<IProjectLineRepository> ProjectLine { get; }
        Lazy<IPurchaseOrderRepository> PurchaseOrder { get; }
        Lazy<IPurchaseOrderLineRepository> PurchaseOrderLine { get; }
        Lazy<IPurchaseTypeRepository> PurchaseType { get; }
        Lazy<ISalesOrderRepository> SalesOrder { get; }
        Lazy<ISalesOrderLineRepository> SalesOrderLine { get; }
        Lazy<ISalesTypeRepository> SalesType { get; }
        Lazy<IShiftRepository> Shift { get; }
        Lazy<IShipmentRepository> Shipment { get; }
        Lazy<IShipmentTypeRepository> ShipmentType { get; }
        Lazy<IProductStockInLogRepository> ProductStockInLogs { get; }
        Lazy<IProductStockInLogLinesRepository> ProductStockInLogLines { get; }
        Lazy<IProductPullOutLogRepository> ProductPullOutLogs { get; }
        Lazy<IProductPullOutLogLinesRepository> ProductPullOutLogLines { get; }
        Lazy<ITargetGoalsRepository> TargetGoals { get; }
        Lazy<ITaxRepository> Tax { get; }
        Lazy<IUnitOfMeasureRepository> UnitOfMeasure { get; }
        Lazy<IUserProfileRepository> UserProfile { get; }
        Lazy<IVendorRepository> Vendor { get; }
        Lazy<IVendorTypeRepository> VendorType { get; }
        Lazy<IWarehouseRepository> Warehouse { get; }
        Lazy<IThirteenthMonthRepository> ThirteenthMonth { get; }
        Lazy<IPayrollRepository> Payroll { get; }
        Lazy<IReviewTopicRepository> ReviewTopic { get; }

        IRepository<T> GetRepository<T>() where T : class;
        void Save();
        Task SaveAsync();
    }
}