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
    public partial class SalesReportView : SfForm, ISalesReportView
    {
        public SalesReportView()
        {
            InitializeComponent();
            txtMonth.SelectionChangeCommitted += (s, e) =>
            {
                UpdateSalesReportEvent?.Invoke(s, EventArgs.Empty);
            };
            txtYear.SelectionChangeCommitted += (s, e) =>
            {
                UpdateSalesReportEvent?.Invoke(s, EventArgs.Empty);
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
            get { return (int)txtMonth.SelectedValue; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ItemSold { set => txtItemSold.Text = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Sales { get => double.Parse(txtSales.Text); set => txtSales.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Purchases { get => double.Parse(txtPurchases.Text); set => txtPurchases.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Net { set => txtNet.Text = value; }

        public void SetDailySalesChart(GunaBarDataset salesbarDataset, GunaBarDataset purchasesbarDataset)
        {
            chartDailySales.Datasets.Clear();
            chartDailySales.Datasets.Add(salesbarDataset);
            chartDailySales.Datasets.Add(purchasesbarDataset);
        }
        public void SetMonthlySalesChart(GunaBarDataset salesbarDataset, GunaBarDataset purchasesbarDataset)
        {
            chartMonthlySales.Datasets.Clear();
            chartMonthlySales.Datasets.Add(salesbarDataset);
            chartMonthlySales.Datasets.Add(purchasesbarDataset);
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

        public void SetDailySalesDataGrid(BindingSource bindingSource)
        {
            dgDailySales.DataSource = bindingSource;
        }
        public void SetMonthlySalesDataGrid(BindingSource bindingSource)
        {
            dgMonthlySales.DataSource = bindingSource;
        }

        public event EventHandler UpdateSalesReportEvent;

        private static SalesReportView? instance;
        public static SalesReportView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SalesReportView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

    }
}
