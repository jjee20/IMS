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
    public partial class PurchaseSettingsView : UserControl, IPurchaseSettingsView
    {
        public PurchaseSettingsView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                if (tcMain.SelectedTab == tbPaymentType)
                {
                    ShowPaymentType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbBranch)
                {
                    ShowBranch?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCashBank)
                {
                    ShowCashBank?.Invoke(this, EventArgs.Empty);
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

        private static PurchaseSettingsView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowPaymentType;
        public event EventHandler ShowBranch;
        public event EventHandler ShowCashBank;
        public event EventHandler ShowVendorType;
        public event EventHandler ShowPurchaseType;
        public event EventHandler ShowBillType;

        public static PurchaseSettingsView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchaseSettingsView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
