namespace PresentationLayer.Views.IViews
{
    public interface ICurrencyView
    {
        string CurrencyCode { get; set; }
        int CurrencyId { get; set; }
        string CurrencyName { get; set; }
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetCurrencyListBindingSource(BindingSource CurrencyList);
    }
}