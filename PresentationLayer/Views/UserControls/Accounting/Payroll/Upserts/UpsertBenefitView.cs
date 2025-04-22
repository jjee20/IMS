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
    public partial class UpsertBenefitView : SfForm
    {
        string message;
        private Benefit _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertBenefitView(IUnitOfWork unitOfWork, Benefit? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Benefit();

            LoadTypes();
            LoadEmployees();
            LoadEntityToForm();
        }

        private void LoadEmployees()
        {
            var entity = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            txtEmployee.DataSource = entity.ToList();
            txtEmployee.DisplayMember = "Name";
            txtEmployee.ValueMember = "EmployeeId";
            txtEmployee.Text = "~Select Employee~";
        }

        private void LoadTypes()
        {
            var entity = EnumHelper.EnumToEnumerable<DomainLayer.Enums.BenefitType>();
            txtBenefitType.DataSource = entity.ToList();
            txtBenefitType.DisplayMember = "Name";
            txtBenefitType.ValueMember = "Id";
            txtBenefitType.Text = "~Select Benefit Type~";
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtBenefitType.Text = _entity.BenefitType.ToString();
                txtAmount.Text = _entity.Amount.ToString();
                txtOther.Text = _entity.Other;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.BenefitId > 0)
            {
                _unitOfWork.Benefit.Value.Detach(_entity);
                _unitOfWork.Benefit.Value.Update(_entity);
                message = "Benefit updated successfully.";
            }
            else
            {
                await _unitOfWork.Benefit.Value.AddAsync(_entity);
                message = "Benefit added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.BenefitType = (DomainLayer.Enums.BenefitType)txtBenefitType.SelectedValue;
            _entity.Amount = !string.IsNullOrEmpty(txtAmount.Text) ? Convert.ToDouble(txtAmount.Text) : 0;
            _entity.Other = txtOther.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
