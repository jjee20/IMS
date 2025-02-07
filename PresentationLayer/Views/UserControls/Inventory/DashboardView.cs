using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PresentationLayer.Views.UserControls
{
    public partial class DashboardView : UserControl, IDashboardView
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private static DashboardView? instance;
        public static DashboardView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        public string OutOfStock
        {
            get { return txtOutofStock.Text; }
            set { txtOutofStock.Text = value; }
        }
        public string Sales
        {
            get { return txtSales.Text; }
            set { txtSales.Text = value; }
        }
        public string Purchased
        {
            get { return txtPurchased.Text; }
            set { txtPurchased.Text = value; }
        }
        public string OnHand
        {
            get { return txtOnHand.Text; }
            set { txtOnHand.Text = value; }
        }
        
        public string POToday
        {
            get { return txtPOToday.Text; }
            set { txtPOToday.Text = value; }
        }
        
        public string PO7Days
        {
            get { return txtPO7Days.Text; }
            set { txtPO7Days.Text = value; }
        }
        
        public string POThisMonth
        {
            get { return txtPOThisMonth.Text; }
            set { txtPOThisMonth.Text = value; }
        }
        
        public string POAnnual
        {
            get { return txtPOAnnual.Text; }
            set { txtPOAnnual.Text = value; }
        }
        public string SOToday
        {
            get { return txtSOToday.Text; }
            set { txtSOToday.Text = value; }
        }
        
        public string SO7Days
        {
            get { return txtSO7Days.Text; }
            set { txtSO7Days.Text = value; }
        }
        
        public string SOThisMonth
        {
            get { return txtSOThisMonth.Text; }
            set { txtSOThisMonth.Text = value; }
        }
        
        public string SOAnnual
        {
            get { return txtSOAnnual.Text; }
            set { txtSOAnnual.Text = value; }
        }

        public string LowStockItem
        {
            get { return txtLowStockItem.Text; }
            set { txtLowStockItem.Text = value; }
        }
        public string AllItemGroup
        {
            get { return txtAllItemGroup.Text; }
            set { txtAllItemGroup.Text = value; }
        }
        public string AllItem
        {
            get { return txtAllItem.Text; }
            set { txtAllItem.Text = value; }
        }

        public void SetTopSellingItemListBindingSource(BindingSource TopSellingItemList)
        {
            dgTopSellingItems.DataSource = TopSellingItemList;
            DataGridHelper.ApplyDisplayNames<TopSellingItemViewModel>(TopSellingItemList, dgTopSellingItems);
        }
        public void SetChartInventoryStatusBindingSource(GunaBarDataset gunaBarDataset)
        {
            chartInventoryStatus.Datasets.Clear();
            chartInventoryStatus.Datasets.Add(gunaBarDataset);
        }
        public void SetChartSalesStatusBindingSource(GunaLineDataset gunaBarDataset)
        {
            chartSalesStatus.Datasets.Clear();
            chartSalesStatus.Datasets.Add(gunaBarDataset);
        }
    }
}
