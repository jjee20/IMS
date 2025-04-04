using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Accounting;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Accounting
{
    public class AccountingPresenter
    {
        private IAccountingView _view;
        private IUnitOfWork _unitOfWork;
        public AccountingPresenter(IAccountingView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowPayrollEvent += ShowPayroll;
            _view.ShowAccountEvent += ShowAccount;
            _view.ShowBudgetEvent += ShowBudget;
            _view.ShowChartOfAccountEvent += ShowChartOfAccount;
            _view.ShowFinancialTransactionEvent += ShowFinancialTransaction;
            _view.ShowInvoiceEvent += ShowInvoice;
            _view.ShowLedgerEntryEvent += ShowLedgerEntry;
        }

        private void ShowLedgerEntry(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowInvoice(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowFinancialTransaction(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowChartOfAccount(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowPayroll(object? sender, EventArgs e)
        {
            //IPayrollSystemView view = new PayrollSystemView();
            //var presenter = new PayrollSystemPresenter(view, _unitOfWork);
            //view.ShowForm();
        }
        private void ShowAccount(object? sender, EventArgs e)
        {

        }
        private void ShowBudget(object? sender, EventArgs e)
        {
            //IUserProfileView view = UserProfileView.GetInstance(_view.Guna2TabControlPage);
            //new UserProfilePresenter(view, _unitOfWork);
        }
    }
}
