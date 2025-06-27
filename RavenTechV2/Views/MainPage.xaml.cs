using Microsoft.UI.Xaml.Controls;

using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

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
