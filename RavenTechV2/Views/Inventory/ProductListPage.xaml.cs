using AutoMapper;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Services;
using RavenTechV2.ViewModels;
using ServiceLayer.Services.IRepositories;

namespace RavenTechV2.Views;

public sealed partial class ProductListPage : Page
{
    public ProductListViewModel ViewModel
    {
        get;
    }
    private readonly IUnitOfService _unitOfService;
    private readonly IMapper _mapper;
    public ProductListPage()
    {
        _unitOfService = App.GetService<IUnitOfService>();
        _mapper = App.GetService<IMapper>();
        ViewModel = App.GetService<ProductListViewModel>();
        InitializeComponent();
        this.DataContext = ViewModel;
    }

    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        //var newProduct = new Product();
        //var dialog = new ProductFormDialogPage(newProduct, "Add Product") { XamlRoot = this.XamlRoot };
        //var result = await dialog.ShowAsync();
        //if (result == ContentDialogResult.Primary)
        //{
        //    await _unitOfService.Product.Value.AddAsync(newProduct);
        //    await _unitOfService.SaveChangesAsync();
        //    await ViewModel.ReloadAsync();
        //}
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is ProductViewModel productVM)
        {
            //var product = await _unitOfService.Product.Value.GetAsync(c => c.ProductId == productVM.ProductId);
            //var dialog = new ProductFormDialogPage(product, "Edit Product") { XamlRoot = this.XamlRoot };
            //var result = await dialog.ShowAsync();
            //if (result == ContentDialogResult.Primary)
            //{
            //    _unitOfService.Product.Value.Update(product);
            //    await _unitOfService.SaveChangesAsync();
            //    await ViewModel.ReloadAsync();
            //}
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is ProductViewModel productVM)
        {
            var dialog = new ContentDialog
            {
                Title = "Delete Product",
                Content = $"Are you sure you want to delete {productVM.ProductName}?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel",
                XamlRoot = this.XamlRoot
            };
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var product = await _unitOfService.Product.Value.GetAsync(c => c.ProductId == productVM.ProductId);
                _unitOfService.Product.Value.Remove(product);
                await _unitOfService.SaveChangesAsync();
                await ViewModel.ReloadAsync();
            }
        }
    }


}
