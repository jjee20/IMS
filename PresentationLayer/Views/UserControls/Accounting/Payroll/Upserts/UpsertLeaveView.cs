using DomainLayer.Enums;
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
    public partial class UpsertLeaveView : SfForm
    {
        string message;
        private Leave _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertLeaveView(IUnitOfWork unitOfWork, Leave? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Leave();

            LoadStatus();
            LoadTypes();
            LoadEmployees();
            LoadEntityToForm();
        }

        private void LoadEmployees()
        {
            var entity = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            txtEmployee.DataSource = entity.OrderBy(c => c.Name).ToList();
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
            txtEmployee.Text = "~Select Employee~";
        }

        private void LoadTypes()
        {
            var entity = EnumHelper.EnumToEnumerable<LeaveType>();
            txtLeaveType.DataSource = entity.ToList();
            txtLeaveType.DisplayMember = "Name";
            txtLeaveType.ValueMember = "Id";
            txtLeaveType.Text = "~Select Leave Type~";
        }
        

        private void LoadStatus()
        {
            var entity = EnumHelper.EnumToEnumerable<Status>();
            txtStatus.DataSource = entity.ToList();
            txtStatus.DisplayMember = "Name";
            txtStatus.ValueMember = "Id";
            txtStatus.Text = "~Select Status~";
        }

        private void LoadEntityToForm()
        {
            if (_entity.LeaveId > 0)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtStatus.SelectedValue = _entity.Status;
                txtLeaveType.SelectedValue = _entity.LeaveType;
                txtNotes.Text = _entity.Notes.ToString() ?? "";
                txtOther.Text = _entity.Other.ToString() ?? "";
                txtStartDate.Value = _entity == null ? _entity.StartDate : DateTime.Now;
                txtEndDate.Value = _entity == null ? _entity.EndDate : DateTime.Now;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.LeaveId > 0)
            {
                _unitOfWork.Leave.Value.Detach(_entity);
                _unitOfWork.Leave.Value.Update(_entity);
                message = "Leave updated successfully.";
            }
            else
            {
                await _unitOfWork.Leave.Value.AddAsync(_entity);
                message = "Leave added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.LeaveType = (LeaveType)txtLeaveType.SelectedValue;
            _entity.Status = (Status)txtLeaveType.SelectedValue;
            _entity.StartDate = txtStartDate.Value;
            _entity.EndDate = txtEndDate.Value;
            _entity.Other = txtOther.Text;
            _entity.Notes = txtNotes.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
