using DomainLayer.Enums;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IBenefitView
    {
        SfDataGrid DataGrid { get; }
        int BenefitId { get; set; }
        public BenefitType BenefitType { get; set; }
        double Amount { get; set; }
        int EmployeeId { get; set; }
        string Other { get; set; }
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

        void SetBenefitListBindingSource(BindingSource BenefitList);
        void SetBenefitTypeListBindingSource(BindingSource BenefitTypeList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}