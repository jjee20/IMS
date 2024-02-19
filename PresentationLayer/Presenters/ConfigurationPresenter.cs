using DomainLayer.Models;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ServiceLayer.Services.CommonServices.MainMenu;

namespace PresentationLayer.Presenters
{
    public class ConfigurationPresenter
    {
        private IConfigurationView _view;
        private IUnitOfWork _unitOfWork;
        public ConfigurationPresenter(IConfigurationView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowCurrency += ShowCurrency;
            _view.ShowBranch += ShowBranch;
            _view.ShowWarehouse += ShowWarehouse;
            _view.ShowCashBank += ShowCashBank;
            _view.ShowPaymentType += ShowPaymentType;
            _view.ShowShipmentType += ShowShipmentType;
            _view.ShowInvoiceType += ShowInvoiceType;
            _view.ShowBillType += ShowBillType;
        }

        private void ShowCurrency(object? sender, EventArgs e)
        {
            ICurrencyView view = CurrencyView.GetInstance(_view.TabControlPage);
            new CurrencyPresenter(view, _unitOfWork);
        }
        private void ShowBranch(object? sender, EventArgs e)
        {
            IBranchView view = BranchView.GetInstance(_view.TabControlPage);
            new BranchPresenter(view, _unitOfWork);
        }

        private void ShowWarehouse(object? sender, EventArgs e)
        {
            IWarehouseView view = WarehouseView.GetInstance(_view.TabControlPage);
            new WarehousePresenter(view, _unitOfWork);
        }

        private void ShowCashBank(object? sender, EventArgs e)
        {
            ICashBankView view = CashBankView.GetInstance(_view.TabControlPage);
            new CashBankPresenter(view, _unitOfWork);
        }

        private void ShowPaymentType(object? sender, EventArgs e)
        {
            IPaymentTypeView view = PaymentTypeView.GetInstance(_view.TabControlPage);
            new PaymentTypePresenter(view, _unitOfWork);
        }

        private void ShowShipmentType(object? sender, EventArgs e)
        {
            IShipmentTypeView view = ShipmentTypeView.GetInstance(_view.TabControlPage);
            new ShipmentTypePresenter(view, _unitOfWork);
        }

        private void ShowInvoiceType(object? sender, EventArgs e)
        {
            IInvoiceTypeView view = InvoiceTypeView.GetInstance(_view.TabControlPage);
            new InvoiceTypePresenter(view, _unitOfWork);
        }

        private void ShowBillType(object? sender, EventArgs e)
        {
            IBillTypeView view = BillTypeView.GetInstance(_view.TabControlPage);
            new BillTypePresenter(view, _unitOfWork);
        }

    }
}
