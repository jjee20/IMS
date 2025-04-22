using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertSalesTypeView : SfForm
    {
        string message;
        private SalesType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertSalesTypeView(IUnitOfWork unitOfWork, SalesType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new SalesType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.SalesTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.SalesTypeId > 0)
            {
                _unitOfWork.SalesType.Value.Detach(_entity);
                _unitOfWork.SalesType.Value.Update(_entity);
                message = "Sales Type updated successfully.";
            }
            else
            {
                await _unitOfWork.SalesType.Value.AddAsync(_entity);
                message = "Sales Type added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.SalesTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
