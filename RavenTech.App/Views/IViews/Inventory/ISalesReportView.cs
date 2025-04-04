using Guna.Charts.WinForms;
using RavenTech_ERP.Views.UserControls.Inventory;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface ISalesReportView
    {
        string Net { set; }
        string ItemSold { set; }
        double Purchases { get; set; }
        double Sales { get; set; }
        int Year { get; }
        int Month { get; }

        event EventHandler UpdateSalesReportEvent;

        static abstract SalesReportView GetInstance(TabPage parentContainer);
        void SetDailySalesChart(GunaBarDataset salesbarDataset, GunaBarDataset purchasesbarDataset);
        void SetDailySalesDataGrid(BindingSource bindingSource);
        void SetMonthlySalesChart(GunaBarDataset salesbarDataset, GunaBarDataset purchasesbarDataset);
        void SetMonthlySalesDataGrid(BindingSource bindingSource);
        void SetMonths(BindingSource bindingSource);
        void SetYears(BindingSource bindingSource);
    }
}