using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
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
    public partial class ShipmentView : UserControl, IShipmentView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ShipmentView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected shipment?", "Warning",
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
        }

        //Properties
        public int ShipmentId
        {
            get { return id; }
            set { id = value; }
        }

        public string ShipmentName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int SalesOrderId
        {
            get { return (int)txtSalesOrder.SelectedValue; }
            set { txtSalesOrder.Text = value.ToString(); }
        }
        public DateTimeOffset ShipmentDate
        {
            get { return txtShipmentDate.Value; }
            set { txtShipmentDate.Text = value.ToString(); }
        }
        public int ShipmentTypeId
        {
            get { return (int)txtShipmentType.SelectedValue; }
            set { txtShipmentType.Text = value.ToString(); }
        }
        public int WarehouseId
        {
            get { return (int)txtWarehouse.SelectedValue; }
            set { txtWarehouse.Text = value.ToString(); }
        }
        public bool IsFullShipment
        {
            get { return txtIsFullShipment.Checked; }
            set { txtIsFullShipment.Checked = value; }
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

        public void SetShipmentListBindingSource(BindingSource ShipmentList)
        {
            dgList.DataSource = ShipmentList;
            DataGridHelper.ApplyDisplayNames<ShipmentViewModel>(ShipmentList, dgList);
        }
        public void SetShipmentTypeListBindingSource(BindingSource ShipmentTypeBindingSource)
        {
            txtShipmentType.DataSource = ShipmentTypeBindingSource;
            txtShipmentType.DisplayMember = "ShipmentTypeName";
            txtShipmentType.ValueMember = "ShipmentTypeId";
        }
        public void SetSalesOrderListBindingSource(BindingSource SalesOrderListBindingSource)
        {
            txtSalesOrder.DataSource = SalesOrderListBindingSource;
            txtSalesOrder.DisplayMember = "SalesOrderName";
            txtSalesOrder.ValueMember = "SalesOrderId";
        }
        public void SetWarehouseListBindingSource(BindingSource WarehouseListBindingSource)
        {
            txtWarehouse.DataSource = WarehouseListBindingSource;
            txtWarehouse.DisplayMember = "WarehouseName";
            txtWarehouse.ValueMember = "WarehouseId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static ShipmentView? instance;
        public static ShipmentView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ShipmentView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
