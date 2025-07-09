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
    public partial class UpsertExamFormatView : SfForm
    {
        string message;
        private ExamFormat _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertExamFormatView(IUnitOfWork unitOfWork, ExamFormat? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ExamFormat();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.Name;
            txtDescription.Text = _entity.Description;
            txtDuration.Text = _entity.DefaultDurationMinutes.ToString();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ExamFormatId > 0)
            {
                _unitOfWork.ExamFormat.Value.Detach(_entity);
                _unitOfWork.ExamFormat.Value.Update(_entity);
                message = "Exam Format updated successfully.";
            }
            else
            {
                await _unitOfWork.ExamFormat.Value.AddAsync(_entity);
                message = "Exam Format added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Name = txtName.Text;
            _entity.Description = txtDescription.Text;
            _entity.DefaultDurationMinutes = Convert.ToInt16(txtDuration.Text);
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
