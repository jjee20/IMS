using DomainLayer.Models.Accounting;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using DomainLayer.ViewModels.Inventory;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using RavenTech_ThinkEE;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace InfastructureLayer.DataAccess.Data
{
    public class ApplicationDataContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDataContext() { }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Fetch the corresponding connection string
            string environment = ConfigurationManager.AppSettings["Environment"];

            // Fetch the corresponding connection string
            string connectionString = ConfigurationManager.ConnectionStrings[environment]?.ConnectionString;

            var connection = new SqlConnection(connectionString);
            optionsBuilder.UseSqlServer(connection);
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_sercs;Integrated Security=True;TrustServerCertificate=True;");
            optionsBuilder.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AppDbSeed.SeedRole(builder);
            AppDbSeed.SeedUserRoles(builder);
            AppDbSeed.SeedUsers(builder);
            AppDbSeed.SeedHolidays(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        #region ThinkEE
        public DbSet<ReviewTopic> ReviewTopics { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ExamFormat> ExamFormats { get; set; }
        public DbSet<PerformanceReport> PerformanceReports { get; set; }
        #endregion

        #region Accounts
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        #endregion

        #region Inventory
        public DbSet<TargetGoals> TargetGoals { get; set; }
        public DbSet<Bill> Bill { get; set; }

        public DbSet<BillType> BillType { get; set; }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<CashBank> CashBank { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CustomerType> CustomerType { get; set; }

        public DbSet<GoodsReceivedNote> GoodsReceivedNote { get; set; }

        public DbSet<DomainLayer.Models.Inventory.Invoice> Invoice { get; set; }

        public DbSet<InvoiceType> InvoiceType { get; set; }

        public DbSet<NumberSequence> NumberSequence { get; set; }

        public DbSet<PaymentReceive> PaymentReceive { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<PaymentVoucher> PaymentVoucher { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStockInLogs> ProductStockInLogs { get; set; }
        public DbSet<ProductStockInLogLines> ProductStockInLogLines { get; set; }
        public DbSet<ProductPullOutLogs> ProductPullOutLogs { get; set; }
        public DbSet<ProductPullOutLogLines> ProductPullOutLogLines { get; set; }

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
        #endregion

        #region Accounting
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<Budget> Budget { get; set; }
        //public DbSet<FinancialSummary> FinancialSummaries { get; set; }
        //public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        //public DbSet<DomainLayer.Models.Accounting.Invoice> Invoices { get; set; }
        //public DbSet<Account> AccountingAccounts { get; set; }
        //public DbSet<LedgerEntry> LedgerEntries { get; set; }
        #region Payroll
        public DbSet<ThirteenthMonth> ThirteenthMonths { get; set; }
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
        public DbSet<ProjectLine> ProjectLines { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<DomainLayer.Models.Accounting.Payroll.EmployeeContribution> EmployeeContributions { get; set; }
        #endregion
        #endregion
    }
}
