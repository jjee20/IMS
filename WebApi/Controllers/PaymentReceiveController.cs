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
    [Route("api/PaymentReceive")]
    public class PaymentReceiveController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public PaymentReceiveController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PaymentReceive
        [HttpGet]
        public IActionResult GetPaymentReceive()
        {
            var Items = _context.PaymentReceive.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<PaymentReceive> payload)
        {
            PaymentReceive paymentReceive = payload.value;
            paymentReceive.PaymentReceiveName = _numberSequence.GetNumberSequence("PAYRCV");
            _context.PaymentReceive.Add(paymentReceive);
            _context.Save();
            return Ok(paymentReceive);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PaymentReceive> payload)
        {
            PaymentReceive paymentReceive = payload.value;
            _context.PaymentReceive.Update(paymentReceive);
            _context.Save();
            return Ok(paymentReceive);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PaymentReceive> payload)
        {
            var paymentReceive = _context.PaymentReceive.Get(x => x.PaymentReceiveId == (int)payload.key);

            _context.PaymentReceive.Remove(paymentReceive);
            _context.Save();
            return Ok(paymentReceive);

        }
    }
}