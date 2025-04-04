using DomainLayer.ViewModels.Inventory;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel;

namespace PresentationLayer.Views.UserControls
{
    public partial class SalesOrderView : SfForm, ISalesOrderView
    {
        private BindingSource _salesOrderLineBindingSource = new BindingSource();
        private int id = 0;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public SalesOrderView()
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
            txtStartDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtEndDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
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
                var result = MessageBox.Show("Are you sure you want to delete the selected sales order?", "Warning",
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
            btnInvoice.Click += delegate
            {
                InvoiceEvent?.Invoke(this, EventArgs.Empty);
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

            txtDiscount.TextChanged += delegate
            {
                PaymentDiscountEvent?.Invoke(this, EventArgs.Empty);
            };

            txtFreight.TextChanged += delegate
            {
                FreightEvent?.Invoke(this, EventArgs.Empty);
            };
            
            btnPayment.Click += delegate
            {
                PaymentEvent?.Invoke(this, EventArgs.Empty);
            };

            dgList.CellDoubleClick += (sender, e) =>
            {
                PrintSOEvent?.Invoke(this, e);
            };

            dgOrderLine.CellEndEdit += (sender, e) =>
            {
                UpdateComputationEvent?.Invoke(this, e);
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
        }

        //PropertiesdgList
        public SfDataGrid DataGrid => dgList; 
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SalesOrderId
        {
            get { return Convert.ToInt32(id); }
            set { id = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SalesOrderName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get { return txtStartDate.Value; }
            set { txtStartDate.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndDate
        {
            get { return txtEndDate.Value; }
            set { txtEndDate.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BranchId
        {
            get { return (int)txtBranch.SelectedValue; }
            set { txtBranch.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CustomerId
        {
            get { return (int)txtCustomer.SelectedValue; }
            set { txtCustomer.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset OrderDate
        {
            get { return txtSalesOrderDate.Value; }
            set { txtSalesOrderDate.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset DeliveryDate
        {
            get { return txtDeliveryDate.Value; }
            set { txtDeliveryDate.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SalesTypeId
        {
            get { return (int)txtSalesType.SelectedValue; }
            set { txtSalesType.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Remarks
        {
            get { return txtRemarks.Text; }
            set { txtRemarks.Text = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerRefNumber
        {
            get { return txtCustomerRefNumber.Text; }
            set { txtCustomerRefNumber.Text = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Amount
        {
            get { return Convert.ToDouble(txtAmount.Text); }
            set { txtAmount.Text = value.ToString("N2"); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double SubTotal
        {
            get { return Convert.ToDouble(txtSubTotal.Text); }
            set { txtSubTotal.Text = value.ToString("N2"); }
        }
        [Browsable(false)]
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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Tax
        {
            get { return Convert.ToDouble(txtTax.Text); }
            set { txtTax.Text = value.ToString("N2"); }
        }
        [Browsable(false)]
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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Total
        {
            get { return Convert.ToDouble(txtTotal.Text); }
            set { txtTotal.Text = value.ToString("N2"); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<SalesOrderLineViewModel> SalesOrderLines
        {
            get { return _salesOrderLineBindingSource.DataSource as List<SalesOrderLineViewModel>; }
            set
            {
                _salesOrderLineBindingSource.DataSource = value;
                dgOrderLine.DataSource = _salesOrderLineBindingSource;
                DataGridHelper.ApplyDisplayNames<SalesOrderLineViewModel>(_salesOrderLineBindingSource, dgOrderLine);
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ShipmentId
        {
            get { return id; }
            set { id = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShipmentName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset ShipmentDate
        {
            get { return txtShipmentDate.Value; }
            set { txtShipmentDate.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ShipmentTypeId
        {
            get { return (int)txtShipmentType.SelectedValue; }
            set { txtShipmentType.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int WarehouseId
        {
            get { return (int)txtWarehouse.SelectedValue; }
            set { txtWarehouse.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFullShipment
        {
            get { return txtIsFullShipment.Checked; }
            set { txtIsFullShipment.Checked = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        //Add Product
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId
        {
            get { return Convert.ToInt32(txtProduct.SelectedValue); }
            set { txtProduct.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProductQuantity
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProductPrice
        {
            get { return Convert.ToDouble(txtProductQty.Text); }
            set { txtProductQty.Text = value.ToString(); }
        }
        [Browsable(false)]
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
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NonStock
        {
            get { return btnNonStock.Checked; }
            set { btnNonStock.Checked = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoShipment
        {
            get { return txtShipment.Checked; }
            set { txtShipment.Checked = value; }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NonStockProductName
        {
            get { return txtNonStock.Text; }
            set { txtNonStock.Text = value; }
        }
        public void SetShipmentTypeListBindingSource(BindingSource ShipmentTypeBindingSource)
        {
            txtShipmentType.DataSource = ShipmentTypeBindingSource;
            txtShipmentType.DisplayMember = "ShipmentTypeName";
            txtShipmentType.ValueMember = "ShipmentTypeId";
        }
        public void SetWarehouseListBindingSource(BindingSource WarehouseListBindingSource)
        {
            txtWarehouse.DataSource = WarehouseListBindingSource;
            txtWarehouse.DisplayMember = "WarehouseName";
            txtWarehouse.ValueMember = "WarehouseId";
        }
        public void SetSalesOrderListBindingSource(IEnumerable<SalesOrderViewModel> SalesOrderList)
        {
            dgPager.DataSource = SalesOrderList;
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetSalesOrderLineListBindingSource(BindingSource SalesOrderLineList)
        {
            dgOrderLine.DataSource = SalesOrderLineList;
        }

        public void SetSalesTypeListBindingSource(BindingSource SalesTypeBindingSource)
        {
            txtSalesType.DataSource = SalesTypeBindingSource;
            txtSalesType.DisplayMember = "SalesTypeName";
            txtSalesType.ValueMember = "SalesTypeId";
        }
        public void SetBranchListBindingSource(BindingSource BranchBindingSource)
        {
            txtBranch.DataSource = BranchBindingSource;
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
        }
        public void SetCustomerListBindingSource(BindingSource CustomerBindingSource)
        {
            txtCustomer.DataSource = CustomerBindingSource;
            txtCustomer.DisplayMember = "CustomerName";
            txtCustomer.ValueMember = "CustomerId";
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
        public event EventHandler InvoiceEvent;
        public event EventHandler PaymentEvent;
        public event EventHandler PrintSOEvent;
        public event EventHandler DeleteProductEvent;
        public event EventHandler UpdateComputationEvent;

        private static SalesOrderView? instance;
        public static SalesOrderView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SalesOrderView();
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

        private void dgOrderLine_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
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

        private void txtShipment_CheckedChanged(object sender, EventArgs e)
        {
            shipmentPanel.Visible = txtShipment.Checked ? false : true;
        }
    }
}
