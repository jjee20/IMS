using DomainLayer.Models;
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

namespace PresentationLayer.Views.UserControls
{
    public partial class SalesSettingsView : UserControl, ISalesSettingsView
    {
        public SalesSettingsView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                if (tcMain.SelectedTab == tbCustomerType)
                {
                    ShowCustomerType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSalesType)
                {
                    ShowSalesType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbShipmentType)
                {
                    ShowShipmentType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbInvoiceType)
                {
                    ShowInvoiceType?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static SalesSettingsView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowCustomerType;
        public event EventHandler ShowSalesType;
        public event EventHandler ShowShipmentType;
        public event EventHandler ShowInvoiceType;

        public static SalesSettingsView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SalesSettingsView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
