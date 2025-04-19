using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.UserControls;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;
using System.ComponentModel;
using DomainLayer.ViewModels.PayrollViewModels;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;

namespace PresentationLayer.Views.UserControls
{
    public partial class AttendanceView : SfForm, IAttendanceView
    {
        public AttendanceView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnAdd.Click += delegate
            {
                AddEvent?.Invoke(this, EventArgs.Empty);
            };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                txtSearch.Focus();
            };
            //Print
            btnPrint.Click += delegate
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
            };
            dgList.CellClick += (sender, e) =>
            {
                if (e.DataColumn.GridColumn.MappingName == "Edit")
                {
                    if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AttendanceViewModel row)
                    {
                        ShowAttendanceEvent?.Invoke(sender, e);
                    }
                }
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public DateTime StartDate => (DateTime)txtStartDate.Value;
        public DateTime EndDate => (DateTime)txtEndDate.Value;

        public void SetAttendanceListBindingSource(IEnumerable<AttendanceViewModel> AttendanceList)
        {
            dgPager.DataSource = AttendanceList;

            foreach (var e in AttendanceList)
            {
                e.Edit = Resources.attendance; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        public event EventHandler AddEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler ShowAttendanceEvent;
        public event EventHandler PrintEvent;
    }
}
