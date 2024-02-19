using PresentationLayer.Views.IViews;

namespace PresentationLayer.Views.UserControls
{
    public partial class BranchView : UserControl, IBranchView
    {
        private int _Id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public BranchView()
        {
            InitializeComponent();
            tabControl1.TabPages.Remove(tabPage2);
            AssociateAndRaiseViewEvents();
            TextBox.CheckForIllegalCrossThreadCalls = false;
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
                    btnReturn.Visible = false;
                    MessageBox.Show(Message);
                }
            };
            txtSearch.TextChanged += (s, e) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Edit
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                if (tabControl1.TabPages.Contains(tabPage1))
                {
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
        public int BranchId
        {
            get { return Convert.ToInt32(_Id); }
            set { _Id = value; }
        }

        public string BranchName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public int CurrencyId
        {
            get { return (int)txtCurrency.SelectedValue; }
            set { txtCurrency.Text = value.ToString(); }
        }
        public string BarangayCode
        {
            get { return (string)txtBarangay.SelectedValue; }
            set { txtBarangay.Text = value; }
        }
        public string CityCode
        {
            get { return (string)txtCity.SelectedValue; }
            set { txtCity.Text = value; }
        }
        public string ProvinceCode
        {
            get { return (string)txtProvince.SelectedValue; }
            set { txtProvince.Text = value; }
        }
        public string RegionCode
        {
            get { return (string)txtRegion.SelectedValue; }
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

        public void SetBranchListBindingSource(BindingSource BranchList)
        {
            dgList.DataSource = BranchList;
        }

        public void SetCurrencyListBindingSource(BindingSource CurrencyBindingSource)
        {
            txtCurrency.DataSource = CurrencyBindingSource;
            txtCurrency.DisplayMember = "CurrencyName";
            txtCurrency.ValueMember = "CurrencyId";
        }
        public void SetAddressBindingSource(
            BindingSource barangayBindingSource,
            BindingSource cityBindingSource,
            BindingSource provinceBindingSource,
            BindingSource regionBindingSource)
        {
            txtBarangay.DataSource = barangayBindingSource;
            txtBarangay.DisplayMember = "BarangayName";
            txtBarangay.ValueMember = "BarangayCode";

            txtCity.DataSource = cityBindingSource;
            txtCity.DisplayMember = "CityName";
            txtCity.ValueMember = "CityCode";

            txtProvince.DataSource = provinceBindingSource;
            txtProvince.DisplayMember = "ProvinceName";
            txtProvince.ValueMember = "ProvinceCode";

            txtRegion.DataSource = regionBindingSource;
            txtRegion.DisplayMember = "RegionName";
            txtRegion.ValueMember = "RegionCode";
        }
        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        public event EventHandler RegionEvent;
        public event EventHandler ProvinceEvent;
        public event EventHandler CityEvent;
        public event DataGridViewCellEventHandler DisplayBranchEvent;
        private static BranchView? instance;
        public static BranchView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BranchView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
