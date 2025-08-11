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

public sealed partial class BranchDialog : ContentDialog
{
    public BranchDialogViewModel ViewModel
    {
        get;
    }

    public BranchDialog(Branch branch, string title = "Add Branch")
    {
        ViewModel = new BranchDialogViewModel(branch, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class BranchDialogViewModel : ValidatableViewModel
{
    [ObservableProperty]
    private Branch branch;

    [ObservableProperty]
    private string dialogTitle; 

    public BranchDialogViewModel(Branch entity, string title)
    {
        Branch = entity;
        DialogTitle = title;
    }
}
