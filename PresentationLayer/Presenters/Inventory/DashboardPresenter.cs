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
using ServiceLayer.Services.IRepositories.IInventory;
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
        private IEnumerable<TopSellingItemViewModel> TopSellingItemList;
        private GunaBarDataset TopSellingDataSet;
        private GunaBarDataset InventoryStatusDataSet;
        private GunaLineDataset DailySalesTrendDataSet;
        private GunaBarDataset MonthlySalesTrendDataset;
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
            TopSellingDataSet = new GunaBarDataset();
            DailySalesTrendDataSet = new GunaLineDataset();
            InventoryStatusDataSet = new GunaBarDataset();
            MonthlySalesTrendDataset = new GunaBarDataset();
            ProjectDataSet = new GunaDoughnutDataset();
            YearBindingSource = new BindingSource();
            MonthBindingSource = new BindingSource();

            LoadAll();

            _view.SetMonth(MonthBindingSource);
            _view.SetYear(YearBindingSource);
            _view.SetTopSelling(TopSellingDataSet);
            _view.SetDailySalesTrend(DailySalesTrendDataSet);
            _view.SetMonthlySalesTrend(MonthlySalesTrendDataset);
            _view.SetInventoryStatus(InventoryStatusDataSet);
            _view.SetProjectExpenseDistribution(ProjectDataSet);
            _view.SetProgressBars(ItemSold, Sales);
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

        private void LoadDailySalesTrend()
        {
            var today = DateTime.Now;
            var days = DateTime.DaysInMonth(today.Year, today.Month);
            var sales = _unitOfWork.SalesOrderLine.GetAll(includeProperties: "SalesOrder");

            DailySalesTrendDataSet.Label = "Qty";
            for (int i = 1; i <= days; i++)
            {
                var date = new DateTime(today.Year, today.Month, i);
                var qty = sales.Where(c => c.SalesOrder.OrderDate.Date == date.Date).Sum(c => c.Quantity);
                DailySalesTrendDataSet.DataPoints.Add(i.ToString(), qty);
            }
        }
        private void LoadPanelHeader(int year)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var salesOrder = _unitOfWork.SalesOrder.GetAll(c => c.OrderDate.Year == year, includeProperties: "SalesOrderLines.Product");
            var purchaseOrder = _unitOfWork.PurchaseOrder.GetAll(c => c.OrderDate.Year == year, includeProperties: "PurchaseOrderLines.Product");

            var sales = salesOrder.Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.Sales = sales.ToString("N2");
            var gross = salesOrder.Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.Product.DefaultBuyingPrice * c.Quantity));
            _view.Gross = gross.ToString("N2");

            var expense = purchaseOrder.Select(c => c.PurchaseOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.Expense = expense.ToString("N2");


            var salesToday = salesOrder.Where(c => c.OrderDate.Date == DateTime.Now.Date)
                .Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.SubTotal));
            _view.SalesToday = salesToday.ToString("N2");
            _view.ExpenseTodaySales = salesToday;
            _view.ExpenseTodaySalesTarget = 100000;

            Sales = (int)(salesToday / 100000.00 * 100);

            var itemsSoldToday = salesOrder.Where(c => c.OrderDate.Date == DateTime.Now.Date)
                .Select(c => c.SalesOrderLines).Sum(c => c.Sum(c => c.Quantity));
            _view.ItemSoldToday = itemsSoldToday.ToString("N0");
            _view.ExpenseTodayItemsSold = itemsSoldToday;
            _view.ExpenseTodayItemsSoldTarget = 1000;

            ItemSold = (int)(itemsSoldToday / 1000.00 * 100);

            var expenseToday = purchaseOrder.Where(c => c.OrderDate.Date == DateTime.Now.Date)
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

        private void LoadTopSellingItems(int year, int? month = 0)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var topSellingItems = _unitOfWork.SalesOrderLine.GetAll(c => c.SalesOrder.OrderDate.Year == year, 
                includeProperties: "Product,SalesOrder")
                .GroupBy(c => c.Product.ProductName)
                .Select(g => new { ProductName = g.Key, Quantity = g.Sum(c => c.Quantity) })
                .OrderByDescending(c => c.Quantity)
                .Take(5) // Top 10
                .ToList();

            TopSellingDataSet.Label = "Qty";

            foreach (var item in topSellingItems)
            {
                TopSellingDataSet.DataPoints.Add(item.ProductName, item.Quantity);
            }
        }

        private void LoadProjectExpenseDistribution(int year, int? month = 0)
        {
            year = year == 0 ? DateTime.Now.Year : _view.Year;
            var projectExpenses = _unitOfWork.Project.GetAll(includeProperties: "ProjectLines")
            .GroupBy(c => c.ProjectName)
            .Select(g => new ProjectExpenseDistributionViewModel
            {
                Project = g.Key,
                Amount = g.Sum(c => c.ProjectLines.Sum(c => c.Amount)) // Total expenses per project
            }).ToList();

            ProjectDataSet.Label = "Amount";

            foreach (var item in projectExpenses)
            {
                ProjectDataSet.DataPoints.Add(item.Project, item.Amount);
            }
        }

        private void LoadInventoryStatus()
        {
            var products = _unitOfWork.Product.GetAll();

            var inventoryData = new List<InventoryStatusViewModel>
                {
                    new InventoryStatusViewModel { Category = "Total Stock", Quantity = products.Sum(c => c.StockQuantity) },
                    new InventoryStatusViewModel { Category = "Low Stock (<10)", Quantity = products.Where(c => c.StockQuantity < 10).Count() },
                    new InventoryStatusViewModel { Category = "Out of Stock", Quantity = products.Where(c => c.StockQuantity == 0).Count() }
                };

            InventoryStatusDataSet.Label = "Qty";

            foreach (var item in inventoryData)
            {
                InventoryStatusDataSet.DataPoints.Add(item.Category, item.Quantity);
            }
        }

        private void LoadMonthlySalesTrend()
        {
            var date = DateTime.Now;
            var months = Enumerable.Range(1, 12)
                .Select(i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                .ToList();

            foreach (var month in months)
            {
                int monthNumber = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, month) + 1;

                var sales = _unitOfWork.SalesOrder.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year,
                    includeProperties: "SalesOrderLines"
                );
                var totalSales = sales.SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity);

                var purchase = _unitOfWork.PurchaseOrder.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == date.Year,
                    includeProperties: "PurchaseOrderLines"
                );
                var totalPurchase = purchase.SelectMany(c => c.PurchaseOrderLines).Sum(c => c.Quantity);

                //totalSales as Sales and totalPurchase as Expenses
                MonthlySalesTrendDataset.Label = "Qty";
                MonthlySalesTrendDataset.DataPoints.Add(month, totalSales);
            }
        }
    }
}
