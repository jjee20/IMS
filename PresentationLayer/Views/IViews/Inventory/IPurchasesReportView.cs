using Guna.Charts.WinForms;
using RavenTech_ERP.Views.UserControls.Inventory;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IPurchasesReportView
    {
        double Purchases { set; }
        int Year { get; }
        int Month { get; }

        event EventHandler UpdatePurchasesReportEvent;
        event EventHandler RefreshEvent;

        static abstract PurchasesReportView GetInstance(TabPage parentContainer);
        void SetDailyPurchasesChart(GunaBarDataset purchasesbarDataset);
        void SetDailyPurchasesDataGrid(BindingSource bindingSource);
        void SetMonthlyPurchasesDataGrid(BindingSource bindingSource);
        void SetAnnuallyPurchasesDataGrid(BindingSource bindingSource);
        void SetMonths(BindingSource bindingSource);
        void SetYears(BindingSource bindingSource);
    }
}