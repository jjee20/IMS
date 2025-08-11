using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

using RavenTechV2.Contracts.Services;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Helpers;
using RavenTechV2.Services;
using RavenTechV2.ViewModels;

using Windows.System;

namespace RavenTechV2.Views;

// TODO: Update NavigationViewItem titles and icons in ShellPage.xaml.
public sealed partial class ShellPage : Page
{
    public ShellViewModel ViewModel
    {
        get;
    }

    public ShellPage(ShellViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();

        DataContext = ViewModel;

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // TODO: Set the title bar icon by updating /Assets/WindowIcon.ico.
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
        //AppTitleBarText.Text = "AppDisplayName".GetLocalized();
    }
    private void Image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Debug.WriteLine("Image tapped!");
    }
    private void AvatarControl_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        if (e.GetCurrentPoint(AvatarControl).Properties.IsLeftButtonPressed)
        {
            FlyoutBase.GetAttachedFlyout(HiddenFlyoutLauncher)?.ShowAt(AvatarControl);
        }
    }
    private async void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer is NavigationViewItem nvi)
        {
            var tag = nvi.Tag as string;

            if (tag == "Logout")
            {
                var dialog = new ContentDialog
                {
                    Title = "Confirm Logout",
                    Content = "Are you sure you want to log out?",
                    PrimaryButtonText = "Logout",
                    CloseButtonText = "Cancel",
                    XamlRoot = this.XamlRoot
                };
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    ViewModel.LogoutCommand.Execute(null);
                    App.MainWindow.Content = new LoginPage();
                }
                return;
            }

            if (tag == "NewCustomer")
            {
                //var newCustomer = new Customer();
                //var customerDialog = new CustomerDialog(newCustomer)
                //{
                //    XamlRoot = this.XamlRoot
                //};

                //var result = await customerDialog.ShowAsync();
                //if (result == ContentDialogResult.Primary)
                //{
                //    // Optional: if using ViewModel
                //    await ViewModel.AddNewCustomerAsync(newCustomer);
                //}

                //return;
            }
        }
    }


    private void OnLoaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        TitleBarHelper.UpdateTitleBar(RequestedTheme);

        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu));
        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.GoBack));
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        ViewModel.DialogXamlRoot = this.XamlRoot;
        //App.AppTitlebar = AppTitleBarText as UIElement;
    }

    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        AppTitleBar.Margin = new Thickness()
        {
            Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
            Top = AppTitleBar.Margin.Top,
            Right = AppTitleBar.Margin.Right,
            Bottom = AppTitleBar.Margin.Bottom
        };

        var width = App.MainWindow.AppWindow.Size.Width;

        if (width >= 1280)
            sender.IsPaneOpen = true;
        else
            sender.IsPaneOpen = false;
    }

    private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
    {
        var keyboardAccelerator = new KeyboardAccelerator() { Key = key };

        if (modifiers.HasValue)
        {
            keyboardAccelerator.Modifiers = modifiers.Value;
        }

        keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;

        return keyboardAccelerator;
    }

    private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
    {
        var navigationService = App.GetService<INavigationService>();

        var result = navigationService.GoBack();

        args.Handled = result;
    }
}
