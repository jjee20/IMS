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
    public partial class UpsertCustomerView : SfForm
    {
        string message;
        private Customer _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertCustomerView(IUnitOfWork unitOfWork, Customer? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Customer();

            LoadCustomerType();
            LoadEntityToForm();
        }

        private void LoadCustomerType()
        {
            var customerTypes = _unitOfWork.CustomerType.Value.GetAll();
            txtCustomerType.DataSource = customerTypes;
            txtCustomerType.DisplayMember = "CustomerTypeName";
            txtCustomerType.ValueMember = "CustomerTypeId";
            txtCustomerType.Text = "~Select Customer Type~";
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.CustomerName;
            txtCustomerType.SelectedValue = _entity.CustomerTypeId;
            txtAddress.Text = _entity.Address;
            txtPhone.Text = _entity.Phone;
            txtEmail.Text = _entity.Email;
            txtContactPerson.Text = _entity.ContactPerson;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.CustomerId > 0)
            {
                _unitOfWork.Customer.Value.Detach(_entity);
                _unitOfWork.Customer.Value.Update(_entity);
                message = "Customer updated successfully.";
            }
            else
            {
                await _unitOfWork.Customer.Value.AddAsync(_entity);
                message = "Customer added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.CustomerName = txtName.Text;
            _entity.CustomerTypeId = (int)txtCustomerType.SelectedValue;
            _entity.Address = txtAddress.Text;
            _entity.Phone = txtPhone.Text;
            _entity.Email = txtEmail.Text;
            _entity.ContactPerson = txtContactPerson.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
