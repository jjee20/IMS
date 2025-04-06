using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IBillTypeView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        int BillTypeId { get; set; }
        string BillTypeName { get; set; }
        string Description { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;
        void SetBillTypeListBindingSource(IEnumerable<BillType> BillTypeList);
    }
}