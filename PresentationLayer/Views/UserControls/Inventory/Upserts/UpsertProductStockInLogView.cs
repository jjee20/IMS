using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.UserControls.Inventory.Searches;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertProductStockInLogView : SfForm
    {
        string message;
        private ProductStockInLog _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertProductStockInLogView(IUnitOfWork unitOfWork, ProductStockInLog? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ProductStockInLog();

            LoadProducts();
            LoadProductStatus();
            LoadEntityToForm();
        }

        private void LoadProductStatus()
        {
            txtProductStatus.DataSource = EnumHelper.EnumToEnumerable<ProductStatus>();
            txtProductStatus.DisplayMember = "Name";
            txtProductStatus.ValueMember = "Id";;
            txtProductStatus.Text = "~Select Product Status~";
        }

        private void LoadProducts()
        {
            txtProduct.DataSource = _unitOfWork.Product.Value.GetAll();
            txtProduct.DisplayMember = "DisplayInfo";
            txtProduct.ValueMember = "ProductId";
            txtProduct.Text = "~Select Product~";
        }

        private void LoadEntityToForm()
        {
            if (_entity.ProductStockInLogId > 0)
            {
                txtProduct.SelectedValue = _entity.ProductId;
                txtDate.Value = _entity.DateAdded;
                txtNotes.Text = _entity.Notes;
                txtProductStatus.SelectedValue = _entity.ProductStatus;
                txtStockQuantity.Text = _entity.StockQuantity.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ProductStockInLogId > 0)
            {
                _unitOfWork.StockInLogs.Value.Detach(_entity);
                _unitOfWork.StockInLogs.Value.Update(_entity);
                message = "ProductStockInLog updated successfully.";
            }
            else
            {
                await _unitOfWork.StockInLogs.Value.AddAsync(_entity);
                message = "ProductStockInLog added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.ProductId = (int)txtProduct.SelectedValue;
            _entity.DateAdded = (DateTime)txtDate.Value;
            _entity.Notes = txtNotes.Text;
            _entity.ProductStatus = (DomainLayer.Enums.ProductStatus)txtProductStatus.SelectedValue;
            _entity.StockQuantity = Convert.ToDouble(txtStockQuantity.Text);
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            using (var searchProduct = new SearchProduct(_unitOfWork))
            {
                if (searchProduct.ShowDialog() == DialogResult.OK)
                {
                    var selectedProduct = searchProduct._entity;
                    txtProduct.SelectedValue = selectedProduct.ProductId;
                }
            }
        }
    }
}
