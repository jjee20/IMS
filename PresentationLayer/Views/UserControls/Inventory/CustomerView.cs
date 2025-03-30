using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
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
    public partial class CustomerView : UserControl, ICustomerView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public CustomerView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected customer?", "Warning",
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
        public int CustomerId
        {
            get { return id; }
            set { id = value; }
        }

        public string CustomerName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int CustomerTypeId
        {
            get { return (int)txtCustomerType.SelectedValue; }
            set { txtCustomerType.Text = value.ToString(); }
        }
        public string Address
        {
            get { return txtAddress.Text.Trim().ToString(); }
            set { txtAddress.Text = value; }
        }
        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
        public string ContactPerson
        {
            get { return txtContactPerson.Text; }
            set { txtContactPerson.Text = value; }
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

        public void SetCustomerListBindingSource(BindingSource CustomerList)
        {
            dgPager.DataSource = CustomerList.ToList<CustomerViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetCustomerTypeListBindingSource(BindingSource customerTypeBindingSource)
        {
            txtCustomerType.DataSource = customerTypeBindingSource;
            txtCustomerType.DisplayMember = "CustomerTypeName";
            txtCustomerType.ValueMember = "CustomerTypeId";
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

        private static CustomerView? instance;
        public static CustomerView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
