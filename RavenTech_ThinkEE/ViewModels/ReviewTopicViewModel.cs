using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTech_ThinkEE.Contracts.ViewModels;
using RavenTech_ThinkEE.Views;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ThinkEE.ViewModels;

public partial class ReviewTopicViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper; 
    public XamlRoot DialogXamlRoot { get; set; }
    public ObservableCollection<DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel> Source { get; } = new ObservableCollection<DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel>();
    private List<DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel> _allData = new();

    [ObservableProperty] 
    DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel selected;
    [ObservableProperty]
    private string searchText;
    public ReviewTopicViewModel()
    {
        _unitOfWork = App.GetService<IUnitOfWork>();
        _mapper = App.GetService<IMapper>();
    }

    public void OnNavigatedFrom() => throw new NotImplementedException();
    public async void OnNavigatedTo(object parameter)
    {
        await ReloadAsync();
    }

    private async Task ReloadAsync()
    {
        Source.Clear();
        var data = _mapper.Map<IEnumerable<DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel>>(await _unitOfWork.ReviewTopic.Value.GetAllAsync());
        foreach (var item in data)
        {
            Source.Add(item);
        }
        _allData = data.ToList();
        FilterData();
    }

    [RelayCommand]
    public async void Add()
    {
        var newReviewTopic = new ReviewTopic();
        var dialog = new ReviewTopicDialogPage(newReviewTopic, "Add Review Topic") { XamlRoot = DialogXamlRoot }; 
        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            _unitOfWork.ReviewTopic.Value.Add(newReviewTopic);
            await _unitOfWork.SaveAsync();
            await ReloadAsync();
        }
    }

    [RelayCommand]  
    public async void Edit(DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel vm)
    {
        if (vm == null) return;
        var entity = await _unitOfWork.ReviewTopic.Value.GetAsync(x => x.Id == vm.Id);
        var dialog = new ReviewTopicDialogPage(entity, "Edit Review Topic") { XamlRoot = DialogXamlRoot }; 
        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            var updatedTopic = dialog.ReviewTopic;
            _unitOfWork.ReviewTopic.Value.Update(updatedTopic);
            await _unitOfWork.SaveAsync();
            await ReloadAsync();
        }
    }

    [RelayCommand]
    public async void Delete(DomainLayer.ViewModels.ThinkEE.ReviewTopicViewModel vm)
    {
        if (vm == null) return;
        var dialog = new ContentDialog
        {
            Title = "Delete Review Topic",
            Content = $"Are you sure you want to delete the review topic '{vm.Name}'?",
            PrimaryButtonText = "Delete",
            CloseButtonText = "Cancel",
            XamlRoot = DialogXamlRoot
        };
        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            var selectedEntity = await _unitOfWork.ReviewTopic.Value.GetAsync(e => e.Id == vm.Id);

            _unitOfWork.ReviewTopic.Value.Remove(selectedEntity);
            await _unitOfWork.SaveAsync();
            await ReloadAsync();
        }
    }

    partial void OnSearchTextChanged(string value)
    {
        FilterData();
    }

    private void FilterData()
    {
        Source.Clear();
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? _allData
            : _allData.Where(x =>
                  (x.Name != null && x.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)) ||
                  (x.Code != null && x.Code.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
        foreach (var item in filtered)
            Source.Add(item);
    }
}
