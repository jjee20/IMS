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
    public partial class UpsertProjectView : SfForm
    {
        string message;
        private Project _entity;
        private List<ProjectLineViewModel> _projectsLines;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertProjectView(IUnitOfWork unitOfWork, Project? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Project();
            _projectsLines = new List<ProjectLineViewModel>();

            LoadProducts();
            LoadEntityToForm();
        }

        private void LoadProducts()
        {
            txtProduct.DataSource = _unitOfWork.Product.Value.GetAll();
            txtProduct.DisplayMember = "DisplayInfo";
            txtProduct.ValueMember = "ProductId";
        }

        private void LoadEntityToForm()
        {
            if (_entity.ProjectId > 0)
            {
                txtProjectName.Text = _entity.ProjectName;
                txtDescription.Text = _entity.Description;
                txtStartDate.Value = _entity.StartDate;
                txtEndDate.Value = _entity.EndDate;
                txtNonStock.Visible = false;
                btnNonStock.Checked = false;
                txtClient.Text = _entity.Client;
                txtBudget.Text = _entity.Budget.ToString();

                if (_entity.ProjectLines == null) _entity.ProjectLines = new List<ProjectLine>();

                foreach (var line in _entity.ProjectLines)
                {
                    var projectLine = new ProjectLineViewModel
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
            _entity.ProjectName = txtProjectName.Text.Trim();
            _entity.Description = txtDescription.Text.Trim();
            _entity.StartDate = txtStartDate.Value;
            _entity.EndDate = txtEndDate.Value;

            _entity.Client = txtClient.Text.Trim();
            _entity.Budget = double.TryParse(txtBudget.Text, out var budget) ? budget : 0.0;

            _entity.ProjectLines = _projectsLines.Select(c => new ProjectLine
            {
                ProjectId = _entity.ProjectId,
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                Price = c.Price,
                Quantity = c.Quantity,
                DiscountPercentage = c.DiscountPercentage,
                SubTotal = c.SubTotal
            }).ToList();
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void buttonDetailsNext_Click(object sender, EventArgs e)
        {
            progressBar.Value++;
            panelDetails.Visible = false;
            panelProducts.Visible = true;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            progressBar.Value--;
            panelDetails.Visible = true;
            panelProducts.Visible = false;
        }

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                MessageBox.Show("Please enter a project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_projectsLines.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtStartDate.Value > txtEndDate.Value)
            {
                MessageBox.Show("End date must be greater than start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_entity.ProjectId > 0)
            {
                var result = MessageBox.Show("Are you sure you want to update the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   var oldProjectLines = await _unitOfWork.ProjectLine.Value.GetAllAsync(c => c.ProjectId == _entity.ProjectId, tracked: true);
                    _unitOfWork.ProjectLine.Value.RemoveRange(oldProjectLines);
                    await _unitOfWork.SaveAsync();

                    _entity.ProjectLines.Clear();

                    UpdateEntityFromForm();
                    _unitOfWork.Project.Value.UpdateWithChildren(_entity, p => p.ProjectLines, pl => pl.ProjectLineId);
                    message = "Project updated successfully.";
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to add the project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _unitOfWork.Project.Value.AddAsync(_entity);
                    message = "Project added successfully.";
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
                    var projectLine = new ProjectLineViewModel
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
                price = product.DefaultBuyingPrice;

                if (_projectsLines.Any(c => c.ProductId == productId))
                {
                    MessageBox.Show("Item is already added.", "Item Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            double quantity = double.TryParse(txtProductQty.Text, out var qty) ? qty : 0.0;
            double discountPercent = double.TryParse(txtProductDiscount.Text, out var disc) ? disc / 100 : 0.0;
            double subTotal = (price * quantity) - (price * discountPercent);

            _projectsLines.Add(new ProjectLineViewModel
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
            var total = _projectsLines.Sum(c => c.SubTotal);
            txtTotal.Text = total.ToString("N2");
        }

        private void dgList_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            // Ensure it's the column we want to monitor
            var columnName = dgList.CurrentCell?.Column?.MappingName;
            if (columnName != "Price" && columnName != "Quantity" && columnName != "DiscountPercentage")
                return;

            // Get the currently edited row's data object
            var record = dgList.GetRecordAtRowIndex(dgList.CurrentCell.RowIndex) as ProjectLineViewModel;
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
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProjectLineViewModel row)
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

        private void btn1_Click(object sender, EventArgs e)
        {
            buttonPrevious_Click(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            buttonDetailsNext_Click(sender, e);
        }
    }
}
