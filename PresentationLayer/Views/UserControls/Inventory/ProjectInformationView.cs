using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin.Controls;
using PresentationLayer;
using RavenTech_ERP.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Renderers;
using static Unity.Storage.RegistrationSet;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class ProjectInformationView: SfForm
    {
        private readonly Project? _project;
        private readonly ProjectViewModel _projectVM;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectInformationView(ProjectViewModel ProjectVM, IUnitOfWork unitOfWork, Project? Project = null)
        {
            InitializeComponent();
            _project = Project;
            _projectVM = ProjectVM;
            _unitOfWork = unitOfWork;

            LoadProjectInformation();
        }

        private void LoadProjectInformation()
        {
            double totalBudget = _projectVM.Budget;
            double targetRevenue = _projectVM.Revenue;

            var startDate = !string.IsNullOrEmpty(_projectVM.StartDate) ? _projectVM.StartDate : "{Needs Updating}";
            var endDate = !string.IsNullOrEmpty(_projectVM.EndDate) ? _projectVM.EndDate : "{Needs Updating}";
            txtProjectName.Text = _project.ProjectName ?? "{Needs Updating}";
            txtClient.Text = _projectVM.Client ?? "{Needs Updating}";
            txtRevenue.Text = targetRevenue.ToString("C2") ?? "{Needs Updating}";
            txtBudget.Text = totalBudget.ToString("C2") ?? "{Needs Updating}";
            txtStartDate.Text = startDate; 
            txtEndDate.Text = endDate;
            txtDescription.Text = _projectVM.Description ?? "{Needs Updating}";

            var projectLines = _project.ProjectLines
             .GroupBy(pl => pl.ProductId)
             .Select(group => {
                 var first = group.First(); // Representative line for shared product data

                 var totalQty = group.Sum(pl => pl.Quantity);
                 var totalAmount = group.Sum(pl => pl.Price * pl.Quantity);
                 var price = first.Price;

                 var actualQty = _project.ProductPullOutLogs
                     .SelectMany(log => log.ProductPullOutLogLines)
                     .Where(logLine => logLine.ProductId == first.ProductId)
                     .Sum(logLine => (double?)logLine.StockQuantity) ?? 0;

                 return new ProjectLineProductViewModel
                 {
                     Name = first.ProductName,
                     UOM = first.Product?.UnitOfMeasure?.UnitOfMeasureName ?? "N/A",
                     Category = first.Product?.ProductType?.ProductTypeName ?? "N/A",
                     Cost = price, // optional: could use weighted avg
                     Qty = Math.Round(totalQty,2),
                     Amount = Math.Round(totalAmount,2),
                     ActualQty = Math.Round(actualQty,2),
                     ActualAmount = Math.Round(actualQty * price,2)
                 };
             })
             .ToList();

            dgPager.DataSource = projectLines;
            dgProjectLines.DataSource = dgPager.PagedSource;

            var holidays = _unitOfWork.Holiday.Value.GetAll(c => c.EffectiveDate.Date >= DateTime.Parse(startDate).Date && c.EffectiveDate.Date <= DateTime.Parse(endDate).Date);
            var employees = _unitOfWork.Employee.Value.GetAll(c => c.Attendances.Any(c => c.ProjectId == _project.ProjectId) , includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves,Contribution");
            var contributions = _unitOfWork.Contribution.Value.GetAll();
            var payroll = PayrollHelper.CalculatePayroll(employees, contributions, _project, DateTime.Parse(startDate), DateTime.Parse(endDate), holidays.ToList());

            // Calculate payroll totals
            var totalPurchase = projectLines.Sum(p => p.ActualAmount);
            txtActualAmount.Text = $"₱{totalPurchase:N2}";

            var totalPayroll = payroll.Sum(p => p.NetPay);
            txtPayroll.Text = totalPayroll.ToString("C2");

            // Compute deductions (Total Purchase + Payroll)
            var totalDeductions = totalPurchase + totalPayroll;
            txtDeduction.Text = totalDeductions.ToString("C2");

            // Compute Total Revenue (Budget - Deductions)
            var totalRevenue = (double)(totalBudget - totalDeductions);
            txtTotalRevenue.Text = totalRevenue.ToString("C2");

            // Compute Variance (Actual Revenue - Target Revenue)
            var variance = totalRevenue - targetRevenue;
            var variancePercent = (targetRevenue == 0) ? 0 : (variance / targetRevenue) * 100;
            txtVariance.Text = $"{variance:C2} ({variancePercent:N2}%)";

        }
    }
}
