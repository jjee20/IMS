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
    [Route("api/ProductType")]
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public ProductTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/ProductType
        [HttpGet]
        public IActionResult GetProductType()
        {
            var Items = _context.ProductType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<ProductType> payload)
        {
            ProductType productType = payload.value;
            _context.ProductType.Add(productType);
            _context.Save();
            return Ok(productType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<ProductType> payload)
        {
            ProductType productType = payload.value;
            _context.ProductType.Update(productType);
            _context.Save();
            return Ok(productType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<ProductType> payload)
        {
            var productType = _context.ProductType.Get(x => x.ProductTypeId == (int)payload.key);

            _context.ProductType.Remove(productType);
            _context.Save();
            return Ok(productType);

        }
    }
}