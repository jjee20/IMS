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
    public partial class UpsertAllowanceView : SfForm
    {
        string message;
        private Allowance _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertAllowanceView(IUnitOfWork unitOfWork, Allowance? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Allowance();

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
            var entity = EnumHelper.EnumToEnumerable<DomainLayer.Enums.AllowanceType>();
            txtAllowanceType.DataSource = entity.ToList();
            txtAllowanceType.DisplayMember = "Name";
            txtAllowanceType.ValueMember = "Id";
            txtAllowanceType.Text = "~Select Allowance Type~";
        }

        private void LoadEntityToForm()
        {
            if(_entity.AllowanceId > 0)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtAllowanceType.Text = _entity.AllowanceType.ToString();
                txtAmount.Text = _entity.Amount.ToString();
                txtDescription.Text = _entity.Description;
                txtDate.Value = _entity == null ? _entity.DateGranted : DateTime.Now;
                txtIsRecurring.Checked = _entity.IsRecurring;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.AllowanceId > 0)
            {
                _unitOfWork.Allowance.Value.Detach(_entity);
                _unitOfWork.Allowance.Value.Update(_entity);
                message = "Allowance updated successfully.";
            }
            else
            {
                await _unitOfWork.Allowance.Value.AddAsync(_entity);
                message = "Allowance added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.AllowanceType = (DomainLayer.Enums.AllowanceType)txtAllowanceType.SelectedValue;
            _entity.DateGranted = txtDate.Value;
            _entity.Amount = !string.IsNullOrEmpty(txtAmount.Text) ? Convert.ToDouble(txtAmount.Text) : 0;
            _entity.Description = txtDescription.Text;
            _entity.IsRecurring = txtIsRecurring.Checked;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
