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
    public partial class UpsertBonusView : SfForm
    {
        string message;
        private Bonus _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertBonusView(IUnitOfWork unitOfWork, Bonus? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Bonus();

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
            var entity = EnumHelper.EnumToEnumerable<DomainLayer.Enums.BonusType>();
            txtBonusType.DataSource = entity.ToList();
            txtBonusType.DisplayMember = "Name";
            txtBonusType.ValueMember = "Id";
            txtBonusType.Text = "~Select Bonus Type~";
        }

        private void LoadEntityToForm()
        {
            if (_entity != null)
            {
                txtEmployee.SelectedValue = _entity.EmployeeId;
                txtBonusType.Text = _entity.BonusType.ToString();
                txtAmount.Text = _entity.Amount.ToString();
                txtDescription.Text = _entity.Description;
                txtDate.Value = _entity == null ? _entity.DateGranted : DateTime.Now;
                txtIsOneTime.Checked = _entity.IsOneTime;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.BonusId > 0)
            {
                _unitOfWork.Bonus.Value.Detach(_entity);
                _unitOfWork.Bonus.Value.Update(_entity);
                message = "Bonus updated successfully.";
            }
            else
            {
                await _unitOfWork.Bonus.Value.AddAsync(_entity);
                message = "Bonus added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.EmployeeId = (int)txtEmployee.SelectedValue;
            _entity.BonusType = (DomainLayer.Enums.BonusType)txtBonusType.SelectedValue;
            _entity.DateGranted = txtDate.Value;
            _entity.Amount = !string.IsNullOrEmpty(txtAmount.Text) ? Convert.ToDouble(txtAmount.Text) : 0;
            _entity.Description = txtDescription.Text;
            _entity.IsOneTime = txtIsOneTime.Checked;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
