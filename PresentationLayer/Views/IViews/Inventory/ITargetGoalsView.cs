namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface ITargetGoalsView
    {
        string Message { set; }
        double ItemSoldCurrent { get; set; }
        string ItemSoldProgress { set; }
        double ItemSoldRemaining { set; }
        double ItemSoldTarget { get; set; }
        double SalesCurrent { get; set; }
        string SalesProgress { set; }
        double SalesRemaining { set; }
        double SalesTarget { get; set; }
        double YearCurrent { get; set; }
        string YearProgress { set; }
        double YearRemaining { set; }
        double YearTarget { get; set; }
        string Year { set; }

        event EventHandler SaveClicked;
    }
}