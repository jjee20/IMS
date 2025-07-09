using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Inventory;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class PurchasesReportView : SfForm, IPurchasesReportView
    {
        public PurchasesReportView()
        {
            InitializeComponent();
            txtMonth.SelectionChangeCommitted += (s, e) =>
            {
                UpdatePurchasesReportEvent?.Invoke(s, EventArgs.Empty);
            };
            txtYear.SelectionChangeCommitted += (s, e) =>
            {
                UpdatePurchasesReportEvent?.Invoke(s, EventArgs.Empty);
            };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Year
        {
            get
            {
                if (txtYear.DataSource != null)
                    return (int)txtYear.SelectedValue;
                else return 0;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Month
        {
            get
            {
                return (int)txtMonth.SelectedValue;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Purchases
        {
            set => txtPurchases.Text = value.ToString("C2");
        }

        public void SetDailyPurchasesChart(GunaBarDataset purchasesbarDataset)
        {
            chartDailyPurchases.Datasets.Clear();
            chartDailyPurchases.Datasets.Add(purchasesbarDataset);
        }

        public void SetMonths(BindingSource bindingSource)
        {
            txtMonth.DataSource = bindingSource;
            txtMonth.DisplayMember = "Name";
            txtMonth.ValueMember = "Id";
        }
        public void SetYears(BindingSource bindingSource)
        {
            txtYear.DataSource = bindingSource;
            txtYear.DisplayMember = "Name";
            txtYear.ValueMember = "Id";
        }

        public void SetDailyPurchasesDataGrid(BindingSource bindingSource)
        {
            dgDailyPurchases.DataSource = bindingSource;
        }
        public void SetMonthlyPurchasesDataGrid(BindingSource bindingSource)
        {
            dgMonthlyPurchases.DataSource = bindingSource;
        }
        public void SetAnnuallyPurchasesDataGrid(BindingSource bindingSource)
        {
            dgAnnualPurchases.DataSource = bindingSource;
        }

        public event EventHandler UpdatePurchasesReportEvent;

        private static PurchasesReportView? instance;
        public static PurchasesReportView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchasesReportView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke(sender, e);
        }
        public event EventHandler RefreshEvent;
    }
}
