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
    [Route("api/SalesOrder")]
    public class SalesOrderController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public SalesOrderController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/SalesOrder
        [HttpGet]
        public IActionResult GetSalesOrder()
        {
            var Items = _context.SalesOrder.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult GetNotShippedYet()
        {
            try
            {
                var shipments = _context.Shipment.GetAll(x => x.SalesOrderId != null);

                var salesOrders = _context.SalesOrder
                    .GetAll(x => x.SalesOrderId.Equals(shipments));
                return Ok(salesOrders);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.SalesOrder
                .Get(x => x.SalesOrderId.Equals(id), includeProperties:"SalesOrderLines");

            return Ok(result);
        }

        private void UpdateSalesOrder(int salesOrderId)
        {
            try
            {
                var salesOrder = _context.SalesOrder
                    .Get(x => x.SalesOrderId.Equals(salesOrderId));

                if (salesOrder != null)
                {
                    var lines = _context.SalesOrderLine.GetAll(x => x.SalesOrderId.Equals(salesOrderId));

                    //update master data by its lines
                    salesOrder.Amount = lines.Sum(x => x.Amount);
                    salesOrder.SubTotal = lines.Sum(x => x.SubTotal);

                    salesOrder.Discount = lines.Sum(x => x.DiscountAmount);
                    salesOrder.Tax = lines.Sum(x => x.TaxAmount);

                    salesOrder.Total = salesOrder.Freight + lines.Sum(x => x.Total);

                    _context.SalesOrder.Update(salesOrder);

                    _context.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<SalesOrder> payload)
        {
            var salesOrder = payload.value;
            salesOrder.SalesOrderName = _numberSequence.GetNumberSequence("SO");
            _context.SalesOrder.Add(salesOrder);
            _context.Save();
            this.UpdateSalesOrder(salesOrder.SalesOrderId);
            return Ok(salesOrder);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<SalesOrder> payload)
        {
            var salesOrder = payload.value;
            _context.SalesOrder.Update(salesOrder);
            _context.Save();
            return Ok(salesOrder);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<SalesOrder> payload)
        {
            var salesOrder = _context.SalesOrder
                .Get(x => x.SalesOrderId == (int)payload.key);
            _context.SalesOrder.Remove(salesOrder);
            _context.Save();
            return Ok(salesOrder);

        }
    }
}