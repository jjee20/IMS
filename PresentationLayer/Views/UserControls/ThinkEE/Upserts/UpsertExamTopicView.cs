using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using DomainLayer.ViewModels.ThinkEE;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertExamTopicView : SfForm
    {
        string message;
        private ExamTopic _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertExamTopicView(IUnitOfWork unitOfWork, ExamTopic? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ExamTopic();
            LoadReviewTopics();
            LoadEntityToForm();
        }

        private void LoadReviewTopics()
        {
            var reviewTopics = _unitOfWork.ReviewTopic.Value.GetAll();
            if (reviewTopics != null)
            {
                txtReviewTopic.DataSource = reviewTopics;
                txtReviewTopic.DisplayMember = "Name";
                txtReviewTopic.ValueMember = "ReviewTopicId";
            }
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.Name;
            txtCategory.Text = _entity.Category;
            txtReviewTopic.SelectedValue = _entity.ReviewTopicId > 0 ? _entity.ReviewTopicId : null;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ExamTopicId > 0)
            {
                _unitOfWork.ExamTopic.Value.Detach(_entity);
                _unitOfWork.ExamTopic.Value.Update(_entity);
                message = "Exam Topic updated successfully.";
            }
            else
            {
                await _unitOfWork.ExamTopic.Value.AddAsync(_entity);
                message = "Exam Topic added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Name = txtName.Text;
            _entity.Category = txtCategory.Text;
            if (txtReviewTopic.SelectedValue != null)
            {
                _entity.ReviewTopicId = Convert.ToInt32(txtReviewTopic.SelectedValue);
            }
            else
            {
                MessageBox.Show("Please select a Review Topic.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
