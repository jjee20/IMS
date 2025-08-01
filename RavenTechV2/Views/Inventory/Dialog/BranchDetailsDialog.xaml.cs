using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.MasterData;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class BranchDetailsDialog : ContentDialog
{
    public BranchDetailsDialogViewModel ViewModel
    {
        get;
    }

    public BranchDetailsDialog(BranchVM Branch)
    {
        ViewModel = new BranchDetailsDialogViewModel(Branch);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class BranchDetailsDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private BranchVM branch;

    public BranchDetailsDialogViewModel(BranchVM entity)
    {
        Branch = entity;
    }
}
