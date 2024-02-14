using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.CommonServices;
using System.Linq;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/GoodsReceivedNote")]
    public class GoodsReceivedNoteController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IGenerateNumberSequence _numberSequence;

        public GoodsReceivedNoteController(IUnitOfWork context,
                        IGenerateNumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }

        // GET: api/GoodsReceivedNote
        [HttpGet]
        public IActionResult GetGoodsReceivedNote()
        {
            var Items = _context.GoodsReceivedNote.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpGet]
        public IActionResult GetNotBilledYet()
        {
            try
            {
                var goodsReceivedNoteIds = _context.Bill.GetAll(v => v.GoodsReceivedNoteId != null);
                var goodsReceivedNotes = _context.GoodsReceivedNote
                    .GetAll(x => x.GoodsReceivedNoteId.Equals(goodsReceivedNoteIds));

                return Ok(goodsReceivedNotes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<GoodsReceivedNote> payload)
        {
            var goodsReceivedNote = payload.value;
            goodsReceivedNote.GoodsReceivedNoteName = _numberSequence.GetNumberSequence("GRN");
            _context.GoodsReceivedNote.Add(goodsReceivedNote);
            _context.Save();
            return Ok(goodsReceivedNote);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<GoodsReceivedNote> payload)
        {
            var goodsReceivedNote = payload.value;
            _context.GoodsReceivedNote.Update(goodsReceivedNote);
            _context.Save();
            return Ok(goodsReceivedNote);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<GoodsReceivedNote> payload)
        {
            var goodsReceivedNote = _context.GoodsReceivedNote.Get(x => x.GoodsReceivedNoteId == (int)payload.key);

            _context.GoodsReceivedNote.Remove(goodsReceivedNote);
            _context.Save();
            return Ok(goodsReceivedNote);

        }
    }
}