using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/CashBank")]
    public class CashBankController : Controller
    {
        private readonly IUnitOfWork _context;

        public CashBankController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/CashBank
        [HttpGet]
        public IActionResult GetCashBank()
        {
            var Items = _context.CashBank.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<CashBank> payload)
        {
            CashBank cashBank = payload.value;
            _context.CashBank.Add(cashBank);
            _context.Save();
            return Ok(cashBank);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<CashBank> payload)
        {
            CashBank cashBank = payload.value;
            _context.CashBank.Update(cashBank);
            _context.Save();
            return Ok(cashBank);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<CashBank> payload)
        {
            var cashBank = _context.CashBank.Get(x => x.CashBankId == (int)payload.key);
            _context.CashBank.Remove(cashBank);
            _context.Save();
            return Ok(cashBank);

        }
    }
}