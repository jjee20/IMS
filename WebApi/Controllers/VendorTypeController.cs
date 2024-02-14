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
    [Route("api/VendorType")]
    public class VendorTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public VendorTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/VendorType
        [HttpGet]
        public IActionResult GetVendorType()
        {
            var Items = _context.VendorType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<VendorType> payload)
        {
            var vendorType = payload.value;
            _context.VendorType.Add(vendorType);
            _context.Save();
            return Ok(vendorType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<VendorType> payload)
        {
            var vendorType = payload.value;
            _context.VendorType.Update(vendorType);
            _context.Save();
            return Ok(vendorType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<VendorType> payload)
        {
            var vendorType = _context.VendorType
                .Get(x => x.VendorTypeId == (int)payload.key);
            _context.VendorType.Remove(vendorType);
            _context.Save();
            return Ok(vendorType);

        }
    }
}