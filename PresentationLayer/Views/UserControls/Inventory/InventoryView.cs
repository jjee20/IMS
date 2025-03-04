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
                                ColorTranslator.FromHtml("#457b9d"),
                                ColorTranslator.FromHtml("#1d3557"),
                                ColorTranslator.FromHtml("#f1faee"),
                                ColorTranslator.FromHtml("#457b9d"),
                                TextShade.WHITE // text shade
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
            Application.Restart();
        }

        public event EventHandler ShowDashboard;
        public event EventHandler ShowSales;
        public event EventHandler ShowPurchase;
        public event EventHandler ShowInventory;
        public event EventHandler ShowProject;
    }
}
