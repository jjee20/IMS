using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories.IInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Inventory
{
    public class SalesPresenter
    {
        private ISalesView _view;
        private IUnitOfWork _unitOfWork;
        public SalesPresenter(ISalesView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowCustomer += ShowCustomer;
            _view.ShowSalesOrder += ShowSalesOrder;
            _view.ShowSettings += ShowSettings;
            _view.ShowWarehouse += ShowWarehouse;
            ShowSalesOrder(this, EventArgs.Empty);
        }

        private void ShowWarehouse(object? sender, EventArgs e)
        {
            IWarehouseView view = WarehouseView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new WarehousePresenter(view, _unitOfWork); ;
        }

        private void ShowCustomer(object? sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new CustomerPresenter(view, _unitOfWork);
        }
        private void ShowSalesOrder(object? sender, EventArgs e)
        {
            ISalesOrderView view = SalesOrderView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new SalesOrderPresenter(view, _unitOfWork);
        }
        private void ShowSettings(object? sender, EventArgs e)
        {
            ISalesSettingsView view = SalesSettingsView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new SalesSettingsPresenter(view, _unitOfWork);
        }
    }
}
