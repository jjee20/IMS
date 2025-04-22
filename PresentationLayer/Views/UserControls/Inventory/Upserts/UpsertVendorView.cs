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
    public partial class UpsertVendorView : SfForm
    {
        string message;
        private Vendor _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertVendorView(IUnitOfWork unitOfWork, Vendor? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Vendor();
            LoadVendorType();
            LoadEntityToForm();
        }

        private void LoadVendorType()
        {
            var vendorTypes = _unitOfWork.VendorType.Value.GetAll();
            txtVendorType.DataSource = vendorTypes;
            txtVendorType.DisplayMember = "VendorTypeName";
            txtVendorType.ValueMember = "VendorTypeId";
            txtVendorType.Text = "~Select Vendor Type~";
        }

        private void LoadEntityToForm()
        {
            if(_entity != null)
            {

            txtName.Text = _entity.VendorName;
            txtVendorType.SelectedValue = _entity.VendorTypeId;
            txtAddress.Text = _entity.Address;
            txtPhone.Text = _entity.Phone;
            txtEmail.Text = _entity.Email;
            txtContactPerson.Text = _entity.ContactPerson;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.VendorId > 0)
            {
                _unitOfWork.Vendor.Value.Detach(_entity);
                _unitOfWork.Vendor.Value.Update(_entity);
                message = "Vendor updated successfully.";
            }
            else
            {
                await _unitOfWork.Vendor.Value.AddAsync(_entity);
                message = "Vendor added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.VendorName = txtName.Text;
            _entity.VendorTypeId = (int)txtVendorType.SelectedValue;
            _entity.Address = txtAddress.Text;
            _entity.Phone = txtPhone.Text;
            _entity.Email = txtEmail.Text;
            _entity.ContactPerson = txtContactPerson.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
