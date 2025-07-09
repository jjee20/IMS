using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertReviewTopicView : SfForm
    {
        string message;
        private ReviewTopic _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertReviewTopicView(IUnitOfWork unitOfWork, ReviewTopic? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ReviewTopic();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.Name;
            txtCode.Text = _entity.Code;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ReviewTopicId > 0)
            {
                _unitOfWork.ReviewTopic.Value.Detach(_entity);
                _unitOfWork.ReviewTopic.Value.Update(_entity);
                message = "Review Topic updated successfully.";
            }
            else
            {
                await _unitOfWork.ReviewTopic.Value.AddAsync(_entity);
                message = "Review Topic added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Name = txtName.Text;
            _entity.Code = txtCode.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
