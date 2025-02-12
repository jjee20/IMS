using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class GoodsReceivedNoteView : UserControl, IGoodsReceivedNoteView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public GoodsReceivedNoteView()
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
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabPage2.Text = "Add New";
                if (Guna2TabControl1.SelectedTab == tabPage1)
                {
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                else
                {
                    Guna2TabControl1.TabPages.Remove(tabPage2);
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
                MessageBox.Show(Message);
            };
            txtSearch.TextChanged += (s, e) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
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
                var result = MessageBox.Show("Are you sure you want to delete the selected goods received note?", "Warning",
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
                RefreshEvent?.Invoke(this, EventArgs.Empty);
                Guna2TabControl1.TabPages.Remove(tabPage2);
                Guna2TabControl1.TabPages.Add(tabPage1);
            };
        }

        //Properties
        public int GoodsReceivedNoteId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string GoodsReceivedNoteName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int PurchaseOrderId
        {
            get { return (int)txtPurchaseOrder.SelectedValue; }
            set { txtPurchaseOrder.Text = value.ToString(); }
        }
        public DateTimeOffset GRNDate
        {
            get { return txtGRNDate.Value; }
            set { txtGRNDate.Text = value.ToString(); }
        }
        public string VendorDONumber
        {
            get { return txtVendorDONumber.Text.Trim().ToString(); }
            set { txtVendorDONumber.Text = value; }
        }
        public string VendorInvoiceNumber
        {
            get { return txtVendorInvoiceNumber.Text.Trim().ToString(); }
            set { txtVendorInvoiceNumber.Text = value; }
        }
        public int WarehouseId
        {
            get { return (int)txtWarehouse.SelectedValue; }
            set { txtWarehouse.Text = value.ToString(); }
        }
        public bool IsFullReceive
        {
            get { return txtIsFullReceive.Checked; }
            set { txtIsFullReceive.Checked = value; }
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

        public void SetGoodsReceivedNoteListBindingSource(BindingSource GoodsReceivedNoteList)
        {
            dgList.DataSource = GoodsReceivedNoteList;
            DataGridHelper.ApplyDisplayNames<GoodsReceiveNoteViewModel>(GoodsReceivedNoteList, dgList);
        }
        public void SetPurchaseOrderListBindingSource(BindingSource PurchaseOrderBindingSource)
        {
            txtPurchaseOrder.DataSource = PurchaseOrderBindingSource;
            txtPurchaseOrder.DisplayMember = "PurchaseOrderName";
            txtPurchaseOrder.ValueMember = "PurchaseOrderId";
        }
        public void SetWarehouseListBindingSource(BindingSource WarehouseBindingSource)
        {
            txtWarehouse.DataSource = WarehouseBindingSource;
            txtWarehouse.DisplayMember = "WarehouseName";
            txtWarehouse.ValueMember = "WarehouseId";
        }

        //public void SetAddressBindingSource(List<string> barangayBindingSource,
        //    List<string> municipalityBindingSource,
        //    List<string> provinceBindingSource,
        //    List<string> regionBindingSource)
        //{
        //    txtBarangay.DataSource = barangayBindingSource;
        //    txtMunicipality.DataSource = municipalityBindingSource;
        //    txtProvince.DataSource = provinceBindingSource;
        //    txtRegion.DataSource = regionBindingSource;
        //}

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static GoodsReceivedNoteView? instance;
        public static GoodsReceivedNoteView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new GoodsReceivedNoteView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
