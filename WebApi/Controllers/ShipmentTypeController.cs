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
    [Route("api/ShipmentType")]
    public class ShipmentTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public ShipmentTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/ShipmentType
        [HttpGet]
        public IActionResult GetShipmentType()
        {
            var Items = _context.ShipmentType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<ShipmentType> payload)
        {
            var shipmentType = payload.value;
            _context.ShipmentType.Add(shipmentType);
            _context.Save();
            return Ok(shipmentType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<ShipmentType> payload)
        {
            var shipmentType = payload.value;
            _context.ShipmentType.Update(shipmentType);
            _context.Save();
            return Ok(shipmentType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<ShipmentType> payload)
        {
            ShipmentType shipmentType = _context.ShipmentType
                .Get(x => x.ShipmentTypeId == (int)payload.key);
            _context.ShipmentType.Remove(shipmentType);
            _context.Save();
            return Ok(shipmentType);

        }
    }
}