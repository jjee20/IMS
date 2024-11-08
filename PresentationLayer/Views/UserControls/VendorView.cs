using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
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
    public partial class VendorView : UserControl, IVendorView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public VendorView()
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
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabPage2.Text = "Add New";
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage2);
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
                EditEvent?.Invoke(this, EventArgs.Empty);
                if (tabControl1.SelectedTab == tabPage1)
                {
                    tabPage2.Text = "Edit Details";
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Vendor type?", "Warning",
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
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
        }

        //Properties
        public int VendorId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string VendorName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int VendorTypeId
        {
            get { return (int)txtVendorType.SelectedValue; }
            set { txtVendorType.Text = value.ToString(); }
        }
        public string Barangay
        {
            get { return txtBarangay.Text.Trim().ToString(); }
            set { txtBarangay.Text = value; }
        }
        public string Municipality
        {
            get { return txtMunicipality.Text.Trim().ToString(); }
            set { txtMunicipality.Text = value; }
        }
        public string Province
        {
            get { return txtProvince.Text.Trim().ToString(); }
            set { txtProvince.Text = value; }
        }
        public string Region
        {
            get { return txtRegion.Text.Trim(); }
            set { txtRegion.Text = value; }
        }
        public string ZipCode
        {
            get { return txtZipCode.Text; }
            set { txtZipCode.Text = value; }
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

        public void SetVendorListBindingSource(BindingSource VendorList)
        {
            dgList.DataSource = VendorList;
        }
        public void SetVendorTypeListBindingSource(BindingSource VendorTypeBindingSource)
        {
            txtVendorType.DataSource = VendorTypeBindingSource;
            txtVendorType.DisplayMember = "VendorTypeName";
            txtVendorType.ValueMember = "VendorTypeId";
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

        private static VendorView? instance;
        public static VendorView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new VendorView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
