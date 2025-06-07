using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertProductTypeView : SfForm
    {
        string message;
        private ProductType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertProductTypeView(IUnitOfWork unitOfWork, ProductType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ProductType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.ProductTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ProductTypeId > 0)
            {
                _unitOfWork.ProductType.Value.Detach(_entity);
                _unitOfWork.ProductType.Value.Update(_entity);
                message = "Product Type updated successfully.";
            }
            else
            {
                await _unitOfWork.ProductType.Value.AddAsync(_entity);
                message = "Product Type added successfully.";
            }
            await _unitOfWork.SaveAsync();

            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.ProductTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
