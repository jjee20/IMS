using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters.Account
{
    public class ChangePasswordPresenter
    {
        public IChangePasswordView _view;
        private IUnitOfWork _unitOfWork;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        public ChangePasswordPresenter(IChangePasswordView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            _passwordHasher = new PasswordHasher<ApplicationUser>();

            _view.SaveEvent += Save;

        }

        private void Save(object? sender, EventArgs e)
        {
            string userId = Settings.Default.User_Id;
            var user = _unitOfWork.ApplicationUser.Get(c => c.Id == userId);

            try
            {
                new ModelDataValidation().Validate(user);

                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, _view.Password);

                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    user.PasswordHash = _view.NewPassword;
                    _unitOfWork.ApplicationUser.Update(user);
                    _view.Message = "Password updated successfully";
                    _unitOfWork.Save();
                    _view.IsSuccessful = true;
                }
                else
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Incorrect old password. Please try again.";
                }
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }
    }
}
