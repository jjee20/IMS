using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertBillTypeView : SfForm
    {
        string message;
        private BillType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertBillTypeView(IUnitOfWork unitOfWork, BillType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new BillType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.BillTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.BillTypeId > 0)
            {
                _unitOfWork.BillType.Value.Detach(_entity);
                _unitOfWork.BillType.Value.Update(_entity);
                message = "Bill Type updated successfully.";
            }
            else
            {
                await _unitOfWork.BillType.Value.AddAsync(_entity);
                message = "Bill Type added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.BillTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
