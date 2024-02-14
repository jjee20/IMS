using DomainLayer.Models;
using DomainLayer.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfastructureLayer.Repositories;
using DomainLayer.ViewModels.ManageViewModels;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        //private readonly ApplicationUserRepository _applicationUserRepository;

        public AccountController()
        {
        }
        //public AccountController(ApplicationUserRepository applicationUserRepository)
        //{
        //    _applicationUserRepository = applicationUserRepository;
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _applicationUserRepository.Login(model.Email, model.Password, model.RememberMe);
        //    if (user == null)
        //    {
        //        return BadRequest(new { error = "Invalid login attempt." });
        //    }

        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _applicationUserRepository.Logout();
        //    return Ok(new { message = "User logged out successfully." });
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    var users = await _applicationUserRepository.GetAll();
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(string id)
        //{
        //    var user = await _applicationUserRepository.GetById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var success = await _applicationUserRepository.ChangePassword(userId, model.OldPassword, model.NewPassword);
        //    if (!success)
        //    {
        //        return BadRequest(new { error = "Failed to change password." });
        //    }
        //    return Ok(new { message = "Password changed successfully." });
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //    var result = await _applicationUserRepository.Add(user, model.Password);
        //    if (result == null)
        //    {
        //        return BadRequest(new { error = "Failed to create user." });
        //    }
        //    return Ok(result);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
        //{
        //    var success = await _applicationUserRepository.Update(user);
        //    if (!success)
        //    {
        //        return BadRequest(new { error = "Failed to update user." });
        //    }
        //    return Ok(user);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(string id)
        //{
        //    var success = await _applicationUserRepository.Delete(id);
        //    if (!success)
        //    {
        //        return BadRequest(new { error = "Failed to delete user." });
        //    }
        //    return Ok(new { message = "User deleted successfully." });
        //}
    }
}
