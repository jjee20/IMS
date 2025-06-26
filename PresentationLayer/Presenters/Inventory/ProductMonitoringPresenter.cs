using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceLayer.Services.CommonServices.EventClasses;

namespace RavenTech_ERP.Presenters.Inventory
{
    public class ProductMonitoringPresenter
    {
        public IProductMonitoringView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<StockViewModel> InStockList;
        private IEnumerable<StockViewModel> LowStockList;
        private IEnumerable<StockViewModel> OutOfStockList;
        private IEnumerable<ProjectFlowViewModel> ProjectFlowList;
        private BindingSource InStockBindingSource;
        private BindingSource LowStockBindingSource;
        private BindingSource OutOfStockBindingSource;
        private BindingSource ProjectFlowBindingSource;
        public ProductMonitoringPresenter(IProductMonitoringView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _eventAggregator = eventAggregator;
            InStockBindingSource = new BindingSource();
            LowStockBindingSource = new BindingSource();
            OutOfStockBindingSource = new BindingSource();
            ProjectFlowBindingSource = new BindingSource();

            _view.PrintEvent -= Print;
            _view.SearchEvent += Search;


            _view.SetInStockListBindingSource(InStockBindingSource);
            _view.SetLowStockListBindingSource(LowStockBindingSource);
            _view.SetOutOfStockListBindingSource(OutOfStockBindingSource);
            _view.SetProjectFlowListBindingSource(ProjectFlowBindingSource);
            RefreshView();
            _eventAggregator.Subscribe<InventoryCompletedEvent>(RefreshView);
        }

        private void RefreshView()
        {
            LoadInStock();
            LoadLowStock();
            LoadOutOfStock();
            LoadProjectFlow();
        }

        private async void LoadProjectFlow()
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            var pullOuts = await _unitOfWork.ProductPullOutLogs.Value.GetAllAsync(includeProperties: "ProductPullOutLogLines.Product,Project");
            ProjectFlowList = pullOuts
                .SelectMany(p => p.ProductPullOutLogLines)
                .Where(p => p.Product != null && p.ProductPullOutLogs != null && p.ProductPullOutLogs.Project != null)
                .GroupBy(p => new
                {
                    ProjectId = p.ProductPullOutLogs.Project.ProjectId,
                    ProductName = p.Product.ProductName,
                    ProjectName = p.ProductPullOutLogs.Project.ProjectName
                })
                .Select(g => new ProjectFlowViewModel
                {
                    Product = g.Key.ProductName,
                    Project = g.Key.ProjectName,
                    Qty = g.Sum(x => x.StockQuantity)
                })
                .ToList();

            if(!emptyValue)
            {
                ProjectFlowList = ProjectFlowList
                    .Where(c => c.Product.ToLower().Contains(_view.SearchValue.ToLower()) || c.Project.ToLower().Contains(_view.SearchValue.ToLower()));
            }

            ProjectFlowBindingSource.DataSource = ProjectFlowList.ToList();
            _view.ProjectFlow = ProjectFlowList.Sum(c => c.Qty);
        }

        private async void LoadOutOfStock()
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            var currentStocks = await GetProductCurrentStocks(emptyValue);

            OutOfStockList = currentStocks
                .Where(x => x.stockQty <= 0)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = 0
                })
                .ToList();

            OutOfStockBindingSource.DataSource = OutOfStockList.ToList();
            _view.OutOfStock = OutOfStockList.Count();
        }
        private async void LoadLowStock()
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            var currentStocks = await GetProductCurrentStocks(emptyValue);

            LowStockList = currentStocks
                .Where(x => x.stockQty > 0 && x.stockQty <= x.product.ReorderLevel)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = g.Sum(x => x.stockQty)
                })
                .ToList();

            LowStockBindingSource.DataSource = LowStockList.ToList();
            _view.LowStock = LowStockList.Sum(c => c.Qty);
        }

        private async void LoadInStock()
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            var currentStocks = await GetProductCurrentStocks(emptyValue);

            InStockList = currentStocks
                .Where(x => x.stockQty > 0)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = g.Sum(x => x.stockQty)
                })
                .ToList();

            InStockBindingSource.DataSource = InStockList.ToList();
            _view.InStock = InStockList.Sum(c => c.Qty);
        }

        private void Print(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Search(object? sender, EventArgs e)
        {
            RefreshView();
        }

        private async Task<List<(Product product, double stockQty)>> GetProductCurrentStocks(bool emptyValue)
        {
            var stockInLogs = await _unitOfWork.ProductStockInLogs.Value.GetAllAsync(includeProperties: "ProductStockInLogLines.Product");
            var pullOutLogs = await _unitOfWork.ProductPullOutLogs.Value.GetAllAsync(includeProperties: "ProductPullOutLogLines.Product");

            var stockIn = stockInLogs
                .SelectMany(log => log.ProductStockInLogLines)
                .Where(l => l.Product != null)
                .GroupBy(l => l.Product.ProductId)
                .ToDictionary(g => g.Key, g => g.Sum(l => l.StockQuantity));

            var pullOut = pullOutLogs
                .SelectMany(log => log.ProductPullOutLogLines)
                .Where(l => l.Product != null)
                .GroupBy(l => l.Product.ProductId)
                .ToDictionary(g => g.Key, g => g.Sum(l => l.StockQuantity));

            var allProducts = stockIn.Keys.Union(pullOut.Keys);

            var currentStocks = allProducts
                .Select(id =>
                {
                    var product = stockInLogs.SelectMany(l => l.ProductStockInLogLines)
                                             .FirstOrDefault(p => p.Product.ProductId == id)?.Product;
                    stockIn.TryGetValue(id, out double stockQtyIn);
                    pullOut.TryGetValue(id, out double stockQtyOut);
                    return (product, stockQtyIn - stockQtyOut);
                })
                .Where(x => x.product != null)
                .ToList();

            return currentStocks;
        }
    }
}
