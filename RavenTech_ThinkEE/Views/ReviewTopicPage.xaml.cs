using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using RavenTech_ThinkEE.ViewModels;

namespace RavenTech_ThinkEE.Views;

public sealed partial class ReviewTopicPage : Page
{
    public ReviewTopicViewModel ViewModel
    {
        get;
    }

    public ReviewTopicPage()
    {
        ViewModel = App.GetService<ReviewTopicViewModel>(); 
        InitializeComponent();
        this.DataContext = ViewModel;
        var rootElement = this.Content as FrameworkElement;
        if (rootElement != null)
            rootElement.Loaded += Root_Loaded;
        
    }
    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel item)
            ViewModel.EditCommand.Execute(item);
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel item)
            ViewModel.DeleteCommand.Execute(item);
    }
    private void PrintButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel item)
            ViewModel.DeleteCommand.Execute(item);
    }
    private void Root_Loaded(object sender, RoutedEventArgs e) => ViewModel.DialogXamlRoot = this.XamlRoot;
}
