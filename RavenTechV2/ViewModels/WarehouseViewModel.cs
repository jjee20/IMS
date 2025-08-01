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
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.Views;
using ServiceLayer.Services.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenTechV2.ViewModels;

public partial class WarehouseViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot
    {
        get; set;
    }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Inventory", "Warehouses" };
    private List<WarehouseVM> _allWarehouses = new();
    public PagerHelper<WarehouseVM> Pager { get; } = new PagerHelper<WarehouseVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public WarehouseViewModel()
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
        var data = _mapper.Map<IEnumerable<WarehouseVM>>(
                await _unitOfService.Warehouse.Value.GetAllAsync(includeProperties: "Branch")
            );
        _allWarehouses = data.ToList();
        Pager.SetItems(_allWarehouses);
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
        var matches = _allWarehouses
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

        IEnumerable<WarehouseVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allWarehouses
         : _allWarehouses.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new Warehouse();
        var result = await _dialogService.ShowDialogAsync(
            () => new WarehouseDialog(entity),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.Warehouse.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Warehouse '{entity.Name}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(WarehouseVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.Warehouse.Value.GetAsync(x => x.WarehouseId == vm.WarehouseId);
        var dialog = new WarehouseDialog(entity, "Edit Warehouse");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            var updatedTopic = dialog.ViewModel.Warehouse;
            _unitOfService.Warehouse.Value.Update(updatedTopic);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Warehouse '{entity.Name}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(WarehouseVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Warehouse",
            Content = $"Are you sure you want to delete the Warehouse '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.Warehouse.Value.GetAsync(e => e.WarehouseId == vm.WarehouseId);

            _unitOfService.Warehouse.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Warehouse '{selectedEntity.Name}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(WarehouseVM vm)
    {
        var dialog = new WarehouseDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print Warehouse Report",
            Content = $"Are you sure you want to print Warehouse report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var WarehousesToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "Warehouse Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Warehouses" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                WarehousesToPrint.Select(c => new
                {
                    c.WarehouseId,
                    c.Name,
                    c.Branch,
                    c.Description
                })
            );
            Notifier.Show($"Warehouse report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Warehouses to Excel",
            Content = $"Are you sure you want to export the Warehouse report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var WarehousesToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = WarehousesToExport.Select(c => new
            {
                c.WarehouseId,
                c.Name,
                c.Branch,
                c.Description
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Warehouse Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
