using PresentationLayer.Views;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
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
            _view.ShowUserProfile += ShowUserProfile;
            _view.ShowChangePassword += ShowChangePassword;
            ShowUserProfile(this, EventArgs.Empty);
        }

        private void ShowChangePassword(object? sender, EventArgs e)
        {
            IChangePasswordView view = ChangePasswordView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new ChangePasswordPresenter(view, _unitOfWork);
        }

        private void ShowUserProfile(object? sender, EventArgs e)
        {
            IUserProfileView view = UserProfileView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new UserProfilePresenter(view, _unitOfWork);
        }
    }
}
