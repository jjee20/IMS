using Syncfusion.WinForms.DataGrid;

namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IChangePasswordView
    {
        SfDataGrid DataGrid { get; }
        string Password { get; set; }
        string NewPassword { get; set; }
        string ConfirmNewPassword { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        event EventHandler SaveEvent;
    }
}