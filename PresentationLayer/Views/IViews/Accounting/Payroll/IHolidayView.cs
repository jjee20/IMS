﻿using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IHolidayView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        string SearchValue { get; set; }

        event EventHandler AddEvent;
        event CellClickEventHandler DeleteEvent;
        event CellClickEventHandler EditEvent;
        event KeyEventHandler MultipleDeleteEvent;
        event EventHandler PrintEvent;
        event EventHandler SearchEvent;

        void SetHolidayListBindingSource(IEnumerable<HolidayViewModel> HolidayList);
    }
}