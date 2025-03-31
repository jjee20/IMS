using PresentationLayer.Presenters.Account;
using PresentationLayer.Presenters.Inventory;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Admin;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Payroll;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Admin
{
    public class AdminPresenter
    {
        private IAdminView _view;
        private IUnitOfWork _unitOfWork;
        public AdminPresenter(IAdminView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowRegister += ShowRegister;
            _view.ShowInventory += ShowInventory;
            _view.ShowPayroll += ShowPayroll;
            _view.ShowProfile += ShowProfile;
            ShowProfile(this, EventArgs.Empty);
        }
        private void ShowProfile(object? sender, EventArgs e)
        {
            IProfileView view = ProfileView.GetInstance(_view.Guna2TabControlPage);
            new ProfilePresenter(view, _unitOfWork);
        }

        private void ShowRegister(object? sender, EventArgs e)
        {
            IRegisterView view = RegisterView.GetInstance(_view.Guna2TabControlPage);
            new RegisterPresenter(view, _unitOfWork);
        }
        private void ShowInventory(object? sender, EventArgs e)
        {
            IInventoryView view = new InventoryView();
            var presenter = new InventoryPresenter(view, _unitOfWork);

            view.ShowForm();
        }
        private void ShowPayroll(object? sender, EventArgs e)
        {
            IPayrollSystemView view = new PayrollSystemView();
            var presenter = new PayrollSystemPresenter(view, _unitOfWork);

            view.ShowForm();
        }
    }
}
