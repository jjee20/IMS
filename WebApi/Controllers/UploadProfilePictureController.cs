using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.CommonServices;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/UploadProfilePicture")]
    [Authorize]
    public class UploadProfilePictureController : Controller
    {
        //private readonly IFunctional _functionalService;
        //private readonly IHostingEnvironment _env; // Use Microsoft.AspNetCore.Hosting.IHostingEnvironment
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IUnitOfWork _context;

        //public UploadProfilePictureController(IFunctional functionalService,
        //    IHostingEnvironment env, // Specify the full namespace
        //    UserManager<ApplicationUser> userManager,
        //    IUnitOfWork context)
        //{
        //    _functionalService = functionalService;
        //    _env = env;
        //    _userManager = userManager;
        //    _context = context;
        //}

        //[HttpPost]
        //[RequestSizeLimit(5000000)]
        //public async Task<IActionResult> PostUploadProfilePicture(List<IFormFile> UploadDefault)
        //{
        //    try
        //    {
        //        var folderUpload = "upload";
        //        var fileName = await _functionalService.UploadFile(UploadDefault, _env, folderUpload);

        //        ApplicationUser appUser = await _userManager.GetUserAsync(User);
        //        if (appUser != null)
        //        {
        //            UserProfile profile = _context.UserProfile.SingleOrDefault(x => x.ApplicationUserId.Equals(appUser.Id));
        //            if (profile != null)
        //            {
        //                profile.ProfilePicture = "/" + folderUpload + "/" + fileName;
        //                _context.UserProfile.Update(profile);
        //                await _context.SaveChangesAsync();
        //            }
        //        }
        //        return Ok(fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}
    }
}
