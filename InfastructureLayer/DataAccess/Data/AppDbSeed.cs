using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.ThinkEE;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RavenTech_ThinkEE;
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

        public static void SeedExamFormat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewTopic>().HasData(
                new ReviewTopic { Id = 1, Code = "REE", Name = "Registered Electrical Engineer" },
                new ReviewTopic { Id = 2, Code = "RME", Name = "Registered Master Electrician" }
            );
            modelBuilder.Entity<ExamTopic>().HasData(
                //REE
                new ExamTopic { Id = 1, Name = "Algebra", Category = "Mathematics" },
                new ExamTopic { Id = 2, Name = "Trigonometry", Category = "Mathematics" },
                new ExamTopic { Id = 3, Name = "Differential and Integral Calculus", Category = "Mathematics" },
                new ExamTopic { Id = 4, Name = "Complex Numbers", Category = "Mathematics" },
                new ExamTopic { Id = 5, Name = "Probability and Statistics", Category = "Mathematics" },
                new ExamTopic { Id = 6, Name = "Differential Equations", Category = "Mathematics" },
                new ExamTopic { Id = 7, Name = "Laplace Transform and Fourier Series", Category = "Mathematics" },
                new ExamTopic { Id = 8, Name = "Matrix Algebra", Category = "Mathematics" },
                new ExamTopic { Id = 9, Name = "Numerical Methods", Category = "Mathematics" },

                new ExamTopic { Id = 10, Name = "Engineering Mechanics", Category = "Engineering Sciences" },
                new ExamTopic { Id = 11, Name = "Strength of Materials", Category = "Engineering Sciences" },
                new ExamTopic { Id = 12, Name = "Thermodynamics", Category = "Engineering Sciences" },
                new ExamTopic { Id = 13, Name = "Fluid Mechanics", Category = "Engineering Sciences" },
                new ExamTopic { Id = 14, Name = "Chemistry and Physics", Category = "Engineering Sciences" },
                new ExamTopic { Id = 15, Name = "Computer Fundamentals and Programming", Category = "Engineering Sciences" },

                new ExamTopic { Id = 16, Name = "DC and AC Circuits", Category = "Electrical Circuits and Devices" },
                new ExamTopic { Id = 17, Name = "Network Theorems", Category = "Electrical Circuits and Devices" },
                new ExamTopic { Id = 18, Name = "Resonance", Category = "Electrical Circuits and Devices" },
                new ExamTopic { Id = 19, Name = "Transformers", Category = "Electrical Circuits and Devices" },
                new ExamTopic { Id = 20, Name = "Motors and Generators", Category = "Electrical Circuits and Devices" },

                new ExamTopic { Id = 21, Name = "Semiconductor Devices", Category = "Electronics" },
                new ExamTopic { Id = 22, Name = "Amplifiers", Category = "Electronics" },
                new ExamTopic { Id = 23, Name = "Oscillators", Category = "Electronics" },
                new ExamTopic { Id = 24, Name = "Operational Amplifiers", Category = "Electronics" },
                new ExamTopic { Id = 25, Name = "Digital Electronics", Category = "Electronics" },
                new ExamTopic { Id = 26, Name = "Communication Basics", Category = "Electronics" },

                new ExamTopic { Id = 27, Name = "Power Generation", Category = "Power Systems" },
                new ExamTopic { Id = 28, Name = "Power Transmission and Distribution", Category = "Power Systems" },
                new ExamTopic { Id = 29, Name = "Load Flow and Short Circuit Analysis", Category = "Power Systems" },
                new ExamTopic { Id = 30, Name = "Protective Relays and Circuit Breakers", Category = "Power Systems" },
                new ExamTopic { Id = 31, Name = "Substation Design", Category = "Power Systems" },

                new ExamTopic { Id = 32, Name = "Synchronous Machines", Category = "Electrical Machines" },
                new ExamTopic { Id = 33, Name = "Induction Motors", Category = "Electrical Machines" },
                new ExamTopic { Id = 34, Name = "Transformers", Category = "Electrical Machines" },
                new ExamTopic { Id = 35, Name = "DC Machines", Category = "Electrical Machines" },
                new ExamTopic { Id = 36, Name = "Motor Control and Starting", Category = "Electrical Machines" },

                new ExamTopic { Id = 37, Name = "Feedback and Control Theory", Category = "Control Systems" },
                new ExamTopic { Id = 38, Name = "Block Diagrams", Category = "Control Systems" },
                new ExamTopic { Id = 39, Name = "Stability Analysis", Category = "Control Systems" },
                new ExamTopic { Id = 40, Name = "Bode Plots and Root Locus", Category = "Control Systems" },

                new ExamTopic { Id = 41, Name = "Electrical Measuring Instruments", Category = "Instrumentation and Measurement" },
                new ExamTopic { Id = 42, Name = "Transducers", Category = "Instrumentation and Measurement" },
                new ExamTopic { Id = 43, Name = "Calibration", Category = "Instrumentation and Measurement" },
                new ExamTopic { Id = 44, Name = "Instrument Errors", Category = "Instrumentation and Measurement" },

                //RME
                new ExamTopic { Id = 45, Name = "Ohm's Law and Power Law", Category = "Basic Electrical Engineering" },
                new ExamTopic { Id = 46, Name = "Wiring Design and Estimating", Category = "Electrical Design" },
                new ExamTopic { Id = 47, Name = "Philippine Electrical Code", Category = "Regulations" },
                new ExamTopic { Id = 48, Name = "Electrical Wiring Installation", Category = "Practical Applications" },
                new ExamTopic { Id = 49, Name = "Tools and Electrical Materials", Category = "Materials and Tools" },
                new ExamTopic { Id = 50, Name = "Safety Practices", Category = "Safety" },
                new ExamTopic { Id = 51, Name = "Electrical Test Equipment", Category = "Testing and Measurement" }
            );



            modelBuilder.Entity<ExamFormat>().HasData(
                new ExamFormat { Id = 1, Name = "Mock Board", Description = "Simulate full exam with time limit", DefaultDurationMinutes = 240 },
                new ExamFormat { Id = 2, Name = "Diagnostic Test", Description = "Identify strengths and weaknesses", DefaultDurationMinutes = 120 },
                new ExamFormat { Id = 3, Name = "Drill/Quiz", Description = "Short topic-based drills or quizzes", DefaultDurationMinutes = 60 },
                new ExamFormat { Id = 4, Name = "Weekly Time-Bound", Description = "Weekly time-constrained exams", DefaultDurationMinutes = 90 }
            );

            // Exam
            modelBuilder.Entity<Exam>().HasData(
                new Exam
                {
                    Id = 1,
                    Title = "Electrical Circuits Mock Exam",
                    Type = "Mock Board",
                    Date = new DateTime(2025, 6, 1),
                    ExamFormatId = 1
                }
            );

            // Questions
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "What is the unit of resistance?", Points = 1 },
                new Question { Id = 2, Text = "What law states that V = IR?", Points = 1 }
            );

            // Choices
            modelBuilder.Entity<Choice>().HasData(
                new Choice { Id = 1, Text = "Ohm", IsCorrect = true, QuestionId = 1 },
                new Choice { Id = 2, Text = "Volt", IsCorrect = false, QuestionId = 1 },
                new Choice { Id = 3, Text = "Watt", IsCorrect = false, QuestionId = 1 },
                new Choice { Id = 4, Text = "Ampere", IsCorrect = false, QuestionId = 1 },

                new Choice { Id = 5, Text = "Ohm's Law", IsCorrect = true, QuestionId = 2 },
                new Choice { Id = 6, Text = "Kirchhoff's Law", IsCorrect = false, QuestionId = 2 },
                new Choice { Id = 7, Text = "Faraday's Law", IsCorrect = false, QuestionId = 2 },
                new Choice { Id = 8, Text = "Coulomb's Law", IsCorrect = false, QuestionId = 2 }
            );
        }
    }
}
