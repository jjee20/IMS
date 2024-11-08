using DomainLayer.Models;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
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
    public partial class PurchaseOrderView : UserControl, IPurchaseOrderView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public PurchaseOrderView()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage2);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Add New
            btnAdd.Click += delegate
            {
                if (tabControl1.TabPages.Contains(tabPage1))
                {
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Add New";
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                    MessageBox.Show(Message);
                }
                btnReturn.Visible = false;
            };
            txtSearch.TextChanged += (s, e) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Edit
            btnEdit.Click += delegate
            {
                if (tabControl1.TabPages.Contains(tabPage1))
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Edit";
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected customer type?", "Warning",
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
                if (!tabControl1.TabPages.Contains(tabPage1))
                {
                    RefreshEvent?.Invoke(this, EventArgs.Empty);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                }
                btnReturn.Visible = false;
            };
        }

        //Properties
        public int PurchaseOrderId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string PurchaseOrderName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int BranchId
        {
            get { return (int)txtBranch.SelectedValue; }
            set { txtBranch.Text = value.ToString(); }
        }
        public int VendorId
        {
            get { return (int)txtVendor.SelectedValue; }
            set { txtVendor.Text = value.ToString(); }
        }
        public DateTimeOffset OrderDate
        {
            get { return txtPurchaseOrderDate.Value; }
            set { txtPurchaseOrderDate.Text = value.ToString(); }
        }
        public DateTimeOffset DeliveryDate
        {
            get { return txtPurchaseOrderDueDate.Value; }
            set { txtPurchaseOrderDueDate.Text = value.ToString(); }
        }
        public int CurrencyId
        {
            get { return (int)txtCurrency.SelectedValue; }
            set { txtCurrency.Text = value.ToString(); }
        }
        public int PurchaseTypeId
        {
            get { return (int)txtPurchaseType.SelectedValue; }
            set { txtPurchaseType.Text = value.ToString(); }
        }
        public string Remarks
        {
            get { return txtRemarks.Text; }
            set { txtRemarks.Text = value; }
        }
        public double Amount
        {
            get { return Convert.ToDouble(txtAmount.Text); }
            set { txtAmount.Text = value.ToString(); }
        }
        public double SubTotal
        {
            get { return PurchaseOrderLines.Select(c => c.Total).Sum(); }
            set { txtSubTotal.Text = value.ToString(); }
        }
        public double Discount
        {
            get { return Convert.ToDouble(txtDiscount.Text); }
            set { txtDiscount.Text = value.ToString(); }
        }
        public double Tax
        {
            get { return Convert.ToDouble(txtTax.Text); }
            set { txtTax.Text = value.ToString(); }
        }
        public double Freight
        {
            get { return Convert.ToDouble(txtFreight.Text); }
            set { txtFreight.Text = value.ToString(); }
        }
        public double Total
        {
            get { return SubTotal - (SubTotal * Discount) + (SubTotal * Tax) + Freight; }
            set { txtTotal.Text = value.ToString(); }
        }
        public List<PurchaseOrderLine> PurchaseOrderLines
        {
            get { return (List<PurchaseOrderLine>)dgOrderLine.DataSource; }
            set { dgOrderLine.DataSource = value; }
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

        public void SetPurchaseOrderListBindingSource(BindingSource PurchaseOrderList)
        {
            dgList.DataSource = PurchaseOrderList;
        }
        public void SetPurchaseTypeListBindingSource(BindingSource PurchaseTypeBindingSource)
        {
            txtPurchaseType.DataSource = PurchaseTypeBindingSource;
            txtPurchaseType.DisplayMember = "PurchaseTypeName";
            txtPurchaseType.ValueMember = "PurchaseTypeId";
        }
        public void SetBranchListBindingSource(BindingSource BranchListBindingSource)
        {
            txtBranch.DataSource = BranchListBindingSource;
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
        }
        public void SetVendorListBindingSource(BindingSource VendorListBindingSource)
        {
            txtVendor.DataSource = VendorListBindingSource;
            txtVendor.DisplayMember = "VendorName";
            txtVendor.ValueMember = "VendorId";
        }
        public void SetCurrencyListBindingSource(BindingSource CurrencyListBindingSource)
        {
            txtCurrency.DataSource = CurrencyListBindingSource;
            txtCurrency.DisplayMember = "CurrencyName";
            txtCurrency.ValueMember = "CurrencyId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

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
    }
}
