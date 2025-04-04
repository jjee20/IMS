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
    public partial class LeaveView : SfForm, ILeaveView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public LeaveView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Leave?", "Warning",
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LeaveId
        {
            get { return id; }
            set { id = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EmployeeId
        {
            get { return (int)txtEmployee.SelectedValue; }
            set { txtEmployee.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate
        {
            get { return txtStartDate.Value; }
            set { txtStartDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndDate
        {
            get { return txtEndDate.Value; }
            set { txtEndDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SearchStartDate
        {
            get { return txtSearchStartDate.Value; }
            set { txtSearchStartDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SearchEndDate
        {
            get { return txtSearchEndDate.Value; }
            set { txtSearchEndDate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LeaveType LeaveType
        {
            get { return (LeaveType)txtLeaveType.SelectedValue; }
            set { txtLeaveType.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Status Status
        {
            get { return (Status)txtStatus.SelectedValue; }
            set { txtStatus.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes
        {
            get { return txtNotes.Text; }
            set { txtNotes.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Other
        {
            get { return txtOther.Text; }
            set { txtOther.Text = value; }
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

        public void SetLeaveListBindingSource(IEnumerable<LeaveViewModel> LeaveList)
        {
            dgPager.DataSource = LeaveList;
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetEmployeeListBindingSource(BindingSource EmployeeList)
        {
            txtEmployee.DataSource = EmployeeList;
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
        }
        public void SetLeaveTypeListBindingSource(BindingSource LeaveTypeList)
        {
            txtLeaveType.DataSource = LeaveTypeList;
            txtLeaveType.DisplayMember = "Name";
            txtLeaveType.ValueMember = "Id";
        }
        public void SetStatusListBindingSource(BindingSource StatusList)
        {
            txtStatus.DataSource = StatusList;
            txtStatus.DisplayMember = "Name";
            txtStatus.ValueMember = "Id";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static LeaveView? instance;
        public static LeaveView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LeaveView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Other") txtOther.ReadOnly = false; else txtOther.ReadOnly = true;
        }

        private void LeaveView_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            txtSearchStartDate.Value = currentDate;
            txtSearchEndDate.Value = currentDate;
            txtStartDate.Value = startDate;
            txtEndDate.Value = endDate;
        }
    }
}
