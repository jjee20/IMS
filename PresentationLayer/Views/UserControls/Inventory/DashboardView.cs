using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
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
    public partial class DashboardView : SfForm, IDashboardView
    {
        public DashboardView()
        {
            InitializeComponent();

            txtYear.SelectionChangeCommitted += (s, e) =>
            {
                UpdateDashboardEvent?.Invoke(this, EventArgs.Empty);
            };
            txtMonth.SelectionChangeCommitted += (s, e) =>
            {
                UpdateDashboardEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler UpdateDashboardEvent;
        public event EventHandler RefreshEvent;

        private static DashboardView? instance;
        public static DashboardView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
        public static DashboardView GetNewInstance(MaterialCard parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DashboardView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Gross
        {
            set
            {
                txtGross.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Sales
        {
            set
            {
                txtSales.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Expense
        {
            set
            {
                txtExpense.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SalesToday
        {
            set
            {
                txtSalesToday.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ItemSoldToday
        {
            set
            {
                txtItemSoldToday.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExpenseToday
        {
            set
            {
                txtExpenseToday.Text = value;
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ExpenseTodayItemsSold
        {
            set
            {
                txtExpenseItemsSold.Text = value.ToString("C2");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ExpenseTodayItemsSoldTarget
        {
            set
            {
                txtExpenseItemsSoldTarget.Text = value.ToString("C2");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ExpenseTodaySales
        {
            set
            {
                txtExpenseSales.Text = value.ToString("C2");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ExpenseTodaySalesTarget
        {
            set
            {
                txtExpenseSalesTarget.Text = value.ToString("C2");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double TotalExpense
        {
            set
            {
                txtTotalExpenses.Text = value.ToString("C2");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double TotalProfit
        {
            set
            {
                txtTotalProfit.Text = value.ToString("C2");
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

        public void SetTopSelling(GunaHorizontalBarDataset dataSet)
        {
            chartTopSelling.Datasets.Clear();
            chartTopSelling.Datasets.Add(dataSet);
        }

        public void SetDailySalesTrend(GunaLineDataset dailySalesTrendDataSet)
        {
            chartDailySales.Datasets.Clear();
            chartDailySales.Datasets.Add(dailySalesTrendDataSet);
        }

        public void SetMonthlySalesTrend(GunaBarDataset monthlySalesTrendDataset, GunaBarDataset monthlyExpenseTrendDataset)
        {
            chartMonthlySales.Datasets.Clear();
            chartMonthlySales.Datasets.Add(monthlySalesTrendDataset);
            chartMonthlySales.Datasets.Add(monthlyExpenseTrendDataset);
        }

        public void SetInventoryStatus(GunaBarDataset inventoryStatusDataset)
        {
            chartInventoryStatus.Datasets.Clear();
            chartInventoryStatus.Datasets.Add(inventoryStatusDataset);
        }

        public void SetProjectExpenseDistribution(GunaDoughnutDataset projectDataSet)
        {
            chartProjectExpenseDistribution.Datasets.Clear();
            chartProjectExpenseDistribution.Datasets.Add(projectDataSet);
        }

        public void SetProgressBars(int itemSold, int sales)
        {
            progressBarItemSold.Value = itemSold;
            progressBarSales.Value = sales;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEvent?.Invoke(sender, e);
        }
    }
}
