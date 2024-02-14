using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using System.Linq.Expressions;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Bill")]
    public class BillController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public BillController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Bill
        [HttpGet]
        public IActionResult GetBill()
        {
            var Items = _context.Bill.GetAll(); // Synchronously wait for the result
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet]
        public IActionResult GetNotPaidYet()
        {
            var vouchers = _context.PaymentVoucher.GetAll();

            // Extract bill IDs from payment vouchers
            var paidBillIds = vouchers.Select(v => v.BillId).ToList();

            // Define the filter expression for bills that are not paid yet
            Expression<Func<Bill, bool>> filter = x => !paidBillIds.Contains(x.BillId);

            // Call the Get method from the repository with the filter expression
            var bills = _context.Bill.GetAll(filter);

            // Return the result
            return Ok(bills);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Bill> payload)
        {
            var bill = payload.value;
            bill.BillName = _numberSequence.GetNumberSequence("BILL");
            _context.Bill.Add(bill);
            _context.Save();
            return Ok(bill);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Bill> payload)
        {
            var bill = payload.value;
            _context.Bill.Update(bill);
            _context.Save();
            return Ok(bill);
        }

        [HttpPost]
        public IActionResult Remove([FromBody] CrudViewModel<Bill> payload)
        {
            try
            {
                var bill = _context.Bill.Get(x => x.BillId == (int)payload.key);

                if (bill != null)
                {
                    _context.Bill.Remove(bill);
                    _context.Save();
                    return Ok(bill);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}