using Microsoft.UI.Xaml.Controls;

using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

public sealed partial class DashboardPage : Page
{
    public DashboardViewModel ViewModel
    {
        get;
    }

    public DashboardPage()
    {
        ViewModel = App.GetService<DashboardViewModel>();
        InitializeComponent();
    }
}
