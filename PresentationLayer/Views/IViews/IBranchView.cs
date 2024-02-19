namespace PresentationLayer.Views.IViews
{
    public interface IBranchView
    {
        string BarangayCode { get; set; }
        int BranchId { get; set; }
        string BranchName { get; set; }
        string CityCode { get; set; }
        string ContactPerson { get; set; }
        int CurrencyId { get; set; }
        string Description { get; set; }
        string Email { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string Phone { get; set; }
        string ProvinceCode { get; set; }
        string RegionCode { get; set; }
        string SearchValue { get; set; }
        string ZipCode { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler CityEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler ProvinceEvent;
        event EventHandler RefreshEvent;
        event EventHandler RegionEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event DataGridViewCellEventHandler DisplayBranchEvent;
        void SetAddressBindingSource(BindingSource barangayBindingSource, BindingSource cityBindingSource, BindingSource provinceBindingSource, BindingSource regionBindingSource);
        void SetBranchListBindingSource(BindingSource BranchList);
        void SetCurrencyListBindingSource(BindingSource CurrencyBindingSource);
    }
}