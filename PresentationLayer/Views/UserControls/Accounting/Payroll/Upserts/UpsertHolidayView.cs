using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertHolidayView : SfForm
    {
        string message;
        private Holiday _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertHolidayView(IUnitOfWork unitOfWork, Holiday? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Holiday();

            LoadTypes();
            LoadEntityToForm();
        }

        private void LoadTypes()
        {
            var types = EnumHelper.EnumToEnumerable<DomainLayer.Enums.HolidayType>();
            txtHolidayType.DataSource = types.ToList();
            txtHolidayType.DisplayMember = "Name";
            txtHolidayType.ValueMember = "Id";
            txtHolidayType.Text = "~Select Holiday Type~";
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtName.Text = _entity.HolidayName;
                txtDescription.Text = _entity.Description;
                txtDate.Value = _entity == null ? _entity.EffectiveDate : DateTime.Now;
                txtHolidayType.SelectedValue = _entity.HolidayType;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.HolidayId > 0)
            {
                _unitOfWork.Holiday.Value.Detach(_entity);
                _unitOfWork.Holiday.Value.Update(_entity);
                message = "Holiday updated successfully.";
            }
            else
            {
                await _unitOfWork.Holiday.Value.AddAsync(_entity);
                message = "Holiday added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.HolidayName = txtName.Text;
            _entity.HolidayType = (DomainLayer.Enums.HolidayType)txtHolidayType.SelectedValue;
            _entity.EffectiveDate = (DateTime)txtDate.Value;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
