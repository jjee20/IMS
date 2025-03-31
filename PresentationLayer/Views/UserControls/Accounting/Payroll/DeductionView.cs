using DomainLayer.Enums;
using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
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
    public partial class DeductionView : UserControl, IDeductionView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public DeductionView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Deduction?", "Warning",
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
            txtStartDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtEndDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        //Properties
        public SfDataGrid DataGrid => dgList;
        public int DeductionId
        {
            get { return id; }
            set { id = value; }
        }
        public DeductionType DeductionType
        {
            get { return (DeductionType)txtDeductionType.SelectedValue; }
            set { txtDeductionType.Text = value.ToString(); }
        }
        public double Amount
        {
            get { return Convert.ToDouble(txtAmount.Text); }
            set { txtAmount.Text = value.ToString(); }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public DateTime DateDeducted
        {
            get { return txtDateDeducted.Value; }
            set { txtDateDeducted.Value = value; }
        }
        public int EmployeeId
        {
            get { return (int)txtEmployee.SelectedValue; }
            set { txtEmployee.Text = value.ToString(); }
        }
        public DateTime StartDate
        {
            get { return txtStartDate.Value; }
            set { txtStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate
        {
            get { return txtEndDate.Value; }
            set { txtEndDate.Text = value.ToString(); }
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

        public void SetDeductionListBindingSource(BindingSource DeductionList)
        {
            dgPager.DataSource = DeductionList.ToList<DeductionViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetEmployeeListBindingSource(BindingSource EmployeeList)
        {
            txtEmployee.DataSource = EmployeeList;
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
        }
        public void SetDeductionTypeListBindingSource(BindingSource DeductionTypeList)
        {
            txtDeductionType.DataSource = DeductionTypeList;
            txtDeductionType.DisplayMember = "Name";
            txtDeductionType.ValueMember = "Id";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static DeductionView? instance;
        public static DeductionView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DeductionView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void txtDeductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDeductionType.Text == "Other") txtDescription.ReadOnly = false; else txtDescription.ReadOnly = true;
        }

        private void DeductionView_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            txtDateDeducted.Value = currentDate;
            txtStartDate.Value = startDate;
            txtEndDate.Value = endDate;
        }
    }
}
