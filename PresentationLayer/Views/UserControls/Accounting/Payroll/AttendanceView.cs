using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
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
    public partial class AttendanceView : UserControl, IAttendanceView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        private bool isIndividual;
        public bool isEdit;
        public AttendanceView()
        {
            InitializeComponent();
            Guna2TabControl1.TabPages.Remove(tabPage2);
            Guna2TabControl1.TabPages.Remove(tabPage3);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Add New
            btnAdd.Click += delegate
            {
                if (Guna2TabControl1.TabPages.Contains(tabPage1) || Guna2TabControl1.TabPages.Contains(tabPage3))
                {
                    tabPage2.Text = "Add New";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Remove(tabPage3);
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
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    if(isEdit)
                    {
                        Guna2TabControl1.TabPages.Remove(tabPage1);
                        Guna2TabControl1.TabPages.Add(tabPage3);
                    }
                    else
                    {
                        Guna2TabControl1.TabPages.Remove(tabPage3);
                        Guna2TabControl1.TabPages.Add(tabPage1);
                        btnReturn.Visible = false;
                    }
                }
                MessageBox.Show(Message);
            };
            txtStartDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtEndDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtSearch.TextChanged += (s, e) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Edit
            btnEdit.Click += delegate
            {
                if (Guna2TabControl1.SelectedTab == tabPage3)
                {
                    tabPage2.Text = "Edit Details";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Remove(tabPage3);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                    EditEvent?.Invoke(this, EventArgs.Empty);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Attendance?", "Warning",
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
                    Guna2TabControl1.TabPages.Remove(tabPage3);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                    RefreshEvent?.Invoke(this, EventArgs.Empty);
                }
                btnReturn.Visible = false;
            };
            dgList.CellDoubleClick += (sender, e) =>
            {
                Guna2TabControl1.TabPages.Remove(tabPage2);
                Guna2TabControl1.TabPages.Remove(tabPage1);
                Guna2TabControl1.TabPages.Add(tabPage3);
                ShowAttendanceEvent?.Invoke(this, e);
                btnReturn.Visible = true;
            };
            btnImport.Click += delegate
            {
                ImportEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        //Properties
        public int AttendanceId
        {
            get { return id; }
            set { id = value; }
        }

        public int EmployeeId
        {
            get
            {
                return txtEmployee.SelectedValue != null ? Convert.ToInt32(txtEmployee.SelectedValue) : 0;
            }
            set
            {
                if (txtEmployee.DataSource != null)
                {
                    txtEmployee.SelectedValue = value;
                }
            }
        }



        public int ProjectId
        {
            get
            {
                return txtProject.SelectedValue != null ? Convert.ToInt32(txtProject.SelectedValue) : 0;
            }
            set
            {
                if (txtProject.DataSource != null)
                {
                    txtProject.SelectedValue = value;
                }
            }
        }



        public TimeSpan TimeIn
        {
            get { return txtTimeIn.Value.TimeOfDay; }
            set { txtTimeIn.Value = DateTime.Today.Add(value); }
        }
        public TimeSpan TimeOut
        {
            get { return txtTimeOut.Value.TimeOfDay; }
            set { txtTimeOut.Value = DateTime.Today.Add(value); }
        }


        public DateTime Date
        {
            get { return txtDate.Value; }
            set { txtDate.Text = value.ToString(); }
        }
        public bool IsPresent
        {
            get { return txtIsPresent.Checked; }
            set { txtIsPresent.Checked = value; }
        }
        public double HoursWorked
        {
            get { return Convert.ToDouble(txtHoursWorked.Text); }
            set { txtHoursWorked.Text = value.ToString(); }
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
        
        public bool IsIndividual
        {
            get { return isIndividual; }
            set { isIndividual = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
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
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public int EmployeeIdFromTextBox
        {
            get { return Convert.ToInt16(txtEmployeeId.Text); }
            set { txtEmployeeId.Text = value.ToString(); }
        }
        public string EmployeeName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public OpenFileDialog OpenFileDialog
        {
            get { return OpenFileDialog; }
        }
        public void SetAttendanceListBindingSource(BindingSource AttendanceList)
        {
            dgList.DataSource = AttendanceList;
            DataGridHelper.ApplyDisplayNames<AttendanceViewModel>(AttendanceList, dgList);
        }
        public void SetIndividualAttendanceListBindingSource(BindingSource IndividualAttendanceList)
        {
            dgListInvidivual.DataSource = IndividualAttendanceList;
            DataGridHelper.ApplyDisplayNames<IndividualAttendanceViewModel>(IndividualAttendanceList, dgListInvidivual);
        }
        public void SetEmployeeListBindingSource(BindingSource EmployeeList)
        {
            EmployeeList.ResetBindings(false);
            txtEmployee.DataSource = EmployeeList;
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
            
        }

        public void SetProjectListBindingSource(BindingSource ProjectList)
        {
            ProjectList.ResetBindings(false);
            txtProject.DataSource = ProjectList;
            txtProject.DisplayMember = "ProjectName";
            txtProject.ValueMember = "ProjectId";
        }

        public void SetEmployeeItem(Employee employee)
        {
            txtProject.SelectedItem = employee;
            txtProject.Refresh();
            txtProject.BindingContext = new BindingContext();
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;
        public event EventHandler ImportEvent;
        public event DataGridViewCellEventHandler ShowAttendanceEvent;

        private static AttendanceView? instance;
        public static AttendanceView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AttendanceView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
