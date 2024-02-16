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
        public InventoryPresenter(IInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowCustomerType += ShowCustomerType;
            _view.ShowCustomer += ShowCustomer;
        }

        private void ShowCustomer(object? sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance((TabPage)_view.TabControlPage);
            new CustomerPresenter(view, _unitOfWork);
        }

        private void ShowCustomerType(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance((TabPage)_view.TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
    }
}
