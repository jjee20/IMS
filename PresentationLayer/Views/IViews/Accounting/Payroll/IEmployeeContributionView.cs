using PresentationLayer.Views.UserControls;

namespace RavenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IEmployeeContributionView
    {
        int EmployeeContributionId { get; set; }
        int EmployeeId { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        double PagIbig { get; set; }
        double PhilHealth { get; set; }
        string SearchValue { get; set; }
        double SSS { get; set; }
        double SSSWISP { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        static abstract EmployeeContributionView GetInstance(TabPage parentContainer);
        void SetEmployeeContributionListBindingSource(BindingSource EmployeeContributionList);
        void SetEmployeeListBindingSource(BindingSource EmployeeList);
    }
}