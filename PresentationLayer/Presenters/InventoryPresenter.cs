using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class InventoryPresenter
    {
        private IInventoryView _view;
        private IUnitOfWork _unitOfWork;
        private CustomerTypePresenter _customerTypePresenter;
        private CustomerPresenter _customerPresenter;
        public InventoryPresenter(IInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowBillType += ShowBillType;
            _view.ShowBill += ShowBill;
            _view.ShowBranch += ShowBranch;
            _view.ShowCashBank += ShowCashBank;
            _view.ShowCurrency += ShowCurrency;
            _view.ShowCustomerType += ShowCustomerType;
            _view.ShowCustomer += ShowCustomer;
            _view.ShowGoodsReceivedNote += ShowGoodsReceivedNote;
            _view.ShowInvoiceType += ShowInvoiceType;
            _view.ShowInvoice += ShowInvoice;
            _view.ShowPaymentReceive += ShowPaymentReceive;
            _view.ShowPaymentType += ShowPaymentType;
            _view.ShowPaymentVoucher += ShowPaymentVoucher;
            _view.ShowProductType += ShowProductType;
            _view.ShowProduct += ShowProduct;
            _view.ShowPurchaseOrder += ShowPurchaseOrder;
            _view.ShowPurchaseType += ShowPurchaseType;
            _view.ShowSalesOrder += ShowSalesOrder;
            _view.ShowSalesType += ShowSalesType;
            _view.ShowShipmentType += ShowShipmentType;
            _view.ShowShipment += ShowShipment;
            _view.ShowUnitOfMeasure += ShowUnitOfMeasure;
            _view.ShowVendorType += ShowVendorType;
            _view.ShowVendor += ShowVendor;
        }

        private void ShowBillType(object? sender, EventArgs e)
        {
            IBillTypeView view = BillTypeView.GetInstance((TabPage)_view.TabControlPage);
            new BillTypePresenter(view, _unitOfWork);
        }
        private void ShowBill(object? sender, EventArgs e)
        {
            IBillView view = BillView.GetInstance((TabPage)_view.TabControlPage);
            new BillPresenter(view, _unitOfWork);
        }
        private void ShowBranch(object? sender, EventArgs e)
        {
            IBranchView view = BranchView.GetInstance((TabPage)_view.TabControlPage);
            new BranchPresenter(view, _unitOfWork);
        }
        private void ShowCashBank(object? sender, EventArgs e)
        {
            ICashBankView view = CashBankView.GetInstance((TabPage)_view.TabControlPage);
            new CashBankPresenter(view, _unitOfWork);
        }
        private void ShowCurrency(object? sender, EventArgs e)
        {
            ICurrencyView view = CurrencyView.GetInstance((TabPage)_view.TabControlPage);
            new CurrencyPresenter(view, _unitOfWork);
        }
        private void ShowCustomerType(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance((TabPage)_view.TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
        private void ShowCustomer(object? sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance((TabPage)_view.TabControlPage);
            new CustomerPresenter(view, _unitOfWork);
        }
        private void ShowGoodsReceivedNote(object? sender, EventArgs e)
        {
            IGoodsReceivedNoteView view = GoodsReceivedNoteView.GetInstance((TabPage)_view.TabControlPage);
            new GoodsReceivedNotePresenter(view, _unitOfWork);
        }
        private void ShowInvoiceType(object? sender, EventArgs e)
        {
            IInvoiceTypeView view = InvoiceTypeView.GetInstance((TabPage)_view.TabControlPage);
            new InvoiceTypePresenter(view, _unitOfWork);
        }
        private void ShowInvoice(object? sender, EventArgs e)
        {
            IInvoiceView view = InvoiceView.GetInstance((TabPage)_view.TabControlPage);
            new InvoicePresenter(view, _unitOfWork);
        }
        private void ShowPaymentReceive(object? sender, EventArgs e)
        {
            IPaymentReceiveView view = PaymentReceiveView.GetInstance((TabPage)_view.TabControlPage);
            new PaymentReceivePresenter(view, _unitOfWork);
        }
        private void ShowPaymentType(object? sender, EventArgs e)
        {
            IPaymentTypeView view = PaymentTypeView.GetInstance((TabPage)_view.TabControlPage);
            new PaymentTypePresenter(view, _unitOfWork);
        }
        private void ShowPaymentVoucher(object? sender, EventArgs e)
        {
            IPaymentVoucherView view = PaymentVoucherView.GetInstance((TabPage)_view.TabControlPage);
            new PaymentVoucherPresenter(view, _unitOfWork);
        }
        private void ShowProductType(object? sender, EventArgs e)
        {
            IProductTypeView view = ProductTypeView.GetInstance((TabPage)_view.TabControlPage);
            new ProductTypePresenter(view, _unitOfWork);
        }
        private void ShowProduct(object? sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance((TabPage)_view.TabControlPage);
            new ProductPresenter(view, _unitOfWork);
        }
        private void ShowPurchaseOrder(object? sender, EventArgs e)
        {
            IPurchaseOrderView view = PurchaseOrderView.GetInstance((TabPage)_view.TabControlPage);
            new PurchaseOrderPresenter(view, _unitOfWork);
        }
        private void ShowPurchaseType(object? sender, EventArgs e)
        {
            IPurchaseTypeView view = PurchaseTypeView.GetInstance((TabPage)_view.TabControlPage);
            new PurchaseTypePresenter(view, _unitOfWork);
        }
        private void ShowSalesOrder(object? sender, EventArgs e)
        {
            ISalesOrderView view = SalesOrderView.GetInstance((TabPage)_view.TabControlPage);
            new SalesOrderPresenter(view, _unitOfWork);
        }
        private void ShowSalesType(object? sender, EventArgs e)
        {
            ISalesTypeView view = SalesTypeView.GetInstance((TabPage)_view.TabControlPage);
            new SalesTypePresenter(view, _unitOfWork);
        }
        private void ShowShipmentType(object? sender, EventArgs e)
        {
            IShipmentTypeView view = ShipmentTypeView.GetInstance((TabPage)_view.TabControlPage);
            new ShipmentTypePresenter(view, _unitOfWork);
        }
        private void ShowShipment(object? sender, EventArgs e)
        {
            IShipmentView view = ShipmentView.GetInstance((TabPage)_view.TabControlPage);
            new ShipmentPresenter(view, _unitOfWork);
        }
        private void ShowUnitOfMeasure(object? sender, EventArgs e)
        {
            IUnitOfMeasureView view = UnitOfMeasureView.GetInstance((TabPage)_view.TabControlPage);
            new UnitOfMeasurePresenter(view, _unitOfWork);
        }
        private void ShowVendorType(object? sender, EventArgs e)
        {
            IVendorTypeView view = VendorTypeView.GetInstance((TabPage)_view.TabControlPage);
            new VendorTypePresenter(view, _unitOfWork);
        }
        private void ShowVendor(object? sender, EventArgs e)
        {
            IVendorView view = VendorView.GetInstance((TabPage)_view.TabControlPage);
            new VendorPresenter(view, _unitOfWork);
        }
    }
}
