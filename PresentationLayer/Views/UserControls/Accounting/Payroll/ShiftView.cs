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
    public partial class ShiftView : SfForm, IShiftView
    {
        public ShiftView()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchEvent?.Invoke(this, EventArgs.Empty);
            txtSearch.Focus();
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Edit")
            {
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is BillTypeViewModel row)
                {
                    EditEvent?.Invoke(sender, e);
                }
            }
            else if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(sender, e);
                }
            }
        }
        private void Me_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected items?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    MultipleDeleteEvent?.Invoke(sender, e);
                }
            }
        }

        //Properties
        public SfDataGrid DataGrid => dgList;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public void SetShiftListBindingSource(IEnumerable<ShiftViewModel> ShiftList)
        {
            dgPager.DataSource = ShiftList;

            foreach (var e in ShiftList)
            {
                e.Edit = Resources.edit; // Or any other image per row
                e.Delete = Resources.delete; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        public event EventHandler AddEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler EditEvent;
        public event CellClickEventHandler DeleteEvent;
        public event KeyEventHandler MultipleDeleteEvent;
        public event EventHandler PrintEvent;
    }
}
