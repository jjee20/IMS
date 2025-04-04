using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
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
    public partial class ContributionView : SfForm, IContributionView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ContributionView()
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
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                txtSearch.Focus();
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Contribution?", "Warning",
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ContributionId
        {
            get { return id; }
            set { id = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ContributionType ContributionType
        {
            get { return (ContributionType)(txtContributionType.SelectedValue); }
            set { txtContributionType.Text = value.ToString(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Rate
        {
            get { return Convert.ToDouble(txtRate.Text); }
            set { txtRate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double MinimumLimit
        {
            get { return Convert.ToDouble(txtMinimumLimit.Text); }
            set { txtMinimumLimit.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double MaximumLimit
        {
            get { return Convert.ToDouble(txtMaximumLimit.Text); }
            set { txtMaximumLimit.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double MandatoryProvidentFund
        {
            get { return Convert.ToDouble(lblMandatoryProvidentFund.Text); }
            set { lblMandatoryProvidentFund.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public SfDataGrid DataGrid => dgList;
        public void SetContributionListBindingSource(IEnumerable<Contribution> ContributionList)
        {
            dgPager.DataSource = ContributionList;
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetContributionTypeListBindingSource(BindingSource ContributionTypeList)
        {
            txtContributionType.DataSource = ContributionTypeList;
            txtContributionType.DisplayMember = "Name";
            txtContributionType.ValueMember = "Id";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static ContributionView? instance;
        public static ContributionView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ContributionView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void txtContributionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((ContributionType)txtContributionType.SelectedValue == ContributionType.SSS)
            {
                lblMandatoryProvidentFund.Visible = true;
                lblMadatoryProvidentFund.Visible = true;
            }
            else
            {
                lblMandatoryProvidentFund.Visible = false;
                lblMandatoryProvidentFund.Visible = false;
            }
        }
    }
}
