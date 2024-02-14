using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Services.IRepositories;
using DomainLayer.ViewModels.SyncfusionViewModels;

namespace WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        //private readonly IUnitOfWork _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public UserController()
        {
        }
        //public UserController(IUnitOfWork context, UserManager<ApplicationUser> userManager,
        //                RoleManager<IdentityRole> roleManager)
        //{
        //    _context = context;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}

        // GET: api/User
        //[HttpGet]
        //public IActionResult GetUser()
        //{
        //    var Items = _context.UserProfile.GetAll();
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetByApplicationUserId([FromRoute]string id)
        //{
        //    var userProfile = _context.UserProfile.GetAll(x => x.ApplicationUserId.Equals(id));
        //    int Count = userProfile.Count();
        //    return Ok(new { userProfile, Count });
        //}

        //[HttpPost]
        //public IActionResult Insert([FromBody]CrudViewModel<UserProfile> payload)
        //{
        //    UserProfile register = payload.value;
        //    if (register.Password.Equals(register.ConfirmPassword))
        //    {
        //        var user = new ApplicationUser() { Email = register.Email, UserName = register.Email, EmailConfirmed = true };
        //        var result = _userManager.CreateAsync(user, register.Password);
        //        if (result.IsCompletedSuccessfully)
        //        {
        //            register.Password = user.PasswordHash;
        //            register.ConfirmPassword = user.PasswordHash;
        //            register.ApplicationUserId = user.Id;
        //            _context.UserProfile.Add(register);
        //            _context.Save();
        //        }
                
        //    }
        //    return Ok(register);
        //}

        //[HttpPost]
        //public IActionResult Update([FromBody]CrudViewModel<UserProfile> payload)
        //{
        //    var profile = payload.value;
        //    _context.UserProfile.Update(profile);
        //    _context.Save();
        //    return Ok(profile);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword([FromBody]CrudViewModel<UserProfile> payload)
        //{
        //    UserProfile profile = payload.value;
        //    if (profile.Password.Equals(profile.ConfirmPassword))
        //    {
        //        var user = await _userManager.FindByIdAsync(profile.ApplicationUserId);
        //        var result = await _userManager.ChangePasswordAsync(user, profile.OldPassword, profile.Password);
        //    }
        //    profile = _context.UserProfile.Get(x => x.ApplicationUserId.Equals(profile.ApplicationUserId));
        //    return Ok(profile);
        //}
        
        //[HttpPost]
        //public IActionResult ChangeRole([FromBody]CrudViewModel<UserProfile> payload)
        //{
        //    UserProfile profile = payload.value;
        //    return Ok(profile);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Remove([FromBody]CrudViewModel<UserProfile> payload)
        //{
        //    UserProfile userProfile = _context.UserProfile.Get(x => x.UserProfileId.Equals((int)payload.key));
        //    if (userProfile != null)
        //    {
        //        var user = _context.ApplicationUser.GetById(userProfile.ApplicationUserId);
        //        var result = await _userManager.DeleteAsync(user.Result);
        //        if (result.Succeeded)
        //        {
        //            _context.ApplicationUser.Delete(userProfile.UserProfileId.ToString());
        //            _context.Save();
        //        }
                
        //    }
            
        //    return Ok();

        //}
        
        
    }
}