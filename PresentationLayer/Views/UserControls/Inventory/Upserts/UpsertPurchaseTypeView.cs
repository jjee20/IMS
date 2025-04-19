using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertPurchaseTypeView : SfForm
    {
        string message;
        private PurchaseType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertPurchaseTypeView(IUnitOfWork unitOfWork, PurchaseType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new PurchaseType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.PurchaseTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.PurchaseTypeId > 0)
            {
                _unitOfWork.PurchaseType.Value.Detach(_entity);
                _unitOfWork.PurchaseType.Value.Update(_entity);
                message = "Purchase Type updated successfully.";
            }
            else
            {
                await _unitOfWork.PurchaseType.Value.AddAsync(_entity);
                message = "Purchase Type added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.PurchaseTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
