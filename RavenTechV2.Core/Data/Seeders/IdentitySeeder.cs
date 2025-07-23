using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RavenTechV2.Core.Models.UserManagement;

namespace RavenTechV2.Core.Data.Seeders;
public static class IdentitySeeder
{
    private static readonly PasswordHasher<User> _passwordHasher = new();
    private static readonly string _adminRoleId = "F30E50F0-D08B-4A2F-90B5-EF67700894F7";
    private static readonly string _adminId = "81E9241B-309F-48AA-A9BF-980E8929834F";
    private static readonly string _managerRoleId = "2A538E36-48E9-4D95-B068-427B62104FFF";

    public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
        new Role
        {
            Id = _adminRoleId,  // must be string if using IdentityRole<string>
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new Role
        {
            Id = _managerRoleId,
            Name = "Manager",
            NormalizedName = "MANAGER"
        }
    );

        // Seed Users (with pre-hashed password)
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = _adminId, // must match key type
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FullName = "Administrator",
                Email = "admin@erp.com",
                NormalizedEmail = "ADMIN@ERP.COM",
                EmailConfirmed = true,
                PasswordHash = _passwordHasher.HashPassword(null, "pass@!23"),  // <<---
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            }
        );

        // Seed UserRoles (link user and role)
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = _adminId,
                RoleId = _adminRoleId
            }
        );
    }
}
