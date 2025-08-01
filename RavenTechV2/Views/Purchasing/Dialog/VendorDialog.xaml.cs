using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Purchasing;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class VendorDialog : ContentDialog
{
    public VendorDialogViewModel ViewModel
    {
        get;
    }

    public VendorDialog(Vendor Vendor, string title = "Add Vendor")
    {
        ViewModel = new VendorDialogViewModel(Vendor, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class VendorDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private Vendor vendor;

    [ObservableProperty]
    private string dialogTitle; 
    [ObservableProperty]
    private EnumDescriptionItem<VendorType> selectedVendorType;

    public ObservableCollection<EnumDescriptionItem<VendorType>> VendorTypes
    {
        get;
    }

    public VendorDialogViewModel(Vendor entity, string title)
    {
        Vendor = entity;
        DialogTitle = title;
        VendorTypes = EnumHelper.GetEnumDescriptionList<VendorType>();

        SelectedVendorType = VendorTypes.FirstOrDefault(x => x.Value == Vendor.Type);
    }
    partial void OnSelectedVendorTypeChanged(EnumDescriptionItem<VendorType>? value)
    {
        if (value != null)
        {
            Vendor.Type = value.Value;
        }
    }
}
