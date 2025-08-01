﻿using DomainLayer.ViewModels.InventoryViewModels;
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
using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductPullOutLogView : SfForm, IProductPullOutLogView
    {
        public ProductPullOutLogView()
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
                else if (e.DataColumn.GridColumn.MappingName == "Print")
                {
                    IndividualPrintEvent?.Invoke(sender, e);
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
            get
            {
                return txtSearch.Text;
            }
            set
            {
                txtSearch.Text = value;
            }
        }

        public void SetProductInStockLogListBindingSource(IEnumerable<ProductPullOutLogViewModel> ProductInStockLogList)
        {
            dgPager.DataSource = ProductInStockLogList;

            foreach (var entity in ProductInStockLogList)
            {
                entity.Edit = Resources.edit; // Or any other image per row
                entity.Delete = Resources.delete; // Or any other image per row
                entity.Print = Resources.printer; // Or any other image per row
            }

            dgList.DataSource = dgPager.PagedSource ;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke(sender, e);
        }

        public event EventHandler AddEvent;
        public event EventHandler RefreshEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler EditEvent;
        public event CellClickEventHandler DeleteEvent;
        public event CellClickEventHandler IndividualPrintEvent;
        public event KeyEventHandler MultipleDeleteEvent;
        public event EventHandler PrintEvent;
    }
}
