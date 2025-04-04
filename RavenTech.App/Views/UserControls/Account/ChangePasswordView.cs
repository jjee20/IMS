using DomainLayer.Models.Accounts;
using InfastructureLayer.DataAccess.Repositories;
using MaterialSkin.Controls;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Presenters.Commons;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Account
{
    public partial class ChangePasswordView : MaterialForm
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationUser _applicationUser;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;

        public ChangePasswordView(ApplicationUser applicationUser, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _applicationUser = applicationUser;
            _unitOfWork = unitOfWork;
            _passwordHasher = new PasswordHasher<ApplicationUser>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                new ModelDataValidation().Validate(_applicationUser);
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(_applicationUser, _applicationUser.PasswordHash, txtOldPassword.Text);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    _applicationUser.PasswordHash = _passwordHasher.HashPassword(_applicationUser, txtNewPassword.Text);
                    _unitOfWork.ApplicationUser.Value.Update(_applicationUser);
                    _unitOfWork.Save();
                    MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect old password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
