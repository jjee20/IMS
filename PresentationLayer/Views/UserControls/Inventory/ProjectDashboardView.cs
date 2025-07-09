using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProjectDashboardView : SfForm, IProjectDashboardView
    {
        public ProjectDashboardView()
        {
            InitializeComponent();

            txtYear.SelectionChangeCommitted += (s, e) =>
            {
                UpdateProjectDashboardEvent?.Invoke(this, EventArgs.Empty);
            };
            txtMonth.SelectionChangeCommitted += (s, e) =>
            {
                UpdateProjectDashboardEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler UpdateProjectDashboardEvent;
        public event EventHandler RefreshEvent;

        private static ProjectDashboardView? instance;
        public static ProjectDashboardView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProjectDashboardView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
        public static ProjectDashboardView GetNewInstance(MaterialCard parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProjectDashboardView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TotalProfit
        {
            set
            {
                txtTotalProfit.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TotalRevenue
        {
            set
            {
                txtTotalRevenue.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TotalExpense
        {
            set
            {
                txtTotalExpenses.Text = value;
            }
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

        public void SetYear(BindingSource dataSource)
        {
            txtYear.DataSource = dataSource;
            txtYear.DisplayMember = "Name";
            txtYear.ValueMember = "Id";
        }
        public void SetMonth(BindingSource dataSource)
        {
            txtMonth.DataSource = dataSource;
            txtMonth.DisplayMember = "Name";
            txtMonth.ValueMember = "Id";
        }

        public void SetTopUsed(GunaHorizontalBarDataset dataSet)
        {
            chartTopUsed.Datasets.Clear();
            chartTopUsed.Datasets.Add(dataSet);
        }

        public void SetTopProjects(GunaHorizontalBarDataset dataSet)
        {
            chartTopProjects.Datasets.Clear();
            chartTopProjects.Datasets.Add(dataSet);
        }

        public void SetDailyTrend(GunaLineDataset dailyTrendDataSet)
        {
            chartDailyTrend.Datasets.Clear();
            chartDailyTrend.Datasets.Add(dailyTrendDataSet);
        }

        public void SetMonthlyTrend(GunaBarDataset monthlyRevenueTrendDataset, GunaBarDataset monthlyExpenseTrendDataset)
        {
            chartMonthlyTrend.Datasets.Clear();
            chartMonthlyTrend.Datasets.Add(monthlyRevenueTrendDataset);
            chartMonthlyTrend.Datasets.Add(monthlyExpenseTrendDataset);
        }

        public void SetInventoryStatus(GunaBarDataset inventoryStatusDataset)
        {
            chartInventoryStatus.Datasets.Clear();
            chartInventoryStatus.Datasets.Add(inventoryStatusDataset);
        }

        public void SetProjectExpenseDistribution(GunaDoughnutDataset ProjectDashboardDataSet)
        {
            chartProjectDashboardExpenseDistribution.Datasets.Clear();
            chartProjectDashboardExpenseDistribution.Datasets.Add(ProjectDashboardDataSet);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke(sender, e);
        }
    }
}
