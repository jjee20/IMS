using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin.Controls;
using PresentationLayer;
using RavenTech_ERP.Helpers;
using ServiceLayer.Services.IRepositories;
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
    public partial class ProjectInformationView: MaterialForm
    {
        private readonly Project _project;
        private readonly ProjectViewModel _projectVM;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectInformationView(Project Project, ProjectViewModel ProjectVM, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _project = Project;
            _projectVM = ProjectVM;

            LoadProjectInformation();
            _unitOfWork = unitOfWork;
        }

        private void LoadProjectInformation()
        {
            txtProjectName.Text = _project.ProjectName ?? "";
            txtClient.Text = _projectVM.Client ?? "";
            txtRevenue.Text = _projectVM.Revenue.ToString() ?? "0";
            txtBudget.Text = _projectVM.Budget.ToString() ?? "0";
            txtStartDate.Text = _projectVM.StartDate.Value.Date.ToLongDateString() ?? "";
            txtEndDate.Text = _projectVM.EndDate.Value.Date.ToLongDateString() ?? "";
            txtDescription.Text = _projectVM.Description ?? "";

            double totalPurchase = _project.ProjectLines.Sum(c => c.SubTotal);
            txtProjectTotalPurchase.Text = totalPurchase.ToString("N2") ?? "0";

            var projectLines = Program.Mapper.Map<IEnumerable<ProjectLineViewModel>>(_project.ProjectLines);
            dgProjectLines.DataSource = projectLines;

            var employees = _unitOfWork.Employee.GetAll(c => c.Attendances.Any(c => c.ProjectId == _project.ProjectId) , includeProperties: "Attendances,Shift,Deductions,Benefits,Allowances,Bonuses,Leaves,Contribution");
            var contributions = _unitOfWork.Contribution.GetAll();
            var payroll = PayrollHelper.CalculatePayroll(employees, contributions, _project, _projectVM.StartDate.Value.Date, _projectVM.EndDate.Value.Date);
        
            dgPayroll.DataSource = payroll;

            // Calculate payroll totals
            double totalPayroll = payroll.Sum(p => p.NetPay);
            txtPayroll.Text = totalPayroll.ToString("N2");

            // Compute deductions (Total Purchase + Payroll)
            double totalDeductions = totalPurchase + totalPayroll;
            txtDeduction.Text = totalDeductions.ToString("N2");

            // Compute Total Revenue (Budget - Deductions)
            double totalRevenue = (double)(_projectVM.Budget - totalDeductions);
            txtTotalRevenue.Text = totalRevenue.ToString("N2");

            // Compute Variance (Total Revenue - Actual Revenue)
            double variance = (double)(totalRevenue - _projectVM.Revenue);
            txtVariance.Text = variance.ToString("N2");
        }
    }
}
