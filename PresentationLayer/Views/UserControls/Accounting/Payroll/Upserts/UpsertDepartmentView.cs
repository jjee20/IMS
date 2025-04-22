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
    public partial class UpsertDepartmentView : SfForm
    {
        string message;
        private Department _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertDepartmentView(IUnitOfWork unitOfWork, Department? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Department();

            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtDescription.Text = _entity.Description;
                txtName.Text = _entity.Name;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.DepartmentId > 0)
            {
                _unitOfWork.Department.Value.Detach(_entity);
                _unitOfWork.Department.Value.Update(_entity);
                message = "Department updated successfully.";
            }
            else
            {
                await _unitOfWork.Department.Value.AddAsync(_entity);
                message = "Department added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.Description = txtDescription.Text;
            _entity.Name = txtName.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
