using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertCashBankView : SfForm
    {
        string message;
        private CashBank _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertCashBankView(IUnitOfWork unitOfWork, CashBank? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new CashBank();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.CashBankName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.CashBankId > 0)
            {
                _unitOfWork.CashBank.Value.Detach(_entity);
                _unitOfWork.CashBank.Value.Update(_entity);
                message = "Cash Bank updated successfully.";
            }
            else
            {
                await _unitOfWork.CashBank.Value.AddAsync(_entity);
                message = "Cash Bank added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.CashBankName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
