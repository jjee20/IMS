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
    [Route("api/Vendor")]
    public class VendorController : Controller
    {
        private readonly IUnitOfWork _context;

        public VendorController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public IActionResult GetVendor()
        {
            var Items = _context.Vendor.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Vendor> payload)
        {
            var vendor = payload.value;
            _context.Vendor.Add(vendor);
            _context.Save();
            return Ok(vendor);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Vendor> payload)
        {
            var vendor = payload.value;
            _context.Vendor.Update(vendor);
            _context.Save();
            return Ok(vendor);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Vendor> payload)
        {
            var vendor = _context.Vendor
                .Get(x => x.VendorId == (int)payload.key);
            _context.Vendor.Remove(vendor);
            _context.Save();
            return Ok(vendor);

        }
    }
}