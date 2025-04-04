using DomainLayer.Enums;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.UserControls.Account;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Account
{
    public class ProfilePresenter
    {
        private IProfileView _view;
        private IUnitOfWork _unitOfWork;
        public ProfilePresenter(IProfileView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowEditProfile += ShowEditProfile;
            _view.ShowChangePassword += ShowChangePassword;

            LoadDetails();
        }

        private void LoadDetails()
        {
            var userId = Settings.Default.User_Id;
            var user = _unitOfWork.ApplicationUser.Value.Get(c => c.Id == userId, includeProperties: "Profile");

            _view.AppUserName = user.Profile != null ? $"{user.Profile.FirstName} {user.Profile.LastName}" ?? "{Needs Updating}" : "{Needs Updating}";
            _view.Email = user.Email ?? "{Needs Updating}";
            _view.Phone = user.PhoneNumber ?? "{Needs Updating}";
            _view.UserName = user.UserName ?? "{Needs Updating}";
            _view.Department = user.Department.ToString() ?? "{Needs Updating}";
            _view.GetTaskRoles(user.TaskRoles.ToList());
        }

        private void ShowChangePassword(object? sender, EventArgs e)
        {
            var userId = Settings.Default.User_Id;
            var user = _unitOfWork.ApplicationUser.Value.Get(c => c.Id == userId, includeProperties: "Profile");
            var changePassword = new ChangePasswordView(user, _unitOfWork);
            changePassword.ShowDialog();
        }

        private void ShowEditProfile(object? sender, EventArgs e)
        {
            var userId = Settings.Default.User_Id;
            var user = _unitOfWork.ApplicationUser.Value.Get(c => c.Id == userId, includeProperties: "Profile");
            using (var accountInformation = new EditAccountInformationView(user, _unitOfWork))
            {
                if(accountInformation.ShowDialog() == DialogResult.OK)
                {
                    LoadDetails();
                }
            } 
            
        }
    }
}
