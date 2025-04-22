using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertUnitOfMeasureView : SfForm
    {
        string message;
        private UnitOfMeasure _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertUnitOfMeasureView(IUnitOfWork unitOfWork, UnitOfMeasure? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new UnitOfMeasure();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.UnitOfMeasureName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.UnitOfMeasureId > 0)
            {
                _unitOfWork.UnitOfMeasure.Value.Detach(_entity);
                _unitOfWork.UnitOfMeasure.Value.Update(_entity);
                message = "Unit Of Measure updated successfully.";
            }
            else
            {
                await _unitOfWork.UnitOfMeasure.Value.AddAsync(_entity);
                message = "Unit Of Measure added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.UnitOfMeasureName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
