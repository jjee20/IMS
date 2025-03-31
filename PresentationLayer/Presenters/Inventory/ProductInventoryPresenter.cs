using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Presenters.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Inventory
{
    public class ProductInventoryPresenter
    {
        private IProductInventoryView _view;
        private IUnitOfWork _unitOfWork;
        public ProductInventoryPresenter(IProductInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowProductType += ShowProductType;
            _view.ShowUnitOfMeasure += ShowUnitOfMeasure;
            _view.ShowProduct += ShowProduct;
            _view.ShowStockIn += ShowStockIn;
            _view.ShowStockMonitoring += ShowStockMonitoring;
            ShowProduct(this, EventArgs.Empty);
        }

        private void ShowStockMonitoring(object? sender, EventArgs e)
        {
            IProductMonitoringView view = ProductMonitoringView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new ProductMonitoringPresenter(view, _unitOfWork);
        }

        private void ShowStockIn(object? sender, EventArgs e)
        {
            IProductStockInLogView view = ProductStockInLogView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new ProductStockInLogPresenter(view, _unitOfWork);
        }

        private void ShowProductType(object? sender, EventArgs e)
        {
            IProductTypeView view = ProductTypeView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new ProductTypePresenter(view, _unitOfWork);
        }
        private void ShowUnitOfMeasure(object? sender, EventArgs e)
        {
            IUnitOfMeasureView view = UnitOfMeasureView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new UnitOfMeasurePresenter(view, _unitOfWork);
        }
        private void ShowProduct(object? sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance((TabPage)_view.Guna2TabControlPage);
            new ProductPresenter(view, _unitOfWork);
        }
    }
}
