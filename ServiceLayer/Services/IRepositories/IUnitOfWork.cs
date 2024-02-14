namespace ServiceLayer.Services.IRepositories
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        IBillRepository Bill { get; }
        IBillTypeRepository BillType { get; }
        IBranchRepository Branch { get; }
        ICashBankRepository CashBank { get; }
        ICurrencyRepository Currency { get; }
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
        void Save();
    }
}