using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using RavenTechV2.Contracts.Services;
using RavenTechV2.Helpers;
using Windows.ApplicationModel;

namespace RavenTechV2.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;

    [ObservableProperty]
    private string _versionDescription;

    // Profile properties
    [ObservableProperty]
    private string _name = "Your Name"; // Set with your user's data

    [ObservableProperty]
    private string _email = "your@email.com"; // Set with your user's data

    [ObservableProperty]
    private bool _isEditing;

    // Feedback for password change
    [ObservableProperty]
    private string _passwordMessage;

    public ICommand SwitchThemeCommand
    {
        get;
    }
    public ICommand EditOrSaveProfileCommand
    {
        get;
    }
    public ICommand ChangePasswordCommand
    {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });

        EditOrSaveProfileCommand = new RelayCommand(EditOrSaveProfile);
        ChangePasswordCommand = new AsyncRelayCommand<(string OldPassword, string NewPassword, string ConfirmPassword)>(ChangePasswordAsync);
    }

    private void EditOrSaveProfile()
    {
        if (IsEditing)
        {
            // TODO: Save profile data (call your service here)
            // Optionally validate before saving!
        }
        IsEditing = !IsEditing;
    }

    private async Task ChangePasswordAsync((string OldPassword, string NewPassword, string ConfirmPassword) args)
    {
        PasswordMessage = string.Empty;

        if (args.NewPassword != args.ConfirmPassword)
        {
            PasswordMessage = "Passwords do not match!";
            return;
        }
        if (string.IsNullOrWhiteSpace(args.NewPassword))
        {
            PasswordMessage = "New password cannot be empty.";
            return;
        }
        // TODO: Verify old password, update in database/service, and give feedback
        // Simulate async operation
        await Task.Delay(500);

        // For now, show success
        PasswordMessage = "Password updated successfully!";
    }

    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;
            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}
