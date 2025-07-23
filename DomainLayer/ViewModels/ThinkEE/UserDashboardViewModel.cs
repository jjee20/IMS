using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.ThinkEE;

namespace DomainLayer.ViewModels.ThinkEE;
public class UserDashboardViewModel
{
    public string FullName
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }

    public List<PerformanceReport> PerformanceReports
    {
        get; set;
    }
    public List<ExamResult> RecentExamResults
    {
        get; set;
    }

    // Calculated
    public double AverageAccuracy => PerformanceReports.Any()
        ? PerformanceReports.Average(r => r.Accuracy) : 0;

    public string WeakAreas => string.Join(", ",
        PerformanceReports
            .OrderByDescending(r => r.ReportDate)
            .FirstOrDefault()?.WeakAreas ?? "N/A");

    public string StrongAreas => string.Join(", ",
        PerformanceReports
            .OrderByDescending(r => r.ReportDate)
            .FirstOrDefault()?.StrongAreas ?? "N/A");
}

