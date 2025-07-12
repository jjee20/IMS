using Microsoft.UI.Xaml.Controls;

using RavenTech_ThinkEE.ViewModels;

namespace RavenTech_ThinkEE.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridViewModel ViewModel
    {
        get;
    }

    public ContentGridPage()
    {
        ViewModel = App.GetService<ContentGridViewModel>();
        InitializeComponent();
    }
}
