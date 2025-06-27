using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Guna.Charts.WinForms;
using PresentationLayer.Views.IViews.Inventory;
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
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly IUnitOfWork _unitOfWork;
        

        // Chart datasets and binding sources
        private readonly GunaHorizontalBarDataset TopSellingDataSet = new();
        private readonly GunaBarDataset InventoryStatusDataSet = new();
        private readonly GunaLineDataset DailySalesTrendDataSet = new();
        private readonly GunaBarDataset MonthlySalesTrendDataset = new();
        private readonly GunaBarDataset MonthlyExpenseTrendDataset = new();
        private readonly GunaDoughnutDataset ProjectDataSet = new();
        private readonly BindingSource MonthBindingSource = new();
        private readonly BindingSource YearBindingSource = new();

        private int ItemSold, Sales;
        private IEnumerable<EnumItemViewModel> YearList, MonthList;

        public DashboardPresenter(IDashboardView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            // Event subscriptions
            _view.UpdateDashboardEvent -= UpdateDashboard;
            _view.RefreshEvent -= Refresh;
            _view.UpdateDashboardEvent += UpdateDashboard;
            _view.RefreshEvent += Refresh;

            // Initial loads and UI bindings
            RefreshEvent();
            _view.SetMonth(MonthBindingSource);
            _view.SetYear(YearBindingSource);
            _view.SetTopSelling(TopSellingDataSet);
            _view.SetDailySalesTrend(DailySalesTrendDataSet);
            _view.SetMonthlySalesTrend(MonthlySalesTrendDataset, MonthlyExpenseTrendDataset);
            _view.SetInventoryStatus(InventoryStatusDataSet);
            _view.SetProjectExpenseDistribution(ProjectDataSet);
            _view.SetProgressBars(ItemSold, Sales);
        }

        private void Refresh(object? sender, EventArgs e) => RefreshEvent();

        private async void UpdateDashboard(object? sender, EventArgs e)
        {
            await LoadDailySalesTrend(_view.Year, _view.Month);
            await LoadMonthlySalesTrend(_view.Year);
        }

        private async void RefreshEvent()
        {
            LoadYears();
            LoadMonths();
            await LoadPanelHeader(_view.Year);
            await LoadTopSellingItems(_view.Year);
            await LoadProjectExpenseDistribution(_view.Year);
            await LoadDailySalesTrend();
            await LoadMonthlySalesTrend();
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
            var salesOrders = await _unitOfWork.SalesOrder.Value.GetAllAsync(
                c => c.OrderDate.Year == year, includeProperties: "SalesOrderLines.Product");
            var purchaseOrders = await _unitOfWork.PurchaseOrder.Value.GetAllAsync(
                c => c.OrderDate.Year == year, includeProperties: "PurchaseOrderLines.Product");

            var sales = salesOrders.SelectMany(o => o.SalesOrderLines).Sum(line => line.SubTotal);
            var gross = salesOrders.SelectMany(o => o.SalesOrderLines).Sum(line => line.Product.DefaultBuyingPrice * line.Quantity);
            var expense = purchaseOrders.SelectMany(o => o.PurchaseOrderLines).Sum(line => line.SubTotal);

            var targetGoals = await _unitOfWork.TargetGoals.Value.GetAllAsync();
            var expenseTarget = targetGoals.FirstOrDefault() ?? new TargetGoals { MonthlySales = 0, MonthlyItemSold = 0 };

            // Daily metrics
            var salesToday = salesOrders
                .Where(c => c.OrderDate.Date == currentDate)
                .SelectMany(o => o.SalesOrderLines)
                .Sum(line => line.SubTotal);

            var itemsSoldToday = salesOrders
                .Where(c => c.OrderDate.Date == currentDate)
                .SelectMany(o => o.SalesOrderLines)
                .Sum(line => line.Quantity);

            var expenseToday = purchaseOrders
                .Where(c => c.OrderDate.Date == currentDate)
                .SelectMany(o => o.PurchaseOrderLines)
                .Sum(line => line.SubTotal);

            // Update View
            _view.Sales = sales.ToString("N2");
            _view.Gross = gross.ToString("N2");
            _view.Expense = expense.ToString("N2");
            _view.SalesToday = salesToday.ToString("N2");
            _view.ExpenseToday = expenseToday.ToString("N2");
            _view.TotalProfit = salesToday - expenseToday;
            _view.ItemSoldToday = itemsSoldToday.ToString("N0");
            _view.ExpenseTodaySales = salesToday;
            _view.ExpenseTodaySalesTarget = expenseTarget.MonthlySales;
            _view.ExpenseTodayItemsSold = itemsSoldToday;
            _view.ExpenseTodayItemsSoldTarget = expenseTarget.MonthlyItemSold;
            _view.TotalExpense = expenseToday;

            Sales = expenseTarget.MonthlySales > 0 ? (int)(salesToday / expenseTarget.MonthlySales * 100) : 0;
            ItemSold = expenseTarget.MonthlyItemSold > 0 ? (int)(itemsSoldToday / expenseTarget.MonthlyItemSold * 100) : 0;
        }

        private async Task LoadTopSellingItems(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var salesLines = await _unitOfWork.SalesOrderLine.Value.GetAllAsync(
                c => c.SalesOrder.OrderDate.Year == year, includeProperties: "Product,SalesOrder");

            var topSellingItems = salesLines
                .GroupBy(c => c.Product.ProductName)
                .Select(g => new { ProductName = g.Key, Quantity = g.Sum(c => c.Quantity) })
                .OrderByDescending(c => c.Quantity)
                .Take(5)
                .ToList();

            TopSellingDataSet.Label = "Product";
            TopSellingDataSet.DataPoints.Clear();
            foreach (var item in topSellingItems)
                TopSellingDataSet.DataPoints.Add(item.ProductName, item.Quantity);
        }

        private async Task LoadProjectExpenseDistribution(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var projectList = await _unitOfWork.Project.Value.GetAllAsync(
                c => c.StartDate.HasValue && c.StartDate.Value.Year == year, includeProperties: "ProjectLines");

            var projectExpenses = projectList
                .GroupBy(c => c.ProjectName)
                .Select(g => new ProjectExpenseDistributionViewModel
                {
                    Project = g.Key,
                    Amount = g.Sum(p => p.ProjectLines.Sum(pl => pl.SubTotal))
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
            var lowStockQty = productStocks.Count(p => p.Product.ReorderLevel > 0 && p.Quantity <= p.Product.ReorderLevel && p.Quantity > 0);
            var outOfStockQty = productStocks.Count(p => p.Quantity <= 0);

            InventoryStatusDataSet.Label = "Qty";
            InventoryStatusDataSet.DataPoints.Clear();
            InventoryStatusDataSet.DataPoints.Add("Total Stock", totalQty);
            InventoryStatusDataSet.DataPoints.Add("Low Stock (< ReorderLevel)", lowStockQty);
            InventoryStatusDataSet.DataPoints.Add("Out of Stock", outOfStockQty);
        }

        private async Task LoadDailySalesTrend(int? year = 0, int? month = 0)
        {
            var today = (year == 0 && month == 0) ? DateTime.Now : new DateTime(year.Value, month.Value, 1);
            int days = DateTime.DaysInMonth(today.Year, today.Month);
            var sales = await _unitOfWork.SalesOrderLine.Value.GetAllAsync(includeProperties: "SalesOrder");

            DailySalesTrendDataSet.DataPoints.Clear();
            DailySalesTrendDataSet.Label = "Qty";
            for (int i = 1; i <= days; i++)
            {
                var date = new DateTime(today.Year, today.Month, i);
                var qty = sales.Where(c => c.SalesOrder.OrderDate.Date == date.Date).Sum(c => c.Quantity);
                DailySalesTrendDataSet.DataPoints.Add(i.ToString(), qty);
            }
        }

        private async Task LoadMonthlySalesTrend(int? year = 0)
        {
            var date = year == 0 ? DateTime.Now : new DateTime(year.Value, 1, 1);
            var months = Enumerable.Range(1, 12).Select(i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)).ToList();

            MonthlySalesTrendDataset.DataPoints.Clear();
            MonthlyExpenseTrendDataset.DataPoints.Clear();

            foreach (var m in months)
            {
                int monthNumber = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, m) + 1;

                var salesOrders = await _unitOfWork.SalesOrder.Value.GetAllAsync(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year, includeProperties: "SalesOrderLines");
                var sales = salesOrders.SelectMany(o => o.SalesOrderLines).Sum(line => line.Quantity);

                var purchaseOrders = await _unitOfWork.PurchaseOrder.Value.GetAllAsync(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year, includeProperties: "PurchaseOrderLines");
                var purchase = purchaseOrders.SelectMany(o => o.PurchaseOrderLines).Sum(line => line.Quantity);

                MonthlySalesTrendDataset.Label = "Sales";
                MonthlySalesTrendDataset.DataPoints.Add(m, sales);
                MonthlySalesTrendDataset.FillColors.Add(Color.Blue);

                MonthlyExpenseTrendDataset.Label = "Expenses";
                MonthlyExpenseTrendDataset.DataPoints.Add(m, purchase);
                MonthlyExpenseTrendDataset.FillColors.Add(Color.Red);
            }
        }
    }
}
