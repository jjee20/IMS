using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
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
    public partial class ProductView : UserControl, IProductView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ProductView()
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
                if (tabControl1.TabPages.Contains(tabPage1))
                {
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Add New";
                    tabControl1.TabPages.Remove(tabPage1);
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
        public int ProductId
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string ProductName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string ProductCode
        {
            get { return txtProductCode.Text; }
            set { txtProductCode.Text = value; }
        }
        public string Barcode
        {
            get { return txtBarcode.Text; }
            set { txtBarcode.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string ProductImageUrl
        {
            get { return txtProductImageUrl.ImageLocation; }
            set { txtProductImageUrl.ImageLocation = value; }
        }
        public int UnitOfMeasureId
        {
            get { return (int)txtUnitOfMeasure.SelectedValue; }
            set { txtUnitOfMeasure.Text = value.ToString(); }
        }
        public double DefaultBuyingPrice
        {
            get { return Convert.ToDouble(txtDefaultBuyingPrice.Text); }
            set { txtDefaultBuyingPrice.Text = value.ToString(); }
        }
        public double DefaultSellingPrice
        {
            get { return Convert.ToDouble(txtDefaultSellingPrice.Text); }
            set { txtDefaultSellingPrice.Text = value.ToString(); }
        }
        public int BranchId
        {
            get { return (int)txtBranch.SelectedValue; }
            set { txtBranch.Text = value.ToString(); }
        }
        public int CurrencyId
        {
            get { return (int)txtCurrency.SelectedValue; }
            set { txtCurrency.Text = value.ToString(); }
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

        public void SetProductListBindingSource(BindingSource ProductList)
        {
            dgList.DataSource = ProductList;
        }
        public void SetProductTypeListBindingSource(BindingSource ProductTypeBindingSource)
        {
            txtUnitOfMeasure.DataSource = ProductTypeBindingSource;
            txtUnitOfMeasure.DisplayMember = "ProductTypeName";
            txtUnitOfMeasure.ValueMember = "ProductTypeId";
        }
        public void SetUnitOfMeasureListBindingSource(BindingSource UnitOfMeasureListBindingSource)
        {
            txtUnitOfMeasure.DataSource = UnitOfMeasureListBindingSource;
            txtUnitOfMeasure.DisplayMember = "UnitOfMeasureName";
            txtUnitOfMeasure.ValueMember = "UnitOfMeasureId";
        }
        public void SetBranchListBindingSource(BindingSource BranchListBindingSource)
        {
            txtBranch.DataSource = BranchListBindingSource;
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
        }
        public void SetCurrencyListBindingSource(BindingSource CurrencyListBindingSource)
        {
            txtCurrency.DataSource = CurrencyListBindingSource;
            txtCurrency.DisplayMember = "CurrencyName";
            txtCurrency.ValueMember = "CurrencyId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static ProductView? instance;
        public static ProductView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
