using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RavenTech_ThinkEE.Contracts.Services;
using RavenTech_ThinkEE.Contracts.ViewModels;
using RavenTech_ThinkEE.Core.Contracts.Services;
using RavenTech_ThinkEE.Core.Models;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ThinkEE.ViewModels;

public partial class ExamViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IUnitOfWork _unitOfWork;

    public ObservableCollection<Exam> Source { get; } = new ObservableCollection<Exam>();

    public ExamViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _unitOfWork = App.GetService<IUnitOfWork>();
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _unitOfWork.Exam.Value.GetAllAsync(includeProperties: "ExamFormat,ExamResult,Questions.Choices");
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void OnItemClick(Exam? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ExamDetailViewModel).FullName!, clickedItem.ExamId);
        }
    }
}
