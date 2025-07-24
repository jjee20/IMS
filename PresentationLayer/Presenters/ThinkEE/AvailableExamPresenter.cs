using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews.ThinkEE;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ERP.Presenters.ThinkEE;
public class AvailableExamPresenter
{
    private readonly IAvailableExamView _availableExamView;
    private readonly IUnitOfWork _unitOfWork;
    public AvailableExamPresenter(IAvailableExamView availableExamView, IUnitOfWork unitOfWork)
    {
        _availableExamView = availableExamView;
        _unitOfWork = unitOfWork;

        _availableExamView.SetUnitOfWork(unitOfWork);
        _availableExamView.SetExams(GetAvailableExams());

        _availableExamView.RefreshEvent += OnRefreshEvent;
    }

    private void OnRefreshEvent(object? sender, EventArgs e)
    {
        _availableExamView.SetExams(GetAvailableExams());
    }

    private IEnumerable<Exam> GetAvailableExams()
    {
        return _unitOfWork.Exam.Value.GetAll(includeProperties: "ExamFormat,Questions.Choices,Questions.ExamTopic,ExamResults.Examinee,ExamResults.SelectedChoices.Choice,ExamResults.SelectedChoices.Question.ExamTopic,ReviewTopic");
    }
}
