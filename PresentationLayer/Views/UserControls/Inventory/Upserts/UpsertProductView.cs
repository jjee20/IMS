using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertProductView : SfForm
    {
        string message;
        private Product _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertProductView(IUnitOfWork unitOfWork, Product? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Product();
            LoadProductTypes();
            LoadUOM();
            LoadBranch();
            LoadEntityToForm();
        }

        private void LoadBranch()
        {
            txtBranch.DataSource = _unitOfWork.Branch.Value.GetAll();
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
            txtBranch.Text = "~Select Branch~";
        }

        private void LoadUOM()
        {
            txtUOM.DataSource = _unitOfWork.UnitOfMeasure.Value.GetAll();
            txtUOM.DisplayMember = "UnitOfMeasureName";
            txtUOM.ValueMember = "UnitOfMeasureId";
            txtUOM.Text = "~Select UOM~";
        }

        private void LoadProductTypes()
        {
            txtProductType.DataSource = _unitOfWork.ProductType.Value.GetAll();
            txtProductType.DisplayMember = "ProductTypeName";
            txtProductType.ValueMember = "ProductTypeId";
            txtProductType.Text = "~Select Product Type~";
        }

        private void LoadEntityToForm()
        {
            if(_entity != null)
            {

            txtName.Text = _entity.ProductName;
            txtDescription.Text = _entity.Description;
            txtBarcode.Text = _entity.Barcode;
            txtProductCode.Text = _entity.ProductCode;
            txtProductType.SelectedValue = _entity.ProductTypeId;
            txtBranch.SelectedValue = _entity.BranchId;
            txtBrand.Text = _entity.Brand;
            txtColor.Text = _entity.Color;
            txtSize.Text = _entity.Size;
            txtReorderLevel.Text = _entity.ReorderLevel.ToString();
            txtUOM.SelectedValue = _entity.UnitOfMeasureId;
            txtDefaultBuyingPrice.Text = _entity.DefaultBuyingPrice.ToString();
            txtDefaultSellingPrice.Text = _entity.DefaultSellingPrice.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ProductId > 0)
            {
                _unitOfWork.Product.Value.Detach(_entity);
                _unitOfWork.Product.Value.Update(_entity);
                message = "Product updated successfully.";
            }
            else
            {
                await _unitOfWork.Product.Value.AddAsync(_entity);
                message = "Product added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.ProductName = txtName.Text;
            _entity.Description = txtDescription.Text;
            _entity.Barcode = txtBarcode.Text;
            _entity.ProductCode = txtProductCode.Text;
            _entity.ProductTypeId = (int)txtProductType.SelectedValue;
            _entity.BranchId = (int)txtBranch.SelectedValue;
            _entity.Brand = txtBrand.Text;
            _entity.Color = txtColor.Text;
            _entity.Size = txtSize.Text;
            _entity.ReorderLevel = int.TryParse(txtReorderLevel.Text, out var reorderLevel) ? reorderLevel : 0;
            _entity.UnitOfMeasureId = (int)txtUOM.SelectedValue;
            _entity.DefaultBuyingPrice = double.TryParse(txtDefaultBuyingPrice.Text, out var buyingPrice) ? buyingPrice : 0.0;
            _entity.DefaultSellingPrice = double.TryParse(txtDefaultSellingPrice.Text, out var sellingPrice) ? sellingPrice : 0.0;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
