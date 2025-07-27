using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertPaymentTypeView : SfForm
    {
        string message;
        private PaymentType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertPaymentTypeView(IUnitOfWork unitOfWork, PaymentType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new PaymentType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.PaymentTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.PaymentTypeId > 0)
            {
                _unitOfWork.PaymentType.Value.Detach(_entity);
                _unitOfWork.PaymentType.Value.Update(_entity);
                message = "Payment Type updated successfully.";
            }
            else
            {
                await _unitOfWork.PaymentType.Value.AddAsync(_entity);
                message = "Payment Type added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.PaymentTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
