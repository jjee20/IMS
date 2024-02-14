using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/BillType")]
    public class BillTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public BillTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/BillType
        [HttpGet]
        public IActionResult GetBillType()
        {
            var Items = _context.BillType.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<BillType> payload)
        {
            BillType billType = payload.value;
            _context.BillType.Add(billType);
            _context.Save();
            return Ok(billType);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<BillType> payload)
        {
            BillType billType = payload.value;
            _context.BillType.Update(billType);
            _context.Save();
            return Ok(billType);
        }

        [HttpPost]
        public IActionResult Remove([FromBody] CrudViewModel<BillType> payload)
        {
            try
            {
                var billtype = _context.BillType.Get(x => x.BillTypeId == (int)payload.key);

                if (billtype != null)
                {
                    _context.BillType.Remove(billtype);
                    _context.Save();
                    return Ok(billtype);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}