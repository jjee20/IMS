using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Models.Inventory;

namespace RavenTechV2.Views;

public sealed partial class WarehouseDetailsDialog : ContentDialog
{
    public WarehouseDetailsDialogViewModel ViewModel
    {
        get;
    }

    public WarehouseDetailsDialog(WarehouseVM Warehouse)
    {
        ViewModel = new WarehouseDetailsDialogViewModel(Warehouse);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class WarehouseDetailsDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private WarehouseVM warehouse;

    public WarehouseDetailsDialogViewModel(WarehouseVM entity)
    {
        Warehouse = entity;
    }
}
