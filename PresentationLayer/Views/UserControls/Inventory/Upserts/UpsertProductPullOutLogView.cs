using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Repositories;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Unity.Storage.RegistrationSet;

namespace RavenTech_ERP.Views.UserControls.Inventory.Upserts
{
    public partial class UpsertProductPullOutLogView : SfForm
    {
        string message = "";
        private readonly IUnitOfWork _unitOfWork;
        private ProductPullOutLogs _entity;
        private List<ProductPullOutLogLineViewModel> _entityViewModel;

        public UpsertProductPullOutLogView(IUnitOfWork unitOfWork, ProductPullOutLogs? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ProductPullOutLogs();
            _entityViewModel = new List<ProductPullOutLogLineViewModel>();
            LoadAllProductList();
            LoadAllStatus();
            LoadAllProjects();

            LoadEntityToForm();
        }

        private void LoadAllProjects()
        {
            txtProject.DataSource = _unitOfWork.Project.Value.GetAll();
            txtProject.DisplayMember = "ProjectName";
            txtProject.ValueMember = "ProjectId";
            txtProject.Text = "~Select Project~";
        }

        private void LoadEntityToForm()
        {
            if (_entity.ProductPullOutLogId > 0)
            {
                txtDeliveredBy.Text = _entity.DeliveredBy;
                txtDeliveredDate.Value = _entity.DeliveredDate;
                txtReceivedBy.Text = _entity.ReceivedBy;
                txtReceivedDate.Value = _entity.ReceivedDate;
                txtStatus.SelectedItem = _entity.ProductStatus;
                txtNotes.Text = _entity.Notes;
                txtProject.SelectedValue = _entity.ProjectId;

                if (_entity.ProductPullOutLogLines == null) _entity.ProductPullOutLogLines = new List<ProductPullOutLogLines>();

                foreach (var item in _entity.ProductPullOutLogLines)
                {
                    var productPullOutLogLines = new ProductPullOutLogLineViewModel
                    {
                        ProductPullOutLogLinesId = item.ProductPullOutLogLinesId,
                        DateAdded = item.DateAdded,
                        ProductId = item.ProductId,
                        ProductName = item.Product.ProductName,
                        Quantity = item.StockQuantity,
                        UnitCost = item.UnitCost == 0 ? item.Product.DefaultBuyingPrice + (item.Product.ProductIncrements.Any() ? item.Product.ProductIncrements.Sum(c => c.Increment) : 0) : item.UnitCost,
                        Delete = Resources.delete
                    };
                    _entityViewModel.Add(productPullOutLogLines);
                }

                dgList.DataSource = null;
                dgList.DataSource = _entityViewModel;

                txtTotal.Text = _entityViewModel.Sum(c => c.TotalCost).ToString("N2");
            }
        }

        private void LoadAllProductList()
        {
            txtProduct.DataSource = _unitOfWork.Product.Value.GetAll();
            txtProduct.DisplayMember = "DisplayInfo";
            txtProduct.ValueMember = "ProductId";
            txtProduct.Text = "~Select Product~";
        }

        private void LoadAllStatus()
        {
            txtStatus.DataSource = EnumHelper.EnumToEnumerable<ProductStatus>();
            txtStatus.DisplayMember = "Name";
            txtStatus.ValueMember = "Id";
            txtStatus.Text = "~Select Status~";
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (txtProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product to add.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a project.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var productId = (int)txtProduct.SelectedValue;

            // Get total pull-out quantity
            var productStockInQty = _unitOfWork.ProductStockInLogLines.Value
                .GetAll(c => c.ProductId == productId)
                .Sum(c => (int?)c.StockQuantity) ?? 0;

            // Get total pull-out quantity
            var productPullOutQty = _unitOfWork.ProductPullOutLogLines.Value
                .GetAll(c => c.ProductId == productId)
                .Sum(c => (int?)c.StockQuantity) ?? 0;

            // Get total sales-order quantity
            var productSalesOrderQty = _unitOfWork.SalesOrderLine.Value
                .GetAll(c => c.ProductId == productId)
                .Sum(c => (int?)c.Quantity) ?? 0;

            // Calculate current stock
            var availableStock = productStockInQty - productPullOutQty - productSalesOrderQty;
            var currentQty = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0;

            var userDepartment = Settings.Default.Department;
            var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);

            var isAdmin = userDepartment == Departments.Admin.ToString();
            var canOverride = appUserRoles != null && appUserRoles.Contains(TaskRoles.Override);

            var allowOverride = false;

            // Centralized override logic
            if (currentQty > availableStock)
            {
                if (isAdmin && canOverride)
                {
                    var result = MessageBox.Show(
                        "Insufficient stock for the selected product. Do you want to override?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        allowOverride = true;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient stock for the selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // If no override, also block zero or negative stock
            if (availableStock <= 0 && !allowOverride)
            {
                MessageBox.Show("No stock available for the selected product.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = _unitOfWork.Product.Value.Get(c => c.ProductId == (int)txtProduct.SelectedValue, includeProperties: "ProductIncrements");

            var productInLogLines = new ProductPullOutLogLineViewModel()
            {
                DateAdded = (DateTime)txtDateAdded.Value,
                ProductId = (int)txtProduct.SelectedValue,
                ProductName = txtProduct.Text,
                Quantity = Convert.ToDouble(txtQuantity.Text),
                UnitCost = product.DefaultBuyingPrice + (product.ProductIncrements.Any() ? product.ProductIncrements.Sum(c => c.Increment) : 0),
                Delete = Resources.delete
            };

            var check = _entityViewModel.Where(c => c.ProductId == productInLogLines.ProductId);

            if (check.Any()) return;

            _entityViewModel.Add(productInLogLines);

            dgList.DataSource = null;
            dgList.DataSource = _entityViewModel;
            ComputeTotal();
        }

        private void dgList_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            dgList.Refresh();
            ComputeTotal();
        }

        private void ComputeTotal()
        {
            txtTotal.Text = _entityViewModel.Sum(c => c.TotalCost).ToString("C2");
        }
        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                // Remove the selected row
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductPullOutLogLineViewModel row)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        var record = _entityViewModel.FirstOrDefault(c => c.ProductId == row.ProductId);
                        if (record != null)
                        {
                            _entityViewModel.Remove(record);
                            dgList.DataSource = null;
                            dgList.DataSource = _entityViewModel;
                            ComputeTotal();
                        }
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

                    UpdateEntityFromForm();
            if (_entity.ProductPullOutLogId > 0)
            {
                var result = MessageBox.Show("Are you sure you want to update the pull-out logs?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _unitOfWork.ProductPullOutLogs.Value.UpdateWithChildren(_entity, p => p.ProductPullOutLogLines, p => p.ProductPullOutLogLinesId);
                    message = "Product pull-out updated successfully.";
                }
                else
                {
                    return;
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to add the stock?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _unitOfWork.ProductPullOutLogs.Value.AddAsync(_entity);
                     message = "Product pull-out log added successfully.";
                }
                else
                {
                    return;
                }
            }

            await _unitOfWork.SaveAsync();
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Notes = txtNotes.Text;
            _entity.ProductStatus = (ProductStatus)txtStatus.SelectedValue;
            _entity.DeliveredDate = txtDeliveredDate.Value;
            _entity.DeliveredBy = txtDeliveredBy.Text;
            _entity.ReceivedDate = txtReceivedDate.Value;
            _entity.ReceivedBy = txtReceivedBy.Text;
            _entity.ProjectId = (int)txtProject.SelectedValue;

            if (_entity.ProductPullOutLogLines == null)
            {
                _entity.ProductPullOutLogLines = new List<ProductPullOutLogLines>();
            }

            foreach (var updatedLine in _entityViewModel)
            {
                var existing = _entity.ProductPullOutLogLines
                    .FirstOrDefault(l => l.ProductPullOutLogLinesId == updatedLine.ProductPullOutLogLinesId);

                if (existing != null)
                {
                    // Update existing
                    existing.DateAdded = updatedLine.DateAdded;
                    existing.ProductId = updatedLine.ProductId;
                    existing.StockQuantity = updatedLine.Quantity;
                    existing.UnitCost = updatedLine.UnitCost;
                }
                else
                {
                    // Add new
                    _entity.ProductPullOutLogLines.Add(new ProductPullOutLogLines
                    {
                        ProductPullOutLogId = _entity.ProductPullOutLogId,
                        DateAdded = updatedLine.DateAdded,
                        ProductId = updatedLine.ProductId,
                        StockQuantity = updatedLine.Quantity,
                        UnitCost = updatedLine.UnitCost
                    });
                }
            }

            // Remove lines no longer in the view model
            var toRemove = _entity.ProductPullOutLogLines
                .Where(l => !_entityViewModel.Any(vm => vm.ProductPullOutLogLinesId == l.ProductPullOutLogLinesId))
                .ToList();

            foreach (var line in toRemove)
            {
                _entity.ProductPullOutLogLines.Remove(line);
            }
        }

    }
}
