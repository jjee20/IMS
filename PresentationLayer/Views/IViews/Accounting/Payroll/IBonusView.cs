using DomainLayer.Enums;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IBonusView
    {
        SfDataGrid DataGrid { get; }
        int BonusId { get; set; }
        public BonusType BonusType { get; set; }
        double Amount { get; set; }
        string Description { get; set; }
        int EmployeeId { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        bool IsOneTime { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;

        void SetBonusListBindingSource(BindingSource BonusList);
        void SetBonusTypeListBindingSource(BindingSource BonusTypeList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}