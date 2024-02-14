using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;
using DomainLayer.ViewModels.ManageViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ChangePassword")]
    public class ChangePasswordController : Controller
    {
       // private readonly IUnitOfWork _context;

        public ChangePasswordController()
        {
        }
        //public ChangePasswordController(IUnitOfWork context)
        //{
        //    _context = context;
        //}

        //// GET: api/ChangePassword
        //[HttpGet]
        //public async Task<IActionResult> GetChangePassword()
        //{
        //    var Items = await _context.ApplicationUser.GetAll();
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Update([FromBody]CrudViewModel<ChangePasswordViewModel> payload)
        //{
        //    ChangePasswordViewModel changePasswordViewModel = payload.value;
        //    var user = _context.ApplicationUser.GetById(changePasswordViewModel.Id);

        //    if (user != null &&
        //        changePasswordViewModel.NewPassword.Equals(changePasswordViewModel.ConfirmPassword))
        //    {
        //        await _context.ApplicationUser.ChangePassword(user.Id.ToString(), changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
        //    }

        //    return Ok();
        //}
        
    }
}