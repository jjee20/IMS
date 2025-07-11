using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Enums;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.CommonServices;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class TargetGoalsView : SfForm, ITargetGoalsView
    {
        private string _message;
        public TargetGoalsView()
        {
            InitializeComponent();
            SetPermissions();

            btnSave.Click += delegate 
            { 
                SaveClicked?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(_message);
            };
        }
        public void SetPermissions()
        {
            var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles); 
            btnSave.Enabled = appUserRoles.Contains(TaskRoles.Add) || appUserRoles.Contains(TaskRoles.Edit);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double SalesCurrent { get => double.Parse(txtSales.Text); set => txtSales.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double SalesTarget { get => double.Parse(txtSalesTarget.Text.Trim()); set => txtSalesTarget.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double SalesRemaining { set => txtSalesRemaining.Text = (SalesTarget - SalesCurrent).ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SalesProgress {  set => txtSalesProgress.Text = $"{SalesCurrent / SalesTarget * 100:N2}%" ?? "0%"; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ItemSoldCurrent { get => double.Parse(txtItemSold.Text); set => txtItemSold.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ItemSoldTarget { get => double.Parse(txtItemSoldTarget.Text.Trim()); set => txtItemSoldTarget.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ItemSoldRemaining { set => txtItemSoldRemaining.Text = (ItemSoldTarget - ItemSoldCurrent).ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ItemSoldProgress {  set => txtItemSoldProgress.Text = $"{ItemSoldCurrent / ItemSoldTarget * 100:N2}%" ?? "0%"; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Year
        {
            set => txtYear.Text = value;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double YearCurrent { get => double.Parse(txtYearCurrent.Text); set => txtYearCurrent.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double YearTarget { get => double.Parse(txtYearTarget.Text.Trim()); set => txtYearTarget.Text = value.ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double YearRemaining {  set => txtYearRemaining.Text = (YearTarget-YearCurrent).ToString("N2"); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string YearProgress { set => txtYearProgress.Text = $"{YearCurrent / YearTarget * 100:N2}%" ?? "0%"; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
