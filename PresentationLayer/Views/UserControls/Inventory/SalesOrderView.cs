using System.ComponentModel;
using DomainLayer.Enums;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;

namespace PresentationLayer.Views.UserControls
{
    public partial class SalesOrderView : SfForm, ISalesOrderView
    {
        public SalesOrderView()
        {
            InitializeComponent();
            SetPermissions();
        }
        public void SetPermissions()
        {
            var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);
            btnAdd.Enabled = appUserRoles.Contains(TaskRoles.Add);
            dgList.Columns["Edit"].Visible = appUserRoles.Contains(TaskRoles.Edit);
            dgList.Columns["Delete"].Visible = appUserRoles.Contains(TaskRoles.Delete);
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
            if (e.DataRow?.RowType == RowType.DefaultRow)
            {
                if (e.DataColumn.GridColumn.MappingName == "Edit")
            {
                EditEvent?.Invoke(sender, e);
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
            else if (e.DataColumn.GridColumn.MappingName == "Payment")
            {
                PaymentEvent?.Invoke(sender, e);
            }
            else if (e.DataColumn.GridColumn.MappingName == "Invoice")
            {
                InvoiceEvent?.Invoke(sender, e);
            }
            else if (e.DataColumn.GridColumn.MappingName == "Details")
            {
                DetailsEvent?.Invoke(sender, e);
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

        public void SetSalesOrderListBindingSource(IEnumerable<SalesOrderViewModel> SalesOrderList)
        {
            dgPager.DataSource = SalesOrderList;

            foreach (var entity in SalesOrderList)
            {
                entity.Payment = Resources.payment; // Or any other image per row
                entity.Invoice = Resources.invoice; // Or any other image per row
                entity.Details = Resources.details; // Or any other image per row
                entity.Edit = Resources.edit; // Or any other image per row
                entity.Delete = Resources.delete; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        public event EventHandler AddEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler EditEvent;
        public event CellClickEventHandler DeleteEvent;
        public event CellClickEventHandler PaymentEvent;
        public event CellClickEventHandler InvoiceEvent;
        public event CellClickEventHandler DetailsEvent;
        public event KeyEventHandler MultipleDeleteEvent;
        public event EventHandler PrintEvent;
    }
}
