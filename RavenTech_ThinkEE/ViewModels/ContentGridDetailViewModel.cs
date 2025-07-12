using CommunityToolkit.Mvvm.ComponentModel;

using RavenTech_ThinkEE.Contracts.ViewModels;
using RavenTech_ThinkEE.Core.Contracts.Services;
using RavenTech_ThinkEE.Core.Models;

namespace RavenTech_ThinkEE.ViewModels;

public partial class ContentGridDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;

    public ContentGridDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
