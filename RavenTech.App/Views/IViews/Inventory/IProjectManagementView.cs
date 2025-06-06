﻿using DomainLayer.ViewModels.PayrollViewModels;
using Syncfusion.WinForms.DataGrid;

namespace RavenTech_ERP.Views.IViews.Inventory
{
    public interface IProjectManagementView
    {
        SfDataGrid DataGrid { get; }
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
        double Total { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler DeleteProductEvent;
        event EventHandler UpdateComputationEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler PrintProjectEvent;
        event EventHandler ProductAddEvent;
        event EventHandler RefreshEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;

        void SetProductListBindingSource(BindingSource ProductBindingSource);
        void SetProjectLineListBindingSource(BindingSource ProjectLineList);
        void SetProjectListBindingSource(BindingSource ProjectList);
    }
}