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
    [Route("api/CustomerType")]
    public class CustomerTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public CustomerTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/CustomerType
        [HttpGet]
        public IActionResult GetCustomerType()
        {
            var Items = _context.CustomerType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<CustomerType> payload)
        {
            CustomerType customerType = payload.value;
            _context.CustomerType.Add(customerType);
            _context.Save();
            return Ok(customerType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<CustomerType> payload)
        {
            CustomerType customerType = payload.value;
            _context.CustomerType.Update(customerType);
            _context.Save();
            return Ok(customerType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<CustomerType> payload)
        {
            var customerType = _context.CustomerType.Get(x => x.CustomerTypeId == (int)payload.key);

            _context.CustomerType.Remove(customerType);
            _context.Save();
            return Ok(customerType);

        }
    }
}