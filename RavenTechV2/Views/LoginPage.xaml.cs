using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        this.InitializeComponent();
        DataContext = App.GetService<LoginViewModel>();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm && sender is PasswordBox pb)
        {
            vm.Password = pb.Password;
        }
    }
}
