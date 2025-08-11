using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Contracts.ViewModels;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.MasterData;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.Views;
using ServiceLayer.Services.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenTechV2.ViewModels;

public partial class CategoryViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot
    {
        get; set;
    }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Inventory", "Category" };
    private List<CategoryVM> _allCategorys = new();
    public PagerHelper<CategoryVM> Pager { get; } = new PagerHelper<CategoryVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public CategoryViewModel()
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
        var data = _mapper.Map<IEnumerable<CategoryVM>>(
                await _unitOfService.Category.Value.GetAllAsync()
            );
        _allCategorys = data.ToList();
        Pager.SetItems(_allCategorys);
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
        var matches = _allCategorys
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

        IEnumerable<CategoryVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allCategorys
         : _allCategorys.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new Category();
        var dialog = new CategoryDialog(entity);
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            dialog.ViewModel.ToEntity(entity);
            await _unitOfService.Category.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Category '{entity.Name}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(CategoryVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.Category.Value.GetAsync(x => x.CategoryId == vm.CategoryId);
        var dialog = new CategoryDialog(entity, "Edit Category");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            dialog.ViewModel.ToEntity(entity);
            _unitOfService.Category.Value.Update(entity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Category '{entity.Name}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(CategoryVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Category",
            Content = $"Are you sure you want to delete the Category '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.Category.Value.GetAsync(e => e.CategoryId == vm.CategoryId);

            _unitOfService.Category.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Category '{selectedEntity.Name}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(CategoryVM vm)
    {
        var dialog = new CategoryDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print Category Report",
            Content = $"Are you sure you want to print Category report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var CategorysToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "Category Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Category" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                CategorysToPrint.Select(c => new
                {
                    c.CategoryId,
                    c.Name,
                    c.Description,
                })
            );
            Notifier.Show($"Category report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Category to Excel",
            Content = $"Are you sure you want to export the Category report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var CategorysToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = CategorysToExport.Select(c => new
            {
                c.CategoryId,
                c.Name,
                c.Description
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Category Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
