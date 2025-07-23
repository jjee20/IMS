using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.UserControls.Inventory.Searches;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertPurchaseOrderView : SfForm
    {
        string message;
        private PurchaseOrder _entity;
        private List<PurchaseOrderLineViewModel> _projectsLines;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertPurchaseOrderView(IUnitOfWork unitOfWork, PurchaseOrder? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new PurchaseOrder();
            _projectsLines = new List<PurchaseOrderLineViewModel>();

            LoadAllProductList();
            LoadAllPurchaseTypeList();
            LoadAllBranchList();
            LoadAllVendorList();
            LoadEntityToForm();
        }

        private void LoadAllVendorList()
        {
            txtVendor.DataSource = _unitOfWork.Vendor.Value.GetAll();
            txtVendor.DisplayMember = "VendorName";
            txtVendor.ValueMember = "VendorId";
            txtVendor.Text = "~Select Vendor~";
        }

        private void LoadAllBranchList()
        {
            txtBranch.DataSource = _unitOfWork.Branch.Value.GetAll();
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
            txtBranch.Text = "~Select Branch~";
        }

        private void LoadAllPurchaseTypeList()
        {
            txtPurchaseType.DataSource = _unitOfWork.PurchaseType.Value.GetAll();
            txtPurchaseType.DisplayMember = "PurchaseTypeName";
            txtPurchaseType.ValueMember = "PurchaseTypeId";
            txtPurchaseType.Text = "~Select Purchase Type~";
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
            if (_entity.PurchaseOrderId > 0)
            {
                txtPurchaseOrderName.Text = _entity.PurchaseOrderName;
                txtBranch.SelectedValue = _entity.BranchId;
                txtVendor.SelectedValue = _entity.VendorId;
                txtOrderDate.Value = _entity.OrderDate.DateTime;
                txtDeliveryDate.Value = _entity.DeliveryDate.DateTime;
                txtPurchaseType.SelectedValue = _entity.PurchaseTypeId;
                txtRemarks.Text = _entity.Remarks;
                txtAmount.Text = _entity.Amount.ToString("N2");
                txtSubtotal.Text = _entity.SubTotal.ToString("N2");
                txtDiscount.Text = _entity.Discount.ToString("N2");
                txtTax.Text = _entity.Tax.ToString("N2");
                txtFreight.Text = _entity.Freight.ToString("N2");
                txtOverallTotal.Text = _entity.Total.ToString("N2");

                if (_entity.PurchaseOrderLines == null) _entity.PurchaseOrderLines = new List<PurchaseOrderLine>();

                foreach (var line in _entity.PurchaseOrderLines)
                {
                    var projectLine = new PurchaseOrderLineViewModel
                    {
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
            _entity.PurchaseOrderName = txtPurchaseOrderName.Text.Trim();
            _entity.BranchId = (int)txtBranch.SelectedValue;
            _entity.VendorId = (int)txtVendor.SelectedValue;
            _entity.OrderDate = (DateTimeOffset)txtOrderDate.Value;
            _entity.DeliveryDate = (DateTimeOffset)txtDeliveryDate.Value;
            _entity.PurchaseTypeId = (int)txtPurchaseType.SelectedValue;
            _entity.Remarks = txtRemarks.Text.Trim();
            _entity.Amount = double.TryParse(txtAmount.Text, out var amountValue) ? amountValue : 0.0;
            _entity.SubTotal = double.TryParse(txtSubtotal.Text, out var subtotalValue) ? subtotalValue : 0.0;
            _entity.Discount = double.TryParse(txtDiscount.Text, out var discountValue) ? discountValue : 0.0;
            _entity.Tax = double.TryParse(txtTax.Text, out var taxValue) ? taxValue : 0.0;
            _entity.Freight = double.TryParse(txtFreight.Text, out var freightValue) ? freightValue : 0.0;
            _entity.Total = double.TryParse(txtOverallTotal.Text, out var totalValue) ? totalValue : 0.0;

            _entity.PurchaseOrderLines = _projectsLines.Select(c => new PurchaseOrderLine
            {
                PurchaseOrderId = _entity.PurchaseOrderId,
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                Price = c.Price,
                Quantity = c.Quantity,
                DiscountPercentage = c.DiscountPercentage,
                SubTotal = c.SubTotal
            }).ToList();

            var total = _projectsLines.Sum(c => c.SubTotal);
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private async void buttonConfirm_Click_1(object sender, EventArgs e)
        {
                    UpdateEntityFromForm();
            if (string.IsNullOrWhiteSpace(txtPurchaseOrderName.Text))
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

            if (_entity.PurchaseOrderId > 0)
            {
                var result = MessageBox.Show("Are you sure you want to update the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    var oldLines = await _unitOfWork.PurchaseOrderLine.Value.GetAllAsync(c => c.PurchaseOrderId == _entity.PurchaseOrderId, tracked: true);
                    _unitOfWork.PurchaseOrderLine.Value.RemoveRange(oldLines);
                    await _unitOfWork.SaveAsync();

                    _unitOfWork.PurchaseOrder.Value.Update(_entity);
                    message = "PurchaseOrder updated successfully.";
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to add the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _unitOfWork.PurchaseOrder.Value.AddAsync(_entity);
                    message = "PurchaseOrder added successfully.";
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
                    var projectLine = new PurchaseOrderLineViewModel
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

            if (btnNonStock.Checked)
            {
                productId = 0;
                productName = txtNonStock.Text.Trim();
                price = 0.00;
            }
            else
            {
                var product = _unitOfWork.Product.Value.Get(c => c.ProductId == (int)txtProduct.SelectedValue);
                if (product == null)
                {
                    MessageBox.Show("Selected product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                productId = product.ProductId;
                productName = product.ProductName;
                price = product.DefaultSellingPrice;

                if (_projectsLines.Any(c => c.ProductId == productId))
                {
                    MessageBox.Show("Item is already added.", "Item Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            double quantity = double.TryParse(txtProductQty.Text, out var qty) ? qty : 0.0;
            double discountPercent = double.TryParse(txtProductDiscount.Text, out var disc) ? disc / 100 : 0.0;
            double subTotal = (price * quantity) - (price * discountPercent);

            _projectsLines.Add(new PurchaseOrderLineViewModel
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
            var record = dgList.GetRecordAtRowIndex(dgList.CurrentCell.RowIndex) as PurchaseOrderLineViewModel;
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
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderLineViewModel row)
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

        private void buttonProductNext_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = true;
            panelProducts.Visible = false;
            progressBar.Value = 2;
        }

        private void buttonProductsPrevious_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = true;
            panelPayment.Visible = false;
            panelProducts.Visible = false;
            progressBar.Value = 0;
        }

        private void buttonDetailsNext_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = true;
            progressBar.Value = 1;
        }

        private void buttonPaymentPrevious_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelPayment.Visible = false;
            panelProducts.Visible = true;
            progressBar.Value = 1;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            buttonProductNext_Click(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            buttonDetailsNext_Click(sender, e);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            buttonProductsPrevious_Click(sender, e);
        }
    }
}
