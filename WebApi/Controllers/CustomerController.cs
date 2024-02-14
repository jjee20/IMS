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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _context;

        public CustomerController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var Items = _context.Customer.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Add(customer);
            _context.Save();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Update(customer);
            _context.Save();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Customer> payload)
        {
            var customer = _context.Customer.Get(x => x.CustomerId == (int)payload.key);

            _context.Customer.Remove(customer);
            _context.Save();
            return Ok(customer);

        }
    }
}