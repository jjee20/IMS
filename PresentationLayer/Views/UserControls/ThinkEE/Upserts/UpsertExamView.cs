using System;
using System.ComponentModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using DomainLayer.ViewModels.ThinkEE;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertExamView : SfForm
    {
        string message;
        private Exam _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertExamView(IUnitOfWork unitOfWork, Exam? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Exam();
            LoadEntityToForm();
            LoadExamFormat();
        }

        private void LoadExamFormat()
        {
            var examFormats = _unitOfWork.ExamFormat.Value.GetAll();
            txtExamFormat.DataSource = examFormats;
            txtExamFormat.DisplayMember = "Name";
            txtExamFormat.ValueMember = "ExamFormatId";
        }

        private void LoadEntityToForm()
        {
            BindingList<ExamQuestionsViewModel> questions = _entity.Questions != null && _entity.Questions.Any() ?
                new BindingList<ExamQuestionsViewModel>(
                _entity.Questions.Select(q => new ExamQuestionsViewModel
                {
                    Question = q.Text,
                    Choice1 = q.Choices.ElementAtOrDefault(0)?.Text,
                    Choice2 = q.Choices.ElementAtOrDefault(1)?.Text,
                    Choice3 = q.Choices.ElementAtOrDefault(2)?.Text,
                    Choice4 = q.Choices.ElementAtOrDefault(3)?.Text,
                    Answer = q.Choices.FirstOrDefault(c => c.IsCorrect)?.Text,
                    Delete = Resources.delete
                }).ToList())
                : new BindingList<ExamQuestionsViewModel>(); 
            dgList.DataSource = questions;
            txtTitle.Text = _entity.Title;
            txtDate.Value = _entity.Date;
            txtExamFormat.SelectedValue = _entity.ExamFormatId > 0 ? _entity.ExamFormatId : 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();


            var questionsVM = dgList.DataSource as BindingList<ExamQuestionsViewModel>;
            var questionList = questionsVM.Select(q => new Question
            {
                QuestionId = _entity.ExamId,
                Text = q.Question,
                Choices = new List<Choice>
                    {
                        new Choice { Text = q.Choice1, IsCorrect = q.Answer == q.Choice1 },
                        new Choice { Text = q.Choice2, IsCorrect = q.Answer == q.Choice2 },
                        new Choice { Text = q.Choice3, IsCorrect = q.Answer == q.Choice3 },
                        new Choice { Text = q.Choice4, IsCorrect = q.Answer == q.Choice4 }
                    }
            }).ToList();

            if (_entity.ExamId > 0)
            {
                foreach (var question in _entity.Questions)
                {
                    _unitOfWork.Question.Value.Remove(question);
                    _unitOfWork.Choice.Value.RemoveRange(question.Choices);
                }

                await _unitOfWork.Question.Value.AddRangeAsync(questionList);

                _unitOfWork.Exam.Value.Update(_entity);
                message = "Exam Format updated successfully.";
            }
            else
            {
                _entity.Questions = questionList;
                await _unitOfWork.Exam.Value.AddAsync(_entity);
                message = "Exam Format added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Title = txtTitle.Text;
            _entity.Date = txtDate.Value ?? DateTime.Now; // Ensure a fallback value if txtDate.Value is null
            _entity.ExamFormat = txtExamFormat.SelectedValue as ExamFormat; // Use 'as' to safely cast and handle null
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void UpsertExamView_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
        }
    }
}
