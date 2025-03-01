using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters.Inventory
{
    public class PurchaseSettingsPresenter
    {
        private IPurchaseSettingsView _view;
        private IUnitOfWork _unitOfWork;
        public PurchaseSettingsPresenter(IPurchaseSettingsView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowPaymentType += ShowPaymentType;
            _view.ShowBranch += ShowBranch;
            _view.ShowCashBank += ShowCashBank;
            _view.ShowVendorType += ShowVendorType;
            _view.ShowPurchaseType += ShowPurchaseType;
            _view.ShowBillType += ShowBillType;
            ShowBranch(this, EventArgs.Empty);
        }

        private void ShowPaymentType(object? sender, EventArgs e)
        {
            IPaymentTypeView view = PaymentTypeView.GetInstance(_view.Guna2TabControlPage);
            new PaymentTypePresenter(view, _unitOfWork);
        }
        private void ShowBranch(object? sender, EventArgs e)
        {
            IBranchView view = BranchView.GetInstance(_view.Guna2TabControlPage);
            new BranchPresenter(view, _unitOfWork);
        }
        private void ShowCashBank(object? sender, EventArgs e)
        {
            ICashBankView view = CashBankView.GetInstance(_view.Guna2TabControlPage);
            new CashBankPresenter(view, _unitOfWork);
        }
        private void ShowVendorType(object? sender, EventArgs e)
        {
            IVendorTypeView view = VendorTypeView.GetInstance(_view.Guna2TabControlPage);
            new VendorTypePresenter(view, _unitOfWork);
        }
        private void ShowPurchaseType(object? sender, EventArgs e)
        {
            IPurchaseTypeView view = PurchaseTypeView.GetInstance(_view.Guna2TabControlPage);
            new PurchaseTypePresenter(view, _unitOfWork);
        }
        private void ShowBillType(object? sender, EventArgs e)
        {
            IBillTypeView view = BillTypeView.GetInstance(_view.Guna2TabControlPage);
            new BillTypePresenter(view, _unitOfWork);
        }
    }
}
