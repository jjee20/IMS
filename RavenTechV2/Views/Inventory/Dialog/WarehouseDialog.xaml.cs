using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;

namespace RavenTechV2.Views;

public sealed partial class WarehouseDialog : ContentDialog
{
    public WarehouseDialogViewModel ViewModel
    {
        get;
    }

    public WarehouseDialog(Warehouse Warehouse, string title = "Add Warehouse")
    {
        ViewModel = new WarehouseDialogViewModel(Warehouse, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class WarehouseDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private Warehouse warehouse;

    [ObservableProperty]
    private string dialogTitle;

    [ObservableProperty]
    private Branch selectedBranch;

    private readonly IUnitOfService _unitOfService;

    // Correct type
    public ObservableCollection<Branch> Branches { get; } = new();

    public WarehouseDialogViewModel(Warehouse entity, string title)
    {
        _unitOfService = App.GetService<IUnitOfService>();
        Warehouse = entity;
        DialogTitle = title;
        _ = LoadBranchesAsync();
    }

    private async Task LoadBranchesAsync()
    {
        var branches = await _unitOfService.Branch.Value.GetAllAsync();
        Branches.Clear();
        foreach (var branch in branches)
            Branches.Add(branch);

        // Now set SelectedBranch if editing existing
        if (Warehouse.Branch != null)
            SelectedBranch = Branches.FirstOrDefault(x => x.BranchId == Warehouse.BranchId);
    }

    partial void OnSelectedBranchChanged(Branch value)
    {
        if (value != null)
            Warehouse.BranchId = value.BranchId;
    }
}
