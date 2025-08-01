using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class UnitOfMeasureDialog : ContentDialog
{
    public UnitOfMeasureDialogViewModel ViewModel
    {
        get;
    }

    public UnitOfMeasureDialog(UnitOfMeasure UnitOfMeasure, string title = "Add Unit Of Measure")
    {
        ViewModel = new UnitOfMeasureDialogViewModel(UnitOfMeasure, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class UnitOfMeasureDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private UnitOfMeasure unitOfMeasure;

    [ObservableProperty]
    private string dialogTitle; 

    public UnitOfMeasureDialogViewModel(UnitOfMeasure entity, string title)
    {
        UnitOfMeasure = entity;
        DialogTitle = title;
    }
}
