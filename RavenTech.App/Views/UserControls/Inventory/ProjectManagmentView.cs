using DomainLayer.Models;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProjectManagementView : UserControl, IProjectManagementView
    {
        private BindingSource _ProjectLineBindingSource = new BindingSource();
        private int id = 0;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ProjectManagementView()
        {
            InitializeComponent();
            Guna2TabControl1.TabPages.Remove(tabPage2);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Add New
            btnAdd.Click += delegate
            {
                if (Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Add New";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                    btnReturn.Visible = true;
                }
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    Guna2TabControl1.TabPages.Remove(tabPage2);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                    btnReturn.Visible = false;
                }
                MessageBox.Show(Message);
            };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                txtSearch.Focus();
            };
            //Edit
            btnEdit.Click += delegate
            {
                if (Guna2TabControl1.SelectedTab == tabPage1)
                {
                    tabPage2.Text = "Edit Details";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                EditEvent?.Invoke(this, EventArgs.Empty);
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected project?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Invoke the DeleteEvent with the selected row as an argument
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            //Print
            btnPrint.Click += delegate
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
            };
            //Refresh
            btnReturn.Click += delegate
            {
                if (!Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    RefreshEvent?.Invoke(this, EventArgs.Empty);
                    Guna2TabControl1.TabPages.Remove(tabPage2);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                }
                btnReturn.Visible = false;
            };

            btnProductAdd.Click += delegate
            {
                if (!string.IsNullOrEmpty(Message)) MessageBox.Show(Message);
                ProductAddEvent?.Invoke(this, EventArgs.Empty);
            };

            dgList.CellDoubleClick += (sender, e) =>
            {
                PrintProjectEvent?.Invoke(this, e);

                if (!isSuccessful)
                {
                    MessageBox.Show(Message);
                }
            };

            dgOrderLine.CellDoubleClick += (sender, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Invoke the DeleteEvent with the selected row as an argument
                    DeleteProductEvent?.Invoke(this, e);
                    MessageBox.Show(Message);
                }
            };
            dgOrderLine.CellEndEdit += (sender, e) =>
            {
                UpdateComputationEvent?.Invoke(this, e);
            };
        }

        //PropertiesdgList
        public SfDataGrid DataGrid => dgList;
        public int ProjectId
        {
            get { return Convert.ToInt32(id); }
            set { id = value; }
        }

        public string ProjectName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string Client
        {
            get { return txtClient.Text; }
            set { txtClient.Text = value; }
        }
        public DateTime StartDate
        {
            get { return txtStartDate.Value; }
            set { txtStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate
        {
            get { return txtEndDate.Value; }
            set { txtEndDate.Text = value.ToString(); }
        }
        public double Budget
        {
            get { return Convert.ToDouble(txtBudget.Text); }
            set { txtBudget.Text = value.ToString(); }
        }
        public double Revenue
        {
            get { return Convert.ToDouble(txtRevenue.Text); }
            set { txtRevenue.Text = value.ToString(); }
        }
        public List<ProjectLineViewModel> ProjectLines
        {
            get { return _ProjectLineBindingSource.DataSource as List<ProjectLineViewModel>; }
            set
            {
                _ProjectLineBindingSource.DataSource = value;
                dgOrderLine.DataSource = _ProjectLineBindingSource;
                DataGridHelper.ApplyDisplayNames<ProjectLineViewModel>(_ProjectLineBindingSource, dgOrderLine);
            }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        //Add Product

        public int ProductId
        {
            get { return Convert.ToInt32(txtProduct.SelectedValue); }
            set { txtProduct.Text = value.ToString(); }
        }
        public double ProductQuantity
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        public double ProductPrice
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        public double ProductDiscount
        {
            get
            {
                if (double.TryParse(txtProductDiscount.Text, out double discount))
                {
                    return discount;
                }
                return 0;
            }
            set
            {
                txtProductDiscount.Text = value.ToString("N2");
            }
        }



        public bool NonStock
        {
            get { return btnNonStock.Checked; }
            set { btnNonStock.Checked = value; }
        }

        public double Total
        {
            get { return Convert.ToDouble(txtAmount.Text); }
            set { txtAmount.Text = value.ToString("N2"); }
        }
        public string NonStockProductName
        {
            get { return txtNonStock.Text; }
            set { txtNonStock.Text = value; }
        }
        public void SetProjectListBindingSource(BindingSource ProjectList)
        {
            dgPager.DataSource = ProjectList.ToList<ProjectViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetProjectLineListBindingSource(BindingSource ProjectLineList)
        {
            dgOrderLine.DataSource = ProjectLineList;
            DataGridHelper.ApplyDisplayNames<ProjectLineViewModel>(ProjectLineList, dgOrderLine);
        }
        public void SetProductListBindingSource(BindingSource ProductBindingSource)
        {
            txtProduct.DataSource = ProductBindingSource;
            txtProduct.DisplayMember = "DisplayInfo";
            txtProduct.ValueMember = "ProductId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;
        public event EventHandler ProductAddEvent;
        public event EventHandler PrintProjectEvent;
        public event EventHandler DeleteProductEvent;
        public event EventHandler UpdateComputationEvent;

        private static ProjectManagementView? instance;
        public static ProjectManagementView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProjectManagementView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void dgOrderLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgOrderLine.Columns["Price"].Index || e.ColumnIndex == dgOrderLine.Columns["Quantity"].Index || e.ColumnIndex == dgOrderLine.Columns["DiscountPercentage"].Index)
            {
                // Get the value from Column1
                var editedValue = dgOrderLine.Rows[e.RowIndex].Cells["Price"].Value;
                var qtyValue = dgOrderLine.Rows[e.RowIndex].Cells["Quantity"].Value;
                var discountValue = dgOrderLine.Rows[e.RowIndex].Cells["DiscountPercentage"].Value;

                // Perform some computation or logic (example: doubling the value)
                if (int.TryParse(editedValue?.ToString(), out int result))
                {
                    if (int.TryParse(qtyValue?.ToString(), out int qtyResult))
                    {
                        if (int.TryParse(discountValue?.ToString(), out int discountResult))
                        {
                            // Update the value in Column2
                            var subTotal = result * qtyResult;
                            dgOrderLine.Rows[e.RowIndex].Cells["SubTotal"].Value = subTotal - (subTotal * discountResult / 100);
                        }
                    }
                }
                else
                {
                    // Handle invalid input (optional)
                    dgOrderLine.Rows[e.RowIndex].Cells["Price"].Value = "Invalid";
                }
            }
        }

        private void btnNonStock_CheckedChanged(object sender, EventArgs e)
        {
            if (btnNonStock.Checked)
            {
                txtProduct.Visible = false;
                txtNonStock.Visible = true;
            }
            else
            {
                txtProduct.Visible = true;
                txtNonStock.Visible = false;
            }
        }
    }
}
