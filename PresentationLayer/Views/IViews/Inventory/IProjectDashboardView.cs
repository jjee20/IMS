using Guna.Charts.WinForms;
using MaterialSkin.Controls;
using PresentationLayer.Views.UserControls;

namespace RavenTech_ERP.Views.IViews.Inventory;
public interface IProjectDashboardView
{
    string TotalExpense
    {
        set;
    }
    string TotalProfit
    {
        set;
    }
    int Month
    {
        get;
    }
    string TotalRevenue
    {
        set;
    }
    int Year
    {
        get;
    }

    event EventHandler RefreshEvent;
    event EventHandler UpdateProjectDashboardEvent;

    static abstract ProjectDashboardView GetInstance(TabPage parentContainer);
    static abstract ProjectDashboardView GetNewInstance(MaterialCard parentContainer);
    void SetDailyTrend(GunaLineDataset dailyTrendDataSet);
    void SetInventoryStatus(GunaBarDataset inventoryStatusDataset);
    void SetMonth(BindingSource dataSource);
    void SetMonthlyTrend(GunaBarDataset monthlyRevenueTrendDataset, GunaBarDataset monthlyExpenseTrendDataset);
    void SetProjectExpenseDistribution(GunaDoughnutDataset projectDataSet);
    void SetTopProjects(GunaHorizontalBarDataset dataSet);
    void SetTopUsed(GunaHorizontalBarDataset dataSet);
    void SetYear(BindingSource dataSource);
}