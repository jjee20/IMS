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
    [Route("api/Warehouse")]
    public class WarehouseController : Controller
    {
        private readonly IUnitOfWork _context;

        public WarehouseController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Warehouse
        [HttpGet]
        public IActionResult GetWarehouse()
        {
            var Items = _context.Warehouse.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Warehouse> payload)
        {
            var warehouse = payload.value;
            _context.Warehouse.Add(warehouse);
            _context.Save();
            return Ok(warehouse);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Warehouse> payload)
        {
            var warehouse = payload.value;
            _context.Warehouse.Update(warehouse);
            _context.Save();
            return Ok(warehouse);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Warehouse> payload)
        {
            var warehouse = _context.Warehouse
                .Get(x => x.WarehouseId == (int)payload.key);
            _context.Warehouse.Remove(warehouse);
            _context.Save();
            return Ok(warehouse);

        }
    }
}