using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
                _db.ChangeTracker.Clear();
                _db.Invoice.Update(obj);
        }
    }
}
