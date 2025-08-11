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

public partial class UnitOfMeasureViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot
    {
        get; set;
    }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Inventory", "UOM" };
    private List<UnitOfMeasureVM> _allUnitOfMeasures = new();
    public PagerHelper<UnitOfMeasureVM> Pager { get; } = new PagerHelper<UnitOfMeasureVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public UnitOfMeasureViewModel()
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
        var data = _mapper.Map<IEnumerable<UnitOfMeasureVM>>(
                await _unitOfService.UnitOfMeasure.Value.GetAllAsync()
            );
        _allUnitOfMeasures = data.ToList();
        Pager.SetItems(_allUnitOfMeasures);
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
        var matches = _allUnitOfMeasures
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

        IEnumerable<UnitOfMeasureVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allUnitOfMeasures
         : _allUnitOfMeasures.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new UnitOfMeasure();
        var result = await _dialogService.ShowDialogAsync(
            () => new UnitOfMeasureDialog(entity),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.UnitOfMeasure.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Unit Of Measure '{entity.Name}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(UnitOfMeasureVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.UnitOfMeasure.Value.GetAsync(x => x.UnitOfMeasureId == vm.UnitOfMeasureId);
        var dialog = new UnitOfMeasureDialog(entity, "Edit Unit Of Measure");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            var updatedTopic = dialog.ViewModel.UnitOfMeasure;
            _unitOfService.UnitOfMeasure.Value.Update(updatedTopic);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Unit Of Measure '{entity.Name}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(UnitOfMeasureVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete UnitOfMeasure",
            Content = $"Are you sure you want to delete the Unit Of Measure '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.UnitOfMeasure.Value.GetAsync(e => e.UnitOfMeasureId == vm.UnitOfMeasureId);

            _unitOfService.UnitOfMeasure.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Unit Of Measure '{selectedEntity.Name}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(UnitOfMeasureVM vm)
    {
        var dialog = new UnitOfMeasureDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print UnitOfMeasure Report",
            Content = $"Are you sure you want to print Unit Of Measure report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var UnitOfMeasuresToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "UnitOfMeasure Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Unit Of Measures" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                UnitOfMeasuresToPrint.Select(c => new
                {
                    c.UnitOfMeasureId,
                    c.Name,
                    c.Symbol,
                })
            );
            Notifier.Show($"Unit Of Measure report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Unit Of Measures to Excel",
            Content = $"Are you sure you want to export the Unit Of Measure report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var UnitOfMeasuresToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = UnitOfMeasuresToExport.Select(c => new
            {
                c.UnitOfMeasureId,
                c.Name,
                c.Symbol
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Unit Of Measure Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
