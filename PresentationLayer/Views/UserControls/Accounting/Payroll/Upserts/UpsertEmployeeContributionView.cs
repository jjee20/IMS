using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertEmployeeContributionView : SfForm
    {
        string message;
        private EmployeeContribution _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertEmployeeContributionView(IUnitOfWork unitOfWork, EmployeeContribution? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new EmployeeContribution();

            LoadEmployees();
            LoadEntityToForm();
        }

        private void LoadEmployees()
        {
            var entity = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            txtEmployee.DataSource = entity.OrderBy(c => c.Name).ToList();
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
            txtEmployee.Text = "~Select Employee~";
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtSSS.Text = _entity.SSS.ToString();
                txtPagIbig.Text = _entity.PagIbig.ToString();
                txtPhilHealth.Text = _entity.PhilHealth.ToString();
                txtSSSWISP.Text = _entity.SSSWISP.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.EmployeeContributionId > 0)
            {
                _unitOfWork.EmployeeContribution.Value.Detach(_entity);
                _unitOfWork.EmployeeContribution.Value.Update(_entity);
                message = "Employee Contribution updated successfully.";
            }
            else
            {
                await _unitOfWork.EmployeeContribution.Value.AddAsync(_entity);
                message = "Employee Contribution added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.PagIbig = !string.IsNullOrEmpty(txtPagIbig.Text) ? Convert.ToDouble(txtPagIbig.Text) : 0;
            _entity.SSS = !string.IsNullOrEmpty(txtSSS.Text) ? Convert.ToDouble(txtSSS.Text) : 0;
            _entity.SSSWISP = !string.IsNullOrEmpty(txtSSSWISP.Text) ? Convert.ToDouble(txtSSSWISP.Text) : 0;
            _entity.PhilHealth = !string.IsNullOrEmpty(txtPhilHealth.Text) ? Convert.ToDouble(txtPhilHealth.Text) : 0;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
