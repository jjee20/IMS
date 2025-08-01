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

public sealed partial class CategoryDialog : ContentDialog
{
    public CategoryDialogViewModel ViewModel
    {
        get;
    }

    public CategoryDialog(Category Category, string title = "Add Category")
    {
        ViewModel = new CategoryDialogViewModel(Category, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class CategoryDialogViewModel : ObservableObject
{
    [ObservableProperty]
    private Category category;

    [ObservableProperty]
    private string dialogTitle; 

    public CategoryDialogViewModel(Category entity, string title)
    {
        Category = entity;
        DialogTitle = title;
    }
}
