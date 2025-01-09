using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class InvoiceTypeRepository : BaseRepository, IInvoiceTypeRepository
    public class InvoiceTypeRepository : Repository<InvoiceType>, IInvoiceTypeRepository
    {
        private ApplicationDataContext _db;
        public InvoiceTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(InvoiceType obj)
        {
            _db.InvoiceType.Update(obj);
        }
    }
}
