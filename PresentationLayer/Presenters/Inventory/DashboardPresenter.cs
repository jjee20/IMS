using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class DashboardPresenter
    {
        private IDashboardView _view;
        private IUnitOfWork _unitOfWork;
        private GunaHorizontalBarDataset TopSellingDataSet;
        private GunaBarDataset InventoryStatusDataSet;
        private GunaLineDataset DailySalesTrendDataSet;
        private GunaBarDataset MonthlySalesTrendDataset;
        private GunaBarDataset MonthlyExpenseTrendDataset;
        private GunaDoughnutDataset ProjectDataSet;
        private BindingSource MonthBindingSource;
        private BindingSource YearBindingSource;
        private IEnumerable<EnumItemViewModel> YearList;
        private IEnumerable<EnumItemViewModel> MonthList;
        private int ItemSold;
        private int Sales;
        public DashboardPresenter(IDashboardView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            TopSellingDataSet = new GunaHorizontalBarDataset();
            DailySalesTrendDataSet = new GunaLineDataset();
            InventoryStatusDataSet = new GunaBarDataset();
            MonthlySalesTrendDataset = new GunaBarDataset();
            MonthlyExpenseTrendDataset = new GunaBarDataset();
            ProjectDataSet = new GunaDoughnutDataset();
            YearBindingSource = new BindingSource();
            MonthBindingSource = new BindingSource();

            _view.UpdateDashboardEvent += UpdateDashboard;

            LoadAll();

            _view.SetMonth(MonthBindingSource);
            _view.SetYear(YearBindingSource);
            _view.SetTopSelling(TopSellingDataSet);
            _view.SetDailySalesTrend(DailySalesTrendDataSet);
            _view.SetMonthlySalesTrend(MonthlySalesTrendDataset, MonthlyExpenseTrendDataset);
            _view.SetInventoryStatus(InventoryStatusDataSet);
            _view.SetProjectExpenseDistribution(ProjectDataSet);
            _view.SetProgressBars(ItemSold, Sales);

        }

        private void UpdateDashboard(object? sender, EventArgs e)
        {
            LoadDailySalesTrend(_view.Year, _view.Month);
            LoadMonthlySalesTrend(_view.Year);
        }

        private void LoadAll()
        {
            var currentDate = DateTime.Now;

            LoadYears();
            LoadMonths();

            LoadPanelHeader(_view.Year);
            LoadTopSellingItems(_view.Year);
            LoadProjectExpenseDistribution(_view.Year);
            LoadDailySalesTrend();
            LoadMonthlySalesTrend();
            LoadInventoryStatus();
        }
        private void LoadPanelHeader(int? year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var today = DateTime.Now;
            var newToday = year == 0 ? DateTime.Now : new DateTime(year.Value, today.Month, today.Day);
            var salesOrder = _unitOfWork.SalesOrder.Value.GetAll(c => c.OrderDate.Year == year, includeProperties: "SalesOrderLines.Product");
            var purchaseOrder = _unitOfWork.PurchaseOrder.Value.GetAll(c => c.OrderDate.Year == year, includeProperties: "PurchaseOrderLines.Product");

            var sales = salesOrder.Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.Sales = sales.ToString("N2");
            var gross = salesOrder.Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.Product.DefaultBuyingPrice * c.Quantity));
            _view.Gross = gross.ToString("N2");

            var expense = purchaseOrder.Select(c => c.PurchaseOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.Expense = expense.ToString("N2");

            var expenseTarget = _unitOfWork.TargetGoals.Value.GetAll().FirstOrDefault();

            if(expenseTarget == null)
            {
                expenseTarget = new TargetGoals
                {
                    MonthlySales = 0,
                    MonthlyItemSold = 0
                };
            }

            var salesToday = salesOrder.Where(c => c.OrderDate.Date == newToday)
                .Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.SalesToday = salesToday.ToString("N2");
            _view.ExpenseTodaySales = salesToday;
            _view.ExpenseTodaySalesTarget = expenseTarget.MonthlySales;

            Sales = (int)(salesToday / expenseTarget.MonthlySales * 100);

            var itemsSoldToday = salesOrder.Where(c => c.OrderDate.Date == newToday)
                .Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.Quantity));
            _view.ItemSoldToday = itemsSoldToday.ToString("N0");
            _view.ExpenseTodayItemsSold = itemsSoldToday;
            _view.ExpenseTodayItemsSoldTarget = expenseTarget.MonthlyItemSold;

            ItemSold = (int)(itemsSoldToday / expenseTarget.MonthlyItemSold * 100);

            var expenseToday = purchaseOrder.Where(c => c.OrderDate.Date == newToday)
                .Select(c => c.PurchaseOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.ExpenseToday = expenseToday.ToString("N2");
            _view.TotalExpense = expenseToday;

            _view.TotalProfit = salesToday - expenseToday;
        }

        private void LoadMonths()
        {
            MonthList = Enumerable.Range(1, 12)
               .Select(m => new EnumItemViewModel
               {
                   Id = m,
                   Name = new DateTime(1, m, 1).ToString("MMMM") // Get month name
               })
               .ToList();

            // Bind Lists to BindingSources
            MonthBindingSource.DataSource = MonthList;
        }

        private void LoadYears()
        {
            // Generate Year List (e.g., 2000 - Current Year + 5)
            int currentYear = DateTime.Now.Year;
            YearList = Enumerable.Range(currentYear - 5, 6) // 20 years back, 5 years ahead
                .Select(y => new EnumItemViewModel
                {
                    Id = y,
                    Name = y.ToString()
                })
                .ToList();
            YearBindingSource.DataSource = YearList.OrderByDescending(c => c.Name);
        }

        private void LoadTopSellingItems(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var topSellingItems = _unitOfWork.SalesOrderLine.Value.GetAll(c => c.SalesOrder.OrderDate.Year == year,
                includeProperties: "Product,SalesOrder")
                .GroupBy(c => c.Product.ProductName)
                .Select(g => new { ProductName = g.Key, Quantity = g.Sum(c => c.Quantity) })
                .OrderByDescending(c => c.Quantity)
                .Take(5) // Top 10
                .ToList();

            TopSellingDataSet.Label = "Product";
            foreach (var item in topSellingItems)
            {
                TopSellingDataSet.DataPoints.Add(item.ProductName, item.Quantity);
            }
        }

        private void LoadProjectExpenseDistribution(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var projectExpenses = _unitOfWork.Project.Value.GetAll(c => c.StartDate.Value.Year == year, includeProperties: "ProjectLines")
            .GroupBy(c => c.ProjectName)
            .Select(g => new ProjectExpenseDistributionViewModel
            {
                Project = g.Key,
                Amount = g.Sum(c => c.ProjectLines.Sum(c => c.SubTotal)) // Total expenses per project
            }).ToList();

            ProjectDataSet.Label = "Project";

            foreach (var item in projectExpenses)
            {
                ProjectDataSet.DataPoints.Add(item.Project, item.Amount);
            }
        }

        private void LoadInventoryStatus()
        {
            var products = _unitOfWork.Product.Value.GetAll(includeProperties: "ProductStockInLogs");

            var inventoryData = new List<InventoryStatusViewModel>
                {
                    new InventoryStatusViewModel { Category = "Total Stock", Quantity = products.SelectMany(c => c.ProductStockInLogs).Sum(c => c.StockQuantity) },
                    new InventoryStatusViewModel { Category = "Low Stock (<10)", Quantity = products.SelectMany(c => c.ProductStockInLogs).Where(c => c.StockQuantity <= c.Product.ReorderLevel).Count() },
                    new InventoryStatusViewModel { Category = "Out of Stock", Quantity = products.SelectMany(c => c.ProductStockInLogs).Where(c => c.StockQuantity == 0).Count() }
                };

            InventoryStatusDataSet.Label = "Qty";

            foreach (var item in inventoryData)
            {
                InventoryStatusDataSet.DataPoints.Add(item.Category, item.Quantity);
            }
        }

        private void LoadDailySalesTrend(int? year = 0, int? month = 0)
        {
            var today = year == 0 && month == 0 ? DateTime.Now : new DateTime(year.Value, month.Value, 1);
            var days = DateTime.DaysInMonth(today.Year, today.Month);
            var sales = _unitOfWork.SalesOrderLine.Value.GetAll(includeProperties: "SalesOrder");

            DailySalesTrendDataSet.DataPoints.Clear();
            DailySalesTrendDataSet.Label = "Qty";
            for (int i = 1; i <= days; i++)
            {
                var date = new DateTime(today.Year, today.Month, i);
                var qty = sales.Where(c => c.SalesOrder.OrderDate.Date == date.Date).Sum(c => c.Quantity);
                DailySalesTrendDataSet.DataPoints.Add(i.ToString(), qty);
            }
        }

        private void LoadMonthlySalesTrend(int? year = 0)
        {
            var date = year == 0 ? DateTime.Now : new DateTime(year.Value, 1, 1);
            var months = Enumerable.Range(1, 12)
                .Select(i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                .ToList();


            MonthlySalesTrendDataset.DataPoints.Clear();
            MonthlyExpenseTrendDataset.DataPoints.Clear();

            foreach (var m in months)
            {
                int monthNumber = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, m) + 1;

                var sales = _unitOfWork.SalesOrder.Value.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year,
                    includeProperties: "SalesOrderLines"
                ).SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity);

                var purchase = _unitOfWork.PurchaseOrder.Value.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year,
                    includeProperties: "PurchaseOrderLines"
                ).SelectMany(c => c.PurchaseOrderLines).Sum(c => c.Quantity);
                //totalSales as Sales and totalPurchase as Expenses
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
