using PresentationLayer.Views.IViews;

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
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
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
