using DomainLayer.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PresentationLayer.Views
{
    public partial class InventoryView : MaterialForm, IInventoryView
    {
        public InventoryView()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var colorScheme = new ColorScheme(
                                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            materialSkinManager.ColorScheme = colorScheme;

            tcMain.SelectedIndexChanged += delegate
            {
                if (tcMain.SelectedTab == tbDashboard)
                {
                    ShowDashboard?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSales)
                {
                    ShowSales?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPurchase)
                {
                    ShowPurchase?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbInventory)
                {
                    ShowInventory?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProject)
                {
                    ShowProject?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbTargetGoals)
                {
                    ShowTargetGoals?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSalesReport)
                {
                    ShowSalesReport?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPurchaseReport)
                {
                    ShowPurchaseReport?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCustomer)
                {
                    ShowCustomers?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbVendor)
                {
                    ShowVendors?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbWarehouse)
                {
                    ShowWarehouse?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCashBank)
                {
                    ShowCashBank?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSettings)
                {
                    ShowSettings?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProfile)
                {
                    ShowProfile?.Invoke(this, EventArgs.Empty);
                }
            };
        }
        public TabPage Guna2TabControlPage
        {
            get { return tcMain.SelectedTab; }
        }

        public void ShowForm()
        {
            Show();
        }

        private void InventoryView_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void InventoryView_Load(object sender, EventArgs e)
        {
            
        }

        public event EventHandler ShowDashboard;
        public event EventHandler ShowSales;
        public event EventHandler ShowPurchase;
        public event EventHandler ShowInventory;
        public event EventHandler ShowProject;
        public event EventHandler ShowTargetGoals;
        public event EventHandler ShowSalesReport;
        public event EventHandler ShowPurchaseReport;
        public event EventHandler ShowCustomers;
        public event EventHandler ShowVendors;
        public event EventHandler ShowWarehouse;
        public event EventHandler ShowCashBank;
        public event EventHandler ShowSettings;
        public event EventHandler ShowProfile;
    }
}
