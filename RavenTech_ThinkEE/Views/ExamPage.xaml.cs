using Microsoft.UI.Xaml.Controls;

using RavenTech_ThinkEE.ViewModels;

namespace RavenTech_ThinkEE.Views;

public sealed partial class ExamPage : Page
{
    public ExamViewModel ViewModel
    {
        get;
    }

    public ExamPage()
    {
        ViewModel = App.GetService<ExamViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
    }
}
