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
    [Route("api/UnitOfMeasure")]
    public class UnitOfMeasureController : Controller
    {
        private readonly IUnitOfWork _context;

        public UnitOfMeasureController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasure
        [HttpGet]
        public IActionResult GetUnitOfMeasure()
        {
            var Items = _context.UnitOfMeasure.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<UnitOfMeasure> payload)
        {
            var unitOfMeasure = payload.value;
            _context.UnitOfMeasure.Add(unitOfMeasure);
            _context.Save();
            return Ok(unitOfMeasure);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<UnitOfMeasure> payload)
        {
            var unitOfMeasure = payload.value;
            _context.UnitOfMeasure.Update(unitOfMeasure);
            _context.Save();
            return Ok(unitOfMeasure);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<UnitOfMeasure> payload)
        {
            var unitOfMeasure = _context.UnitOfMeasure
                .Get(x => x.UnitOfMeasureId == (int)payload.key);
            _context.UnitOfMeasure.Remove(unitOfMeasure);
            _context.Save();
            return Ok(unitOfMeasure);

        }
    }
}