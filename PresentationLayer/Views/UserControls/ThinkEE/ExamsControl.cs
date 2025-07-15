using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Enums;
using DomainLayer.Models.ThinkEE;
using RavenTech_ERP.Properties;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ERP.Views.UserControls.ThinkEE;
public partial class ExamsControl : UserControl
{
    private readonly Exam _exam;
    private readonly IUnitOfWork _unitOfWork;

    public ExamsControl(Exam exam, IUnitOfWork unitOfWork)
    {
        InitializeComponent();
        _exam = exam;
        _unitOfWork = unitOfWork;
        LoadAllExamFormatList();
    }

    private bool IsExamExpired(ExamResult examResult)
    {
        if (examResult.ExamStatus != ExamStatus.Ongoing) return false;
        // If you stored ExamDuration as TimeSpan, this is fine:
        var deadline = examResult.ExamStartTime + examResult.ExamDuration;
        return DateTime.Now > deadline;
    }

    private async void btnTake_Click(object sender, EventArgs e)
    {
        

        if (_exam.Questions.Count >= 0 && !_exam.Questions.Any())
        {
            MessageBox.Show("No availabe question for this exam. Please contact your administrator.", "No Questions Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var form = new ExamTaken(_exam, _unitOfWork);
        var userExamResult = _exam.ExamResults
            .FirstOrDefault(x => x.ExamineeId == Settings.Default.User_Id);

        if (userExamResult != null)
        {
            if (userExamResult.ExamStatus == ExamStatus.Taken)
            {
                MessageBox.Show("You have already taken this exam.", "Exam Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (userExamResult.ExamStatus == ExamStatus.Ongoing)
            {
                if (IsExamExpired(userExamResult))
                {
                    // Optionally, update the status
                    userExamResult.ExamStatus = ExamStatus.Taken;
                    _unitOfWork.ExamResult.Value.Update(userExamResult);
                    await _unitOfWork.SaveAsync();

                    MessageBox.Show("Your time for this exam has expired. You cannot retake it.", "Exam Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("You have an ongoing exam session. Please continue.", "Exam Ongoing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else
        {
            userExamResult = new ExamResult
            {
                ExamId = _exam.ExamId,
                ExamineeId = Settings.Default.User_Id,  
                ExamStatus = ExamStatus.Ongoing,
                ExamStartTime = DateTime.Now,
                ExamDuration = TimeSpan.FromMinutes(_exam.ExamFormat?.DefaultDurationMinutes ?? 0)
            };
            await _unitOfWork.ExamResult.Value.AddAsync(userExamResult);
        }

            await _unitOfWork.SaveAsync();

        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadAllExamFormatList();
        }
    }

    private void LoadAllExamFormatList()
    {

        var userExamResult = _exam.ExamResults
            .FirstOrDefault(x => x.ExamineeId == Settings.Default.User_Id);

        var status = userExamResult?.ExamStatus ?? ExamStatus.NotTaken;
        var examDate = _exam.Date.Date;

        lblTitle.Text = _exam.Title;
        lblType.Text = _exam.ExamFormat?.Name ?? "N/A";
        lblTime.Text = _exam.ExamFormat?.DurationText ?? "N/A";
        lblDate.Text = _exam.DisplayDate ?? "N/A";
        lblStatus.Text = status.ToString();

        var resultAvailable = userExamResult != null;
        var isTaken = status == ExamStatus.Taken;
        var isOngoing = status == ExamStatus.Ongoing;
        var isExamDay = examDate == DateTime.Now.Date;

        if (isTaken)
        {
            btnTake.Text = "Exam Taken";
            btnTake.Enabled = false;
        }
        else if (!isExamDay)
        {
            btnTake.Text = "Exam Not Available";
            btnTake.Enabled = false;
        }
        else if (isExamDay && isOngoing)
        {
            btnTake.Text = "Continue Exam";
            btnTake.Enabled = true;
        }
        else
        {
            btnTake.Text = "Take Exam";
            btnTake.Enabled = true;
        }

        if (userExamResult != null && userExamResult.TotalPoints > 0)
        {
            var percent = (double)userExamResult.Score / userExamResult.TotalPoints * 100;
            lblScore.Text = $"Score: {userExamResult.Score} / {userExamResult.TotalPoints} ({percent:N0}%)";
        }
        else if (userExamResult != null)
        {
            lblScore.Text = $"Score: {userExamResult.Score}";
        }
        else
        {
            lblScore.Text = "Score: N/A";
        }
    }

}
