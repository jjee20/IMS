using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertBranchView : SfForm
    {
        string message;
        private Branch _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertBranchView(IUnitOfWork unitOfWork, Branch? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Branch();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.BranchName;
            txtDescription.Text = _entity.Description;
            txtAddress.Text = _entity.Address;
            txtPhone.Text = _entity.Phone;
            txtEmail.Text = _entity.Email;
            txtContactPerson.Text = _entity.ContactPerson;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.BranchId > 0)
            {
                _unitOfWork.Branch.Value.Detach(_entity);
                _unitOfWork.Branch.Value.Update(_entity);
                message = "Branch updated successfully.";
            }
            else
            {
                await _unitOfWork.Branch.Value.AddAsync(_entity);
                message = "Branch added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.BranchName = txtName.Text;
            _entity.Description = txtDescription.Text;
            _entity.Address = txtAddress.Text;
            _entity.Phone = txtPhone.Text;
            _entity.Email = txtEmail.Text;
            _entity.ContactPerson = txtContactPerson.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
