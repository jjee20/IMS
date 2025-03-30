using DomainLayer.Models;
using DomainLayer.Models.Inventory;
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
    public partial class SettingsView : UserControl, ISettingsView
    {
        public SettingsView()
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
                else if (tcMain.SelectedTab == tbPaymentType)
                {
                    ShowPaymentType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbVendorType)
                {
                    ShowVendorType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPurchaseType)
                {
                    ShowPurchaseType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbBillType)
                {
                    ShowBillType?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static SettingsView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowCustomerType;
        public event EventHandler ShowSalesType;
        public event EventHandler ShowShipmentType;
        public event EventHandler ShowInvoiceType;
        public event EventHandler ShowPaymentType;
        public event EventHandler ShowVendorType;
        public event EventHandler ShowPurchaseType;
        public event EventHandler ShowBillType;

        public static SettingsView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SettingsView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
