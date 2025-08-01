﻿using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.UserControls.Inventory.Searches;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertSalesOrderView : SfForm
    {
        string message;
        private SalesOrder _entity;
        private List<SalesOrderLineViewModel> _projectsLines;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertSalesOrderView(IUnitOfWork unitOfWork, SalesOrder? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new SalesOrder();
            _projectsLines = new List<SalesOrderLineViewModel>();

            LoadAllProductList();
            LoadAllSalesTypeList();
            LoadAllBranchList();
            LoadAllCustomerList();
            LoadAllShipmentTypeList();
            LoadAllWarehouseList();
            LoadEntityToForm();
        }

        private void LoadAllWarehouseList()
        {
            txtWarehouse.DataSource = _unitOfWork.Warehouse.Value.GetAll();
            txtWarehouse.DisplayMember = "WarehouseName";
            txtWarehouse.ValueMember = "WarehouseId";
            txtWarehouse.Text = "~Select Warehouse~";
        }

        private void LoadAllShipmentTypeList()
        {
            txtShipmentType.DataSource = _unitOfWork.ShipmentType.Value.GetAll();
            txtShipmentType.DisplayMember = "ShipmentTypeName";
            txtShipmentType.ValueMember = "ShipmentTypeId";
            txtShipmentType.Text = "~Select Shipment Type~";
        }

        private void LoadAllCustomerList()
        {
            txtCustomer.DataSource = _unitOfWork.Customer.Value.GetAll();
            txtCustomer.DisplayMember = "CustomerName";
            txtCustomer.ValueMember = "CustomerId";
            txtCustomer.Text = "~Select Customer~";
        }

        private void LoadAllBranchList()
        {
            txtBranch.DataSource = _unitOfWork.Branch.Value.GetAll();
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
            txtBranch.Text = "~Select Branch~";
        }

        private void LoadAllSalesTypeList()
        {
            txtSalesType.DataSource = _unitOfWork.SalesType.Value.GetAll();
            txtSalesType.DisplayMember = "SalesTypeName";
            txtSalesType.ValueMember = "SalesTypeId";
            txtSalesType.Text = "~Select Sales Type~";
        }

        private void LoadAllProductList()
        {
            txtProduct.DataSource = _unitOfWork.Product.Value.GetAll();
            txtProduct.DisplayMember = "DisplayInfo";
            txtProduct.ValueMember = "ProductId";
            txtProduct.Text = "~Select Product~";
        }

        private void LoadEntityToForm()
        {
            if (_entity.SalesOrderId > 0)
            {
                txtSalesOrderName.Text = _entity.SalesOrderName;
                txtBranch.SelectedValue = _entity.BranchId;
                txtCustomer.SelectedValue = _entity.CustomerId;
                txtOrderDate.Value = _entity.OrderDate.DateTime;
                txtDeliveryDate.Value = _entity.DeliveryDate.DateTime;
                txtCustomerRefNumber.Text = _entity.CustomerRefNumber;
                txtSalesType.SelectedValue = _entity.SalesTypeId;
                txtRemarks.Text = _entity.Remarks;
                txtAmount.Text = _entity.Amount.ToString("N2");
                txtSubtotal.Text = _entity.SubTotal.ToString("N2");
                txtDiscount.Text = _entity.Discount.ToString("N2");
                txtTax.Text = _entity.Tax.ToString("N2");
                txtFreight.Text = _entity.Freight.ToString("N2");
                txtOverallTotal.Text = _entity.Total.ToString("N2");

                if (_entity.SalesOrderLines == null) _entity.SalesOrderLines = new List<SalesOrderLine>();

                foreach (var line in _entity.SalesOrderLines)
                {
                    var projectLine = new SalesOrderLineViewModel
                    {
                        SalesOrderLineId = line.SalesOrderLineId,
                        ProductId = (int)line.ProductId,
                        ProductName = line.ProductName,
                        Price = line.Price,
                        Quantity = line.Quantity,
                        DiscountPercentage = line.DiscountPercentage,
                        SubTotal = line.SubTotal,
                        Delete = Resources.delete
                    };
                    _projectsLines.Add(projectLine);
                }

                dgList.DataSource = null;
                dgList.DataSource = _projectsLines;

                txtTotal.Text = _projectsLines.Sum(c => c.SubTotal).ToString("N2");
            }
        }

        private void UpdateEntityFromForm()
        {
            _entity.SalesOrderName = txtSalesOrderName.Text.Trim();
            _entity.BranchId = (int)txtBranch.SelectedValue;
            _entity.CustomerId = (int)txtCustomer.SelectedValue;
            _entity.OrderDate = (DateTimeOffset)txtOrderDate.Value;
            _entity.DeliveryDate = (DateTimeOffset)txtDeliveryDate.Value;
            _entity.CustomerRefNumber = txtCustomerRefNumber.Text.Trim();
            _entity.SalesTypeId = (int)txtSalesType.SelectedValue;
            _entity.Remarks = txtRemarks.Text.Trim();

            _entity.Amount = double.TryParse(txtAmount.Text, out var amountValue) ? amountValue : 0.0;
            _entity.SubTotal = double.TryParse(txtSubtotal.Text, out var subtotalValue) ? subtotalValue : 0.0;
            _entity.Discount = double.TryParse(txtDiscount.Text, out var discountValue) ? discountValue : 0.0;
            _entity.Tax = double.TryParse(txtTax.Text, out var taxValue) ? taxValue : 0.0;
            _entity.Freight = double.TryParse(txtFreight.Text, out var freightValue) ? freightValue : 0.0;
            _entity.Total = double.TryParse(txtOverallTotal.Text, out var totalValue) ? totalValue : 0.0;

            // Handle Shipment
            if (btnNoShipment.Checked)
            {
                _entity.Shipment = null;
            }
            else
            {
                if (_entity.Shipment == null)
                    _entity.Shipment = new Shipment();

                _entity.Shipment.ShipmentTypeId = (int)txtShipmentType.SelectedValue;
                _entity.Shipment.WarehouseId = (int)txtWarehouse.SelectedValue;
            }

            // === Update SalesOrderLines without replacing the collection ===
            foreach (var updatedLine in _projectsLines)
            {
                var existing = _entity.SalesOrderLines
                    .FirstOrDefault(sol => sol.SalesOrderLineId == updatedLine.SalesOrderLineId);

                if (existing != null)
                {
                    // Update existing
                    existing.ProductId = updatedLine.ProductId;
                    existing.ProductName = updatedLine.ProductName;
                    existing.Price = updatedLine.Price;
                    existing.Quantity = updatedLine.Quantity;
                    existing.DiscountPercentage = updatedLine.DiscountPercentage;
                    existing.SubTotal = updatedLine.SubTotal;
                }
                else
                {
                    // Add new
                    _entity.SalesOrderLines.Add(new SalesOrderLine
                    {
                        SalesOrderId = _entity.SalesOrderId,
                        ProductId = updatedLine.ProductId,
                        ProductName = updatedLine.ProductName,
                        Price = updatedLine.Price,
                        Quantity = updatedLine.Quantity,
                        DiscountPercentage = updatedLine.DiscountPercentage,
                        SubTotal = updatedLine.SubTotal
                    });
                }
            }

            // Remove lines no longer in _projectsLines
            var toRemove = _entity.SalesOrderLines
                .Where(sol => !_projectsLines.Any(p => p.SalesOrderLineId == sol.SalesOrderLineId))
                .ToList();

            foreach (var line in toRemove)
            {
                _entity.SalesOrderLines.Remove(line);
            }

            // Recalculate total just in case
            _entity.SubTotal = _projectsLines.Sum(c => c.SubTotal);
        }


        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private async void buttonConfirm_Click_1(object sender, EventArgs e)
        {
                    UpdateEntityFromForm();
            if (string.IsNullOrWhiteSpace(txtSalesOrderName.Text))
            {
                MessageBox.Show("Please enter a project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_projectsLines.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtOrderDate.Value > txtDeliveryDate.Value)
            {
                MessageBox.Show("End date must be greater than start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_entity.SalesOrderId > 0)
            {
                var result = MessageBox.Show("Are you sure you want to update the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _unitOfWork.SalesOrder.Value.UpdateWithChildren(_entity, c => c.SalesOrderLines, cd => cd.SalesOrderLineId);

                    message = "SalesOrder updated successfully.";
                }
                else
                {
                    return;
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to add the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _unitOfWork.SalesOrder.Value.AddAsync(_entity);
                    message = "SalesOrder added successfully.";
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

        private void btnNonStock_CheckedChanged(object sender, EventArgs e)
        {
            txtNonStock.Visible = btnNonStock.Checked;
            txtProduct.Visible = !btnNonStock.Checked;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            using (var searchProduct = new SearchProduct(_unitOfWork))
            {
                if (searchProduct.ShowDialog() == DialogResult.OK)
                {
                    var product = searchProduct._entity;
                    var projectLine = new SalesOrderLineViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Price = product.DefaultBuyingPrice,
                        Quantity = 1,
                        SubTotal = product.DefaultBuyingPrice,
                        Delete = Resources.delete
                    };
                    _projectsLines.Add(projectLine);
                    dgList.DataSource = null;
                    dgList.DataSource = _projectsLines;

                    ComputeTotal();
                }
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            int productId;
            string productName;
            double price;

            if (string.IsNullOrWhiteSpace(txtProductQty.Text))
            {
                MessageBox.Show("Please enter quantity and discount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnNonStock.Checked && string.IsNullOrWhiteSpace(txtNonStock.Text))
            {
                MessageBox.Show("Please enter non-stock item name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnNonStock.Checked && string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                MessageBox.Show("Please select a product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // For non-stock items
            if (btnNonStock.Checked)
            {
                productId = 0;
                productName = txtNonStock.Text.Trim();
                price = 0.00;
            }
            else
            {
                productId = (int)txtProduct.SelectedValue;

                // Get total stock-in quantity
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
                var currentQty = int.TryParse(txtProductQty.Text, out var qty) ? qty : 0;

                var userDepartment = Settings.Default.Department;
                var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);

                var isAdmin = userDepartment == Departments.Admin.ToString();
                var canOverride = appUserRoles != null && appUserRoles.Contains(TaskRoles.Override);

                var allowOverride = false;

                // Centralized override logic
                if (currentQty > availableStock || availableStock <= 0)
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

                // Only proceed if there is enough stock, or override is allowed
                if (currentQty > availableStock && !allowOverride)
                {
                    // This is a secondary check for when override is declined
                    MessageBox.Show("Insufficient stock for the selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var product = _unitOfWork.Product.Value.Get(c => c.ProductId == productId, includeProperties: "ProductIncrements");
                if (product == null)
                {
                    MessageBox.Show("Selected product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                productId = product.ProductId;
                productName = product.ProductName;
                price = product.DefaultSellingPrice + (product.ProductIncrements.Any() ? product.ProductIncrements.Sum(c => c.Increment) : 0);

                if (_projectsLines.Any(c => c.ProductId == productId))
                {
                    MessageBox.Show("Item is already added.", "Item Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            double quantity = double.TryParse(txtProductQty.Text, out var qty2) ? qty2 : 0.0;
            double discountPercent = double.TryParse(txtProductDiscount.Text, out var disc) ? disc / 100 : 0.0;
            double subTotal = (price * quantity) - (price * discountPercent);

            _projectsLines.Add(new SalesOrderLineViewModel
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                DiscountPercentage = discountPercent,
                SubTotal = subTotal,
                Delete = Resources.delete
            });
            dgList.DataSource = null;
            dgList.DataSource = _projectsLines;

            ComputeTotal();
        }


        private void ComputeTotal()
        {
            // Sum of all line item subtotals
            var total = _projectsLines.Sum(c => c.SubTotal);
            txtTotal.Text = total.ToString("N2");

            // Sum individual columns
            var totalPrice = _projectsLines.Sum(c => c.Price);
            var totalQuantity = _projectsLines.Sum(c => c.Quantity);

            // Calculate gross total (not always Price × Quantity globally — this might double-count)
            var grossTotal = _projectsLines.Sum(c => c.Price * c.Quantity);

            // Calculate discount from expected gross total to current total
            var discount = grossTotal - total;

            // Subtotal after discount (same as 'total' if discount already applied)
            var subTotal = grossTotal - discount;

            // Tax calculation (12% VAT)
            var tax = subTotal * 0.12;

            // Freight input parsing
            var freight = double.TryParse(txtFreight.Text, out var freightValue) ? freightValue : 0.0;

            // Final overall total
            var overallTotal = subTotal + tax + freight;

            // Optionally show intermediate values on UI
            txtTax.Text = tax.ToString("N2");
            txtDiscount.Text = discount.ToString("N2");
            txtSubtotal.Text = subTotal.ToString("N2");
            txtOverallTotal.Text = overallTotal.ToString("N2");
        }


        private void dgList_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            // Ensure it's the column we want to monitor
            var columnName = dgList.CurrentCell?.Column?.MappingName;
            if (columnName != "Price" && columnName != "Quantity" && columnName != "DiscountPercentage")
                return;

            // Get the currently edited row's data object
            var record = dgList.GetRecordAtRowIndex(dgList.CurrentCell.RowIndex) as SalesOrderLineViewModel;
            if (record == null) return;

            // Ensure values are valid
            double price = record.Price;
            double quantity = record.Quantity;
            double discountPercent = record.DiscountPercentage;

            double subtotal = price * quantity;
            double discountAmount = subtotal * (discountPercent / 100);
            record.SubTotal = Math.Round(subtotal - discountAmount, 2);
            // Refresh the grid to show updated SubTotal
            dgList.Refresh();

            ComputeTotal();
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                // Remove the selected row
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderLineViewModel row)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        var record = _projectsLines.FirstOrDefault(c => c.ProductId == row.ProductId);
                        if (record != null)
                        {
                            _projectsLines.Remove(record);
                            dgList.DataSource = null;
                            dgList.DataSource = _projectsLines;
                            ComputeTotal();
                        }
                    }
                }
            }
        }

        private void txtFreight_TextChanged(object sender, EventArgs e)
        {
            ComputeTotal();
        }

        private void buttonShipmentPrevious_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = true;
            panelPayment.Visible = false;
            panelProducts.Visible = false;
            panelShipment.Visible = false;
            progressBar.Value = 0;
        }

        private void buttonShipmentNext_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = true;
            panelShipment.Visible = false;
            progressBar.Value = 2;
        }

        private void buttonProductNext_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = true;
            panelProducts.Visible = false;
            panelShipment.Visible = false;
            progressBar.Value = 3;
        }

        private void buttonProductsPrevious_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = false;
            panelShipment.Visible = true;
            progressBar.Value = 1;
        }

        private void buttonDetailsNext_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = false;
            panelShipment.Visible = true;
            progressBar.Value = 1;
        }

        private void buttonPaymentPrevious_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = true;
            panelShipment.Visible = false;
            progressBar.Value = 2;
        }

        private void btnNoShipment_CheckStateChanged(object sender, EventArgs e)
        {
            panelShipmentInner.Visible = !btnNoShipment.Checked;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            buttonShipmentPrevious_Click(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            buttonDetailsNext_Click(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            buttonShipmentNext_Click(sender, e);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            buttonProductNext_Click(sender, e);
        }
    }
}
