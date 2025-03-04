using DomainLayer.ViewModels.PayrollViewModels;

namespace PresentationLayer.Views.UserControls
{
    public interface IProjectManagementView
    {
        double Budget { get; set; }
        string Client { get; set; }
        string Description { get; set; }
        DateTime EndDate { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        bool NonStock { get; set; }
        string NonStockProductName { get; set; }
        double ProductDiscount { get; set; }
        int ProductId { get; set; }
        double ProductPrice { get; set; }
        double ProductQuantity { get; set; }
        int ProjectId { get; set; }
        List<ProjectLineViewModel> ProjectLines { get; set; }
        string ProjectName { get; set; }
        double Revenue { get; set; }
        string SearchValue { get; set; }
        DateTime StartDate { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event DataGridViewCellEventHandler DeleteProductEvent;
        event EventHandler EditEvent;
        event EventHandler FreightEvent;
        event EventHandler PaymentDiscountEvent;
        event EventHandler PrintEvent;
        event DataGridViewCellEventHandler PrintSOEvent;
        event EventHandler ProductAddEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetProductListBindingSource(BindingSource ProductBindingSource);
        void SetProjectLineListBindingSource(BindingSource ProjectLineList);
        void SetProjectListBindingSource(BindingSource ProjectList);
    }
}