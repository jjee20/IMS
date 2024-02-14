using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.CommonServices;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Shipment")]
    public class ShipmentController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public ShipmentController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/Shipment
        [HttpGet]
        public IActionResult GetShipment()
        {
            var Items = _context.Shipment.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult GetNotInvoicedYet()
        {
            try
            {
                var invoices = _context.Invoice.GetAll(x => x.ShipmentId != null);
                
                var shipments = _context.Shipment
                    .GetAll(x => x.ShipmentId.Equals(x.ShipmentId));
                return Ok(shipments);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Shipment> payload)
        {
            var shipment = payload.value;
            shipment.ShipmentName = _numberSequence.GetNumberSequence("DO");
            _context.Shipment.Add(shipment);
            _context.Save();
            return Ok(shipment);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Shipment> payload)
        {
            var shipment = payload.value;
            _context.Shipment.Update(shipment);
            _context.Save();
            return Ok(shipment);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Shipment> payload)
        {   
            var shipment = _context.Shipment
                .Get(x => x.ShipmentId == (int)payload.key);
            _context.Shipment.Remove(shipment);
            _context.Save();
            return Ok(shipment);

        }
    }
}