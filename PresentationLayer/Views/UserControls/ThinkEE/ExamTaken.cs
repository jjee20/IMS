﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Models.ThinkEE;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Properties;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.ThinkEE;
public partial class ExamTaken : SfForm
{
    private readonly Exam _exam;
    private bool _examTaken = false; // To track if the exam has been submitted
    private TimeSpan _remainingTime;
    private DateTime _examStartTime;
    private TimeSpan _examDuration;
    private int _currentQuestionIndex = 0;
    private QuestionsControl _questionControl;
    private List<Question> _questions = new();
    private Dictionary<int, Choice> _selectedChoices = new();
    private readonly IUnitOfWork _unitOfWork;

    public ExamTaken(Exam exam, IUnitOfWork unitOfWork)
    {
        InitializeComponent();

        this._exam = exam;
        LoadExamDetails();
        LoadQuestionNo();

        _examStartTime = _exam.ExamResults.Any() ? _exam.ExamResults.FirstOrDefault(x => x.ExamineeId == Settings.Default.User_Id).ExamStartTime : DateTime.Now; // Or get from ExamResult if resuming
        _examDuration = TimeSpan.FromMinutes(exam.ExamFormat?.DefaultDurationMinutes ?? 60);
        _remainingTime = _examStartTime.Add(_examDuration) - DateTime.Now;
        if (_remainingTime < TimeSpan.Zero) _remainingTime = TimeSpan.Zero;
        examTimer.Start();

        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.RunWorkerAsync();

        _unitOfWork = unitOfWork;

        UpdateTimeLabel();
    }

    private void UpdateTimeLabel()
    {
        lblTimeRemaining.Text = $"Time Left: {_remainingTime:hh\\:mm\\:ss}";
    }

    private void LoadQuestionNo()
    {
        txtQuestionNo.DataSource = null;
        var questionNumbers = Enumerable.Range(1, _questions.Count).ToList();
        txtQuestionNo.DataSource = questionNumbers;
    }
    private void LoadQuestionControl()
    {
        panelQuestions.Controls.Clear();

        var currentQuestion = _questions[_currentQuestionIndex];
        _questionControl = new QuestionsControl(_currentQuestionIndex + 1, currentQuestion);
        _questionControl.ChoiceSelected += QuestionControl_ChoiceSelected;

        // If already answered, mark selection
        if (_selectedChoices.TryGetValue(_currentQuestionIndex, out var savedChoice))
        {
            _questionControl.SelectChoice(savedChoice); // You can add this method to QuestionsControl if you want to show selected
        }

        _questionControl.Size = new Size(panelQuestions.Width, panelQuestions.Height);
        panelQuestions.Controls.Add(_questionControl);
    }

    private void UpdateProgress()
    {
        lblProgress.Text = $"Question {_currentQuestionIndex + 1} of {_questions.Count}";
        pBarPercentage.Maximum = _questions.Count;
        pBarPercentage.Value = _currentQuestionIndex + 1;
    }

    private void QuestionControl_ChoiceSelected(object sender, ChoiceSelectedEventArgs e)
    {
        // Save the user's choice for the current question
        _selectedChoices[_currentQuestionIndex] = e.SelectedChoice;
        // Optionally, auto-advance to next question here
        // NextQuestion();
    }

    private void LoadExamDetails()
    {
        panelQuestions.Controls.Clear();
        _questions = _exam.Questions.ToList();
        var examResult = _exam.ExamResults.FirstOrDefault(x => x.ExamineeId == Settings.Default.User_Id);
        // LOAD SAVED USER CHOICES
        if (examResult != null && examResult.SelectedChoices.Any())
        {
            _selectedChoices.Clear();
            foreach (var resultChoice in examResult.SelectedChoices)
            {
                var qIndex = _questions.FindIndex(q => q.QuestionId == resultChoice.QuestionId);
                if (qIndex >= 0)
                {
                    var choice = _questions[qIndex].Choices.FirstOrDefault(c => c.ChoiceId == resultChoice.ChoiceId);
                    if (choice != null)
                        _selectedChoices[qIndex] = choice; // key is index
                }
            }

            // Set current index to the next unanswered question
            var nextUnanswered = Enumerable.Range(0, _questions.Count)
                .FirstOrDefault(i => !_selectedChoices.ContainsKey(i));
            _currentQuestionIndex = nextUnanswered < _questions.Count ? nextUnanswered : _questions.Count - 1;
        }
        else
        {

            _currentQuestionIndex = 0;
        }

        // Load ComboBox only once, then set to _currentQuestionIndex
        LoadQuestionNo();
        txtQuestionNo.SelectedIndex = _currentQuestionIndex;

        if (_questions == null || !_questions.Any())
        {
            panelQuestions.Controls.Add(new Label
            {
                Text = "No questions available for this exam.",
                AutoSize = true,
                ForeColor = Color.Red,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            return;
        }
        LoadQuestionControl();
        UpdateProgress();
    }


    private void btnPrevious_Click(object sender, EventArgs e)
    {
        if (_currentQuestionIndex > 0)
        {
            _currentQuestionIndex--;
            LoadQuestionControl();
            UpdateProgress();
            UpdateButtonStates();
        }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (!_selectedChoices.ContainsKey(_currentQuestionIndex))
        {
            MessageBox.Show("Please select an answer before proceeding.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_currentQuestionIndex < _questions.Count - 1)
        {
            _currentQuestionIndex++;
            txtQuestionNo.SelectedIndex = _currentQuestionIndex;
            LoadQuestionControl();
            UpdateProgress();
            UpdateButtonStates();
        }
        else
        {
            SubmitExam();
        }
    }

    private async void SubmitExam()
    {
        var unanswered = _questions.Count - _selectedChoices.Count;
        if (unanswered > 0)
        {
            var confirm = MessageBox.Show(
                $"You have {unanswered} unanswered questions. Submit anyway?",
                "Confirm Submit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;
        }

        int correctCount = _selectedChoices.Values.Count(choice => choice.IsCorrect);

        SaveExamProgress(correctCount);

        // Save results, close form, show score, etc.
        MessageBox.Show("Exam submitted!");

        DialogResult = DialogResult.OK;
        Close();
    }

    private void UpdateButtonStates()
    {
        btnPrevious.Enabled = _currentQuestionIndex > 0;
        if (_currentQuestionIndex < _questions.Count - 1)
        {
            btnNext.Text = "Next";
            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Text = "Submit";
            btnNext.Enabled = true; // Optionally, you can have logic to enable only if answered
            _examTaken = true;
        }
    }

    private void btnBackward_Click(object sender, EventArgs e)
    {
        if (_questions.Any() && _currentQuestionIndex != 0)
        {
            _currentQuestionIndex = 0;
            LoadQuestionControl();
            UpdateProgress();
            UpdateButtonStates();
        }
    }
    private void btnForward_Click(object sender, EventArgs e)
    {
        if (_questions.Any() && _currentQuestionIndex != _questions.Count - 1)
        {
            _currentQuestionIndex = _questions.Count - 1;
            LoadQuestionControl();
            UpdateProgress();
            UpdateButtonStates();
        }
    }

    private void txtQuestionNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtQuestionNo.SelectedIndex >= 0 && txtQuestionNo.SelectedIndex < _questions.Count)
        {
            _currentQuestionIndex = txtQuestionNo.SelectedIndex;
            LoadQuestionControl();
            UpdateProgress();
            UpdateButtonStates();
        }
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while (_remainingTime.TotalSeconds > 0)
        {
            // Wait one second
            Thread.Sleep(1000);
            _remainingTime = _examStartTime.Add(_examDuration) - DateTime.Now;
            if (_remainingTime < TimeSpan.Zero)
                _remainingTime = TimeSpan.Zero;

            backgroundWorker1.ReportProgress(0);
        }
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        UpdateTimeLabel();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        MessageBox.Show("Time is up! Exam will be submitted automatically.", "Time Up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        SubmitExam();
    }

    private void examTimer_Tick(object sender, EventArgs e)
    {
        _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));

        UpdateTimeLabel();

        if (_remainingTime.TotalSeconds <= 0)
        {
            examTimer.Stop();
            MessageBox.Show("Time's up! The exam will be submitted.", "Exam Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SubmitExam(); // Your method to finish the exam
        }
    }

    private void ExamTaken_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (examTimer != null)
        {
            examTimer.Stop();
            examTimer.Dispose();
        }

        // (Optional) Ask user if they really want to close if the exam isn't finished
        if (_remainingTime.TotalSeconds > 0 && !_examTaken)
        {
            var confirm = MessageBox.Show(
                "You have not finished the exam. Are you sure you want to exit? Your answers will be saved.",
                "Exit Exam",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
            {
                e.Cancel = true; // Prevent closing
                return;
            }

            SaveExamProgress();
        }
    }

    private async void SaveExamProgress(int correctCount = 0)
    {
        var examResult = _exam.ExamResults
            .FirstOrDefault(x => x.ExamineeId == Settings.Default.User_Id);

        examResult.SelectedChoices ??= new List<ExamResultChoice>();
        examResult.ExamStatus = !_examTaken ? DomainLayer.Enums.ExamStatus.Ongoing : DomainLayer.Enums.ExamStatus.Taken;
        examResult.TotalPoints = _questions.Count;
        examResult.Score = correctCount;
        examResult.ExamDuration = _remainingTime; 
        examResult.ExamStartTime = _examStartTime;

        foreach (var kvp in _selectedChoices)
        {
            Choice selectedChoice = kvp.Value;
            // Try to find existing result choice for this question
            var existingResultChoice = examResult.SelectedChoices
                .FirstOrDefault(rc => rc.QuestionId == selectedChoice.QuestionId);

            if (existingResultChoice != null)
            {
                // Update ChoiceId if different
                if (existingResultChoice.ChoiceId != selectedChoice.ChoiceId)
                    existingResultChoice.ChoiceId = selectedChoice.ChoiceId;
            }
            else
            {
                // Add as new if not exists
                examResult.SelectedChoices.Add(new ExamResultChoice
                {
                    QuestionId = selectedChoice.QuestionId,
                    ChoiceId = selectedChoice.ChoiceId
                });
            }

            var toRemove = examResult.SelectedChoices
                .Where(rc => rc.QuestionId == selectedChoice.QuestionId && rc.ChoiceId != selectedChoice.ChoiceId)
                .ToList();
            foreach (var removeChoice in toRemove)
            {
                examResult.SelectedChoices.Remove(removeChoice);
            }    
        }


        _unitOfWork.ExamResult.Value.UpdateWithChildren(
            examResult,
            c => c.SelectedChoices,
            c => c.Id
            );

        await _unitOfWork.SaveAsync(); 

        if(_examTaken) await GeneratePerformanceReportAsync(examResult);
    }

    private async Task GeneratePerformanceReportAsync(ExamResult examResult)
    {
        // Ensure exam with questions and choices loaded
        var exam = examResult.Exam ?? await _unitOfWork.Exam.Value.GetAsync(
            e => e.ExamId == examResult.ExamId,
            includeProperties: "Questions.Choices"
        );

        // Defensive: load SelectedChoices with Questions and Choices if not loaded
        var selectedChoices = examResult.SelectedChoices?.ToList()
            ?? (await _unitOfWork.ExamResultChoice.Value.GetAllAsync(
                    c => c.ExamResultId == examResult.ExamResultId, includeProperties: "ExamResult,Choice,Question.ExamTopic")).ToList();

        // Group correct/wrong by area/category
        Dictionary<string, int> correctByArea = new();
        Dictionary<string, int> totalByArea = new();

        foreach (var question in exam.Questions)
        {
            var area = question.ExamTopic.Category;
            if (!correctByArea.ContainsKey(area)) correctByArea[area] = 0;
            if (!totalByArea.ContainsKey(area)) totalByArea[area] = 0;
            totalByArea[area]++;
        }

        foreach (var rc in selectedChoices)
        {
            var question = exam.Questions.FirstOrDefault(q => q.QuestionId == rc.QuestionId);
            var area = question.ExamTopic.Category;
            var choice = question?.Choices.FirstOrDefault(c => c.ChoiceId == rc.ChoiceId);

            if (choice?.IsCorrect == true)
                correctByArea[area]++;
        }

        // Find strong/weak areas
        var areaAccuracies = correctByArea
            .ToDictionary(
                kvp => kvp.Key,
                kvp => totalByArea[kvp.Key] > 0 ? (double)kvp.Value / totalByArea[kvp.Key] : 0
            );

        var strongAreas = areaAccuracies
            .OrderByDescending(a => a.Value)
            .Take(3) // top 2
            .Select(a => a.Key)
            .ToList();

        var weakAreas = areaAccuracies
            .OrderBy(a => a.Value)
            .Take(3) // bottom 2
            .Select(a => a.Key)
            .ToList();

        // Prepare the report
        var report = new PerformanceReport
        {
            ExamineeId = examResult.ExamineeId,
            ExamId = examResult.ExamId,
            Score = examResult.Score,
            TotalItems = examResult.TotalPoints,
            StrongAreas = string.Join(", ", strongAreas),
            WeakAreas = string.Join(", ", weakAreas),
            ReportDate = DateTime.Now
        };

        await _unitOfWork.PerformanceReport.Value.AddAsync(report);
        await _unitOfWork.SaveAsync();
    }


}
