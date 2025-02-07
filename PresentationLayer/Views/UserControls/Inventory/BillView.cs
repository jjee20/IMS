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
    public partial class BillView : UserControl, IBillView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public BillView()
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
                if (Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Edit";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected bill?", "Warning",
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
        public int BillId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string BillName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int GoodsReceivedNoteId
        {
            get { return (int)txtGoodsReceivedNote.SelectedValue; }
            set { txtGoodsReceivedNote.Text = value.ToString(); }
        }
        public string VendorDONumber
        {
            get { return txtVendorDONumber.Text; }
            set { txtVendorDONumber.Text = value; }
        }
        public string VendorInvoiceNumber
        {
            get { return txtVendorInvoiceNumber.Text; }
            set { txtVendorInvoiceNumber.Text = value; }
        }
        public DateTimeOffset BillDate
        {
            get { return txtBillDate.Value; }
            set { txtBillDate.Text = value.ToString(); }
        }
        public DateTimeOffset BillDueDate
        {
            get { return txtBillDueDate.Value; }
            set { txtBillDueDate.Text = value.ToString(); }
        }
        public int BillTypeId
        {
            get { return (int)txtBillType.SelectedValue; }
            set { txtBillType.Text = value.ToString(); }
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

        public void SetBillListBindingSource(BindingSource BillList)
        {
            dgList.DataSource = BillList;
            DataGridHelper.ApplyDisplayNames<BillViewModel>(BillList, dgList);
        }
        public void SetBillTypeListBindingSource(BindingSource BillTypeBindingSource)
        {
            txtBillType.DataSource = BillTypeBindingSource;
            txtBillType.DisplayMember = "BillTypeName";
            txtBillType.ValueMember = "BillTypeId";
        }
        public void SetGoodsReceivedNoteListBindingSource(BindingSource GoodsReceivedNoteListBindingSource)
        {
            txtGoodsReceivedNote.DataSource = GoodsReceivedNoteListBindingSource;
            txtGoodsReceivedNote.DisplayMember = "GoodsReceivedNoteName";
            txtGoodsReceivedNote.ValueMember = "GoodsReceivedNoteId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static BillView? instance;
        public static BillView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BillView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
