using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RavenTech_ERP.Views.IViews.ThinkEE;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.ThinkEE;
public partial class AvailableExamView : SfForm, IAvailableExamView
{
    private IUnitOfWork _unitOfWork;
    public event EventHandler RefreshEvent;

    public AvailableExamView()
    {
        InitializeComponent();
    }

    public void SetUnitOfWork(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void SetExams(IEnumerable<Exam> exams)
    {
        // Clear existing items
        flowLayoutPanelExams.Controls.Clear();
        // Add each exam to the flow layout panel
        foreach (var exam in exams.OrderByDescending(c => c.Date))
        {
            var examControl = new ExamsControl(exam, _unitOfWork);
            flowLayoutPanelExams.Controls.Add(examControl);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        RefreshEvent?.Invoke(this, EventArgs.Empty);
    }
}
