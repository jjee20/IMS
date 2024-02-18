namespace PresentationLayer.Views.IViews
{
    public interface ICustomerView
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        int CustomerTypeId { get; set; }
        string BarangayCode { get; set; }
        string CityCode { get; set; }
        string ProvinceCode { get; set; }
        string RegionCode { get; set; }
        string ZipCode { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string ContactPerson { get; set; }
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

        event EventHandler RegionEvent;
        event EventHandler ProvinceEvent;
        event EventHandler CityEvent;

        event DataGridViewCellEventHandler DisplayCustomerEvent;

        void SetAddressBindingSource(BindingSource barangayBindingSource,
                                     BindingSource municipalityBindingSource,
                                     BindingSource provinceBindingSource,
                                     BindingSource regionBindingSource);
        void SetCustomerListBindingSource(BindingSource CustomerList);
        void SetCustomerTypeListBindingSource(BindingSource customerTypeBindingSource);
    }
}