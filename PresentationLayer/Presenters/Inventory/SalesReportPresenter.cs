using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.InventoryViewModels;
using Guna.Charts.WinForms;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.IRepositories.IInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters.Inventory
{
    public class SalesReportPresenter
    {
        private ISalesReportView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource MonthBindingSource;
        private BindingSource YearBindingSource;
        private BindingSource DailySalesBindingSource;
        private BindingSource MonthlySalesBindingSource;
        private IEnumerable<EnumItemViewModel> YearList;
        private IEnumerable<EnumItemViewModel> MonthList;
        private GunaBarDataset DailySalesTrendDataSet;
        private GunaBarDataset DailyPurchasesTrendDataSet;
        private GunaBarDataset MonthlySalesTrendDataset;
        private GunaBarDataset MonthlyPurchasesTrendDataset;

        public SalesReportPresenter(ISalesReportView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            YearBindingSource = new BindingSource();
            MonthBindingSource = new BindingSource();
            DailySalesBindingSource = new BindingSource();
            MonthlySalesBindingSource = new BindingSource();
            DailySalesTrendDataSet = new GunaBarDataset();
            DailyPurchasesTrendDataSet = new GunaBarDataset();
            MonthlySalesTrendDataset = new GunaBarDataset();
            MonthlyPurchasesTrendDataset = new GunaBarDataset();

            _view.UpdateSalesReportEvent += UpdateSalesReport;

            LoadAllYears();
            LoadAllMonths();
            LoadReport();

            _view.SetYears(YearBindingSource);
            _view.SetMonths(MonthBindingSource);
            _view.SetDailySalesChart(DailySalesTrendDataSet, DailyPurchasesTrendDataSet);
            _view.SetMonthlySalesChart(MonthlySalesTrendDataset, MonthlyPurchasesTrendDataset);
            _view.SetDailySalesDataGrid(DailySalesBindingSource);
            _view.SetMonthlySalesDataGrid(MonthlySalesBindingSource);
        }

        private void LoadAllMonths()
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

        private void LoadAllYears()
        {
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

        private void LoadReport(int? year = 0, int? month = 0)
        {
            if(year == 0 || month == 0)
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
            }

            var sales = _unitOfWork.SalesOrder.GetAll(includeProperties: "SalesOrderLines");
            var purchases = _unitOfWork.PurchaseOrder.GetAll(includeProperties: "PurchaseOrderLines");

            _view.ItemSold = sales.Where(c => c.OrderDate.Year == year.Value).SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity).ToString();
            _view.Sales = sales.Where(c => c.OrderDate.Year == year.Value).Sum(c => c.Total);
            _view.Purchases = purchases.Where(c => c.OrderDate.Year == year.Value).Sum(c => c.Total);
            _view.Net = (_view.Sales - _view.Purchases).ToString("N2");

            var daysInMonth = DateTime.DaysInMonth(year.Value, month.Value);
            var daysRange = Enumerable.Range(1, daysInMonth);
            var dailySalesData = daysRange
                .Select(day => new DailySalesBreakdownViewModel
                {
                    Day = day,
                    ItemSold = (int)sales.Where(c => c.OrderDate.Month == month.Value && c.OrderDate.Day == day).SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity),
                    Sales = sales.Where(c => c.OrderDate.Month == month.Value && c.OrderDate.Day == day).Sum(c => c.Total),
                    Purchases = purchases.Where(c => c.OrderDate.Month == month.Value && c.OrderDate.Day == day).Sum(c => c.Total)
                })
                .ToList();
            DailySalesBindingSource.DataSource = dailySalesData;


            DailySalesTrendDataSet.DataPoints.Clear();
            DailyPurchasesTrendDataSet.DataPoints.Clear();
            DailySalesTrendDataSet.Label = "Sales";
            DailySalesTrendDataSet.FillColors.Add(Color.Blue);
            DailyPurchasesTrendDataSet.Label = "Purchases";
            DailyPurchasesTrendDataSet.FillColors.Add(Color.Red);

            for (int day = 1; day < daysRange.LastOrDefault(); day++)
            {
                var date = new DateTime(year.Value, month.Value, day);
                var salesAmount = sales.Where(c => c.OrderDate.Date == date.Date).Sum(c => c.Amount);
                var purchaseAmount = purchases.Where(c => c.OrderDate.Date == date.Date).Sum(c => c.Amount);
                DailySalesTrendDataSet.DataPoints.Add(day.ToString(), salesAmount);
                DailyPurchasesTrendDataSet.DataPoints.Add(day.ToString(), purchaseAmount);
            }

            var monthRange = Enumerable.Range(1, 12);
            var monthlySalesData = monthRange
                .Select(month => new MonthlySalesBreakdownViewModel
                {
                    Month = new DateTime(1, month, 1).ToString("MMMM"),
                    ItemSold = (int)sales.Where(c => c.OrderDate.Month == month).SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity),
                    Sales = sales.Where(c => c.OrderDate.Month == month).Sum(c => c.Total),
                    Purchases = purchases.Where(c => c.OrderDate.Month == month).Sum(c => c.Total)
                })
                .ToList();
            MonthlySalesBindingSource.DataSource = monthlySalesData;

            MonthlySalesTrendDataset.DataPoints.Clear();
            MonthlyPurchasesTrendDataset.DataPoints.Clear();
            MonthlySalesTrendDataset.Label = "Sales";
            MonthlySalesTrendDataset.FillColors.Add(Color.Blue);
            MonthlyPurchasesTrendDataset.Label = "Purchases";
            MonthlyPurchasesTrendDataset.FillColors.Add(Color.Red);


            for (int m = 1; m < monthRange.LastOrDefault(); m++)
            {
                var salesAmount = sales.Where(c => c.OrderDate.Month == m).Sum(c => c.Amount);
                var purchaseAmount = purchases.Where(c => c.OrderDate.Month == m).Sum(c => c.Amount);
                MonthlySalesTrendDataset.DataPoints.Add(new DateTime(1,m,1).ToString("MMMM"), salesAmount);
                MonthlyPurchasesTrendDataset.DataPoints.Add(new DateTime(1, m, 1).ToString("MMMM"), purchaseAmount);
            }
        }

        private void UpdateSalesReport(object? sender, EventArgs e)
        {
            LoadReport(_view.Year, _view.Month);
        }
    }
}
