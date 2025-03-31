using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Inventory
{
    public class SettingsPresenter
    {
        private ISettingsView _view;
        private IUnitOfWork _unitOfWork;
        public SettingsPresenter(ISettingsView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowCustomerType += ShowCustomerType;
            _view.ShowSalesType += ShowSalesType;
            _view.ShowShipmentType += ShowShipmentType;
            _view.ShowInvoiceType += ShowInvoiceType;
            _view.ShowPaymentType += ShowPaymentType;
            _view.ShowVendorType += ShowVendorType;
            _view.ShowPurchaseType += ShowPurchaseType;
            _view.ShowBillType += ShowBillType;
            ShowSalesType(this, EventArgs.Empty);
        }

        private void ShowBillType(object? sender, EventArgs e)
        {
            IBillTypeView view = BillTypeView.GetInstance(_view.Guna2TabControlPage);
            new BillTypePresenter(view, _unitOfWork);
        }

        private void ShowPurchaseType(object? sender, EventArgs e)
        {
            IPurchaseTypeView view = PurchaseTypeView.GetInstance(_view.Guna2TabControlPage);
            new PurchaseTypePresenter(view, _unitOfWork);
        }

        private void ShowVendorType(object? sender, EventArgs e)
        {
            IVendorTypeView view = VendorTypeView.GetInstance(_view.Guna2TabControlPage);
            new VendorTypePresenter(view, _unitOfWork);
        }

        private void ShowPaymentType(object? sender, EventArgs e)
        {
            IPaymentTypeView view = PaymentTypeView.GetInstance(_view.Guna2TabControlPage);
            new PaymentTypePresenter(view, _unitOfWork);
        }

        private void ShowCustomerType(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance(_view.Guna2TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
        private void ShowSalesType(object? sender, EventArgs e)
        {
            ISalesTypeView view = SalesTypeView.GetInstance(_view.Guna2TabControlPage);
            new SalesTypePresenter(view, _unitOfWork);
        }
        private void ShowShipmentType(object? sender, EventArgs e)
        {
            IShipmentTypeView view = ShipmentTypeView.GetInstance(_view.Guna2TabControlPage);
            new ShipmentTypePresenter(view, _unitOfWork);
        }
        private void ShowInvoiceType(object? sender, EventArgs e)
        {
            IInvoiceTypeView view = InvoiceTypeView.GetInstance(_view.Guna2TabControlPage);
            new InvoiceTypePresenter(view, _unitOfWork);
        }
    }
}
