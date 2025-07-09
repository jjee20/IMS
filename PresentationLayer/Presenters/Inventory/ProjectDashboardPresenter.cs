using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ServiceLayer.Services.CommonServices.EventClasses;

// Domain/Service/Presentation imports omitted for brevity...

namespace PresentationLayer.Presenters
{
    public class ProjectDashboardPresenter
    {
        private readonly IProjectDashboardView _view;
        private readonly IUnitOfWork _unitOfWork;
        

        // Chart datasets and binding sources
        private readonly GunaHorizontalBarDataset TopUsedDataSet = new();
        private readonly GunaHorizontalBarDataset TopProjectsDataSet = new();
        private readonly GunaBarDataset InventoryStatusDataSet = new();
        private readonly GunaLineDataset DailyTrendDataSet = new();
        private readonly GunaBarDataset MonthlyRevenueTrendDataset = new();
        private readonly GunaBarDataset MonthlyExpenseTrendDataset = new();
        private readonly GunaDoughnutDataset ProjectDataSet = new();
        private readonly BindingSource MonthBindingSource = new();
        private readonly BindingSource YearBindingSource = new();

        private int ItemSold, Sales;
        private IEnumerable<EnumItemViewModel> YearList, MonthList;

        public ProjectDashboardPresenter(IProjectDashboardView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            // Event subscriptions
            _view.UpdateProjectDashboardEvent -= UpdateProjectDashboard;
            _view.RefreshEvent -= Refresh;
            _view.UpdateProjectDashboardEvent += UpdateProjectDashboard;
            _view.RefreshEvent += Refresh;

            // Initial loads and UI bindings
            RefreshEvent();
            _view.SetMonth(MonthBindingSource);
            _view.SetYear(YearBindingSource);
            _view.SetTopUsed(TopUsedDataSet);
            _view.SetTopProjects(TopProjectsDataSet);
            _view.SetDailyTrend(DailyTrendDataSet);
            _view.SetMonthlyTrend(MonthlyRevenueTrendDataset, MonthlyExpenseTrendDataset);
            _view.SetInventoryStatus(InventoryStatusDataSet);
            _view.SetProjectExpenseDistribution(ProjectDataSet);
        }

        private void Refresh(object? sender, EventArgs e) => RefreshEvent();

        private async void UpdateProjectDashboard(object? sender, EventArgs e)
        {
            await LoadDailyTrend(_view.Year, _view.Month);
            await LoadMonthlyTrend(_view.Year);
        }

        private async void RefreshEvent()
        {
            LoadYears();
            LoadMonths();
            await LoadPanelHeader(_view.Year);
            await LoadTopUsedItems(_view.Year);
            await LoadTopProjects(_view.Year);
            await LoadProjectExpenseDistribution(_view.Year);
            await LoadDailyTrend();
            await LoadMonthlyTrend();
            await LoadInventoryStatus();
        }

        private void LoadMonths()
        {
            MonthList = Enumerable.Range(1, 12)
                .Select(m => new EnumItemViewModel { Id = m, Name = new DateTime(1, m, 1).ToString("MMMM") })
                .ToList();
            MonthBindingSource.DataSource = MonthList;
        }

        private void LoadYears()
        {
            int currentYear = DateTime.Now.Year;
            YearList = Enumerable.Range(currentYear - 5, 6)
                .Select(y => new EnumItemViewModel { Id = y, Name = y.ToString() })
                .OrderByDescending(c => c.Name)
                .ToList();
            YearBindingSource.DataSource = YearList;
        }

        private async Task LoadPanelHeader(int? year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var today = DateTime.Now;
            var currentDate = year == 0 ? today : new DateTime(year.Value, today.Month, today.Day);



            // Fetch sales and purchase data
            var projects = await _unitOfWork.Project.Value.GetAllAsync(
                c => c.StartDate.Value.Year == year, includeProperties: "ProjectLines.Product");
            var pullouts = await _unitOfWork.ProductPullOutLogs.Value.GetAllAsync(
                c => c.DeliveredDate.Value.Year == year, includeProperties: "ProductPullOutLogLines.Product");

            var totalRevenue = projects.Sum(line => line.Revenue);
            var totalExpense = pullouts.SelectMany(o => o.ProductPullOutLogLines).Sum(line => line.StockQuantity * line.Product.DefaultBuyingPrice);
            var totalProfit = totalRevenue - totalExpense;
            // Update View
            _view.TotalRevenue = totalRevenue?.ToString("C2");
            _view.TotalProfit = totalProfit?.ToString("C2");
            _view.TotalExpense = totalExpense.ToString("C2");   
        }

        private async Task LoadTopUsedItems(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var pulloutItems = await _unitOfWork.ProductPullOutLogLines.Value.GetAllAsync(
                c => c.ProductPullOutLogs.DeliveredDate.Value.Year == year, includeProperties: "ProductPullOutLogs,Product");

            var topSellingItems = pulloutItems
                .GroupBy(c => c.Product.ProductName)
                .Select(g => new { ProductName = g.Key, Quantity = g.Sum(c => c.StockQuantity) })
                .OrderByDescending(c => c.Quantity)
                .Take(5)
                .ToList();

            TopUsedDataSet.Label = "Product";
            TopUsedDataSet.DataPoints.Clear();
            foreach (var item in topSellingItems)
                TopUsedDataSet.DataPoints.Add(item.ProductName, item.Quantity);
        }

        private async Task LoadTopProjects(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var projects = await _unitOfWork.Project.Value.GetAllAsync(
                c => c.StartDate.Value.Year == year, includeProperties: "ProjectLines");

            var topProjects = projects
                .Select(g => new { g.ProjectName, Revenue = g.Budget })
                .OrderByDescending(c => c.Revenue)
                .Take(5)
                .ToList();

            TopProjectsDataSet.Label = "Project";
            TopProjectsDataSet.DataPoints.Clear();
            foreach (var item in topProjects)
                TopProjectsDataSet.DataPoints.Add(item.ProjectName, (double)item.Revenue);
        }

        private async Task LoadProjectExpenseDistribution(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var projectList = await _unitOfWork.Project.Value.GetAllAsync(
                c => c.StartDate.HasValue && c.StartDate.Value.Year == year, includeProperties: "ProductPullOutLogs.ProductPullOutLogLines.Product");

            var projectExpenses = projectList
                .GroupBy(c => c.ProjectName)
                .Select(g => new ProjectExpenseDistributionViewModel
                {
                    Project = g.Key,
                    Amount = g.Sum(p => p.ProductPullOutLogs.SelectMany(c => c.ProductPullOutLogLines).Sum(pl => pl.StockQuantity * pl.Product.DefaultBuyingPrice))
                })
                .ToList();

            ProjectDataSet.Label = "Project";
            ProjectDataSet.DataPoints.Clear();
            foreach (var item in projectExpenses)
                ProjectDataSet.DataPoints.Add(item.Project, item.Amount);
        }

        private async Task LoadInventoryStatus()
        {
            var productsStockIn = await _unitOfWork.ProductStockInLogs.Value
                .GetAllAsync(includeProperties: "ProductStockInLogLines.Product");
            var productsPullOut = await _unitOfWork.ProductPullOutLogs.Value
                .GetAllAsync(includeProperties: "ProductPullOutLogLines.Product");

            var allStockIn = productsStockIn.SelectMany(log => log.ProductStockInLogLines)
                .Where(line => line.Product != null).ToList();
            var allPullOut = productsPullOut.SelectMany(log => log.ProductPullOutLogLines)
                .Where(line => line.Product != null).ToList();

            var groupedStockIn = allStockIn.GroupBy(l => l.Product.ProductId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.StockQuantity));
            var groupedPullOut = allPullOut.GroupBy(l => l.Product.ProductId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.StockQuantity));

            var productStocks = allStockIn.Select(line => line.Product).Distinct().Select(product =>
            {
                groupedStockIn.TryGetValue(product.ProductId, out var stockInQty);
                groupedPullOut.TryGetValue(product.ProductId, out var pullOutQty);
                int currentQty = (int)(stockInQty - pullOutQty);
                return new { Product = product, Quantity = currentQty };
            }).ToList();

            var totalQty = productStocks.Sum(p => p.Quantity);
            var totalPullOutQty = allPullOut.Sum(p => p.StockQuantity);
            var lowStockQty = productStocks.Count(p => p.Product.ReorderLevel > 0 && p.Quantity <= p.Product.ReorderLevel && p.Quantity > 0);
            var outOfStockQty = productStocks.Count(p => p.Quantity <= 0); 

            InventoryStatusDataSet.Label = "Qty";
            InventoryStatusDataSet.DataPoints.Clear();
            InventoryStatusDataSet.DataPoints.Add("Total Stock", totalQty);
            InventoryStatusDataSet.DataPoints.Add("Pulled Out", totalPullOutQty);
            InventoryStatusDataSet.DataPoints.Add("Low Stock (< ReorderLevel)", lowStockQty);
            InventoryStatusDataSet.DataPoints.Add("Out of Stock", outOfStockQty);
        }

        private async Task LoadDailyTrend(int? year = 0, int? month = 0)
        {
            var today = (year == 0 && month == 0) ? DateTime.Now : new DateTime(year.Value, month.Value, 1);
            int days = DateTime.DaysInMonth(today.Year, today.Month);
            var pullouts = await _unitOfWork.ProductPullOutLogLines.Value.GetAllAsync(includeProperties: "ProductPullOutLogs");

            DailyTrendDataSet.DataPoints.Clear();
            DailyTrendDataSet.Label = "Qty";
            for (int i = 1; i <= days; i++)
            {
                var date = new DateTime(today.Year, today.Month, i);
                var qty = pullouts.Where(c => c.ProductPullOutLogs.DeliveredDate.Value.Date == date.Date).Sum(c => c.StockQuantity);
                DailyTrendDataSet.DataPoints.Add(i.ToString(), qty);
            }
        }

        private async Task LoadMonthlyTrend(int? year = null)
        {
            // Use current year if not specified
            int actualYear = year ?? DateTime.Now.Year;

            var months = Enumerable.Range(1, 12).Select(i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)).ToList();

            MonthlyRevenueTrendDataset.DataPoints.Clear();
            MonthlyExpenseTrendDataset.DataPoints.Clear();
            MonthlyRevenueTrendDataset.Label = "Target Revenue";
            MonthlyExpenseTrendDataset.Label = "Expenses";
            MonthlyRevenueTrendDataset.FillColors.Clear();
            MonthlyExpenseTrendDataset.FillColors.Clear();

            // Fetch all projects and pullouts ONCE for the year
            var allProjects = (await _unitOfWork.Project.Value.GetAllAsync(
                c => c.StartDate.HasValue && c.StartDate.Value.Year == actualYear,
                includeProperties: "ProjectLines.Product"
            )).ToList();

            var allPullouts = (await _unitOfWork.ProductPullOutLogs.Value.GetAllAsync(
                c => c.DeliveredDate.HasValue && c.DeliveredDate.Value.Year == actualYear,
                includeProperties: "ProductPullOutLogLines.Product"
            )).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

                // Revenue for projects started this month
                var monthProjects = allProjects.Where(p => p.StartDate.Value.Month == i);
                var totalRevenue = monthProjects.Sum(p => p.Revenue ?? 0);

                // Expenses for pullouts delivered this month
                var monthPullouts = allPullouts.Where(p => p.DeliveredDate.Value.Month == i);
                var totalExpense = monthPullouts
                    .SelectMany(o => o.ProductPullOutLogLines)
                    .Sum(line => line.StockQuantity * (line.Product?.DefaultBuyingPrice ?? 0));

                MonthlyRevenueTrendDataset.DataPoints.Add(monthName, totalRevenue);
                MonthlyRevenueTrendDataset.FillColors.Add(Color.Blue);

                MonthlyExpenseTrendDataset.DataPoints.Add(monthName, totalExpense);
                MonthlyExpenseTrendDataset.FillColors.Add(Color.Red);
            }
        }

    }
}
