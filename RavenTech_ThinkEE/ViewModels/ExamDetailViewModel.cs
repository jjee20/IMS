using CommunityToolkit.Mvvm.ComponentModel;
using DomainLayer.Models.ThinkEE;
using RavenTech_ThinkEE.Contracts.ViewModels;
using RavenTech_ThinkEE.Core.Contracts.Services;
using RavenTech_ThinkEE.Core.Models;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ThinkEE.ViewModels;

public partial class ExamDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly IUnitOfWork _unitOfWork;

    [ObservableProperty]
    private Exam? exam;

    [ObservableProperty]
    private int currentQuestionIndex;

    [ObservableProperty]
    private bool isSelected;
    public ExamDetailViewModel()
    {
        _unitOfWork = App.GetService<IUnitOfWork>();
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is int examId)
        {
            var data = await _unitOfWork.Exam.Value.GetAllAsync(includeProperties: "ExamFormat,ExamResult,Questions.Choices");
            Exam = data.Where(data => data.ExamId == examId).FirstOrDefault();
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public Question? CurrentQuestion => Exam?.Questions?.ElementAtOrDefault(CurrentQuestionIndex);
    public string CurrentQuestionDisplay => $"Question #{CurrentQuestionIndex + 1}";
    public int CurrentQuestionIndexDisplay => CurrentQuestionIndex+ 1;
    // For navigation:
    public void NextQuestion()
    {
        if (Exam?.Questions != null && CurrentQuestionIndex < Exam.Questions.Count - 1)
        {
            CurrentQuestionIndex++;
        }
    }

    public void PreviousQuestion()
    {
        if (CurrentQuestionIndex > 0)
        {
            CurrentQuestionIndex--;
        }
    }
}
