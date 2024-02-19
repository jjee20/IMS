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
    public class InventoryPresenter
    {
        private IInventoryView _view;
        private IUnitOfWork _unitOfWork;
        public InventoryPresenter(IInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowCustomerType += ShowCustomerType;
            _view.ShowCustomer += ShowCustomer;
            _view.ShowSalesType += ShowSalesType;
            _view.ShowSalesOrder += ShowSalesOrder;
            _view.ShowShipment += ShowShipment;
            _view.ShowInvoice += ShowInvoice;
            _view.ShowPaymentReceive += ShowPaymentReceive;
            _view.ShowVendorType += ShowVendorType;
            _view.ShowPurchaseType += ShowPurchaseType;
            _view.ShowPurchaseOrder += ShowPurchaseOrder;
            _view.ShowGRN += ShowGRN;
            _view.ShowBill += ShowBill;
            _view.ShowPaymentVoucher += ShowPaymentVoucher;
            _view.ShowProduct += ShowProduct;
            _view.ShowProductType += ShowProductType;
            _view.ShowUnitOfMeasure += ShowUnitOfMeasure;
            _view.ShowConfiguration += ShowConfiguration;
            _view.ShowUserAndRole += ShowUserAndRole;
            _view.ShowVendor += ShowVendor;
        }

        private void ShowUserAndRole(object? sender, EventArgs e)
        {
            //IUserAndRoleView view = UserAndRoleView.GetInstance(_view.TabControlPage);
            //new UserAndRolePresenter(view, _unitOfWork);
        }

        private void ShowConfiguration(object? sender, EventArgs e)
        {
            IConfigurationView view = ConfigurationView.GetInstance(_view.TabControlPage);
            new ConfigurationPresenter(view, _unitOfWork);
        }

        private void ShowVendor(object? sender, EventArgs e)
        {
            IVendorView view = VendorView.GetInstance(_view.TabControlPage);
            new VendorPresenter(view, _unitOfWork);
        }
        private void ShowUnitOfMeasure(object? sender, EventArgs e)
        {
            IUnitOfMeasureView view = UnitOfMeasureView.GetInstance(_view.TabControlPage);
            new UnitOfMeasurePresenter(view, _unitOfWork);
        }

        private void ShowProductType(object? sender, EventArgs e)
        {
            IProductTypeView view = ProductTypeView.GetInstance(_view.TabControlPage);
            new ProductTypePresenter(view, _unitOfWork);
        }

        private void ShowProduct(object? sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance(_view.TabControlPage);
            new ProductPresenter(view, _unitOfWork);
        }

        private void ShowPaymentVoucher(object? sender, EventArgs e)
        {
            IPaymentVoucherView view = PaymentVoucherView.GetInstance(_view.TabControlPage);
            new PaymentVoucherPresenter(view, _unitOfWork);
        }

        private void ShowBill(object? sender, EventArgs e)
        {
            IBillView view = BillView.GetInstance(_view.TabControlPage);
            new BillPresenter(view, _unitOfWork);
        }

        private void ShowGRN(object? sender, EventArgs e)
        {
            IGoodsReceivedNoteView view = GoodsReceivedNoteView.GetInstance(_view.TabControlPage);
            new GoodsReceivedNotePresenter(view, _unitOfWork);
        }

        private void ShowPurchaseOrder(object? sender, EventArgs e)
        {
            IPurchaseOrderView view = PurchaseOrderView.GetInstance(_view.TabControlPage);
            new PurchaseOrderPresenter(view, _unitOfWork);
        }

        private void ShowPurchaseType(object? sender, EventArgs e)
        {
            IPurchaseTypeView view = PurchaseTypeView.GetInstance(_view.TabControlPage);
            new PurchaseTypePresenter(view, _unitOfWork);
        }

        private void ShowVendorType(object? sender, EventArgs e)
        {
            IVendorTypeView view = VendorTypeView.GetInstance(_view.TabControlPage);
            new VendorTypePresenter(view, _unitOfWork);
        }

        private void ShowPaymentReceive(object? sender, EventArgs e)
        {
            IPaymentReceiveView view = PaymentReceiveView.GetInstance(_view.TabControlPage);
            new PaymentReceivePresenter(view, _unitOfWork);
        }

        private void ShowInvoice(object? sender, EventArgs e)
        {
            IInvoiceView view = InvoiceView.GetInstance(_view.TabControlPage);
            new InvoicePresenter(view, _unitOfWork);
        }

        private void ShowShipment(object? sender, EventArgs e)
        {
            IShipmentView view = ShipmentView.GetInstance(_view.TabControlPage);
            new ShipmentPresenter(view, _unitOfWork);
        }

        private void ShowSalesOrder(object? sender, EventArgs e)
        {
            ISalesOrderView view = SalesOrderView.GetInstance(_view.TabControlPage);
            new SalesOrderPresenter(view, _unitOfWork);
        }

        private void ShowCustomer(object? sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance(_view.TabControlPage);
            new CustomerPresenter(view, _unitOfWork);
        }

        private void ShowCustomerType(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance(_view.TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
        private void ShowSalesType(object? sender, EventArgs e)
        {
            ISalesTypeView view = SalesTypeView.GetInstance(_view.TabControlPage);
            new SalesTypePresenter(view, _unitOfWork);
        }
    }
}
