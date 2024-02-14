using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.CommonServices;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Invoice")]
    public class InvoiceController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public InvoiceController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var Items = _context.Invoice.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet]
        public async Task<IActionResult> GetNotPaidYet()
        {
            try
            {
                var receives = _context.PaymentReceive.GetAll(v => v.InvoiceId != null);
                
                var invoices = _context.Invoice
                    .GetAll(x => x.InvoiceId.Equals(receives))
                    .ToList();
                return Ok(invoices);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Invoice> payload)
        {
            Invoice invoice = payload.value;
            invoice.InvoiceName = _numberSequence.GetNumberSequence("INV");
            _context.Invoice.Add(invoice);
            _context.Save();
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Invoice> payload)
        {
            Invoice invoice = payload.value;
            _context.Invoice.Update(invoice);
            _context.Save();
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Invoice> payload)
        {
            var invoice = _context.Invoice.Get(x => x.InvoiceId == (int)payload.key);

            _context.Invoice.Remove(invoice);
            _context.Save();
            return Ok(invoice);

        }
    }
}