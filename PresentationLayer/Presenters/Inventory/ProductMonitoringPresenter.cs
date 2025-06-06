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

            _view.PrintEvent -= Print;
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
            var pullOuts = _unitOfWork.ProductPullOutLogs.Value.GetAll(includeProperties: "ProductPullOutLogLines.Product,Project");
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

            ProjectFlowBindingSource.DataSource = ProjectFlowList;
            _view.ProjectFlow = ProjectFlowList.Sum(c => c.Qty);
        }

        private void LoadOutOfStock()
        {
            var currentStocks = GetProductCurrentStocks();

            OutOfStockList = currentStocks
                .Where(x => x.stockQty <= 0)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = 0
                })
                .ToList();

            OutOfStockBindingSource.DataSource = OutOfStockList;
            _view.OutOfStock = OutOfStockList.Count();
        }
        private void LoadLowStock()
        {
            var currentStocks = GetProductCurrentStocks();

            LowStockList = currentStocks
                .Where(x => x.stockQty > 0 && x.stockQty <= x.product.ReorderLevel)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = g.Sum(x => x.stockQty)
                })
                .ToList();

            LowStockBindingSource.DataSource = LowStockList;
            _view.LowStock = LowStockList.Sum(c => c.Qty);
        }

        private void LoadInStock()
        {
            var currentStocks = GetProductCurrentStocks();

            InStockList = currentStocks
                .Where(x => x.stockQty > 0)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = g.Sum(x => x.stockQty)
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

        private List<(Product product, double stockQty)> GetProductCurrentStocks()
        {
            var stockInLogs = _unitOfWork.ProductStockInLogs.Value.GetAll(includeProperties: "ProductStockInLogLines.Product");
            var pullOutLogs = _unitOfWork.ProductPullOutLogs.Value.GetAll(includeProperties: "ProductPullOutLogLines.Product");

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
