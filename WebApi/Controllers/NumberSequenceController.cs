using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/NumberSequence")]
    public class NumberSequenceController : Controller
    {
        private readonly IUnitOfWork _context;

        public NumberSequenceController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/NumberSequence
        [HttpGet]
        public IActionResult GetNumberSequence()
        {
            var Items = _context.NumberSequence.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        // PUT: api/NumberSequence/5
        [HttpPut]
        public IActionResult PutNumberSequence([FromBody] NumberSequence numberSequence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NumberSequence.Update(numberSequence);

            _context.Save();

            return Ok();
        }

        // POST: api/NumberSequence
        [HttpPost]
        public IActionResult PostNumberSequence([FromBody] NumberSequence numberSequence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NumberSequence.Add(numberSequence);
            _context.Save();

            return Ok(numberSequence);
        }

        // DELETE: api/NumberSequence/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNumberSequence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberSequence = _context.NumberSequence.Get(m => m.NumberSequenceId == id);
            if (numberSequence == null)
            {
                return NotFound();
            }

            _context.NumberSequence.Remove(numberSequence);
            _context.Save();

            return Ok(numberSequence);
        }

        [HttpGet("{id}")]
        private bool NumberSequenceExists(int id)
        {
            return _context.NumberSequence.Exists(id);
        }
    }
}