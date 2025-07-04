using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using static ServiceLayer.Services.CommonServices.EventClasses;

namespace RavenTech_ERP.Presenters.Inventory
{
    public class ProductMonitoringPresenter
    {
        public IProductMonitoringView _view;
        private readonly IUnitOfWork _unitOfWork;
        
        private IEnumerable<StockViewModel> InStockList;
        private IEnumerable<StockViewModel> LowStockList;
        private IEnumerable<StockViewModel> OutOfStockList;
        private IEnumerable<ProjectFlowViewModel> ProjectFlowList;
        private BindingSource InStockBindingSource;
        private BindingSource LowStockBindingSource;
        private BindingSource OutOfStockBindingSource;
        private BindingSource ProjectFlowBindingSource;
        private readonly GunaBarDataset InStockTrendDataSet = new();
        private readonly GunaBarDataset PullOutStockTrendDataSet = new();
        private readonly GunaBarDataset LowStockTrendDataSet = new();
        private readonly GunaBarDataset OutOfStockTrendDataSet = new();
        public ProductMonitoringPresenter(IProductMonitoringView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            InStockBindingSource = new BindingSource();
            LowStockBindingSource = new BindingSource();
            OutOfStockBindingSource = new BindingSource();
            ProjectFlowBindingSource = new BindingSource();

            _view.PrintEvent += Print;
            _view.SearchEvent += Search;
            _view.RefreshEvent += Refresh;


            _view.SetInStockListBindingSource(InStockBindingSource);
            _view.SetLowStockListBindingSource(LowStockBindingSource);
            _view.SetOutOfStockListBindingSource(OutOfStockBindingSource);
            _view.SetProjectFlowListBindingSource(ProjectFlowBindingSource);
            _view.SetTrendsBindingSource(InStockTrendDataSet, PullOutStockTrendDataSet, LowStockTrendDataSet, OutOfStockTrendDataSet);  
            RefreshView();
        }

        private void Refresh(object? sender, EventArgs e) => RefreshView();

        private async void RefreshView()
        {
            await LoadInStock();
            await LoadLowStock();
            await LoadOutOfStock();
            await LoadProjectFlow();
            await LoadTrends();
        }

        private async Task LoadTrends()
        {
            var currentStocks = await GetProductCurrentStocks(true); // true = no search filter

            // Clear old data
            InStockTrendDataSet.DataPoints.Clear();
            PullOutStockTrendDataSet.DataPoints.Clear();
            LowStockTrendDataSet.DataPoints.Clear();
            OutOfStockTrendDataSet.DataPoints.Clear();

            // Combine all unique product names
            var allProductNames = currentStocks
                .Select(cs => cs.product.ProductName)
                .Union(LowStockList.Select(p => p.Product))
                .Union(OutOfStockList.Select(p => p.Product))
                .Distinct()
                .ToList();

            foreach (var productName in allProductNames)
            {
                double inStockQty = InStockList.FirstOrDefault(p => p.Product == productName)?.Qty ?? 0;
                double pullOutQty = ProjectFlowList.FirstOrDefault(p => p.Product == productName)?.Qty ?? 0;
                double lowStockQty = LowStockList.FirstOrDefault(p => p.Product == productName)?.Qty ?? 0;
                double outOfStockQty = OutOfStockList.FirstOrDefault(p => p.Product == productName)?.Qty ?? 0;

                InStockTrendDataSet.Label = "In Stock";
                InStockTrendDataSet.FillColors.Add(Color.Green);
                InStockTrendDataSet.DataPoints.Add(productName, Math.Round(inStockQty, 2));
                PullOutStockTrendDataSet.Label = "Pulled Out";
                PullOutStockTrendDataSet.FillColors.Add(Color.Blue);
                PullOutStockTrendDataSet.DataPoints.Add(productName, Math.Round(pullOutQty, 2));
                LowStockTrendDataSet.Label = "Low Stock";
                LowStockTrendDataSet.FillColors.Add(Color.Orange);
                LowStockTrendDataSet.DataPoints.Add(productName, Math.Round(lowStockQty, 2));
                OutOfStockTrendDataSet.Label = "Out of Stock";
                OutOfStockTrendDataSet.FillColors.Add(Color.Crimson);
                OutOfStockTrendDataSet.DataPoints.Add(productName, Math.Round(outOfStockQty, 2));
            }

        }


        private async Task LoadProjectFlow()
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
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

        private async Task LoadOutOfStock()
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
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
        private async Task LoadLowStock()
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
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

        private async Task LoadInStock()
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            var currentStocks = await GetProductCurrentStocks(emptyValue);

            InStockList = currentStocks
                .Where(x => x.stockQty > 0)
                .GroupBy(x => x.product.ProductName)
                .Select(g => new StockViewModel
                {
                    Product = g.Key,
                    Qty = g.Sum(x => x.stockQty)
                })
                .Where(vm => string.IsNullOrEmpty(_view.SearchValue) || vm.Product.ToLower().Contains(_view.SearchValue.ToLower()))
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
                    stockIn.TryGetValue(id, out var stockQtyIn);
                    pullOut.TryGetValue(id, out var stockQtyOut);
                    return (product, stockQtyIn - stockQtyOut);
                })
                .Where(x => x.product != null)
                .ToList();

            return currentStocks;
        }
    }
}
