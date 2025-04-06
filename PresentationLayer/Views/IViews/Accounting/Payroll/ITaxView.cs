using DomainLayer.Models.Accounting.Payroll;
using RavenTech_ERP.Views.IViews;
using Syncfusion.WinForms.DataGrid;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface ITaxView : IMessageBase
    {
        SfDataGrid DataGrid { get; }
        int TaxId { get; set; }
        double MinimumSalary { get; set; }
        double MaximumSalary { get; set; }
        double TaxRate { get; set; }
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

        void SetTaxListBindingSource(IEnumerable<Tax> TaxList);
    }
}