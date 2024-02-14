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
    [Route("api/PurchaseOrder")]
    public class PurchaseOrderController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public PurchaseOrderController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/PurchaseOrder
        [HttpGet]
        public IActionResult GetPurchaseOrder()
        {
            var Items = _context.PurchaseOrder.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult GetNotReceivedYet()
        {
            try
            {
                var grns = _context.GoodsReceivedNote.GetAll(x => x.PurchaseOrderId !=null);
                
                var purchaseOrders = _context.PurchaseOrder
                    .GetAll(x => x.PurchaseOrderId.Equals(grns))
                    .ToList();
                return Ok(purchaseOrders);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _context.PurchaseOrder
                .Get(x => x.PurchaseOrderId.Equals(id), includeProperties: "PurchaseOrderLines");

            return Ok(result);
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
        public IActionResult Insert([FromBody]CrudViewModel<PurchaseOrder> payload)
        {
            PurchaseOrder purchaseOrder = payload.value;
            purchaseOrder.PurchaseOrderName = _numberSequence.GetNumberSequence("PO");
            _context.PurchaseOrder.Add(purchaseOrder);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<PurchaseOrder> payload)
        {
            PurchaseOrder purchaseOrder = payload.value;
            _context.PurchaseOrder.Update(purchaseOrder);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<PurchaseOrder> payload)
        {
            var purchaseOrder = _context.PurchaseOrder.Get(x => x.PurchaseOrderId == (int)payload.key);

            _context.PurchaseOrder.Remove(purchaseOrder);
            _context.Save();
            UpdatePurchaseOrder(purchaseOrder.PurchaseOrderId);
            return Ok(purchaseOrder);

        }
    }
}