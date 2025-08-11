using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Contracts.ViewModels;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.Views;

namespace RavenTechV2.ViewModels;

public partial class ProductViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot { get; set; }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Inventory", "Productes" }; 
    private List<ProductVM> _allProducts = new();
    public PagerHelper<ProductVM> Pager { get; } = new PagerHelper<ProductVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public ProductViewModel()
    {
        _pdfReportService = App.GetService<PrintReportService>();
        _unitOfService = App.GetService<IUnitOfService>();
        _dialogService = App.GetService<IDialogService>();
        Notifier = App.GetService<NotificationService>();
        _mapper = App.GetService<IMapper>();
    }

    public async void OnNavigatedTo(object parameter)
    {
        await ReloadAsync();
    }

    private async Task ReloadAsync()
    {
        var data = _mapper.Map<IEnumerable<ProductVM>>(
                await _unitOfService.Product.Value.GetAllAsync()
            );
        _allProducts = data.ToList();
        Pager.SetItems(_allProducts);
    }
    // RelayCommands for paging
    [RelayCommand]
    public void FirstPage() => Pager.FirstPage();

    [RelayCommand]
    public void PrevPage() => Pager.PrevPage();

    [RelayCommand]
    public void NextPage() => Pager.NextPage();

    [RelayCommand]
    public void LastPage() => Pager.LastPage();

    partial void OnSearchTextChanged(string value)
    {
        UpdateSuggestions(value);
        DebounceFilter();
    }

    private void UpdateSuggestions(string value)
    {
        SearchSuggestions.Clear();
        if (string.IsNullOrWhiteSpace(value))
            return;

        // Example: suggest from all unique names and emails
        var matches = _allProducts
            .SelectMany(c => c.GetType().GetProperties().Select(p => p.GetValue(c)?.ToString()))
            .Where(field => !string.IsNullOrWhiteSpace(field) && field.Contains(value, StringComparison.OrdinalIgnoreCase))
            .Distinct()
            .Take(10);

        foreach (var match in matches)
            SearchSuggestions.Add(match);
    }

    private async void DebounceFilter()
    {
        _debounceCts?.Cancel();
        var cts = _debounceCts = new CancellationTokenSource();
        try
        {
            await Task.Delay(300, cts.Token); // 300ms debounce
            FilterData();
        }
        catch (TaskCanceledException) { }
    }

    private async void FilterData()
    {
        if (string.IsNullOrEmpty(SearchText))
        {
            await ReloadAsync();
            return;
        }

        IEnumerable<ProductVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allProducts
         : _allProducts.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new Product();
        var result = await _dialogService.ShowDialogAsync(
            () => new ProductDialog(entity),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.Product.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Product '{entity.ProductName}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(ProductVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.Product.Value.GetAsync(x => x.ProductId == vm.ProductId);
        var dialog = new ProductDialog(entity, "Edit Product");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            dialog.ViewModel.ApplyToEntity(entity);
            _unitOfService.Product.Value.Update(entity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Product '{entity.ProductName}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(ProductVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Product",
            Content = $"Are you sure you want to delete the Product '{vm.ProductName}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.Product.Value.GetAsync(e => e.ProductId == vm.ProductId);

            _unitOfService.Product.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Product '{selectedEntity.ProductName}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(ProductVM vm)
    {
        var dialog = new ProductDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print Product Report",
            Content = $"Are you sure you want to print Product report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if(result == ContentDialogResult.Primary)
        {
            var ProductsToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "Product Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Products" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                ProductsToPrint.Select(c => new
                {
                    c.ProductId,
                    c.ProductName
                })
            );
            Notifier.Show($"Product report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Products to Excel",
            Content = $"Are you sure you want to export the Product report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var ProductsToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = ProductsToExport.Select(c => new
            {
                c.ProductId,
                c.ProductName
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Product Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
