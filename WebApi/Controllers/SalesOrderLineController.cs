using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using static ServiceLayer.Services.CommonServices.MainMenu;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/SalesOrderLine")]
    public class SalesOrderLineController : Controller
    {
        private readonly IUnitOfWork _context;

        public SalesOrderLineController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/SalesOrderLine
        [HttpGet]
        public IActionResult GetSalesOrderLine()
        {
            var headers = Request.Headers["SalesOrderId"];
            int salesOrderId = Convert.ToInt32(headers);
            var Items = _context.SalesOrderLine
                .GetAll(x => x.SalesOrderId.Equals(salesOrderId));
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult GetSalesOrderLineByShipmentId()
        {
            var headers = Request.Headers["ShipmentId"];
            int shipmentId = Convert.ToInt32(headers);
            var shipment = _context.Shipment.Get(x => x.ShipmentId.Equals(shipmentId));
            var Items = _context.SalesOrderLine
                     .GetAll(x => x.SalesOrderId.Equals(shipment.SalesOrderId));
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult GetSalesOrderLineByInvoiceId()
        {
            var headers = Request.Headers["InvoiceId"];
            int invoiceId = Convert.ToInt32(headers);
            var invoice = _context.Invoice.Get(x => x.InvoiceId.Equals(invoiceId));
            var shipment = _context.Shipment.Get(x => x.ShipmentId.Equals(invoice.ShipmentId));
            var Items = _context.SalesOrderLine
                .GetAll(x => x.SalesOrderId.Equals(shipment.SalesOrderId));

            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        private SalesOrderLine Recalculate(SalesOrderLine salesOrderLine)
        {
            try
            {
                salesOrderLine.Amount = salesOrderLine.Quantity * salesOrderLine.Price;
                salesOrderLine.DiscountAmount = (salesOrderLine.DiscountPercentage * salesOrderLine.Amount) / 100.0;
                salesOrderLine.SubTotal = salesOrderLine.Amount - salesOrderLine.DiscountAmount;
                salesOrderLine.TaxAmount = (salesOrderLine.TaxPercentage * salesOrderLine.SubTotal) / 100.0;
                salesOrderLine.Total = salesOrderLine.SubTotal + salesOrderLine.TaxAmount;

            }
            catch (Exception)
            {

                throw;
            }

            return salesOrderLine;
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
        public IActionResult Insert([FromBody]CrudViewModel<SalesOrderLine> payload)
        {
            SalesOrderLine salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.SalesOrderLine.Add(salesOrderLine);
            _context.Save();
            UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<SalesOrderLine> payload)
        {
            SalesOrderLine salesOrderLine = payload.value;
            salesOrderLine = this.Recalculate(salesOrderLine);
            _context.SalesOrderLine.Update(salesOrderLine);
            _context.Save();
            UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<SalesOrderLine> payload)
        {
            SalesOrderLine salesOrderLine = _context.SalesOrderLine
                .Get(x => x.SalesOrderLineId == (int)payload.key);
            _context.SalesOrderLine.Remove(salesOrderLine);
            _context.Save();
            UpdateSalesOrder(salesOrderLine.SalesOrderId);
            return Ok(salesOrderLine);

        }
    }
}