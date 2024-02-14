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
    [Route("api/Branch")]
    public class BranchController : Controller
    {
        private readonly IUnitOfWork _context;

        public BranchController(IUnitOfWork context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult GetBranch()
        {
            var Items = _context.Branch.GetAll();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost]
        public IActionResult Insert([FromBody]CrudViewModel<Branch> payload)
        {
            Branch branch = payload.value;
            _context.Branch.Add(branch);
            _context.Save();
            return Ok(branch);
        }

        [HttpPost]
        public IActionResult Update([FromBody]CrudViewModel<Branch> payload)
        {
            Branch branch = payload.value;
            _context.Branch.Update(branch);
            _context.Save();
            return Ok(branch);
        }

        [HttpPost]
        public IActionResult Remove([FromBody]CrudViewModel<Branch> payload)
        {
            var branch = _context.Branch.Get(x => x.BranchId == (int)payload.key);
            _context.Branch.Remove(branch);
            _context.Save();
            return Ok(branch);

        }
        
    }
}