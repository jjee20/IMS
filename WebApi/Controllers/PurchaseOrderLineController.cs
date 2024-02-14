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
    [Route("api/PurchaseOrderLine")]
    public class PurchaseOrderLineController : Controller
    {
        private readonly IUnitOfWork _context;

        public PurchaseOrderLineController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderLine
        [HttpGet]
        public IActionResult GetPurchaseOrderLine()
        {
            var headers = Request.Headers["PurchaseOrderId"];
            int purchaseOrderId = Convert.ToInt32(headers);
            var Items = _context.PurchaseOrderLine
                .GetAll(x => x.PurchaseOrderId.Equals(purchaseOrderId));
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        private PurchaseOrderLine Recalculate(PurchaseOrderLine purchaseOrderLine)
        {
            try
            {
                purchaseOrderLine.Amount = purchaseOrderLine.Quantity * purchaseOrderLine.Price;
                purchaseOrderLine.DiscountAmount = (purchaseOrderLine.DiscountPercentage * purchaseOrderLine.Amount) / 100.0;
                purchaseOrderLine.SubTotal = purchaseOrderLine.Amount - purchaseOrderLine.DiscountAmount;
                purchaseOrderLine.TaxAmount = (purchaseOrderLine.TaxPercentage * purchaseOrderLine.SubTotal) / 100.0;
                purchaseOrderLine.Total = purchaseOrderLine.SubTotal + purchaseOrderLine.TaxAmount;

            }
            catch (Exception)
            {

                throw;
            }

            return purchaseOrderLine;
        }

        private void UpdatePurchaseOrder(int purchaseOrderId)
        {
            try
            {
                var purchaseOrder = _context.PurchaseOrder
                    .Get(x => x.PurchaseOrderId.Equals(purchaseOrderId));

                if (purchaseOrder != null)
                {
                    var lines = _context.PurchaseOrderLine.GetAll(x => x.PurchaseOrderId.Equals(purchaseOrderId));

                    //update master data by its lines
                    purchaseOrder.Amount = lines.Sum(x => x.Amount);
                    purchaseOrder.SubTotal = lines.Sum(x => x.SubTotal);
                    
                    purchaseOrder.Discount = lines.Sum(x => x.DiscountAmount);
                    purchaseOrder.Tax = lines.Sum(x => x.TaxAmount);

                    purchaseOrder.Total = purchaseOrder.Freight + lines.Sum(x => x.Total);

                    _context.PurchaseOrder.Update(purchaseOrder);

                    _context.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            PurchaseOrderLine purchaseOrderLine = payload.value;
            purchaseOrderLine = this.Recalculate(purchaseOrderLine);
            _context.PurchaseOrderLine.Add(purchaseOrderLine);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            PurchaseOrderLine purchaseOrderLine = payload.value;
            purchaseOrderLine = this.Recalculate(purchaseOrderLine);
            _context.PurchaseOrderLine.Update(purchaseOrderLine);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PurchaseOrderLine> payload)
        {
            var purchaseOrderLine = _context.PurchaseOrderLine
                .Get(x => x.PurchaseOrderLineId == (int)payload.key);
            _context.PurchaseOrderLine.Remove(purchaseOrderLine);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrderLine.PurchaseOrderId);
            return Ok(purchaseOrderLine);

        }
    }
}