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
    public partial class UpsertDeductionView : SfForm
    {
        string message;
        private Deduction _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertDeductionView(IUnitOfWork unitOfWork, Deduction? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Deduction();

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
            var entity = EnumHelper.EnumToEnumerable<DomainLayer.Enums.DeductionType>();
            txtDeductionType.DataSource = entity.ToList();
            txtDeductionType.DisplayMember = "Name";
            txtDeductionType.ValueMember = "Id";
            txtDeductionType.Text = "~Select Deduction Type~";
        }

        private void LoadEntityToForm()
        {

            if (_entity != null)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtDeductionType.Text = _entity.DeductionType.ToString();
                txtAmount.Text = _entity.Amount.ToString();
                txtDescription.Text = _entity.Description;
                txtDate.Value = _entity == null ? _entity.DateDeducted : DateTime.Now;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.DeductionId > 0)
            {
                _unitOfWork.Deduction.Value.Detach(_entity);
                _unitOfWork.Deduction.Value.Update(_entity);
                message = "Deduction updated successfully.";
            }
            else
            {
                await _unitOfWork.Deduction.Value.AddAsync(_entity);
                message = "Deduction added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.DeductionType = (DomainLayer.Enums.DeductionType)txtDeductionType.SelectedValue;
            _entity.DateDeducted = txtDate.Value;
            _entity.Amount = !string.IsNullOrEmpty(txtAmount.Text) ? Convert.ToDouble(txtAmount.Text) : 0;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
