using AutoMapper;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using RavenTechV2.ViewModels;
using ServiceLayer.Services.IRepositories;

namespace RavenTechV2.Views;

public sealed partial class ProductListPage : Page
{
    public ProductListViewModel ViewModel
    {
        get;
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductListPage()
    {
        _unitOfWork = App.GetService<IUnitOfWork>();
        _mapper = App.GetService<IMapper>();
        ViewModel = App.GetService<ProductListViewModel>();
        InitializeComponent();
        this.DataContext = ViewModel;
    }

    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var newProduct = new Product();
        var dialog = new ProductFormDialogPage(newProduct, "Add Product") { XamlRoot = this.XamlRoot };
        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            _unitOfWork.Product.Value.Add(newProduct);
            await _unitOfWork.SaveAsync();
            await ViewModel.ReloadAsync();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is ProductViewModel productVM)
        {
            var product = await _unitOfWork.Product.Value.GetAsync(c => c.ProductId == productVM.ProductId);
            var dialog = new ProductFormDialogPage(product, "Edit Product") { XamlRoot = this.XamlRoot };
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                _unitOfWork.Product.Value.Update(product);
                await _unitOfWork.SaveAsync();
                await ViewModel.ReloadAsync();
            }
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
                var product = await _unitOfWork.Product.Value.GetAsync(c => c.ProductId == productVM.ProductId);
                _unitOfWork.Product.Value.Remove(product);
                await _unitOfWork.SaveAsync();
                await ViewModel.ReloadAsync();
            }
        }
    }


}
