using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertJobPositionView : SfForm
    {
        string message;
        private JobPosition _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertJobPositionView(IUnitOfWork unitOfWork, JobPosition? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new JobPosition();

            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtDescription.Text = _entity.Description;
                txtName.Text = _entity.Title;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.JobPositionId > 0)
            {
                _unitOfWork.JobPosition.Value.Detach(_entity);
                _unitOfWork.JobPosition.Value.Update(_entity);
                message = "JobPosition updated successfully.";
            }
            else
            {
                await _unitOfWork.JobPosition.Value.AddAsync(_entity);
                message = "JobPosition added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Description = txtDescription.Text;
            _entity.Title = txtName.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
