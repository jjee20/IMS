using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class CustomerDetailsDialog : ContentDialog
{
    public CustomerDetailsDialogViewModel ViewModel
    {
        get;
    }

    public CustomerDetailsDialog(CustomerVM customer)
    {
        ViewModel = new CustomerDetailsDialogViewModel(customer);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class CustomerDetailsDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private CustomerVM customer;

    public CustomerDetailsDialogViewModel(CustomerVM entity)
    {
        Customer = entity;
    }
}
