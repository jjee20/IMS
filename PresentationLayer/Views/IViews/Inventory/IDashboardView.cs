using Guna.Charts.WinForms;

namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IDashboardView
    {
        string OutOfStock { get; set; }
        string Sales { get; set; }
        string Purchased { get; set; }
        string OnHand { get; set; }
        string LowStockItem { get; set; }
        string AllItemGroup { get; set; }
        string AllItem { get; set; }
        string POToday { get; set; }
        string PO7Days { get; set; }
        string POThisMonth { get; set; }
        string POAnnual { get; set; }
        string SOToday { get; set; }
        string SO7Days { get; set; }
        string SOThisMonth { get; set; }
        string SOAnnual { get; set; }
        void SetTopSellingItemListBindingSource(BindingSource TopSellingItemList);
        void SetChartInventoryStatusBindingSource(GunaBarDataset gunaBarDataset);
        void SetChartSalesStatusBindingSource(GunaLineDataset gunaBarDataset);
    }
}