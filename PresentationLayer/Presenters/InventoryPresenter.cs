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
        public InventoryPresenter(IInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowCustomerType += ShowCustomerType;
            //var customerTypeView = new CustomerTypeView();
            //_customerTypePresenter = new CustomerTypePresenter(customerTypeView, unitOfWork);
        }

        private void ShowCustomerType(object? sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstance((TabPage)_view.TabControlPage);
            new CustomerTypePresenter(view, _unitOfWork);
        }
    }
}
