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
    public partial class PaymentVoucherView : UserControl, IPaymentVoucherView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public PaymentVoucherView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected payment voucher?", "Warning",
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
        public int PaymentVoucherId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string PaymentVoucherName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int BillId
        {
            get { return (int)txtBill.SelectedValue; }
            set { txtBill.Text = value.ToString(); }
        }
        public DateTimeOffset PaymentDate
        {
            get { return txtPaymentDate.Value; }
            set { txtPaymentDate.Text = value.ToString(); }
        }
        public int PaymentTypeId
        {
            get { return (int)txtPaymentType.SelectedValue; }
            set { txtPaymentType.Text = value.ToString(); }
        }
        public double PaymentAmount
        {
            get { return Convert.ToDouble(txtPaymentAmount.Text.Trim()); }
            set { txtPaymentAmount.Text = value.ToString(); }
        }
        public int CashBankId
        {
            get { return (int)txtCashBank.SelectedValue; }
            set { txtCashBank.Text = value.ToString(); }
        }
        public bool IsFullPayment
        {
            get { return txtIsFullPayment.Checked; }
            set { txtIsFullPayment.Checked = value; }
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

        public void SetPaymentVoucherListBindingSource(BindingSource PaymentVoucherList)
        {
            dgList.DataSource = PaymentVoucherList;
            DataGridHelper.ApplyDisplayNames<PaymentVoucherViewModel>(PaymentVoucherList, dgList);
        }
        public void SetBillListBindingSource(BindingSource BillBindingSource)
        {
            txtPaymentType.DataSource = BillBindingSource;
            txtPaymentType.DisplayMember = "BillName";
            txtPaymentType.ValueMember = "BillId";
        }
        public void SetPaymentTypeListBindingSource(BindingSource PaymentTypeBindingSource)
        {
            txtCashBank.DataSource = PaymentTypeBindingSource;
            txtCashBank.DisplayMember = "PaymentTypeName";
            txtCashBank.ValueMember = "PaymentTypeId";
        }
        public void SetCashBankListBindingSource(BindingSource CashBankListBindingSource)
        {
            txtPaymentType.DataSource = CashBankListBindingSource;
            txtPaymentType.DisplayMember = "CashBankName";
            txtPaymentType.ValueMember = "CashBankId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static PaymentVoucherView? instance;
        public static PaymentVoucherView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PaymentVoucherView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
