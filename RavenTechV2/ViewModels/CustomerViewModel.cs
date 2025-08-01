using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoMapper;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Contracts.ViewModels;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.Views;
using ServiceLayer.Services.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenTechV2.ViewModels;

public partial class CustomerViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfService _unitOfService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    public XamlRoot? DialogXamlRoot { get; set; }
    public ObservableCollection<string> BreadcrumbItems { get; } = new() { "Home", "Sales", "Customers" }; 
    private List<CustomerVM> _allCustomers = new();
    public PagerHelper<CustomerVM> Pager { get; } = new PagerHelper<CustomerVM>();
    private readonly PrintReportService _pdfReportService;

    [ObservableProperty] private string? searchText;
    public ObservableCollection<string> SearchSuggestions { get; } = new();
    private CancellationTokenSource? _debounceCts;

    public NotificationService Notifier;
    public CustomerViewModel()
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
        var data = _mapper.Map<IEnumerable<CustomerVM>>(
                await _unitOfService.Customer.Value.GetAllAsync(includeProperties: "SalesOrders.SalesOrderLines,Invoices")
            );
        _allCustomers = data.ToList();
        Pager.SetItems(_allCustomers);
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
        var matches = _allCustomers
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

        IEnumerable<CustomerVM> filtered = string.IsNullOrWhiteSpace(SearchText)
         ? _allCustomers
         : _allCustomers.Where(item =>
             item.GetType().GetProperties()
                 .Select(p => p.GetValue(item)?.ToString())
                 .Any(val => val?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0));
        Pager.SetItems(filtered);
    }

    [RelayCommand]
    public async void Add()
    {
        var entity = new Customer();
        var result = await _dialogService.ShowDialogAsync(
            () => new CustomerDialog(entity),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.Customer.Value.AddAsync(entity);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Customer '{entity.Name}' added successfully.", InfoBarSeverity.Success);
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Edit(CustomerVM vm)
    {
        if (vm == null) return;
        var entity = await _unitOfService.Customer.Value.GetAsync(x => x.CustomerId == vm.CustomerId);
        var dialog = new CustomerDialog(entity, "Edit Customer");
        var result = await _dialogService.ShowDialogAsync(
            () => dialog,
            DialogXamlRoot);
        if (result)
        {
            var updatedTopic = dialog.ViewModel.Customer;
            _unitOfService.Customer.Value.Update(updatedTopic);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Customer '{entity.Name}' updated successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Delete(CustomerVM vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Customer",
            Content = $"Are you sure you want to delete the customer '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfService.Customer.Value.GetAsync(e => e.CustomerId == vm.CustomerId);

            _unitOfService.Customer.Value.Remove(selectedEntity);
            await _unitOfService.SaveChangesAsync();
            await ReloadAsync();
            Notifier.Show($"Customer '{selectedEntity.Name}' deleted successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void Details(CustomerVM vm)
    {
        var dialog = new CustomerDetailsDialog(vm);
        dialog.XamlRoot = DialogXamlRoot;
        await dialog.ShowAsync();
    }

    [RelayCommand]
    public async void PrintPdf()
    {
        var dialog = new ContentDialog
        {
            Title = "Print Customer Report",
            Content = $"Are you sure you want to print customer report?",
            PrimaryButtonText = "Print",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if(result == ContentDialogResult.Primary)
        {
            var customersToPrint = Pager.AllItems;

            await _pdfReportService.GeneratePdfReportAsync(
                "Customer Report",
                string.IsNullOrWhiteSpace(SearchText) ? "All Customers" : $"Filtered: {SearchText}",
                $"Date: {DateTime.Now:yyyy-MM-dd}",
                customersToPrint.Select(c => new
                {
                    c.CustomerId,
                    c.Name,
                    c.Email,
                    c.Phone,
                })
            );
            Notifier.Show($"Customer report printed successfully.", InfoBarSeverity.Success);
        }
    }

    [RelayCommand]
    public async void PrintExcel()
    {
        var dialog = new ContentDialog
        {
            Title = "Export Customers to Excel",
            Content = $"Are you sure you want to export the customer report as Excel?",
            PrimaryButtonText = "Export",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var customersToExport = Pager.AllItems;

            // Export selected fields as anonymous type
            var exportList = customersToExport.Select(c => new
            {
                c.CustomerId,
                c.Name,
                c.Email,
                c.Phone,
            });

            var filePath = await _pdfReportService.GenerateExcelReportAsync(exportList, "Customer Report");
            Notifier.Show($"Excel exported: {filePath}", InfoBarSeverity.Success);

            // Optionally open the file
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
