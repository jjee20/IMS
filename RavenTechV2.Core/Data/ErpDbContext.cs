using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RavenTechV2.Core.Data.Seeders;
using RavenTechV2.Core.Models.Accounting;
using RavenTechV2.Core.Models.AuditTrail;
using RavenTechV2.Core.Models.Banking;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.MasterData;
using RavenTechV2.Core.Models.Payroll;
using RavenTechV2.Core.Models.Projects;
using RavenTechV2.Core.Models.Purchasing;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.UserManagement;

public class ErpDbContext : IdentityDbContext<User, Role, string>
{

    public ErpDbContext()
    {
    }

    public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_raventech;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        options.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    // Accounting/Finance
    public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
    public DbSet<LedgerEntry> LedgerEntries { get; set; }
    public DbSet<Budget> Budgets { get; set; }

    // Sales
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<SalesPayment> SalesPayments { get; set; }

    // Purchasing
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<PurchasePayment> PurchasePayments { get; set; }

    // Inventory
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    // Banking
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankTransaction> BankTransactions { get; set; }
    public DbSet<BankReconciliation> BankReconciliations { get; set; }

    // Payroll
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Allowance> Allowances { get; set; }
    public DbSet<Deduction> Deductions { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<PayrollRun> PayrollRuns { get; set; }
    public DbSet<Payslip> Payslips { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<JobPosition> JobPositions { get; set; }
    public DbSet<Shift> Shifts { get; set; }

    // Projects
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectResource> ProjectResources { get; set; }
    public DbSet<ProjectExpense> ProjectExpenses { get; set; }
    public DbSet<Branch> Branches { get; set; }

    // Workflow/Status
    public DbSet<WorkflowState> WorkflowStates { get; set; }
    public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }

    // Audit Trail & Notifications
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    // Permissions (if not using IdentityRole claims)
    //public DbSet<Permission> Permissions { get; set; }
    //public DbSet<RolePermission> RolePermissions { get; set; }

    // Fluent API & Model Configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // VERY IMPORTANT for Identity

        // Configure Identity User and Role
        IdentitySeeder.SeedUsersAndRoles(modelBuilder);

        // Add your additional model configuration here
        // E.g., configure unique indices, property lengths, decimal precision, etc.
    }
}

