using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
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
    public partial class DashboardView : UserControl, IDashboardView
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

        public string Gross
        {
            set { txtGross.Text = value; }
        }
        public string Sales
        {
            set { txtSales.Text = value; }
        }
        public string Expense
        {
            set { txtExpense.Text = value; }
        }
        public string SalesToday
        {
            set { txtSalesToday.Text = value; }
        }

        public string ItemSoldToday
        {
            set { txtItemSoldToday.Text = value; }
        }

        public string ExpenseToday
        {
            set { txtExpenseToday.Text = value; }
        }

        public int Year
        {
            get {
                    if (txtYear.DataSource != null)
                        return (int)txtYear.SelectedValue;
                    else return 0;
            }
        }
        public int Month
        {
            get { return (int)txtMonth.SelectedValue; }
        }
        public double ExpenseTodayItemsSold
        {
            set { txtExpenseItemsSold.Text = value.ToString("N2"); }
        }
        public double ExpenseTodayItemsSoldTarget
        {
            set { txtExpenseItemsSoldTarget.Text = value.ToString("N2"); }
        }
        public double ExpenseTodaySales
        {
            set { txtExpenseSales.Text = value.ToString("N2"); }
        }
        public double ExpenseTodaySalesTarget
        {
            set { txtExpenseSalesTarget.Text = value.ToString("N2"); }
        }
        public double TotalExpense
        {
            set { txtTotalExpenses.Text = value.ToString("N2"); }
        }
        public double TotalProfit
        {
            set { txtTotalProfit.Text = value.ToString("N2"); }
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
    }
}
