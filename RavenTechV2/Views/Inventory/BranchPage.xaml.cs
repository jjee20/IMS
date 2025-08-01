using AutoMapper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.Sales;
using RavenTechV2.Core.Models.Sales.ViewModels;
using RavenTechV2.Core.Services;
using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class BranchPage : Page
{

    public BranchViewModel ViewModel
    {
        get;
    }

    public BranchPage()
    {
        ViewModel = App.GetService<BranchViewModel>();
        InitializeComponent();
        DataContext = ViewModel;
        var rootElement = this.Content as FrameworkElement;
        if (rootElement != null)
            rootElement.Loaded += Root_Loaded;
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is BranchVM item)
            ViewModel.EditCommand.Execute(item);
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is BranchVM item)
            ViewModel.DeleteCommand.Execute(item);
    }
    private void DetailsButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is BranchVM item)
            ViewModel.DetailsCommand.Execute(item);
    }
    private void Root_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel.DialogXamlRoot = this.XamlRoot;
    }
}
