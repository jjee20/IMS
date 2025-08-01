using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = App.GetService<LoginViewModel>();
    }
    private void Input_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            var vm = DataContext as LoginViewModel;
            if (vm?.LoginCommand?.CanExecute(null) == true)
            {
                vm.LoginCommand.Execute(null);
            }

            e.Handled = true;
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm && sender is PasswordBox pb)
        {
            vm.Password = pb.Password;
        }
    }
}
