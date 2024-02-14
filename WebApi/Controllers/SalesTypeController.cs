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
    [Route("api/SalesType")]
    public class SalesTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public SalesTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/SalesType
        [HttpGet]
        public IActionResult GetSalesType()
        {
            var Items = _context.SalesType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<SalesType> payload)
        {
            var salesType = payload.value;
            _context.SalesType.Add(salesType);
            _context.Save();
            return Ok(salesType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<SalesType> payload)
        {
            var salesType = payload.value;
            _context.SalesType.Update(salesType);
            _context.Save();
            return Ok(salesType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<SalesType> payload)
        {
            var salesType = _context.SalesType
                .Get(x => x.SalesTypeId == (int)payload.key);
            _context.SalesType.Remove(salesType);
            _context.Save();
            return Ok(salesType);

        }
    }
}