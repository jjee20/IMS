using CommunityToolkit.WinUI.UI.Animations;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using RavenTech_ThinkEE.Contracts.Services;
using RavenTech_ThinkEE.ViewModels;

namespace RavenTech_ThinkEE.Views;

public sealed partial class ExamDetailPage : Page
{
    public ExamDetailViewModel ViewModel
    {
        get;
    }

    public ExamDetailPage()
    {
        ViewModel = App.GetService<ExamDetailViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Exam != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Exam);
            }
        }
    }
    private void Previous_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.PreviousQuestion();
    }
    private void Next_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.NextQuestion();
    }
}
