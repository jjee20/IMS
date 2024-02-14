using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDataContext _db;
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IBillRepository Bill { get; private set; }
        public IBillTypeRepository BillType { get; private set; }
        public IBranchRepository Branch { get; private set; }
        public ICashBankRepository CashBank { get; private set; }
        public ICurrencyRepository Currency { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public ICustomerTypeRepository CustomerType { get; private set; }
        public IGoodsReceivedNoteRepository GoodsReceivedNote { get; private set; }
        public IInvoiceRepository Invoice { get; private set; }
        public IInvoiceTypeRepository InvoiceType { get; private set; }
        public INumberSequenceRepository NumberSequence { get; private set; }
        public IPaymentReceiveRepository PaymentReceive { get; private set; }
        public IPaymentTypeRepository PaymentType { get; private set; }
        public IPaymentVoucherRepository PaymentVoucher { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductTypeRepository ProductType { get; private set; }
        public IPurchaseOrderRepository PurchaseOrder { get; private set; }
        public IPurchaseOrderLineRepository PurchaseOrderLine { get; private set; }
        public IPurchaseTypeRepository PurchaseType { get; private set; }
        public ISalesOrderRepository SalesOrder { get; private set; }
        public ISalesOrderLineRepository SalesOrderLine { get; private set; }
        public ISalesTypeRepository SalesType { get; private set; }
        public IShipmentRepository Shipment { get; private set; }
        public IShipmentTypeRepository ShipmentType { get; private set; }
        public IUnitOfMeasureRepository UnitOfMeasure { get; private set; }
        public IVendorRepository Vendor { get; private set; }
        public IVendorTypeRepository VendorType { get; private set; }
        public IWarehouseRepository Warehouse { get; private set; }
        public IUserProfileRepository UserProfile { get; private set; }
        public UnitOfWork(ApplicationDataContext db)
        {
            _db = db;
            Bill = new BillRepository(_db);
            ApplicationUser = new ApplicationUserRepository(db);
            BillType = new BillTypeRepository(_db);
            Branch = new BranchRepository(_db);
            CashBank = new CashBankRepository(_db);
            Currency = new CurrencyRepository(_db);
            Customer = new CustomerRepository(_db);
            CustomerType = new CustomerTypeRepository(_db);
            GoodsReceivedNote = new GoodsReceivedNoteRepository(_db);
            Invoice = new InvoiceRepository(_db);
            InvoiceType = new InvoiceTypeRepository(_db);
            NumberSequence = new NumberSequenceRepository(_db);
            PaymentReceive = new PaymentReceiveRepository(_db);
            PaymentType = new PaymentTypeRepository(_db);
            PaymentVoucher = new PaymentVoucherRepository(_db);
            Product = new ProductRepository(_db);
            ProductType = new ProductTypeRepository(_db);
            PurchaseOrder = new PurchaseOrderRepository(_db);
            PurchaseOrderLine = new PurchaseOrderLineRepository(_db);
            PurchaseType = new PurchaseTypeRepository(_db);
            SalesOrder = new SalesOrderRepository(_db);
            SalesOrderLine = new SalesOrderLineRepository(_db);
            SalesType = new SalesTypeRepository(_db);
            Shipment = new ShipmentRepository(_db);
            ShipmentType = new ShipmentTypeRepository(_db);
            UnitOfMeasure = new UnitOfMeasureRepository(_db);
            Vendor = new VendorRepository(_db);
            VendorType = new VendorTypeRepository(_db);
            Warehouse = new WarehouseRepository(_db);
            UserProfile = new UserProfileRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
