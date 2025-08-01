using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Purchasing.ViewModels;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class VendorDetailsDialog : ContentDialog
{
    public VendorDetailsDialogViewModel ViewModel
    {
        get;
    }

    public VendorDetailsDialog(VendorVM Vendor)
    {
        ViewModel = new VendorDetailsDialogViewModel(Vendor);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class VendorDetailsDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private VendorVM vendor;

    public VendorDetailsDialogViewModel(VendorVM entity)
    {
        Vendor = entity;
    }
}
