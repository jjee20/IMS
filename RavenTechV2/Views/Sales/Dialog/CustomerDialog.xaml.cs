using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class CustomerDialog : ContentDialog
{
    public CustomerDialogViewModel ViewModel
    {
        get;
    }

    public CustomerDialog(Customer customer, string title = "Add Customer")
    {
        ViewModel = new CustomerDialogViewModel(customer, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class CustomerDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private Customer customer;

    [ObservableProperty]
    private string dialogTitle; 
    [ObservableProperty]
    private EnumDescriptionItem<CustomerType> selectedCustomerType;

    public ObservableCollection<EnumDescriptionItem<CustomerType>> CustomerTypes
    {
        get;
    }

    public CustomerDialogViewModel(Customer entity, string title)
    {
        Customer = entity;
        DialogTitle = title;
        CustomerTypes = EnumHelper.GetEnumDescriptionList<CustomerType>();

        SelectedCustomerType = CustomerTypes.FirstOrDefault(x => x.Value == entity.Type);
    }
    partial void OnSelectedCustomerTypeChanged(EnumDescriptionItem<CustomerType>? value)
    {
        if (value != null)
        {
            Customer.Type = value.Value;
        }
    }
}
