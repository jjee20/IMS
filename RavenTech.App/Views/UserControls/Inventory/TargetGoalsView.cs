using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RavenTech_ERP.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class TargetGoalsView : UserControl, ITargetGoalsView
    {
        private string _message;
        public TargetGoalsView()
        {
            InitializeComponent();

            btnSave.Click += delegate 
            { 
                SaveClicked?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(_message);
            };
        }

        public double SalesCurrent { get => double.Parse(txtSales.Text); set => txtSales.Text = value.ToString("N2"); }
        public double SalesTarget { get => double.Parse(txtSalesTarget.Text.Trim()); set => txtSalesTarget.Text = value.ToString("N2"); }
        public double SalesRemaining{  set => txtSalesRemaining.Text = (SalesTarget-SalesCurrent).ToString("N2"); }
        public string SalesProgress {  set => txtSalesProgress.Text = $"{SalesCurrent / SalesTarget * 100:N2}%" ?? "0%"; }
        public double ItemSoldCurrent { get => double.Parse(txtItemSold.Text); set => txtItemSold.Text = value.ToString("N2"); }
        public double ItemSoldTarget { get => double.Parse(txtItemSoldTarget.Text.Trim()); set => txtItemSoldTarget.Text = value.ToString("N2"); }
        public double ItemSoldRemaining{  set => txtItemSoldRemaining.Text =  (ItemSoldTarget-ItemSoldCurrent).ToString("N2"); }
        public string ItemSoldProgress {  set => txtItemSoldProgress.Text = $"{ItemSoldCurrent / ItemSoldTarget * 100:N2}%" ?? "0%"; }
        public string Year { set => txtYear.Text = value; }
        public double YearCurrent { get => double.Parse(txtYearCurrent.Text); set => txtYearCurrent.Text = value.ToString("N2"); }
        public double YearTarget { get => double.Parse(txtYearTarget.Text.Trim()); set => txtYearTarget.Text = value.ToString("N2"); }
        public double YearRemaining {  set => txtYearRemaining.Text = (YearTarget-YearCurrent).ToString("N2"); }
        public string YearProgress { set => txtYearProgress.Text = $"{YearCurrent / YearTarget * 100:N2}%" ?? "0%"; }
        public string Message { set => _message = value; }

        public event EventHandler SaveClicked;
        private static TargetGoalsView? instance;
        public static TargetGoalsView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TargetGoalsView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
