using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
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
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class EmployeeView : SfForm, IEmployeeView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public EmployeeView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Employee?", "Warning",
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

            dgList.CellDoubleClick += (s, e) =>
            {
                UserInformationEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public SfDataGrid DataGrid => dgList;
        //Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EmployeeId
        {
            get { return id; }
            set { id = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EmployeeFirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EmployeeLastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateOfBirth
        {
            get { return txtDateOfBirth.Value; }
            set { txtDateOfBirth.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Gender Gender
        {
            get { return (Gender)txtGender.SelectedValue; }
            set { txtGender.SelectedValue = (int)value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ContactNumber
        {
            get { return txtContactNumber.Text; }
            set { txtContactNumber.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DepartmentId
        {
            get { return (int)txtDepartment.SelectedValue; }
            set { txtDepartment.SelectedValue = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int JobPositionId
        {
            get { return (int)txtJobPosition.SelectedValue; }
            set { txtJobPosition.SelectedValue = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ShiftId
        {
            get { return (int)txtShift.SelectedValue; }
            set { txtShift.SelectedValue = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double BasicSalary
        {
            get { return Convert.ToDouble(txtBasicSalary.Text); }
            set { txtBasicSalary.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double LeaveCredits
        {
            get { return Convert.ToDouble(txtLeaveCredits.Text); }
            set { txtLeaveCredits.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SaveButton
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool isDeducted
        {
            get { return txtisDeducted.Checked; }
            set { txtisDeducted.Checked = value; }
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
        public void SetEmployeeListBindingSource(IEnumerable<EmployeeViewModel> EmployeeList)
        {
            dgPager.DataSource = EmployeeList;
            dgList.DataSource = dgPager.PagedSource;
        }

        public void SetGenderListBindingSource(BindingSource GenderList)
        {
            txtGender.DataSource = GenderList;
            txtGender.DisplayMember = "Name";
            txtGender.ValueMember = "Id";
        }
        public void SetDepartmentListBindingSource(BindingSource DepartmentList)
        {
            txtDepartment.DataSource = DepartmentList;
            txtDepartment.DisplayMember = "Name";
            txtDepartment.ValueMember = "DepartmentId";
        }
        public void SetJobPositionListBindingSource(BindingSource JobPositionList)
        {
            txtJobPosition.DataSource = JobPositionList;
            txtJobPosition.DisplayMember = "Title";
            txtJobPosition.ValueMember = "JobPositionId";
        }
        public void SetShiftListBindingSource(BindingSource ShiftList)
        {
            txtShift.DataSource = ShiftList;
            txtShift.DisplayMember = "ShiftName";
            txtShift.ValueMember = "ShiftId";
        }


        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;
        public event EventHandler UserInformationEvent;

        private static EmployeeView? instance;
        public static EmployeeView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeeView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
