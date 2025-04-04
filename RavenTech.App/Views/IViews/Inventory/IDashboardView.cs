using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using Syncfusion.WinForms.DataGrid;

namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IDashboardView
    {
        string Gross { set; }
        string Sales { set; }
        string Expense { set; }
        string SalesToday { set; }
        string ItemSoldToday { set; }
        string ExpenseToday { set; }
        int Year { get; }
        int Month { get; }
        double ExpenseTodayItemsSold { set; }
        double ExpenseTodayItemsSoldTarget { set; }
        double ExpenseTodaySales { set; }
        double ExpenseTodaySalesTarget { set; }
        double TotalExpense { set; }
        double TotalProfit { set; }
        event EventHandler UpdateDashboardEvent;
        void SetYear(BindingSource dataSource);
        void SetMonth(BindingSource dataSource);
        void SetTopSelling(GunaHorizontalBarDataset topSellingItemsBindingSource);
        void SetDailySalesTrend(GunaLineDataset dailySalesTrendDataSet);
        void SetMonthlySalesTrend(GunaBarDataset monthlySalesTrendDataset, GunaBarDataset monthlyExpenseTrendDataset);
        void SetInventoryStatus(GunaBarDataset monthlySalesTrendDataset);
        void SetProjectExpenseDistribution(GunaDoughnutDataset projectDataSet);
        void SetProgressBars(int itemSold, int sales);
    }
}