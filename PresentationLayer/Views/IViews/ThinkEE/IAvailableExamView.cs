using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ERP.Views.IViews.ThinkEE;
public interface IAvailableExamView
{
    void SetExams(IEnumerable<Exam> exams);
    void SetUnitOfWork(IUnitOfWork unitOfWork);
    event EventHandler RefreshEvent;
}