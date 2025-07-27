using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertCustomerTypeView : SfForm
    {
        string message;
        private CustomerType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertCustomerTypeView(IUnitOfWork unitOfWork, CustomerType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new CustomerType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.CustomerTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.CustomerTypeId > 0)
            {
                _unitOfWork.CustomerType.Value.Detach(_entity);
                _unitOfWork.CustomerType.Value.Update(_entity);
                message = "Customer Type updated successfully.";
            }
            else
            {
                await _unitOfWork.CustomerType.Value.AddAsync(_entity);
                message = "Customer Type added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.CustomerTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
