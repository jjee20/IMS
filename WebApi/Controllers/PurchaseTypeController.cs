using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/PurchaseType")]
    public class PurchaseTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public PurchaseTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/PurchaseType
        [HttpGet]
        public IActionResult GetPurchaseType()
        {
            var Items = _context.PurchaseType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<PurchaseType> payload)
        {
            PurchaseType purchaseType = payload.value;
            _context.PurchaseType.Add(purchaseType);
            _context.Save();
            return Ok(purchaseType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PurchaseType> payload)
        {
            PurchaseType purchaseType = payload.value;
            _context.PurchaseType.Update(purchaseType);
            _context.Save();
            return Ok(purchaseType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PurchaseType> payload)
        {
            var purchaseType = _context.PurchaseType
                .Get(x => x.PurchaseTypeId == (int)payload.key);
            _context.PurchaseType.Remove(purchaseType);
            _context.Save();
            return Ok(purchaseType);

        }
    }
}