using PresentationLayer.Views.IViews;

namespace PresentationLayer.Views.UserControls
{
    public partial class CustomerView : UserControl, ICustomerView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public CustomerView()
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
                tabPage2.Text = "Add New";
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                if (tabControl1.TabPages.Contains(tabPage1))
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                }
                else if ((tabControl1.TabPages.Contains(tabPage2) && tabPage2.Text == "Edit"))
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
        public int CustomerId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
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
        public string Barangay
        {
            get { return txtBarangay.SelectedItem.ToString(); }
            set { txtBarangay.Text = value; }
        }
        public string Municipality
        {
            get { return txtMunicipality.SelectedItem.ToString(); }
            set { txtMunicipality.Text = value; }
        }
        public string Province
        {
            get { return txtProvince.SelectedItem.ToString(); }
            set { txtProvince.Text = value; }
        }
        public string Region
        {
            get { return txtRegion.SelectedItem.ToString(); }
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

        public void SetCustomerListBindingSource(BindingSource CustomerList)
        {
            dgList.DataSource = CustomerList;
        }
        public void SetCustomerTypeListBindingSource(BindingSource customerTypeBindingSource)
        {
            txtCustomerType.DataSource = customerTypeBindingSource;
            txtCustomerType.DisplayMember = "CustomerTypeName";
            txtCustomerType.ValueMember = "CustomerTypeId";
        }

        public void SetAddressBindingSource(List<string> barangayBindingSource,
            List<string> municipalityBindingSource,
            List<string> provinceBindingSource,
            List<string> regionBindingSource)
        {
            txtBarangay.DataSource = barangayBindingSource;
            txtMunicipality.DataSource = municipalityBindingSource;
            txtProvince.DataSource = provinceBindingSource;
            txtRegion.DataSource = regionBindingSource;
        }

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
