using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
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
        private BindingSource TopSellingItemsBindingSource;
        private IEnumerable<TopSellingItemViewModel> TopSellingItemList;
        private GunaBarDataset _barDataset;
        private GunaLineDataset _lineDataset;
        public DashboardPresenter(IDashboardView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            TopSellingItemsBindingSource = new BindingSource();
            _barDataset = new GunaBarDataset();
            _lineDataset = new GunaLineDataset();
            LoadAll();

            _view.SetTopSellingItemListBindingSource(TopSellingItemsBindingSource);
            _view.SetChartInventoryStatusBindingSource(_barDataset);
            _view.SetChartSalesStatusBindingSource(_lineDataset);
        }

        private void LoadAll()
        {
            var currentDate = DateTime.Now;

            #region TopSellingItems
            LoadTopSellingItems();
            #endregion

            #region Inventory Summary
            LoadInventorySummary();
            #endregion

            #region Product Details
            LoadProductDetails();
            #endregion

            #region Charts
            LoadMonthlyCharts(currentDate);
            #endregion

            #region Tables
            LoadSalesAndPurchaseSummaries(currentDate);
            #endregion
        }

        private void LoadTopSellingItems()
        {
            var topSellingItems = _unitOfWork.SalesOrderLine.GetAll(includeProperties: "Product")
                .GroupBy(c => c.Product.ProductName)
                .Select(g => new { ProductName = g.Key, Quantity = g.Sum(c => c.Quantity) })
                .OrderByDescending(c => c.Quantity)
                .Take(10)
                .Select(c => new TopSellingItemViewModel
                {
                    Product = c.ProductName,
                    Qty = c.Quantity.ToString()
                });

            TopSellingItemsBindingSource.DataSource = topSellingItems.ToList();
        }

        private void LoadInventorySummary()
        {
            var productStock = _unitOfWork.Product.GetAll().Sum(c => c.StockQuantity);
            var salesCount = _unitOfWork.SalesOrderLine.GetAll().Sum(c => c.Quantity);
            var purchaseCount = _unitOfWork.PurchaseOrderLine.GetAll().Sum(c => c.Quantity);
            var outOfStock = _unitOfWork.Product.GetAll(c => c.StockQuantity == 0).Sum(c => c.StockQuantity);

            _view.Sales = salesCount.ToString();
            _view.Purchased = purchaseCount.ToString();
            _view.OnHand = (productStock - salesCount + purchaseCount).ToString();
            _view.OutOfStock = outOfStock.ToString();
        }

        private void LoadProductDetails()
        {
            var products = _unitOfWork.Product.GetAll();
            var productTypes = _unitOfWork.ProductType.GetAll();

            _view.LowStockItem = products.Where(c => c.StockQuantity <= c.ReorderLevel)
                                          .Sum(c => c.StockQuantity)
                                          .ToString();
            _view.AllItemGroup = productTypes.Count().ToString();
            _view.AllItem = products.Count().ToString();
        }

        private void LoadMonthlyCharts(DateTime currentDate)
        {
            var months = Enumerable.Range(1, currentDate.Month)
                .Select(i => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i))
                .ToList();

            foreach (var month in months)
            {
                int monthNumber = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, month) + 1;

                var sales = _unitOfWork.SalesOrder.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == currentDate.Year,
                    includeProperties: "SalesOrderLines"
                );
                var totalSales = sales.SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity);

                var purchases = _unitOfWork.PurchaseOrder.GetAll(
                    c => c.OrderDate.Month == monthNumber && c.OrderDate.Year == currentDate.Year,
                    includeProperties: "PurchaseOrderLines"
                );
                var totalPurchases = purchases.SelectMany(c => c.PurchaseOrderLines).Sum(c => c.Quantity);

                _barDataset.Label = "Qty";
                _lineDataset.Label = "Qty";
                _barDataset.DataPoints.Add(month, totalSales);
                _lineDataset.DataPoints.Add(month, totalPurchases);
            }
        }

        private void LoadSalesAndPurchaseSummaries(DateTime currentDate)
        {
            var startDay = new DateTime(currentDate.Year, 1, 1);
            var weekly = currentDate.AddDays(7);
            var startmonth = new DateTime(currentDate.Year, currentDate.Month, 1); 
            var endmonth = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1).AddDays(-1);
            // Helper function for date range queries (Sales Orders)
            Func<DateTime, DateTime, IEnumerable<SalesOrder>> GetSalesOrders = (start, end) =>
                _unitOfWork.SalesOrder.GetAll(c => c.OrderDate >= start && c.OrderDate <= end, includeProperties: "SalesOrderLines");

            // Helper function for date range queries (Purchase Orders)
            Func<DateTime, DateTime, IEnumerable<PurchaseOrder>> GetPurchaseOrders = (start, end) =>
                _unitOfWork.PurchaseOrder.GetAll(c => c.OrderDate >= start && c.OrderDate <= end, includeProperties: "PurchaseOrderLines");

            // Helper function to calculate total quantity from Sales Orders
            int GetSalesQuantity(IEnumerable<SalesOrder> orders) =>
                (int)orders.SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity);

            // Helper function to calculate total quantity from Purchase Orders
            int GetPurchaseQuantity(IEnumerable<PurchaseOrder> orders) =>
                (int)orders.SelectMany(c => c.PurchaseOrderLines).Sum(c => c.Quantity);

            // Sales Summary
            _view.SOToday = GetSalesQuantity(GetSalesOrders(currentDate.Date, currentDate.Date)).ToString();
            _view.SO7Days = GetSalesQuantity(GetSalesOrders(currentDate.Date, weekly.Date)).ToString();
            _view.SOThisMonth = GetSalesQuantity(GetSalesOrders(startmonth, endmonth)).ToString();
            _view.SOAnnual = GetSalesQuantity(GetSalesOrders(startDay, currentDate)).ToString();

            // Purchase Summary
            _view.POToday = GetPurchaseQuantity(GetPurchaseOrders(currentDate.Date, currentDate.Date)).ToString();
            _view.PO7Days = GetPurchaseQuantity(GetPurchaseOrders(currentDate.Date, weekly.Date)).ToString();
            _view.POThisMonth = GetPurchaseQuantity(GetPurchaseOrders(startmonth, endmonth)).ToString();
            _view.POAnnual = GetPurchaseQuantity(GetPurchaseOrders(startDay, currentDate)).ToString();
        }


        private int ConvertMonthToInt(string monthName)
        {
            return DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;
        }
    }
}
