using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        IBillRepository Bill { get; }
        IBillTypeRepository BillType { get; }
        IBranchRepository Branch { get; }
        ICashBankRepository CashBank { get; }
        ICustomerRepository Customer { get; }
        ICustomerTypeRepository CustomerType { get; }
        IGoodsReceivedNoteRepository GoodsReceivedNote { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceTypeRepository InvoiceType { get; }
        INumberSequenceRepository NumberSequence { get; }
        IPaymentReceiveRepository PaymentReceive { get; }
        IPaymentTypeRepository PaymentType { get; }
        IPaymentVoucherRepository PaymentVoucher { get; }
        IProductRepository Product { get; }
        IProductTypeRepository ProductType { get; }
        IPurchaseOrderRepository PurchaseOrder { get; }
        IPurchaseOrderLineRepository PurchaseOrderLine { get; }
        IPurchaseTypeRepository PurchaseType { get; }
        ISalesOrderRepository SalesOrder { get; }
        ISalesOrderLineRepository SalesOrderLine { get; }
        ISalesTypeRepository SalesType { get; }
        IShipmentRepository Shipment { get; }
        IShipmentTypeRepository ShipmentType { get; }
        IUnitOfMeasureRepository UnitOfMeasure { get; }
        IVendorRepository Vendor { get; }
        IVendorTypeRepository VendorType { get; }
        IWarehouseRepository Warehouse { get; }
        IUserProfileRepository UserProfile { get; }
        IDepartmentRepository Department { get; }
        IAttendanceRepository Attendance { get; }
        IAuditLogRepository AuditLog { get; }
        IBenefitRepository Benefit { get; }
        IContributionRepository Contribution { get; }
        IDeductionRepository Deduction { get; }
        IEmployeeRepository Employee { get; }
        IJobPositionRepository JobPosition { get; }
        ILeaveRepository Leave { get; }
        IPerformanceReviewRepository PerformanceReview { get; }
        IShiftRepository Shift { get; }
        ITaxRepository Tax { get; }
        IProjectRepository Project { get; }
        IAllowanceRepository Allowance { get; }
        IBonusRepository Bonus { get; }
        IProjectLineRepository ProjectLine { get; }
        void Save();
    }
}