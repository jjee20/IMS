using Microsoft.UI.Xaml.Controls;

using RavenTech_ThinkEE.ViewModels;

namespace RavenTech_ThinkEE.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
