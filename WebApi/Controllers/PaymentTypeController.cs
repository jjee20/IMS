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
    [Route("api/PaymentType")]
    public class PaymentTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public PaymentTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public IActionResult GetPaymentType()
        {
            var Items = _context.PaymentType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<PaymentType> payload)
        {
            PaymentType paymentType = payload.value;
            _context.PaymentType.Add(paymentType);
            _context.Save();
            return Ok(paymentType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PaymentType> payload)
        {
            PaymentType paymentType = payload.value;
            _context.PaymentType.Update(paymentType);
            _context.Save();
            return Ok(paymentType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PaymentType> payload)
        {
            var paymentType = _context.PaymentType.Get(x => x.PaymentTypeId == (int)payload.key);

            _context.PaymentType.Remove(paymentType);
            _context.Save();
            return Ok(paymentType);

        }
    }
}