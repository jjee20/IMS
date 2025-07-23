using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using RavenTechV2.Contracts.Services;
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

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    private readonly NotificationService _notificationService = App.GetService<NotificationService>();
    public ObservableCollection<NavMenuItem> MenuItems { get; } = new();
    private readonly IUserSessionService _userSession;
    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService, IUserSessionService userSession)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        LogoutCommand = new RelayCommand(Logout);
        _userSession = userSession;

    }
    private void Logout()
    {
        _notificationService.Show($"Logout Successful, see you next time!", NotificationType.Success);
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
