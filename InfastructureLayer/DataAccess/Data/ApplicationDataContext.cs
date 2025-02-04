using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace InfastructureLayer.DataAccess.Data
{
    public class ApplicationDataContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string environment = ConfigurationManager.AppSettings["Environment"];

            //// Fetch the corresponding connection string
            //string connectionString = ConfigurationManager.ConnectionStrings[environment]?.ConnectionString;

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new Exception($"Connection string for environment '{environment}' not found.");
            //}
            //var connection = new SqlConnection(connectionString);
            //optionsBuilder.UseSqlServer(connection);
            optionsBuilder.UseSqlServer("");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AppDbSeed.SeedRole(builder);
            AppDbSeed.SeedUserRoles(builder);
            AppDbSeed.SeedUsers(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        //Inventory
        public DbSet<Bill> Bill { get; set; }

        public DbSet<BillType> BillType { get; set; }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<CashBank> CashBank { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CustomerType> CustomerType { get; set; }

        public DbSet<GoodsReceivedNote> GoodsReceivedNote { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<InvoiceType> InvoiceType { get; set; }

        public DbSet<NumberSequence> NumberSequence { get; set; }

        public DbSet<PaymentReceive> PaymentReceive { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<PaymentVoucher> PaymentVoucher { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<PurchaseType> PurchaseType { get; set; }

        public DbSet<SalesOrder> SalesOrder { get; set; }

        public DbSet<SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<SalesType> SalesType { get; set; }

        public DbSet<Shipment> Shipment { get; set; }

        public DbSet<ShipmentType> ShipmentType { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }

        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<VendorType> VendorType { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }

        //Payroll
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }

    }
}
