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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchEvent?.Invoke(this, EventArgs.Empty);
            txtSearch.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintEvent?.Invoke(this, EventArgs.Empty);
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {

            if (e.DataColumn.GridColumn.MappingName == "Edit")
            {
                ShowAttendanceEvent?.Invoke(sender, e);
            }
        }

        private void AttendanceView_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            txtStartDate.Value = startDate;
            txtEndDate.Value = endDate;
        }

        private void txtEndDate_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtStartDate_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AddEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler ShowAttendanceEvent;
        public event EventHandler PrintEvent;
    }
}
