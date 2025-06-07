using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.CommonServices;

namespace InfastructureLayer.DataAccess.Data
{
    public class AppDbSeed
    {
        //Role Ids
        private static string SuperAdminRoleId = "EAA7F29D - DF72 - 44EB - 84B2 - 7ACCE813336A";
        private static string InventoryRoleId = "C2C4EE84-DA3F-46ED-B55C-EDFE9D4C227E";
        private static string PayrollRoleId = "A55B2EC0-5D09-4509-9844-8F474BB85C5D";

		//User Ids
		private static string SuperAdminId = "587A4D5B-33EB-469C-ADE6-EC9F95C651AD";
        private static string InventoryId = "FB38CC93-2B1E-4444-9A48-396E4C28E190";
        private static string PayrollId = "6628DE62-AF21-4389-B612-623A1A17637C";

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

        public static void SeedHolidays(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>().HasData(
                new Holiday { HolidayId = 1, HolidayName = "New Year's Day", EffectiveDate = new DateTime(2025, 1, 1), HolidayType = HolidayType.RegularHoliday, Description = "Start of the New Year" },
                new Holiday { HolidayId = 2, HolidayName = "Maundy Thursday", EffectiveDate = new DateTime(2025, 4, 17), HolidayType = HolidayType.RegularHoliday, Description = "Holy Week" },
                new Holiday { HolidayId = 3, HolidayName = "Good Friday", EffectiveDate = new DateTime(2025, 4, 18), HolidayType = HolidayType.RegularHoliday, Description = "Holy Week" },
                new Holiday { HolidayId = 4, HolidayName = "Araw ng Kagitingan", EffectiveDate = new DateTime(2025, 4, 9), HolidayType = HolidayType.RegularHoliday, Description = "Day of Valor" },
                new Holiday { HolidayId = 5, HolidayName = "Labor Day", EffectiveDate = new DateTime(2025, 5, 1), HolidayType = HolidayType.RegularHoliday, Description = "Workers' holiday" },
                new Holiday { HolidayId = 6, HolidayName = "Independence Day", EffectiveDate = new DateTime(2025, 6, 12), HolidayType = HolidayType.RegularHoliday, Description = "Philippine independence" },
                new Holiday { HolidayId = 7, HolidayName = "National Heroes Day", EffectiveDate = new DateTime(2025, 8, 25), HolidayType = HolidayType.RegularHoliday, Description = "Last Monday of August" },
                new Holiday { HolidayId = 8, HolidayName = "Bonifacio Day", EffectiveDate = new DateTime(2025, 11, 30), HolidayType = HolidayType.RegularHoliday, Description = "Birth of Andres Bonifacio" },
                new Holiday { HolidayId = 9, HolidayName = "Christmas Day", EffectiveDate = new DateTime(2025, 12, 25), HolidayType = HolidayType.RegularHoliday, Description = "Christmas celebration" },
                new Holiday { HolidayId = 10, HolidayName = "Rizal Day", EffectiveDate = new DateTime(2025, 12, 30), HolidayType = HolidayType.RegularHoliday, Description = "Jose Rizal's death anniversary" },

                new Holiday { HolidayId = 11, HolidayName = "Chinese New Year", EffectiveDate = new DateTime(2025, 1, 29), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "Chinese lunar new year" },
                new Holiday { HolidayId = 12, HolidayName = "EDSA People Power Revolution", EffectiveDate = new DateTime(2025, 2, 25), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "1986 EDSA revolution anniversary" },
                new Holiday { HolidayId = 13, HolidayName = "Black Saturday", EffectiveDate = new DateTime(2025, 4, 19), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "Holy Week" },
                new Holiday { HolidayId = 14, HolidayName = "Ninoy Aquino Day", EffectiveDate = new DateTime(2025, 8, 21), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "In honor of Ninoy Aquino" },
                new Holiday { HolidayId = 15, HolidayName = "All Saints’ Day", EffectiveDate = new DateTime(2025, 11, 1), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "Remembrance of saints" },
                new Holiday { HolidayId = 16, HolidayName = "All Souls’ Day", EffectiveDate = new DateTime(2025, 11, 2), HolidayType = HolidayType.SpecialWorkingHoliday, Description = "Remembrance of departed" },
                new Holiday { HolidayId = 17, HolidayName = "Feast of the Immaculate Conception", EffectiveDate = new DateTime(2025, 12, 8), HolidayType = HolidayType.SpecialNonWorkingHoliday, Description = "Catholic feast" },
                new Holiday { HolidayId = 18, HolidayName = "Christmas Eve", EffectiveDate = new DateTime(2025, 12, 24), HolidayType = HolidayType.SpecialWorkingHoliday, Description = "Night before Christmas" },
                new Holiday { HolidayId = 19, HolidayName = "New Year's Eve", EffectiveDate = new DateTime(2025, 12, 31), HolidayType = HolidayType.SpecialWorkingHoliday, Description = "End of year celebration" }
            );
        }
    }
}
