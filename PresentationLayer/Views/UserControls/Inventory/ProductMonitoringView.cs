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
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using Syncfusion.WinForms.Controls;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductMonitoringView : SfForm, IProductMonitoringView
    {
        public ProductMonitoringView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Print
            //btnPrint.Click += delegate
            //{
            //    PrintEvent?.Invoke(this, EventArgs.Empty);
            //};
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get
            {
                return txtSearch.Text;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double InStock
        {
            set
            {
                txtInStock.Text = value.ToString();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double LowStock
        {
            set
            {
                txtLowStock.Text = value.ToString();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double OutOfStock
        {
            set
            {
                txtOutOfStock.Text = value.ToString();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProjectFlow
        {
            set
            {
                txtPulledOut.Text = value.ToString();
            }
        }

        public void SetInStockListBindingSource(BindingSource source)
        {
            dgInStock.DataSource = source;
        }
        public void SetLowStockListBindingSource(BindingSource source)
        {
            dgLowStock.DataSource = source;
        }
        public void SetOutOfStockListBindingSource(BindingSource source)
        {
            dgOutOfStock.DataSource = source;
        }
        public void SetProjectFlowListBindingSource(BindingSource source)
        {
            dgPulledOut.DataSource = source;
        }
        public void SetTrendsBindingSource(GunaBarDataset inStockTrendDataset, GunaBarDataset pullOutStockTrendDataset, GunaBarDataset lowStockTrendDataset, GunaBarDataset outOfStockTrendDataset)
        {
            chartTrends.Datasets.Clear();
            chartTrends.Datasets.Add(inStockTrendDataset);
            chartTrends.Datasets.Add(pullOutStockTrendDataset);
            chartTrends.Datasets.Add(lowStockTrendDataset);
            chartTrends.Datasets.Add(outOfStockTrendDataset);
        }

        public event EventHandler PrintEvent;

        private static ProductMonitoringView? instance;
        public static ProductMonitoringView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductMonitoringView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SearchEvent?.Invoke(this, EventArgs.Empty);
            txtSearch.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RefreshEvent;

        public event EventHandler SearchEvent;
    }
}
