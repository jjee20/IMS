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
    public partial class UpsertEmployeeView : SfForm
    {
        string message;
        private Employee _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertEmployeeView(IUnitOfWork unitOfWork, Employee? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Employee();

            LoadGender();
            LoadShifts();
            LoadDepartments();
            LoadJobPosition();
            LoadEntityToForm();
        }

        private void LoadGender()
        {
            txtGender.DataSource = EnumHelper.EnumToEnumerable<Gender>();
            txtGender.DisplayMember = "Name";
            txtGender.ValueMember = "Id";
            txtGender.Text = "~Select Gender~";
        }

        private void LoadShifts()
        {
            var entity = _unitOfWork.Shift.Value.GetAll(); 
            txtShift.DataSource = entity.ToList();
            txtShift.DisplayMember = "ShiftName";
            txtShift.ValueMember = "ShiftId";
            txtShift.Text = "~Select Shift Schedule~";
        }

        private void LoadJobPosition()
        {

            var entity = _unitOfWork.JobPosition.Value.GetAll(); ;
            txtJobPosition.DataSource = entity.ToList();
            txtJobPosition.DisplayMember = "Title";
            txtJobPosition.ValueMember = "JobPositionId";
            txtJobPosition.Text = "~Select Job Position~";
        }

        private void LoadDepartments()
        {
            var entity = _unitOfWork.Department.Value.GetAll();
            txtDepartment.DataSource = entity.ToList();
            txtDepartment.DisplayMember = "Name";
            txtDepartment.ValueMember = "DepartmentId";
            txtDepartment.Text = "~Select Department~";
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtDepartment.SelectedValue = _entity.DepartmentId;
                txtJobPosition.SelectedValue = _entity.JobPositionId;
                txtShift.SelectedValue = _entity.ShiftId;
                txtGender.SelectedValue = _entity.Gender;
                txtBasicSalary.Text = _entity.BasicSalary.ToString();
                txtLeaveCredits.Text = _entity.LeaveCredits.ToString();
                txtAddress.Text = _entity.Address;
                txtContactNumber.Text = _entity.ContactNumber;
                txtEmail.Text = _entity.Email;
                txtFirstName.Text = _entity.FirstName;
                txtLastName.Text = _entity.LastName;
                txtBirthDate.Value = _entity == null ? _entity.DateOfBirth : DateTime.Now;
                txtIsDeducted.Checked = _entity.isDeducted;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.EmployeeId > 0)
            {
                _unitOfWork.Employee.Value.Detach(_entity);
                _unitOfWork.Employee.Value.Update(_entity);
                message = "Employee updated successfully.";
            }
            else
            {
                await _unitOfWork.Employee.Value.AddAsync(_entity);
                message = "Employee added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.DepartmentId= (int)txtDepartment.SelectedValue;
            _entity.JobPositionId = (int)txtJobPosition.SelectedValue;
            _entity.ShiftId = (int)txtShift.SelectedValue;
            _entity.Gender = (Gender)txtGender.SelectedValue;
            _entity.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
            _entity.LeaveCredits = Convert.ToDouble(txtLeaveCredits.Text);
            _entity.Address = txtAddress.Text;
            _entity.ContactNumber = txtContactNumber.Text;
            _entity.Email = txtEmail.Text;
            _entity.FirstName = txtFirstName.Text;
            _entity.LastName = txtLastName.Text;
            _entity.DateOfBirth = txtBirthDate.Value;
            _entity.isDeducted = txtIsDeducted.Checked;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
