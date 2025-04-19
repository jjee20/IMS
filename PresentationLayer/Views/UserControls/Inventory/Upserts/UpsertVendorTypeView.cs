using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertVendorTypeView : SfForm
    {
        string message;
        private VendorType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertVendorTypeView(IUnitOfWork unitOfWork, VendorType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new VendorType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.VendorTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.VendorTypeId > 0)
            {
                _unitOfWork.VendorType.Value.Detach(_entity);
                _unitOfWork.VendorType.Value.Update(_entity);
                message = "Vendor Type updated successfully.";
            }
            else
            {
                await _unitOfWork.VendorType.Value.AddAsync(_entity);
                message = "Vendor Type added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.VendorTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
