using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Account
{
    public class UserProfilePresenter
    {
        public IUserProfileView _view;
        private IUnitOfWork _unitOfWork;
        public UserProfilePresenter(IUserProfileView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            _view.SaveEvent += Save;
            _view.PrintEvent += Print;

            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            string userId = Settings.Default.User_Id;
            if (!string.IsNullOrEmpty(userId))
            {
                var user = _unitOfWork.ApplicationUser.Get(c => c.Id == userId, includeProperties: "Profile");

                if (user.Profile == null) user.Profile = new UserProfile();
                _view.PhoneNumber = user.PhoneNumber;
                _view.Email = user.Email;
                _view.FirstName = user.Profile.FirstName;
                _view.LastName = user.Profile.LastName;
            }
        }

        private void Save(object? sender, EventArgs e)
        {
            string userId = Settings.Default.User_Id;
            var user = _unitOfWork.ApplicationUser.Get(c => c.Id == userId, includeProperties: "Profile");

            if (user == null) user = new ApplicationUser();
            if (user.Profile == null) user.Profile = new UserProfile();
            else _unitOfWork.ApplicationUser.Detach(user);

            user.Profile.FirstName = _view.FirstName;
            user.Profile.LastName = _view.LastName;
            user.Email = _view.Email;
            user.NormalizedEmail = _view.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.PhoneNumber = _view.PhoneNumber;

            try
            {
                new ModelDataValidation().Validate(user);
                _unitOfWork.ApplicationUser.Update(user);
                _view.Message = "Profile edited successfully";
                _unitOfWork.Save();
                _view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            //string reportFileName = "UserProfileReport.rdlc";
            //string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            //string reportPath = Path.Combine(reportDirectory, reportFileName);
            //var localReport = new LocalReport();
            //var reportDataSource = new ReportDataSource("UserProfile", UserProfileList);
            //var reportView = new ReportView(reportPath, reportDataSource, localReport);
            //reportView.ShowDialog();
        }
    }
}
