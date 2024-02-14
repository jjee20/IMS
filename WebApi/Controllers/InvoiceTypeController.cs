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
    [Route("api/InvoiceType")]
    public class InvoiceTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public InvoiceTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/InvoiceType
        [HttpGet]
        public IActionResult GetInvoiceType()
        {
            var Items = _context.InvoiceType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<InvoiceType> payload)
        {
            InvoiceType invoiceType = payload.value;
            _context.InvoiceType.Add(invoiceType);
            _context.Save();
            return Ok(invoiceType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<InvoiceType> payload)
        {
            InvoiceType invoiceType = payload.value;
            _context.InvoiceType.Update(invoiceType);
            _context.Save();
            return Ok(invoiceType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<InvoiceType> payload)
        {
            var invoiceType = _context.InvoiceType.Get(x => x.InvoiceTypeId == (int)payload.key);

            _context.InvoiceType.Remove(invoiceType);
            _context.Save();
            return Ok(invoiceType);

        }
    }
}