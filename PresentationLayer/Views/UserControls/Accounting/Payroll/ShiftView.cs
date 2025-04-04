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
    public partial class ShiftView : SfForm, IShiftView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public ShiftView()
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
                var result = MessageBox.Show("Are you sure you want to delete the selected Shift?", "Warning",
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
        public int ShiftId
        {
            get { return id; }
            set { id = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShiftName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan StartTime
        {
            get { return txtStartTime.Value.TimeOfDay; }
            set { txtStartTime.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan EndTime
        {
            get { return txtEndTime.Value.TimeOfDay; }
            set { txtEndTime.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double OvertimeRate
        {
            get { return Convert.ToDouble(txtOvertimeRate.Text); }
            set { txtOvertimeRate.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double RegularHours
        {
            get { return Convert.ToDouble(txtRegularHours.Text); }
            set { txtRegularHours.Text = value.ToString(); }
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

        public void SetShiftListBindingSource(IEnumerable<ShiftViewModel> ShiftList)
        {
            dgPager.DataSource = ShiftList;
            dgList.DataSource = dgPager.PagedSource;
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static ShiftView? instance;
        private static ShiftView? dialogInstance;

        public static ShiftView GetInstance(TabPage? parentContainer = null)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ShiftView();
            }

            if (parentContainer != null && !parentContainer.Controls.Contains(instance))
            {
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        public static ShiftView GetInstanceAsDialog(Form form)
        {
            if (dialogInstance == null || dialogInstance.IsDisposed)
            {
                dialogInstance = new ShiftView();
            }
            form.Controls.Add(dialogInstance);


            return dialogInstance;
        }

    }
}
