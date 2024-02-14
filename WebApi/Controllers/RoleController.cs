using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;
using DomainLayer.ViewModels.AccountViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
       // private readonly IUnitOfWork _context;

        public RoleController()
        {
        }
        //public RoleController(IUnitOfWork context)
        //{
        //    _context = context;
        //}

        // GET: api/Role
        //[HttpGet]
        //public IActionResult GetRole()
        //{
        //    var Items = _context.Roles.GetRole();
        //    return Ok(new { Items });
        //}

        //// GET: api/Role
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRoleByApplicationUserId([FromRoute]string id)
        //{
        //    var user = await _context.Roles.GetUserRolesAsync(id);
   
        //    int Count = user.Count();
        //    return Ok(new { user, Count });
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateUserRole([FromBody]CrudViewModel<UserRoleViewModel> payload)
        //{
        //    var user = await _context.Roles.UpdateUserRoleAsync(payload.value);
        //    return Ok(user);
        //}
    }
}