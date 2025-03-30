using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductStockInLogView : UserControl, IProductStockInLogView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ProductStockInLogView()
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
                    tabPage2.Text = "Add New";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
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
                    tabPage2.Text = "Edit";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                    EditEvent?.Invoke(this, EventArgs.Empty);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected stock logs?", "Warning",
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
                    Guna2TabControl1.TabPages.Remove(tabPage2);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                    RefreshEvent?.Invoke(this, EventArgs.Empty);
                }
                btnReturn.Visible = false;
            };
        }

        //Properties
        public int ProductStockInLogId
        {
            get { return id; }
            set { id = value; }
        }

        public int ProductId
        {
            get { return (int)txtProduct.SelectedValue; }
            set { txtProduct.SelectedValue = value; }
        }
        public ProductStatus ProductStatus
        {
            get { return (ProductStatus)txtStatus.SelectedValue; }
            set { txtStatus.Text = value.ToString(); }
        }
        public double StockQuantity
        {
            get { return Convert.ToDouble(txtQuantity.Text); }
            set { txtQuantity.Text = value.ToString(); }
        }

        public DateTime DateAdded
        {
            get { return txtDate.Value; }
            set { txtDate.Value = value; }
        }
        public string Notes
        {
            get { return txtNotes.Text; }
            set { txtNotes.Text = value; }
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

        public void SetProductListBindingSource(BindingSource bindingSource)
        {
            txtProduct.DataSource = bindingSource;
            txtProduct.DisplayMember = "ProductName";
            txtProduct.ValueMember = "ProductId";
        }
        public void SetProductStatusListBindingSource(BindingSource bindingSource)
        {
            txtStatus.DataSource = bindingSource;
            txtStatus.DisplayMember = "Name";
            txtStatus.ValueMember = "Id";
        }
        public void SetProductStockInLogListBindingSource(BindingSource ProductStockInLogList)
        {
            dgPager.DataSource = ProductStockInLogList.ToList<ProductStockInLogViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static ProductStockInLogView? instance;
        public static ProductStockInLogView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductStockInLogView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void ProductStockInLogView_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
        }
    }
}
