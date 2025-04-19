using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin.Controls;
using PresentationLayer;
using RavenTech_ERP.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            double budget = _projectVM.Budget;
            double revenue = _projectVM.Revenue;

            var startDate = !string.IsNullOrEmpty(_projectVM.StartDate) ? _projectVM.StartDate : DateTime.Now.Date.ToLongDateString();
            var endDate = !string.IsNullOrEmpty(_projectVM.EndDate) ? _projectVM.EndDate : DateTime.Now.Date.ToLongDateString();
            txtProjectName.Text = _project.ProjectName ?? "{Needs Updating}";
            txtClient.Text = _projectVM.Client ?? "{Needs Updating}";
            txtRevenue.Text = budget.ToString() ?? "{Needs Updating}";
            txtBudget.Text = revenue.ToString() ?? "{Needs Updating}";
            txtStartDate.Text = startDate; 
            txtEndDate.Text = endDate;
            txtDescription.Text = _projectVM.Description ?? "{Needs Updating}";

            double totalPurchase = _project.ProjectLines.Sum(c => c.SubTotal);
            txtProjectTotalPurchase.Text = totalPurchase.ToString("N2") ?? "0";

            var projectLines = Program.Mapper.Map<IEnumerable<ProjectLineViewModel>>(_project.ProjectLines);
            dgProjectLines.DataSource = projectLines;

            var employees = _unitOfWork.Employee.Value.GetAll(c => c.Attendances.Any(c => c.ProjectId == _project.ProjectId) , includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves,Contribution");
            var contributions = _unitOfWork.Contribution.Value.GetAll();
            var payroll = PayrollHelper.CalculatePayroll(employees, contributions, _project, DateTime.Parse(startDate), DateTime.Parse(endDate));
        
            dgPayroll.DataSource = payroll;

            // Calculate payroll totals
            double totalPayroll = payroll.Sum(p => p.NetPay);
            txtPayroll.Text = totalPayroll.ToString("N2");

            // Compute deductions (Total Purchase + Payroll)
            double totalDeductions = totalPurchase + totalPayroll;
            txtDeduction.Text = totalDeductions.ToString("N2");
            // Compute Total Revenue (Budget - Deductions)
            double totalRevenue = (double)(budget - totalDeductions);
            txtTotalRevenue.Text = totalRevenue.ToString("N2");
            // Compute Variance (Total Revenue - Actual Revenue)
            double variance = (double)(totalRevenue - revenue);
            txtVariance.Text = variance.ToString("N2");
        }
    }
}
