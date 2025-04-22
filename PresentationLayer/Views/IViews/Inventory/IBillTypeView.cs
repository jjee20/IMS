using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews
{
    public interface IBillTypeView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event CellClickEventHandler DeleteEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event CellClickEventHandler EditEvent;
        event EventHandler AddEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;
        void SetBillTypeListBindingSource(IEnumerable<BillTypeViewModel> BillTypeList);
    }
}