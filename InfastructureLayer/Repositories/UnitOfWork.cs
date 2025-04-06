using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories;
using InfastructureLayer.Repositories.Accounting.Payroll;
using InfastructureLayer.Repositories.Accounts;
using InfastructureLayer.Repositories.Inventory;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;
using ServiceLayer.Services.IRepositories.IAccounts;
using ServiceLayer.Services.IRepositories.IInventory;
using System;

namespace InfastructureLayer.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext _db;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDataContext db)
        {
            _db = db;

            // Lazy Initialization
            ApplicationUser = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(_db));
            TargetGoals = new Lazy<ITargetGoalsRepository>(() => new TargetGoalsRepository(_db));
            Bill = new Lazy<IBillRepository>(() => new BillRepository(_db));
            BillType = new Lazy<IBillTypeRepository>(() => new BillTypeRepository(_db));
            Branch = new Lazy<IBranchRepository>(() => new BranchRepository(_db));
            CashBank = new Lazy<ICashBankRepository>(() => new CashBankRepository(_db));
            Customer = new Lazy<ICustomerRepository>(() => new CustomerRepository(_db));
            CustomerType = new Lazy<ICustomerTypeRepository>(() => new CustomerTypeRepository(_db));
            GoodsReceivedNote = new Lazy<IGoodsReceivedNoteRepository>(() => new GoodsReceivedNoteRepository(_db));
            Invoice = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(_db));
            InvoiceType = new Lazy<IInvoiceTypeRepository>(() => new InvoiceTypeRepository(_db));
            NumberSequence = new Lazy<INumberSequenceRepository>(() => new NumberSequenceRepository(_db));
            PaymentReceive = new Lazy<IPaymentReceiveRepository>(() => new PaymentReceiveRepository(_db));
            PaymentType = new Lazy<IPaymentTypeRepository>(() => new PaymentTypeRepository(_db));
            PaymentVoucher = new Lazy<IPaymentVoucherRepository>(() => new PaymentVoucherRepository(_db));
            Product = new Lazy<IProductRepository>(() => new ProductRepository(_db));
            ProductType = new Lazy<IProductTypeRepository>(() => new ProductTypeRepository(_db));
            PurchaseOrder = new Lazy<IPurchaseOrderRepository>(() => new PurchaseOrderRepository(_db));
            PurchaseOrderLine = new Lazy<IPurchaseOrderLineRepository>(() => new PurchaseOrderLineRepository(_db));
            PurchaseType = new Lazy<IPurchaseTypeRepository>(() => new PurchaseTypeRepository(_db));
            SalesOrder = new Lazy<ISalesOrderRepository>(() => new SalesOrderRepository(_db));
            SalesOrderLine = new Lazy<ISalesOrderLineRepository>(() => new SalesOrderLineRepository(_db));
            SalesType = new Lazy<ISalesTypeRepository>(() => new SalesTypeRepository(_db));
            Shipment = new Lazy<IShipmentRepository>(() => new ShipmentRepository(_db));
            ShipmentType = new Lazy<IShipmentTypeRepository>(() => new ShipmentTypeRepository(_db));
            UnitOfMeasure = new Lazy<IUnitOfMeasureRepository>(() => new UnitOfMeasureRepository(_db));
            Vendor = new Lazy<IVendorRepository>(() => new VendorRepository(_db));
            VendorType = new Lazy<IVendorTypeRepository>(() => new VendorTypeRepository(_db));
            Warehouse = new Lazy<IWarehouseRepository>(() => new WarehouseRepository(_db));
            UserProfile = new Lazy<IUserProfileRepository>(() => new UserProfileRepository(_db));
            Department = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_db));
            Attendance = new Lazy<IAttendanceRepository>(() => new AttendanceRepository(_db));
            AuditLog = new Lazy<IAuditLogRepository>(() => new AuditLogRepository(_db));
            Benefit = new Lazy<IBenefitRepository>(() => new BenefitRepository(_db));
            Contribution = new Lazy<IContributionRepository>(() => new ContributionRepository(_db));
            Deduction = new Lazy<IDeductionRepository>(() => new DeductionRepository(_db));
            Employee = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_db));
            JobPosition = new Lazy<IJobPositionRepository>(() => new JobPositionRepository(_db));
            Leave = new Lazy<ILeaveRepository>(() => new LeaveRepository(_db));
            PerformanceReview = new Lazy<IPerformanceReviewRepository>(() => new PerformanceReviewRepository(_db));
            Shift = new Lazy<IShiftRepository>(() => new ShiftRepository(_db));
            Tax = new Lazy<ITaxRepository>(() => new TaxRepository(_db));
            Project = new Lazy<IProjectRepository>(() => new ProjectRepository(_db));
            Allowance = new Lazy<IAllowanceRepository>(() => new AllowanceRepository(_db));
            Bonus = new Lazy<IBonusRepository>(() => new BonusRepository(_db));
            ProjectLine = new Lazy<IProjectLineRepository>(() => new ProjectLineRepository(_db));
            StockInLogs = new Lazy<IProductStockInLogRepository>(() => new ProductStockInLogRepository(_db));
            EmployeeContribution = new Lazy<IEmployeeContributionRepository>(() => new EmployeeContributionRepository(_db));
        }

        // Lazy Repository Properties
        public Lazy<IApplicationUserRepository> ApplicationUser { get; }
        public Lazy<ITargetGoalsRepository> TargetGoals { get; }
        public Lazy<IBillRepository> Bill { get; }
        public Lazy<IBillTypeRepository> BillType { get; }
        public Lazy<IBranchRepository> Branch { get; }
        public Lazy<ICashBankRepository> CashBank { get; }
        public Lazy<ICustomerRepository> Customer { get; }
        public Lazy<ICustomerTypeRepository> CustomerType { get; }
        public Lazy<IGoodsReceivedNoteRepository> GoodsReceivedNote { get; }
        public Lazy<IInvoiceRepository> Invoice { get; }
        public Lazy<IInvoiceTypeRepository> InvoiceType { get; }
        public Lazy<INumberSequenceRepository> NumberSequence { get; }
        public Lazy<IPaymentReceiveRepository> PaymentReceive { get; }
        public Lazy<IPaymentTypeRepository> PaymentType { get; }
        public Lazy<IPaymentVoucherRepository> PaymentVoucher { get; }
        public Lazy<IProductRepository> Product { get; }
        public Lazy<IProductTypeRepository> ProductType { get; }
        public Lazy<IPurchaseOrderRepository> PurchaseOrder { get; }
        public Lazy<IPurchaseOrderLineRepository> PurchaseOrderLine { get; }
        public Lazy<IPurchaseTypeRepository> PurchaseType { get; }
        public Lazy<ISalesOrderRepository> SalesOrder { get; }
        public Lazy<ISalesOrderLineRepository> SalesOrderLine { get; }
        public Lazy<ISalesTypeRepository> SalesType { get; }
        public Lazy<IShipmentRepository> Shipment { get; }
        public Lazy<IShipmentTypeRepository> ShipmentType { get; }
        public Lazy<IUnitOfMeasureRepository> UnitOfMeasure { get; }
        public Lazy<IVendorRepository> Vendor { get; }
        public Lazy<IVendorTypeRepository> VendorType { get; }
        public Lazy<IWarehouseRepository> Warehouse { get; }
        public Lazy<IUserProfileRepository> UserProfile { get; }
        public Lazy<IDepartmentRepository> Department { get; }
        public Lazy<IAttendanceRepository> Attendance { get; }
        public Lazy<IAuditLogRepository> AuditLog { get; }
        public Lazy<IBenefitRepository> Benefit { get; }
        public Lazy<IContributionRepository> Contribution { get; }
        public Lazy<IDeductionRepository> Deduction { get; }
        public Lazy<IEmployeeRepository> Employee { get; }
        public Lazy<IJobPositionRepository> JobPosition { get; }
        public Lazy<ILeaveRepository> Leave { get; }
        public Lazy<IPerformanceReviewRepository> PerformanceReview { get; }
        public Lazy<IShiftRepository> Shift { get; }
        public Lazy<ITaxRepository> Tax { get; }
        public Lazy<IProjectRepository> Project { get; }
        public Lazy<IAllowanceRepository> Allowance { get; }
        public Lazy<IBonusRepository> Bonus { get; }
        public Lazy<IProjectLineRepository> ProjectLine { get; }
        public Lazy<IProductStockInLogRepository> StockInLogs { get; }
        public Lazy<IEmployeeContributionRepository> EmployeeContribution { get; }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new Repository<T>(_db);
                _repositories[type] = repositoryInstance;
            }

            return (IRepository<T>)_repositories[type];
        }

        public async void Save() => _db.SaveChanges();
        public Task SaveAsync() => _db.SaveChangesAsync();
    }
}
