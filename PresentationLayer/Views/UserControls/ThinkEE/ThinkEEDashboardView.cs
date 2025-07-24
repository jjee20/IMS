using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Models.ThinkEE;
using Guna.Charts.WinForms;
using RavenTech_ERP.Views.IViews.ThinkEE;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.ThinkEE;
public partial class ThinkEEDashboardView : SfForm, IThinkEEDashboardView
{
    public ThinkEEDashboardView()
    {
        InitializeComponent();
    }

    public void SetExamHistory(List<ExamResult> examResults)
    {
        dgPager.DataSource = examResults.Select(x => new
        {
            x.Exam.Title,
            x.Score,
            Status = x.ExamStatus.ToString(),
            x.Exam.Date,
        }).ToList();

        dgList.DataSource = dgPager.PagedSource;
    }

    public void SetPerformanceChart(GunaLineDataset gunaLineDataset)
    {
        chartPerformance.Datasets.Clear();
        chartPerformance.Datasets.Add(gunaLineDataset);
    }

    public void SetAreas(List<string> strong, List<string> weak)
    {
        listBoxStrong.DataSource = strong;
        listBoxWeak.DataSource = weak;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string FullName
    {
        get
        {
            return txtName.Text;
        }
        set
        {
            txtName.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Email
    {
        get
        {
            return txtEmail.Text;
        }
        set
        {
            txtEmail.Text = value;
        }
    }
}
