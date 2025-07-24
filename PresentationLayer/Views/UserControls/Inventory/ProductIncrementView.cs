using System.ComponentModel;
using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductIncrementView : SfForm, IProductIncrementView
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _productId;
        private IEnumerable<ProductIncrementViewModel> ProductIncrementList;
        public ProductIncrementView(IUnitOfWork unitOfWork, int productId = 0)
        {
            _unitOfWork = unitOfWork;
            _productId = productId;
            InitializeComponent();
            SetPermissions();
            LoadAllProductIncrementList();
        }
        public void SetPermissions()
        {
            var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);
            btnAdd.Enabled = appUserRoles.Contains(TaskRoles.Add);
            dgList.Columns["Edit"].Visible = appUserRoles.Contains(TaskRoles.Edit);
            dgList.Columns["Delete"].Visible = appUserRoles.Contains(TaskRoles.Delete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new UpsertProductIncrementView(_unitOfWork, _productId);
            form.Text = "Add Product Increment";
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllProductIncrementList();
            }
        }

        private async void LoadAllProductIncrementList(bool emptyValue = false)
        {
            ProductIncrementList = Program.Mapper.Map<IEnumerable<ProductIncrementViewModel>>(await _unitOfWork.ProductIncrement.Value.GetAllAsync(c => c.ProductId == _productId, includeProperties: "Product"));

            if (!emptyValue) ProductIncrementList = ProductIncrementList.Where(c => c.Increment.ToString().ToLower().Contains(txtSearch.Text.ToLower()));
            SetProductIncrementListBindingSource(ProductIncrementList);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var productName = _unitOfWork.Product.Value.Get(c => c.ProductId == _productId)?.ProductName ?? "All Products";
            var reportFileName = "ProductIncrementReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductIncrement", ProductIncrementList);
            var reportParameters = new List<ReportParameter> { new ("Product", productName)};
            var reportView = new ReportView(reportPath, reportDataSource, localReport, reportParameters);
            reportView.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var emptyValue = string.IsNullOrWhiteSpace(txtSearch.Text.Trim());
                LoadAllProductIncrementList(emptyValue);
            }
            txtSearch.Focus();
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow)
            {
                if (e.DataColumn.GridColumn.MappingName == "Edit")
                {
                    if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductIncrementViewModel row)
                    {
                        var entity = _unitOfWork.ProductIncrement.Value.Get(c => c.ProductIncrementId == row.ProductIncrementId);
                        using var form = new UpsertProductIncrementView(_unitOfWork, _productId, entity);
                        form.Text = "Edit Product Increment";
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllProductIncrementList();
                        }
                    }
                }
                else if (e.DataColumn.GridColumn.MappingName == "Delete")
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductIncrementViewModel row)
                        {
                            var entity = _unitOfWork.ProductIncrement.Value.Get(c => c.ProductIncrementId == row.ProductIncrementId);
                            if (entity != null)
                            {
                                _unitOfWork.ProductIncrement.Value.Detach(entity);
                                _unitOfWork.ProductIncrement.Value.Remove(entity);
                                _unitOfWork.Save();

                                MessageBox.Show("Product Increment deleted successfully.");

                                LoadAllProductIncrementList();
                            }
                        }
                    }
                }
            }
        }
        private void Me_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected items?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (dgList.SelectedItems == null || dgList.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("Please select item(s) to delete.");
                            return;
                        }

                        var selected = dgList.SelectedItems.Cast<ProductIncrementViewModel>().ToList(); // If you're using view models
                        var ids = selected.Select(b => b.ProductIncrementId).ToList();

                        var entities = _unitOfWork.ProductIncrement.Value
                            .GetAll()
                            .Where(b => ids.Contains(b.ProductIncrementId))
                            .ToList();

                        if (!entities.Any())
                        {
                            MessageBox.Show("Selected records could not be found.");
                            return;
                        }

                        _unitOfWork.ProductIncrement.Value.RemoveRange(entities);
                        _unitOfWork.Save();

                        MessageBox.Show($"{entities.Count} entries deleted successfully.");
                        LoadAllProductIncrementList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting: {ex.Message}");
                    }
                }
            }
        }

        public void SetProductIncrementListBindingSource(IEnumerable<ProductIncrementViewModel> ProductIncrementList)
        {
            dgPager.DataSource = ProductIncrementList;

            foreach (var entity in ProductIncrementList)
            {
                entity.Edit = Resources.edit; // Or any other image per row
                entity.Delete = Resources.delete; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource;
        }
    }
}
