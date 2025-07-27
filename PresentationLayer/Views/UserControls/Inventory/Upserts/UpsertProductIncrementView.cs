using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertProductIncrementView : SfForm
    {
        string message;
        private ProductIncrements _entity;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _productId;

        public UpsertProductIncrementView(IUnitOfWork unitOfWork, int productId = 0, ProductIncrements? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _productId = productId;
            _entity = entity ?? new ProductIncrements();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtDate.Value = _entity.Date;
            txtIncrement.Text = _entity.Increment.ToString();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ProductIncrementId > 0)
            {
                _unitOfWork.ProductIncrement.Value.Detach(_entity);
                _unitOfWork.ProductIncrement.Value.Update(_entity);
                message = "Product Increment updated successfully.";
            }
            else
            {
                await _unitOfWork.ProductIncrement.Value.AddAsync(_entity);
                message = "Product Increment added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Date = (DateTime)txtDate.Value;
            _entity.ProductId = _productId;
            _entity.Increment = Convert.ToDouble(txtIncrement.Text);
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void UpsertProductIncrementView_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
        }
    }
}
