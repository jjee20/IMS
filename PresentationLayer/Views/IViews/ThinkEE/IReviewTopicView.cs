using DomainLayer.ViewModels.ThinkEE;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.ThinkEE;
public interface IReviewTopicView : IMessageBase
{
    SfDataGrid DataGrid
    {
        get;
    }
    string SearchValue
    {
        get;
        set;
    }

    event EventHandler AddEvent;
    event CellClickEventHandler DeleteEvent;
    event CellClickEventHandler EditEvent;
    event KeyEventHandler MultipleDeleteEvent;
    event EventHandler PrintEvent;
    event EventHandler SearchEvent;



    void SetReviewTopicListBindingSource(IEnumerable<ReviewTopicViewModel> ReviewTopicList);
}