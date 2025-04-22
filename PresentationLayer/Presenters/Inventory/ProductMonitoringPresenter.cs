using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters.Inventory
{
    public class ProductMonitoringPresenter
    {
        public IProductMonitoringView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<StockViewModel> InStockList;
        private IEnumerable<StockViewModel> LowStockList;
        private IEnumerable<StockViewModel> OutOfStockList;
        private IEnumerable<ProjectFlowViewModel> ProjectFlowList;
        private BindingSource InStockBindingSource;
        private BindingSource LowStockBindingSource;
        private BindingSource OutOfStockBindingSource;
        private BindingSource ProjectFlowBindingSource;
        public ProductMonitoringPresenter(IProductMonitoringView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            InStockBindingSource = new BindingSource();
            LowStockBindingSource = new BindingSource();
            OutOfStockBindingSource = new BindingSource();
            ProjectFlowBindingSource = new BindingSource();

            _view.PrintEvent += Print;

            LoadInStock();
            LoadLowStock();
            LoadOutOfStock();
            LoadProjectFlow();

            _view.SetInStockListBindingSource(InStockBindingSource);
            _view.SetLowStockListBindingSource(LowStockBindingSource);
            _view.SetOutOfStockListBindingSource(OutOfStockBindingSource);
            _view.SetProjectFlowListBindingSource(ProjectFlowBindingSource);
        }

        private void LoadProjectFlow()
        {
            ProjectFlowList = _unitOfWork.ProjectLine.Value.GetAll(includeProperties: "Project")
                .GroupBy(p => new
                {
                    p.ProjectId,
                    ProductName = p.Product?.ProductName ?? p.ProductName // Fallback if navigation is null
                })
               .Select(g => new ProjectFlowViewModel
               {
                   Product = g.Key.ProductName,
                   Qty = g.Sum(c => c.Quantity),
                   Project = g.FirstOrDefault()?.Project?.ProjectName ?? "Unknown"
               })
               .ToList();
            ProjectFlowBindingSource.DataSource = ProjectFlowList;
            _view.ProjectFlow = ProjectFlowList.Sum(c => c.Qty);
        }

        private void LoadOutOfStock()
        {
            OutOfStockList = _unitOfWork.Product.Value.GetAll(includeProperties: "ProductStockInLogs")
               .Where(p => p.ProductStockInLogs.Sum(c => c.StockQuantity) == 0) // Ensure total stock is 0
               .GroupBy(p => p.ProductName)
               .Select(g => new StockViewModel
               {
                   Product = g.Key,
                   Qty = g.Sum(p => p.ProductStockInLogs.Sum(c => c.StockQuantity))
               })
               .ToList();
            OutOfStockBindingSource.DataSource = OutOfStockList;
            _view.OutOfStock = OutOfStockList.Sum(c => c.Qty);
        }

        private void LoadLowStock()
        {
            LowStockList = _unitOfWork.Product.Value.GetAll(includeProperties: "ProductStockInLogs")
               .Where(p => p.ProductStockInLogs.Sum(c => c.StockQuantity) <= p.ReorderLevel && p.ProductStockInLogs.Sum(c => c.StockQuantity) != 0) // Ensure total stock is 0
               .GroupBy(p => p.ProductName)
               .Select(g => new StockViewModel
               {
                   Product = g.Key,
                   Qty = g.Sum(p => p.ProductStockInLogs.Sum(c => c.StockQuantity)) // Fix the Sum logic
               })
               .ToList();
            LowStockBindingSource.DataSource = LowStockList;

            _view.LowStock = LowStockList.Sum(c => c.Qty);
        }

        private void LoadInStock()
        {
            InStockList = _unitOfWork.Product.Value.GetAll(includeProperties: "ProductStockInLogs")
               .GroupBy(p => p.ProductName)
               .Select(g => new StockViewModel
               {
                   Product = g.Key,
                   Qty = g.Sum(p => p.ProductStockInLogs.Sum(c => c.StockQuantity)) // Fix the Sum logic
               })
               .ToList();
            InStockBindingSource.DataSource = InStockList;
            _view.InStock = InStockList.Sum(c => c.Qty);
        }

        private void Print(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Search(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
