using DomainLayer.Enums;
using DomainLayer.ViewModels.AccountViewModels;
using Syncfusion.WinForms.DataGrid;

namespace PresentationLayer.Views.IViews.Account
{
    public interface IRegisterView
    {
        string Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        int Department { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        bool Adding { get; set; }
        bool Editing { get; set; }
        bool Deleting { get; set; }
        bool Viewing { get; set; }
        bool Overriding { get; set; }
        SfDataGrid DataGrid { get; }
        void SetRegisterListBindingSource(IEnumerable<AccountViewModel> RegisterList);
        void SetDepartmentListBindingSource(BindingSource departmentBindingSource);

        event EventHandler AddNewEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
    }
}