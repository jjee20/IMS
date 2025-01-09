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
    public class SalesSettingsPresenter
    {
        private ISalesSettingsView _view;
        private IUnitOfWork _unitOfWork;
        public SalesSettingsPresenter(ISalesSettingsView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowCustomerType += ShowCustomer;
            _view.ShowSalesType += ShowSales;
            _view.ShowShipmentType += ShowShipment;
            _view.ShowInvoiceType += ShowInvoice;
            ShowCustomer(this, EventArgs.Empty);
        }
        private void ShowCustomer(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance(_view.Guna2TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
        private void ShowSales(object? sender, EventArgs e)
        {
            ISalesTypeView view = SalesTypeView.GetInstance(_view.Guna2TabControlPage);
            new SalesTypePresenter(view, _unitOfWork);
        }
        private void ShowShipment(object? sender, EventArgs e)
        {
            IShipmentTypeView view = ShipmentTypeView.GetInstance(_view.Guna2TabControlPage);
            new ShipmentTypePresenter(view, _unitOfWork);
        }
        private void ShowInvoice(object? sender, EventArgs e)
        {
            IInvoiceTypeView view = InvoiceTypeView.GetInstance(_view.Guna2TabControlPage);
            new InvoiceTypePresenter(view, _unitOfWork);
        }
    }
}
