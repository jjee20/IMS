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
    public partial class UpsertProductStockInLogView : SfForm
    {
        string message = "";
        private readonly IUnitOfWork _unitOfWork;
        private ProductStockInLogs _entity;
        private List<ProductStockInLogLineViewModel> _entityViewModel;

        public UpsertProductStockInLogView(IUnitOfWork unitOfWork, ProductStockInLogs? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ProductStockInLogs();
            _entityViewModel = new List<ProductStockInLogLineViewModel>();
            LoadAllProductList();
            LoadAllStatus();

            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            if (_entity.ProductStockInLogId > 0)
            {
                txtDeliveredBy.Text = _entity.DeliveredBy;
                txtDeliveredDate.Value = _entity.DeliveredDate;
                txtReceivedBy.Text = _entity.ReceivedBy;
                txtReceivedDate.Value = _entity.ReceivedDate;
                txtStatus.SelectedItem = _entity.ProductStatus;
                txtNotes.Text = _entity.Notes;

                if (_entity.ProductStockInLogLines == null) _entity.ProductStockInLogLines = new List<ProductStockInLogLines>();

                foreach (var item in _entity.ProductStockInLogLines)
                {
                    var productStockInLogLines = new ProductStockInLogLineViewModel
                    {
                        ProductStockInLogLinesId = item.ProductStockInLogLinesId,
                        DateAdded = item.DateAdded,
                        ProductId = item.ProductId,
                        ProductName = item.Product.ProductName,
                        Quantity = item.StockQuantity,
                        UnitCost = item.UnitCost == 0 ? item.Product.DefaultBuyingPrice + (item.Product.ProductIncrements.Any() ? item.Product.ProductIncrements.Sum(c => c.Increment) : 0) : item.UnitCost,
                        Delete = Resources.delete
                    };
                    _entityViewModel.Add(productStockInLogLines);
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
            if(txtProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product to add.","Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }


            var product = _unitOfWork.Product.Value.Get(c => c.ProductId == (int)txtProduct.SelectedValue, includeProperties: "ProductIncrements");

            var productInLogLines = new ProductStockInLogLineViewModel()
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

            txtTotal.Text = _entityViewModel.Sum(c => c.TotalCost).ToString("N2");
        }
        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                // Remove the selected row
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductStockInLogLineViewModel row)
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
            if (_entity.ProductStockInLogId > 0)
            {
                var result = MessageBox.Show("Are you sure you want to update the stock in logs?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _unitOfWork.ProductStockInLogs.Value.UpdateWithChildren(_entity, p => p.ProductStockInLogLines, p => p.ProductStockInLogLinesId);
                    message = "Product stock-in updated successfully.";
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
                    await _unitOfWork.ProductStockInLogs.Value.AddAsync(_entity);
                     message = "Product stock-in log added successfully.";
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
            // ✅ DO NOT overwrite _entity if updating
            _entity.Notes = txtNotes.Text;
            _entity.ProductStatus = (ProductStatus)txtStatus.SelectedValue;
            _entity.DeliveredDate = txtDeliveredDate.Value;
            _entity.DeliveredBy = txtDeliveredBy.Text;
            _entity.ReceivedDate = txtReceivedDate.Value;
            _entity.ReceivedBy = txtReceivedBy.Text;

            if (_entity.ProductStockInLogLines == null)
                _entity.ProductStockInLogLines = new List<ProductStockInLogLines>();

            foreach (var updated in _entityViewModel)
            {
                var existing = _entity.ProductStockInLogLines
                    .FirstOrDefault(l => l.ProductStockInLogLinesId == updated.ProductStockInLogLinesId);

                if (existing != null)
                {
                    existing.DateAdded = updated.DateAdded;
                    existing.ProductId = updated.ProductId;
                    existing.StockQuantity = updated.Quantity;
                    existing.UnitCost = updated.UnitCost;
                }
                else
                {
                    _entity.ProductStockInLogLines.Add(new ProductStockInLogLines
                    {
                        ProductStockInLogId = _entity.ProductStockInLogId,
                        DateAdded = updated.DateAdded,
                        ProductId = updated.ProductId,
                        StockQuantity = updated.Quantity,
                        UnitCost = updated.UnitCost
                    });
                }
            }

            // Remove deleted lines
            var toRemove = _entity.ProductStockInLogLines
                .Where(l => !_entityViewModel.Any(vm => vm.ProductStockInLogLinesId == l.ProductStockInLogLinesId))
                .ToList();

            foreach (var line in toRemove)
            {
                _entity.ProductStockInLogLines.Remove(line);
            }
        }

    }
}
