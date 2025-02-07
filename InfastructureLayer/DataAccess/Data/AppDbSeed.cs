using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.CommonServices;

namespace InfastructureLayer.DataAccess.Data
{
    public class AppDbSeed
    {
        //Role Ids
        private static string SuperAdminRoleId = Guid.NewGuid().ToString();
        private static string InventoryRoleId = Guid.NewGuid().ToString();
        private static string PayrollRoleId = Guid.NewGuid().ToString();

		//User Ids
		private static string SuperAdminId = Guid.NewGuid().ToString();
        private static string InventoryId = Guid.NewGuid().ToString();
        private static string PayrollId = Guid.NewGuid().ToString();

        public static void SeedRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = SuperAdminRoleId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = null },
                    new IdentityRole { Id = InventoryRoleId, Name = "Inventory", NormalizedName = "INVENTORY", ConcurrencyStamp = null },
                    new IdentityRole { Id = PayrollRoleId, Name = "Payroll", NormalizedName = "PAYROLL", ConcurrencyStamp = null }
            );
        }

        public static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = SuperAdminId, RoleId = SuperAdminRoleId },
                new IdentityUserRole<string> { UserId = InventoryId, RoleId = InventoryRoleId },
                new IdentityUserRole<string> { UserId = PayrollId, RoleId = PayrollRoleId }
            );
        }
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var superadmin = new ApplicationUser
            {
                Id = SuperAdminId,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Department = Departments.Admin,
                Email = "super@admin.com",
                NormalizedEmail = "SUPER@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
            };
            superadmin.PasswordHash = hasher.HashPassword(superadmin, "pass@123");
            modelBuilder.Entity<ApplicationUser>().HasData(superadmin);


            var inventory = new ApplicationUser
            {
                Id = InventoryId,
                UserName = "inventory",
                NormalizedUserName = "inventory",
                Department = Departments.Inventory,
                Email = "inventory@user.com",
                NormalizedEmail = "INVENTORY@USER.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
            };
            inventory.PasswordHash = hasher.HashPassword(inventory, "pass@123");
            modelBuilder.Entity<ApplicationUser>().HasData(inventory);


            var payroll = new ApplicationUser
            {
                Id = PayrollId,
                UserName = "payroll",
                NormalizedUserName = "payroll",
                Department = Departments.Payroll,
                Email = "payroll@user.com",
                NormalizedEmail = "PAYROLL@USER.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
            };
            payroll.PasswordHash = hasher.HashPassword(payroll, "pass@123");
            modelBuilder.Entity<ApplicationUser>().HasData(payroll);
        }
    }
}
