using DomainLayer.Models;
using PresentationLayer.Views.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ConfigurationView : UserControl, IConfigurationView
    {
        public ConfigurationView()
        {
            InitializeComponent();
            tcConfiguration.SelectedIndexChanged += delegate
            {
                if (tcConfiguration.SelectedTab == tbCurrency)
                {
                    ShowCurrency?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbBranch)
                {
                    ShowBranch?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbWarehouse)
                {
                    ShowWarehouse?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbCashBank)
                {
                    ShowCashBank?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbPaymentType)
                {
                    ShowPaymentType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbShipmentType)
                {
                    ShowShipmentType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbInvoiceType)
                {
                    ShowInvoiceType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcConfiguration.SelectedTab == tbBillType)
                {
                    ShowBillType?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public TabPage TabControlPage
        {
            get { return tcConfiguration.SelectedTab; }
        }

        public event EventHandler ShowCurrency;
        public event EventHandler ShowBranch;
        public event EventHandler ShowWarehouse;
        public event EventHandler ShowCashBank;
        public event EventHandler ShowPaymentType;
        public event EventHandler ShowShipmentType;
        public event EventHandler ShowInvoiceType;
        public event EventHandler ShowBillType;

        private static ConfigurationView? instance;
        public static ConfigurationView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ConfigurationView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
