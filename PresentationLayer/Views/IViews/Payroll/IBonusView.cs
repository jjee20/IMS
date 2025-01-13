using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IBonusView
    {
        int BonusId { get; set; }
        public BonusType BonusType { get; set; }
        double Amount { get; set; }
        string Description { get; set; }
        int EmployeeId { get; set; }
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

        void SetBonusListBindingSource(BindingSource BonusList);
        void SetBonusTypeListBindingSource(BindingSource BonusTypeList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}