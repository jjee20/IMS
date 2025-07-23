using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.ThinkEE;
using DomainLayer.ViewModels.ThinkEE;
using Guna.Charts.WinForms;
using Microsoft.DotNet.DesignTools.ViewModels;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews.ThinkEE;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ERP.Presenters.ThinkEE;
public class ThinkEEDashboardPresenter
{
    private readonly IThinkEEDashboardView _view;
    private readonly IUnitOfWork _unitOfWork;
    private UserDashboardViewModel _viewModel;
    public ThinkEEDashboardPresenter(IThinkEEDashboardView view, IUnitOfWork unitOfWork)
    {
        _view = view;
        _unitOfWork = unitOfWork;
        _viewModel = new UserDashboardViewModel();
        
        LoadDashboard();
    }

    private async void LoadDashboard()
    {

        var user = await AppUser();
        // Load reports and recent exams
        var reports = await _unitOfWork.PerformanceReport.Value.GetAllAsync(r => r.ExamineeId == user.Id);
        var examResults = await _unitOfWork.ExamResult.Value.GetAllAsync(r => r.ExamineeId == user.Id, includeProperties: "Exam");

        _viewModel = new UserDashboardViewModel
        {
            FullName = user.Profile == null ? "{Needs Updating}" : $"{user.Profile.LastName}, {user.Profile.FirstName}",
            Email = user.Email,
            PerformanceReports = reports.OrderByDescending(r => r.ReportDate).Take(5).ToList(),
            RecentExamResults = examResults.OrderByDescending(r => r.Exam.Date).Take(5).ToList()
        };

        BindDashboard();
    }

    private void BindDashboard()
    {
        _view.FullName = _viewModel.FullName;
        _view.Email = _viewModel.Email;
        // Set exam history
        _view.SetExamHistory(_viewModel.RecentExamResults);
        // Set performance chart
        var performanceChart = new GunaLineDataset();
        performanceChart.Label = "Performance";
        performanceChart.DataPoints.Clear();
        foreach (var report in _viewModel.PerformanceReports)
        {
            performanceChart.DataPoints.Add(report.ReportDate.ToString("MM/dd/yyyy"), report.Score);
        }

        _view.SetPerformanceChart(performanceChart);
        // Set areas of strength and weakness
        var strongAreas = _viewModel.PerformanceReports.Where(r => r.Score / r.TotalItems * 100 >= 75).Select(r => r.StrongAreas).ToList();
        var weakAreas = _viewModel.PerformanceReports.Where(r => r.Score / r.TotalItems * 100 < 75).Select(r => r.WeakAreas).ToList();
        _view.SetAreas(strongAreas, weakAreas);
    }
    private async Task<ApplicationUser> AppUser() => await _unitOfWork.ApplicationUser.Value.GetAsync(c => c.Id == Settings.Default.User_Id, includeProperties: "Profile");

}
