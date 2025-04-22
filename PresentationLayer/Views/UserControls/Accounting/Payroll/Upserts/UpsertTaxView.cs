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
    public partial class UpsertTaxView : SfForm
    {
        string message;
        private Tax _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTaxView(IUnitOfWork unitOfWork, Tax? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Tax();

            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtMinimumSalary.Text = _entity.MinimumSalary.ToString();
                txtMaximumSalary.Text = _entity.MaximumSalary.ToString();
                txtTaxRate.Text = _entity.TaxRate.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.TaxId > 0)
            {
                _unitOfWork.Tax.Value.Detach(_entity);
                _unitOfWork.Tax.Value.Update(_entity);
                message = "Tax updated successfully.";
            }
            else
            {
                await _unitOfWork.Tax.Value.AddAsync(_entity);
                message = "Tax added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.MinimumSalary = Convert.ToDouble(txtMinimumSalary.Text);
            _entity.MaximumSalary = Convert.ToDouble(txtMaximumSalary.Text);
            _entity.TaxRate = Convert.ToDouble(txtTaxRate.Text);
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
