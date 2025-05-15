using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class InvoiceTypeRepository : BaseRepository, IInvoiceTypeRepository
    public class InvoiceTypeRepository : Repository<InvoiceType>, IInvoiceTypeRepository
    {
        private ApplicationDataContext _db;
        public InvoiceTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
