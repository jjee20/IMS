using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class InvoiceRepository : BaseRepository, IInvoiceRepository
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private ApplicationDataContext _db;
        public InvoiceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Invoice obj)
        {
            _db.Invoice.Update(obj);
        }
    }
}
