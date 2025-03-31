using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
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
    public partial class EmployeeContributionView : UserControl, IEmployeeContributionView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public EmployeeContributionView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected employee contribution?", "Warning",
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
        public SfDataGrid DataGrid => dgList;
        public int EmployeeContributionId
        {
            get { return id; }
            set { id = value; }
        }
        public int EmployeeId
        {
            get { return Convert.ToInt32(txtEmployeeId.Text); }
            set { txtEmployeeId.Text = value.ToString(); }
        }

        public double SSS
        {
            get { return Convert.ToDouble(txtSSS.Text); }
            set { txtSSS.Text = value.ToString(); }
        }
        public double SSSWISP
        {
            get { return Convert.ToDouble(txtSSSWISP.Text); }
            set { txtSSSWISP.Text = value.ToString(); }
        }
        public double PagIbig
        {
            get { return Convert.ToDouble(txtPagIbig.Text); }
            set { txtPagIbig.Text = value.ToString(); }
        }
        public double PhilHealth
        {
            get { return Convert.ToDouble(txtPhilHealth.Text); }
            set { txtPhilHealth.Text = value.ToString(); }
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

        public void SetEmployeeContributionListBindingSource(BindingSource EmployeeContributionList)
        {
            dgPager.DataSource = EmployeeContributionList.ToList<EmployeeContributionViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetEmployeeListBindingSource(BindingSource EmployeeList)
        {
            txtEmployeeId.DataSource = EmployeeList;
            txtEmployeeId.DisplayMember = "Name";
            txtEmployeeId.ValueMember = "Id";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static EmployeeContributionView? instance;
        public static EmployeeContributionView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeeContributionView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
