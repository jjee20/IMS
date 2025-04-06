using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
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
    public partial class PurchaseOrderView : SfForm, IPurchaseOrderView
    {
        private BindingSource _PurchaseOrderLineBindingSource = new BindingSource();
        private int id = 0;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public PurchaseOrderView()
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
                }
                btnReturn.Visible = true;
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Purchase order?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Invoke the DeleteEvent with the selected row as an argument
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    
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

            txtStartDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtEndDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            btnProductAdd.Click += delegate
            {
                if (!string.IsNullOrEmpty(Message)) 
                ProductAddEvent?.Invoke(this, EventArgs.Empty);
            };

            txtDiscount.TextChanged += delegate
            {
                PaymentDiscountEvent?.Invoke(this, EventArgs.Empty);
            };

            txtFreight.TextChanged += delegate
            {
                FreightEvent?.Invoke(this, EventArgs.Empty);
            };

            dgList.CellDoubleClick += (sender, e) =>
            {
                PrintPOEvent?.Invoke(this, e);
            };
            dgPurchaseLine.CellEndEdit += (sender, e) =>
            {
                UpdateComputationEvent?.Invoke(this, e);
            };
            dgPurchaseLine.CellDoubleClick += (sender, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Invoke the DeleteEvent with the selected row as an argument
                    DeleteProductEvent?.Invoke(this, e);
                    
                }
            };
            btnGRN.Click += delegate
            {
                GRNEvent?.Invoke(this, EventArgs.Empty);
            };
            btnBill.Click += delegate
            {
                BillEvent?.Invoke(this, EventArgs.Empty);
            };
            btnPaymentVoucher.Click += delegate
            {
                PaymentVoucherEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        //PropertiesdgList
        public SfDataGrid DataGrid => dgList;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PurchaseOrderId
        {
            get { return Convert.ToInt32(id); }
            set { id = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PurchaseOrderName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get { return txtStartDate.Value; }
            set { txtStartDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndDate
        {
            get { return txtEndDate.Value; }
            set { txtEndDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BranchId
        {
            get { return (int)txtBranch.SelectedValue; }
            set { txtBranch.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VendorId
        {
            get { return (int)txtVendor.SelectedValue; }
            set { txtVendor.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset OrderDate
        {
            get { return txtPurchaseOrderDate.Value; }
            set { txtPurchaseOrderDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset DeliveryDate
        {
            get { return txtDeliveryDate.Value; }
            set { txtDeliveryDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PurchaseTypeId
        {
            get { return (int)txtPurchaseType.SelectedValue; }
            set { txtPurchaseType.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Remarks
        {
            get { return txtRemarks.Text; }
            set { txtRemarks.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Amount
        {
            get { return Convert.ToDouble(txtAmount.Text); }
            set { txtAmount.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double SubTotal
        {
            get { return Convert.ToDouble(txtSubTotal.Text); }
            set { txtSubTotal.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Discount
        {
            get
            {
                if (double.TryParse(txtProductDiscount.Text, out double discount))
                {
                    string discountText = txtDiscount.Text.Replace("%", "").Trim();
                    return Convert.ToDouble(discountText) / 100;
                }
                return 0;
            }
            set { txtDiscount.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Tax
        {
            get { return Convert.ToDouble(txtTax.Text); }
            set { txtTax.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Freight
        {
            get
            {
                if (double.TryParse(txtFreight.Text, out double freight))
                {
                    return freight;
                }
                return 0;
            }
            set { txtFreight.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Total
        {
            get { return Convert.ToDouble(txtTotal.Text); }
            set { txtTotal.Text = value.ToString("N2"); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PurchaseOrderLineViewModel> PurchaseOrderLines
        {
            get { return _PurchaseOrderLineBindingSource.DataSource as List<PurchaseOrderLineViewModel>; }
            set
            {
                _PurchaseOrderLineBindingSource.DataSource = value;
                dgPurchaseLine.DataSource = _PurchaseOrderLineBindingSource;
                DataGridHelper.ApplyDisplayNames<PurchaseOrderLineViewModel>(_PurchaseOrderLineBindingSource, dgPurchaseLine);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        //Add Product

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId
        {
            get { return Convert.ToInt32(txtProduct.SelectedValue); }
            set { txtProduct.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProductQuantity
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProductPrice
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NonStock
        {
            get { return btnNonStock.Checked; }
            set { btnNonStock.Checked = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NonStockProductName
        {
            get { return txtNonStock.Text; }
            set { txtNonStock.Text = value; }
        }
        public void SetPurchaseOrderListBindingSource(IEnumerable<PurchaseOrderViewModel> PurchaseOrderList)
        {
            dgPager.DataSource = PurchaseOrderList;
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetPurchaseOrderLineListBindingSource(BindingSource PurchaseOrderLineList)
        {
            dgPurchaseLine.DataSource = PurchaseOrderLineList;
            DataGridHelper.ApplyDisplayNames<PurchaseOrderLineViewModel>(PurchaseOrderLineList, dgPurchaseLine);
        }

        public void SetPurchaseTypeListBindingSource(BindingSource PurchaseTypeBindingSource)
        {
            txtPurchaseType.DataSource = PurchaseTypeBindingSource;
            txtPurchaseType.DisplayMember = "PurchaseTypeName";
            txtPurchaseType.ValueMember = "PurchaseTypeId";
        }
        public void SetBranchListBindingSource(BindingSource BranchBindingSource)
        {
            txtBranch.DataSource = BranchBindingSource;
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
        }
        public void SetVendorListBindingSource(BindingSource VendorBindingSource)
        {
            txtVendor.DataSource = VendorBindingSource;
            txtVendor.DisplayMember = "VendorName";
            txtVendor.ValueMember = "VendorId";
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
        public event EventHandler PaymentDiscountEvent;
        public event EventHandler FreightEvent;
        public event EventHandler GRNEvent;
        public event EventHandler BillEvent;
        public event EventHandler PaymentVoucherEvent;
        public event EventHandler PrintPOEvent;
        public event EventHandler DeleteProductEvent;
        public event EventHandler UpdateComputationEvent;

        private static PurchaseOrderView? instance;
        public static PurchaseOrderView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchaseOrderView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
        private void btnNonStock_CheckedChanged_1(object sender, EventArgs e)
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

        private void dgPurchaseLine_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgPurchaseLine.Columns["Price"].Index || e.ColumnIndex == dgPurchaseLine.Columns["Quantity"].Index || e.ColumnIndex == dgPurchaseLine.Columns["DiscountPercentage"].Index)
            {
                // Get the value from Column1
                var editedValue = dgPurchaseLine.Rows[e.RowIndex].Cells["Price"].Value;
                var qtyValue = dgPurchaseLine.Rows[e.RowIndex].Cells["Quantity"].Value;
                var discountValue = dgPurchaseLine.Rows[e.RowIndex].Cells["DiscountPercentage"].Value;

                // Perform some computation or logic (example: doubling the value)
                if (int.TryParse(editedValue?.ToString(), out int result))
                {
                    if (int.TryParse(qtyValue?.ToString(), out int qtyResult))
                    {
                        if (int.TryParse(discountValue?.ToString(), out int discountResult))
                        {
                            // Update the value in Column2
                            var subTotal = result * qtyResult;
                            dgPurchaseLine.Rows[e.RowIndex].Cells["SubTotal"].Value = subTotal - (subTotal * discountResult/ 100);
                        }
                    }
                }
                else
                {
                    // Handle invalid input (optional)
                    dgPurchaseLine.Rows[e.RowIndex].Cells["Price"].Value = "Invalid";
                }
            }
        }
    }
}
