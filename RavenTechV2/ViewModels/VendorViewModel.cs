using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Contracts.ViewModels;
using RavenTechV2.Core.Models.Purchasing;
using RavenTechV2.Core.Models.Purchasing.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.Views;
using ServiceLayer.Services.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenTechV2.ViewModels;

public partial class VendorViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot { get; set; }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Purchasing", "Vendors" }; 
    private List<VendorVM> _allVendors = new();
    public PagerHelper<VendorVM> Pager { get; } = new PagerHelper<VendorVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public VendorViewModel()
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
        var data = _mapper.Map<IEnumerable<VendorVM>>(
                await _unitOfService.Vendor.Value.GetAllAsync(includeProperties: "PurchaseOrders.PurchaseOrderLines,Bills")
            );
        _allVendors = data.ToList();
        Pager.SetItems(_allVendors);
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
        var matches = _allVendors
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

        IEnumerable<VendorVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allVendors
         : _allVendors.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new Vendor();
        var result = await _dialogService.ShowDialogAsync(
            () => new VendorDialog(entity),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.Vendor.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Vendor '{entity.Name}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(VendorVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.Vendor.Value.GetAsync(x => x.VendorId == vm.VendorId);
        var dialog = new VendorDialog(entity, "Edit Vendor");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            var updatedTopic = dialog.ViewModel.Vendor;
            _unitOfService.Vendor.Value.Update(updatedTopic);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Vendor '{entity.Name}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(VendorVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Vendor",
            Content = $"Are you sure you want to delete the Vendor '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.Vendor.Value.GetAsync(e => e.VendorId == vm.VendorId);

            _unitOfService.Vendor.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Vendor '{selectedEntity.Name}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(VendorVM vm)
    {
        var dialog = new VendorDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print Vendor Report",
            Content = $"Are you sure you want to print Vendor report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if(result == ContentDialogResult.Primary)
        {
            var VendorsToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "Vendor Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Vendors" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                VendorsToPrint.Select(c => new
                {
                    c.VendorId,
                    c.Name,
                    c.Email,
                    c.Phone,
                })
            );
            Notifier.Show($"Vendor report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Vendors to Excel",
            Content = $"Are you sure you want to export the Vendor report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var VendorsToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = VendorsToExport.Select(c => new
            {
                c.VendorId,
                c.Name,
                c.Email,
                c.Phone,
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Vendor Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
