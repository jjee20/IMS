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
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private readonly IUnitOfWork _context;

        public CurrencyController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Currency
        [HttpGet]
        public IActionResult GetCurrency()
        {
            var Items = _context.Currency.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet("{id}")]
        public IActionResult GetByBranchId([FromRoute]int id)
        {
            Branch branch = new Branch();
            Currency currency = new Currency();
            branch = _context.Branch.Get(x => x.BranchId.Equals(id));
            if (branch != null && branch.CurrencyId != 0)
            {
                currency = _context.Currency.Get(x => x.CurrencyId.Equals(branch.CurrencyId));
                
            }
            return Ok(currency);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Currency> payload)
        {
            Currency currency = payload.value;
            _context.Currency.Add(currency);
            _context.Save();
            return Ok(currency);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Currency> payload)
        {
            Currency currency = payload.value;
            _context.Currency.Update(currency);
            _context.Save();
            return Ok(currency);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Currency> payload)
        {
            var currency = _context.Currency.Get(x => x.CurrencyId == (int)payload.key);

            _context.Currency.Remove(currency);
            _context.Save();
            return Ok(currency);

        }
    }
}