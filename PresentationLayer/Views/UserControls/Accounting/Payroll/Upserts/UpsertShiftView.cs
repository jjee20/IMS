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
    public partial class UpsertShiftView : SfForm
    {
        string message;
        private Shift _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertShiftView(IUnitOfWork unitOfWork, Shift? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Shift();

            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtRegularHours.Text = _entity.RegularHours.ToString();
                txtName.Text = _entity.ShiftName;

                txtStartTime.Value = DateTime.Today.Add(_entity.StartTime);
                txtEndTime.Value = DateTime.Today.Add(_entity.EndTime);
            }

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ShiftId > 0)
            {
                _unitOfWork.Shift.Value.Detach(_entity);
                _unitOfWork.Shift.Value.Update(_entity);
                message = "Shift updated successfully.";
            }
            else
            {
                await _unitOfWork.Shift.Value.AddAsync(_entity);
                message = "Shift added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.RegularHours = Convert.ToDouble(txtRegularHours.Text);
            _entity.StartTime = txtStartTime.Value.Value.TimeOfDay;
            _entity.EndTime = txtEndTime.Value.Value.TimeOfDay;
            _entity.ShiftName = txtName.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
