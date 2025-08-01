﻿using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.PayrollViewModels;
using PresentationLayer;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Pdf;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll.Upserts
{
    public partial class UpsertAttendanceView : SfForm
    {
        private string message;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Attendance? _entity;
        private readonly int? _employeeId;

        public UpsertAttendanceView(IUnitOfWork unitOfWork, Attendance? entity = null, int? employeeId = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Attendance();
            _employeeId = employeeId;
            LoadEmployees();
            LoadProjects();
            LoadEntityToForm();
        }

        private void LoadEmployees()
        {
            var entity = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());

            if (_employeeId > 0)
            {
                entity = entity.Where(c => c.EmployeeId == _employeeId);
            }

            txtEmployee.DataSource = entity.OrderBy(c => c.Name).ToList();
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
            txtEmployee.Text = "~Select Employee~";
        }

        private void LoadProjects()
        {
            var entity = _unitOfWork.Project.Value.GetAll();
            txtProject.DataSource = entity.ToList();
            txtProject.DisplayMember = "ProjectName";
            txtProject.ValueMember = "ProjectId";
            txtProject.Text = "~Select Project~";
        }

        private void LoadEntityToForm()
        {
            if (_employeeId > 0 || _employeeId != null)
                txtEmployee.SelectedValue = _employeeId;

            if (_entity.AttendanceId > 0)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtDate.Text = _entity == null ? _entity.Date.ToString() : DateTime.Now.ToString();
                txtHoursWorked.Text = _entity.HoursWorked.ToString() ?? 8.ToString();
                txtIsHalfDay.Checked = _entity.IsHalfDay;
                txtIsPresent.Checked = _entity.IsPresent;
                txtProject.SelectedValue = _entity.ProjectId;
                txtTimein.Text = _entity.TimeIn.ToString();
                txtTimeout.Text = _entity.TimeOut.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.AttendanceId > 0)
            {
                _unitOfWork.Attendance.Value.Detach(_entity);
                _unitOfWork.Attendance.Value.Update(_entity);
                message = "Attendance updated successfully.";
            }
            else
            {
                await _unitOfWork.Attendance.Value.AddAsync(_entity);
                message = "Attendance added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.Date = (DateTime)txtDate.Value;
            _entity.ProjectId = (int)txtProject.SelectedValue;
            _entity.TimeIn = txtTimein.Value.Value.TimeOfDay;
            _entity.TimeOut = txtTimeout.Value.Value.TimeOfDay;
            _entity.HoursWorked = double.TryParse(txtHoursWorked.Text, out double hours) ? hours : 0;
            _entity.IsHalfDay = txtIsHalfDay.Checked;
            _entity.IsPresent = txtIsPresent.Checked;
        }
        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void UpsertAttendanceView_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now;
        }
    }
}
