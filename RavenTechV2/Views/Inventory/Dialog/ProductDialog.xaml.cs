using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Enums;
using RavenTechV2.Core.Helpers;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Helpers;
using RavenTechV2.Services;

namespace RavenTechV2.Views;

public sealed partial class ProductDialog : ContentDialog
{
    public ProductDialogViewModel ViewModel
    {
        get;
    }

    public ProductDialog(Product Product, string title = "Add Product")
    {
        ViewModel = new ProductDialogViewModel(Product, title);
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }
}

public partial class ProductDialogViewModel : ObservableValidator
{
    [ObservableProperty]
    private bool isFormValid;

    // Properties for each field you want to validate
    [ObservableProperty]
    [Required(ErrorMessage = "Product Name is required.")]
    public string productName;

    [ObservableProperty]
    [Required(ErrorMessage = "Product Code is required.")]
    public string productCode;

    [ObservableProperty]
    public string description;

    [ObservableProperty]
    [Required(ErrorMessage = "Product Type is required.")]
    public ProductType productType;

    [ObservableProperty]
    [Required(ErrorMessage = "Category is required.")]
    public int categoryId;

    [ObservableProperty]
    public string brand;

    [ObservableProperty]
    public string color;

    [ObservableProperty]
    public string size;

    [ObservableProperty]
    [Required(ErrorMessage = "Unit of Measure is required.")]
    public int unitOfMeasureId;

    [ObservableProperty]
    [Range(0.01, double.MaxValue, ErrorMessage = "Buying Price must be greater than zero.")]
    public decimal defaultBuyPrice;

    [ObservableProperty]
    [Range(0.01, double.MaxValue, ErrorMessage = "Selling Price must be greater than zero.")]
    public decimal defaultSellPrice;

    [ObservableProperty]
    [Range(0, int.MaxValue, ErrorMessage = "Reorder Level must be zero or greater.")]
    public int reorderLevel;

    [ObservableProperty]
    [Required(ErrorMessage = "Branch is required.")]
    public int branchId;

    [ObservableProperty]
    public bool isActive = true;

    [ObservableProperty]
    public string dialogTitle;

    // CTOR: Fill from Product model if needed
    public ProductDialogViewModel(Product entity, string title)
    {
        // copy values from entity (for Edit)
        ProductName = entity.ProductName;
        ProductCode = entity.ProductCode;
        Description = entity.Description;
        ProductType = entity.ProductType;
        CategoryId = entity.CategoryId;
        Brand = entity.Brand;
        Color = entity.Color;
        Size = entity.Size;
        UnitOfMeasureId = entity.UnitOfMeasureId;
        DefaultBuyPrice = entity.DefaultBuyPrice;
        DefaultSellPrice = entity.DefaultSellPrice;
        ReorderLevel = entity.ReorderLevel;
        BranchId = entity.BranchId;
        IsActive = entity.IsActive;
        DialogTitle = title;
    }

    // ToEntity for Save:
    public void ApplyToEntity(Product entity)
    {
        entity.ProductName = ProductName;
        entity.ProductCode = ProductCode;
        entity.Description = Description;
        entity.ProductType = ProductType;
        entity.CategoryId = CategoryId;
        entity.Brand = Brand;
        entity.Color = Color;
        entity.Size = Size;
        entity.UnitOfMeasureId = UnitOfMeasureId;
        entity.DefaultBuyPrice = DefaultBuyPrice;
        entity.DefaultSellPrice = DefaultSellPrice;
        entity.ReorderLevel = ReorderLevel;
        entity.BranchId = BranchId;
        entity.IsActive = IsActive;
    }
    private void UpdateIsFormValid()
    {
        IsFormValid = !HasErrors;
    }

    public bool Validate()
    {
        ValidateAllProperties();
        UpdateIsFormValid();
        return !HasErrors;
    }

    [RelayCommand]
    public void Save()
    {
        if (!Validate())
        {

            return;
        }
    }
}
