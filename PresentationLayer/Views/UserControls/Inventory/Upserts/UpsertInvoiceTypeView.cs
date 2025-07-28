using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertInvoiceTypeView : SfForm
    {
        string message;
        private InvoiceType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertInvoiceTypeView(IUnitOfWork unitOfWork, InvoiceType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new InvoiceType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.InvoiceTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.InvoiceTypeId > 0)
            {
                _unitOfWork.InvoiceType.Value.Detach(_entity);
                _unitOfWork.InvoiceType.Value.Update(_entity);
                message = "Invoice Type updated successfully.";
            }
            else
            {
                await _unitOfWork.InvoiceType.Value.AddAsync(_entity);
                message = "Invoice Type added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.InvoiceTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
