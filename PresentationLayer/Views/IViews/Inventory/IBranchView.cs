namespace PresentationLayer.Views.IViews
{
    public interface IBranchView
    {
        int BranchId { get; set; }
        string BranchName { get; set; }
        string Description { get; set; }
        string Address { get; set; }
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

        //void SetAddressBindingSource(List<string> barangayBindingSource,
        //                             List<string> municipalityBindingSource, 
        //                             List<string> provinceBindingSource, 
        //                             List<string> regionBindingSource);
        void SetBranchListBindingSource(BindingSource BranchList);
    }
}