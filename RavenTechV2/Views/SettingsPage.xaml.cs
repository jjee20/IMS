using Microsoft.UI.Xaml.Controls;

using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private void SavePassword_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Example: get passwords from PasswordBox controls
        var oldPwd = OldPasswordBox.Password;
        var newPwd = NewPasswordBox.Password;
        var confirmPwd = ConfirmPasswordBox.Password;

        if (newPwd != confirmPwd)
        {
            ViewModel.PasswordMessage = "Passwords do not match!";
            return;
        }

        // Call a ViewModel command, or add your logic here.
        // For example, if you have ChangePasswordCommand in your ViewModel:
        if (ViewModel.ChangePasswordCommand.CanExecute((oldPwd, newPwd, confirmPwd)))
            ViewModel.ChangePasswordCommand.Execute((oldPwd, newPwd, confirmPwd));
    }
    private void EditOrSave_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Call your ViewModel command or logic
        if (ViewModel.EditOrSaveProfileCommand.CanExecute(null))
            ViewModel.EditOrSaveProfileCommand.Execute(null);
    }

}
