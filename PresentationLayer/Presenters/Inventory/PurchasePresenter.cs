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
    public class PurchasePresenter
    {
        private IPurchaseView _view;
        private IUnitOfWork _unitOfWork;
        public PurchasePresenter(IPurchaseView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowPurchaseOrder += ShowPurchaseOrder;
            _view.ShowSettings += ShowSettings;
            _view.ShowVendor += ShowVendor;
            ShowPurchaseOrder(this, EventArgs.Empty);
        }

        private void ShowVendor(object? sender, EventArgs e)
        {
            IVendorView view = VendorView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new VendorPresenter(view, _unitOfWork);
        }

        private void ShowPurchaseOrder(object? sender, EventArgs e)
        {
            IPurchaseOrderView view = PurchaseOrderView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new PurchaseOrderPresenter(view, _unitOfWork);
        }
        private void ShowSettings(object? sender, EventArgs e)
        {
            IPurchaseSettingsView view = PurchaseSettingsView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new PurchaseSettingsPresenter(view, _unitOfWork);
        }
    }
}
