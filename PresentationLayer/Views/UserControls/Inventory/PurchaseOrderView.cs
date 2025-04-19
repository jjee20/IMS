using DomainLayer.ViewModels.InventoryViewModels;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
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
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using RavenTech_ERP.Views.IViews.Inventory;
using DomainLayer.ViewModels.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class PurchaseOrderView : SfForm, IPurchaseOrderView
    {
        public PurchaseOrderView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
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
                    if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
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
                else if (e.DataColumn.GridColumn.MappingName == "GRN")
                {
                    GRNEvent?.Invoke(sender, e);
                }
                else if (e.DataColumn.GridColumn.MappingName == "Bill")
                {
                    BillEvent?.Invoke(sender, e);
                }
                else if (e.DataColumn.GridColumn.MappingName == "Voucher")
                {
                    VoucherEvent?.Invoke(sender, e);
                }
            };

            dgList.KeyDown += (sender, e) =>
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

        public void SetPurchaseOrderListBindingSource(IEnumerable<PurchaseOrderViewModel> PurchaseOrderList)
        {
            dgPager.DataSource = PurchaseOrderList;

            foreach (var entity in PurchaseOrderList)
            {
                entity.GRN = Resources.grn; // Or any other image per row
                entity.Bill = Resources.bill; // Or any other image per row
                entity.Voucher = Resources.payment; // Or any other image per row
                entity.Edit = Resources.edit; // Or any other image per row
                entity.Delete = Resources.delete; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtStartDate_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
        }

        private void txtEndDate_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
        }

        public event EventHandler AddEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler EditEvent;
        public event CellClickEventHandler DeleteEvent;
        public event CellClickEventHandler GRNEvent;
        public event CellClickEventHandler BillEvent;
        public event CellClickEventHandler VoucherEvent;
        public event KeyEventHandler MultipleDeleteEvent;
        public event EventHandler PrintEvent;
    }
}
