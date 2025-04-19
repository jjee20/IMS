using DomainLayer.Models.Inventory;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertWarehouseView : SfForm
    {
        string message;
        private Warehouse _entity;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertWarehouseView(IUnitOfWork unitOfWork, Warehouse? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity ?? new Warehouse();

            LoadBranch();
            LoadEntityToForm();
        }

        private void LoadBranch()
        {
            txtBranch.DataSource = _unitOfWork.Branch.Value.GetAll();
            txtBranch.DisplayMember = "BranchName";
            txtBranch.ValueMember = "BranchId";
        }

        private void LoadEntityToForm()
        {
            txtName.Text = _entity.WarehouseName;
            txtDescription.Text = _entity.Description;
            txtBranch.SelectedValue = _entity.BranchId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            if (_entity.WarehouseId > 0)
            {
                _unitOfWork.Warehouse.Value.Detach(_entity);
                _unitOfWork.Warehouse.Value.Update(_entity);
                message = "Cash Bank updated successfully.";
            }
            else
            {
                await _unitOfWork.Warehouse.Value.AddAsync(_entity);
                message = "Cash Bank added successfully.";
            }

            ShowSuccess(message);
            await _unitOfWork.SaveAsync();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {
            _entity.WarehouseName = txtName.Text;
            _entity.Description = txtDescription.Text;
            _entity.BranchId = (int)txtBranch.SelectedValue;
        }

        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
