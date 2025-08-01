using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using RavenTechV2.Contracts.Services;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Services;
using RavenTechV2.Models;
using RavenTechV2.Services;
using RavenTechV2.Views;
using Windows.System;

namespace RavenTechV2.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    public IRelayCommand LogoutCommand
    {
        get;
    }

    public IRelayCommand NewCustomerCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    public IUnitOfService _unitOfService;
    public XamlRoot? DialogXamlRoot { get; set; }
    private readonly IDialogService _dialogService;
    private readonly NotificationService _notificationService = App.GetService<NotificationService>();
    public ObservableCollection<NavMenuItem> MenuItems { get; } = new();
    private readonly IUserSessionService _userSession;
    public NotificationService Notifier  { get; }
    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService, IUserSessionService userSession)
    {
        _unitOfService = App.GetService<IUnitOfService>();
        _dialogService = App.GetService<IDialogService>();
        Notifier = App.GetService<NotificationService>();
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        LogoutCommand = new RelayCommand(Logout);
        NewCustomerCommand = new RelayCommand(NewCustomer);
        _userSession = userSession;
    }

    private async void NewCustomer()
    {
        var customer = new Customer();
        var result = await _dialogService.ShowDialogAsync(
            () => new CustomerDialog(customer),
            DialogXamlRoot);

        if (result)
        {
            await _unitOfService.Customer.Value.AddAsync(customer);
            await _unitOfService.SaveChangesAsync();
            Notifier.Show($"Customer '{customer.Name}' added successfully.", InfoBarSeverity.Success);
        }
    }

    private void Logout()
    {

    }
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}
