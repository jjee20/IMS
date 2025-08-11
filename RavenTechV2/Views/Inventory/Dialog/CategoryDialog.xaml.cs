using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
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

public partial class CategoryDialogViewModel : ValidatableViewModel
{
    [ObservableProperty]
    public int categoryId;
    [ObservableProperty]
    [Required(ErrorMessage = "Category name is required.")]
    private string name;
    public string NameError => GetError(nameof(Name));

    [ObservableProperty]
    public string description;
    public string DescriptionError => GetError(nameof(Description));

    [ObservableProperty]
    private string dialogTitle;

    [ObservableProperty]
    private bool isFormValid;

    public CategoryDialogViewModel(Category entity, string title)
    {
        CategoryId = entity.CategoryId;
        Name = entity.Name;
        Description = entity.Description;
    }

    public void ToEntity(Category entity)
    {
        entity.CategoryId = CategoryId;
        entity.Name = Name;
        entity.Description = Description;
    }

    partial void OnNameChanged(string value)
    {
        ValidateAllProperties();
        IsFormValid = !HasErrors;
        OnPropertyChanged(nameof(NameError));
    }

    partial void OnDescriptionChanged(string value)
    {
        ValidateAllProperties();
        IsFormValid = !HasErrors;
        OnPropertyChanged(nameof(DescriptionError));
    }
}
