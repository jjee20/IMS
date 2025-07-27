using System;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Presenters.Commons;
using RavenTech_ERP.Views.IViews;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using static Unity.Storage.RegistrationSet;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class UpsertRegisterAccountView : SfForm
    {
        string message;
        private ApplicationUser _entity;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;

        public UpsertRegisterAccountView(IUnitOfWork unitOfWork, ApplicationUser? entity = null)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _entity = entity;
            _passwordHasher = new PasswordHasher<ApplicationUser>();
            LoadDepartments();
            LoadEntityToForm();
        }

        private void LoadDepartments()
        {
            if (EnumHelper.EnumToEnumerable<Departments>() is { } departments)
            {
                txtDepartment.DataSource = departments;
                txtDepartment.DisplayMember = "Name";
                txtDepartment.ValueMember = "Id";
            }
            else
            {
                txtDepartment.DataSource = null;
            }
        }

        private async void LoadEntityToForm()
        {
            string id = null;
            if (_entity != null || _unitOfWork.ApplicationUser?.Value != null)
            {
                id = _entity.Id;
            }
            if (id != null)
            {
                txtEmail.Text = _entity.Email;
                txtPassword.Visible = false;
                lblPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtDepartment.Text = _entity.Department.ToString() ?? "";

                if (_entity.TaskRoles != null)
                {
                    btnAdd.Checked = _entity.TaskRoles.Contains(TaskRoles.Add);
                    btnEdit.Checked = _entity.TaskRoles.Contains(TaskRoles.Edit);
                    btnDelete.Checked = _entity.TaskRoles.Contains(TaskRoles.Delete);
                    btnView.Checked = _entity.TaskRoles.Contains(TaskRoles.View);
                    btnOverride.Checked = _entity.TaskRoles.Contains(TaskRoles.Override);
                }
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEntityFromForm();

            var user = await _unitOfWork.ApplicationUser.Value.GetAsync(c => c.Id == _entity.Id);

            if (user != null)
            {
                _unitOfWork.ApplicationUser.Value.Update(_entity);
                message = "Account updated successfully.";
            }
            else
            {
                await _unitOfWork.ApplicationUser.Value.AddAsync(_entity);
                message = "Account added successfully.";
            }

            await _unitOfWork.SaveAsync();
            ShowSuccess(message);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateEntityFromForm()
        {

            _entity ??= new ApplicationUser();
            _entity.Email = txtEmail.Text.Trim();

            // Assuming Id is int; check if this is a new user
            if (_entity.Id == null)
            {
                _entity.PasswordHash = _passwordHasher.HashPassword(null, txtPassword.Text.Trim());
            }

            _entity.Department = (Departments)txtDepartment.SelectedValue;

            _entity.NormalizedEmail = txtEmail.Text.Trim().ToUpper();
            _entity.UserName = txtEmail.Text.Trim();
            _entity.NormalizedUserName = txtEmail.Text.Trim().ToUpper();
            _entity.EmailConfirmed = true; // Assuming email confirmation is not required for this form
            _entity.PhoneNumber = null; // Assuming phone number is not requiredq
            _entity.PhoneNumberConfirmed = false; // Assuming phone number confirmation is not required
            _entity.TwoFactorEnabled = false; // Assuming two-factor authentication is not required
            _entity.LockoutEnabled = false; // Assuming lockout is not enabled
            _entity.AccessFailedCount = 0; // Resetting access failed count


            // Ensure TaskRoles is initialized
            if (_entity.TaskRoles == null)
            {
                _entity.TaskRoles = new List<TaskRoles>();
            }

            // Define selected roles based on UI checkboxes
            var selectedRoles = new List<TaskRoles>();
            if (btnAdd.Checked) selectedRoles.Add(TaskRoles.Add);
            if (btnEdit.Checked) selectedRoles.Add(TaskRoles.Edit);
            if (btnDelete.Checked) selectedRoles.Add(TaskRoles.Delete);
            if (btnView.Checked) selectedRoles.Add(TaskRoles.View);
            if (btnOverride.Checked) selectedRoles.Add(TaskRoles.Override);

            // Update existing roles or assign new ones (preserving tracking)
            // Remove any roles no longer selected
            var toRemove = _entity.TaskRoles.Except(selectedRoles).ToList();
            foreach (var role in toRemove)
            {
                _entity.TaskRoles.Remove(role);
            }

            // Add any newly selected roles
            var toAdd = selectedRoles.Except(_entity.TaskRoles).ToList();
            foreach (var role in toAdd)
            {
                _entity.TaskRoles.Add(role);
            }
        }


        private void ShowSuccess(string message) =>
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
