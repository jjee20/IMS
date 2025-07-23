using DomainLayer.Models.ThinkEE;
using Guna.Charts.WinForms;

namespace RavenTech_ERP.Views.IViews.ThinkEE;
public interface IThinkEEDashboardView
{
    string Email
    {
        get; set;
    }
    string FullName
    {
        get; set;
    }

    void SetAreas(List<string> strong, List<string> weak);
    void SetExamHistory(List<ExamResult> examResults);
    void SetPerformanceChart(GunaLineDataset gunaLineDataset);
}