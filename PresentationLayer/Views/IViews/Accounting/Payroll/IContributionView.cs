using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IContributionView
    {
        int ContributionId { get; set; }
        ContributionType ContributionType { get; set; }
        double Rate { get; set; }
        double MinimumLimit { get; set; }
        double MaximumLimit { get; set; }
        double MandatoryProvidentFund { get; set; }
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

        void SetContributionListBindingSource(BindingSource ContributionList);
        void SetContributionTypeListBindingSource(BindingSource ContributionTypeList);
    }
}