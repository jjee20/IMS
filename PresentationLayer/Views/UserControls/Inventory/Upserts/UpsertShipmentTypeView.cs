using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertShipmentTypeView : SfForm
    {
        string message;
        private ShipmentType _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertShipmentTypeView(IUnitOfWork unitOfWork, ShipmentType? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new ShipmentType();
            LoadEntityToForm();
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.ShipmentTypeName;
            txtDescription.Text = _entity.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.ShipmentTypeId > 0)
            {
                _unitOfWork.ShipmentType.Value.Detach(_entity);
                _unitOfWork.ShipmentType.Value.Update(_entity);
                message = "Shipment Type updated successfully.";
            }
            else
            {
                await _unitOfWork.ShipmentType.Value.AddAsync(_entity);
                message = "Shipment Type added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.ShipmentTypeName = txtName.Text;
            _entity.Description = txtDescription.Text;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
