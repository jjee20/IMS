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
    [Route("api/PaymentVoucher")]
    public class PaymentVoucherController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public PaymentVoucherController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PaymentVoucher
        [HttpGet]
        public IActionResult GetPaymentVoucher()
        {
            var Items = _context.PaymentVoucher.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<PaymentVoucher> payload)
        {
            PaymentVoucher paymentVoucher = payload.value;
            paymentVoucher.PaymentVoucherName = _numberSequence.GetNumberSequence("PAYVCH");
            _context.PaymentVoucher.Add(paymentVoucher);
            _context.Save();
            return Ok(paymentVoucher);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PaymentVoucher> payload)
        {
            PaymentVoucher paymentVoucher = payload.value;
            _context.PaymentVoucher.Update(paymentVoucher);
            _context.Save();
            return Ok(paymentVoucher);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PaymentVoucher> payload)
        {
            var paymentVoucher = _context.PaymentVoucher.Get(x => x.PaymentVoucherId == (int)payload.key);

            _context.PaymentVoucher.Remove(paymentVoucher);
            _context.Save();
            return Ok(paymentVoucher);

        }
    }
}