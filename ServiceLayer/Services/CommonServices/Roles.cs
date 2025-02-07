using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Services.CommonServices
{
    public class Roles : IRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Roles(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task GenerateRolesFromPagesAsync()
        {
            //Type t = typeof(MainMenu);
            //foreach (Type item in t.GetNestedTypes())
            //{
            //    foreach (var itm in item.GetFields())
            //    {
            //        if (itm.Name.Contains("RoleName"))
            //        {
            //            string roleName = (string)itm.GetValue(item);
            //            if (!_roleManager.RoleExistsAsync(roleName))
            //                _roleManager.CreateAsync(new IdentityRole(roleName));
            //        }
            //    }
            //}
        }

        public async Task AddToRoles(string applicationUserId)
        {
            //var user = _userManager.FindByIdAsync(applicationUserId);
            //if (user != null)
            //{
            //    var roles = _roleManager.Roles;
            //    List<string> listRoles = new List<string>();
            //    foreach (var item in roles)
            //    {
            //        listRoles.Add(item.Name);
            //    }
            //    _userManager.AddToRolesAsync(user, listRoles);
            //}
        }
    }
}
