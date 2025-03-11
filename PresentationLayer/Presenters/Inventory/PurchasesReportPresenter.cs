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
    public class PurchasesReportPresenter
    {
        private IPurchasesReportView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource MonthBindingSource;
        private BindingSource YearBindingSource;
        private BindingSource DailyPurchasesBindingSource;
        private BindingSource MonthlyPurchasesBindingSource;
        private BindingSource AnnuallyPurchasesBindingSource;
        private IEnumerable<EnumItemViewModel> YearList;
        private IEnumerable<EnumItemViewModel> MonthList;
        private GunaBarDataset DailyPurchasesTrendDataSet;

        public PurchasesReportPresenter(IPurchasesReportView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            YearBindingSource = new BindingSource();
            MonthBindingSource = new BindingSource();
            DailyPurchasesBindingSource = new BindingSource();
            MonthlyPurchasesBindingSource = new BindingSource();
            AnnuallyPurchasesBindingSource = new BindingSource();
            DailyPurchasesTrendDataSet = new GunaBarDataset();

            _view.UpdatePurchasesReportEvent += UpdatePurchasesReport;

            LoadAllYears();
            LoadAllMonths();
            LoadReport();

            _view.SetYears(YearBindingSource);
            _view.SetMonths(MonthBindingSource);
            _view.SetDailyPurchasesChart(DailyPurchasesTrendDataSet);
            _view.SetDailyPurchasesDataGrid(DailyPurchasesBindingSource);
            _view.SetMonthlyPurchasesDataGrid(MonthlyPurchasesBindingSource);
            _view.SetAnnuallyPurchasesDataGrid(AnnuallyPurchasesBindingSource);
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

            var purchases = _unitOfWork.PurchaseOrder.GetAll(includeProperties: "PurchaseOrderLines");

            _view.Purchases = purchases.Where(c => c.OrderDate.Year == year.Value).Sum(c => c.Total);
            
            var daysInMonth = DateTime.DaysInMonth(year.Value, month.Value);
            var daysRange = Enumerable.Range(1, daysInMonth);
            var dailyPurchasesData = daysRange
                .Select(day => new DailyPurchasesBreakdownViewModel
                {
                    Day = day,
                    Purchases = purchases.Where(c => c.OrderDate.Month == month.Value && c.OrderDate.Day == day).Sum(c => c.Total)
                })
                .ToList();
            DailyPurchasesBindingSource.DataSource = dailyPurchasesData;


            DailyPurchasesTrendDataSet.DataPoints.Clear();
            DailyPurchasesTrendDataSet.DataPoints.Clear();
            DailyPurchasesTrendDataSet.Label = "Purchases";
            DailyPurchasesTrendDataSet.FillColors.Add(Color.Red);

            for (int day = 1; day < daysRange.LastOrDefault(); day++)
            {
                var date = new DateTime(year.Value, month.Value, day);
                var purchaseAmount = purchases.Where(c => c.OrderDate.Date == date.Date).Sum(c => c.Amount);
                DailyPurchasesTrendDataSet.DataPoints.Add(day.ToString(), purchaseAmount);
            }

            var monthRange = Enumerable.Range(1, 12);
            var monthlyPurchasesData = monthRange
                .Select(m => new MonthlyPurchasesBreakdownViewModel
                {
                    Month = new DateTime(1, m, 1).ToString("MMMM"),
                    Purchases = purchases.Where(c => c.OrderDate.Month == m).Sum(c => c.Total)
                })
                .ToList();
            MonthlyPurchasesBindingSource.DataSource = monthlyPurchasesData;

            var yearRange = Enumerable.Range(year.Value - 9, 10);
            var annuallyPurchasesData = yearRange
                .Select(m => new AnnuallyPurchasesBreakdownViewModel
                {
                    Year = m,
                    Purchases = purchases.Where(c => c.OrderDate.Year == m).Sum(c => c.Total)
                })
                .ToList().OrderByDescending(c => c.Year);
            AnnuallyPurchasesBindingSource.DataSource = annuallyPurchasesData;

        }

        private void UpdatePurchasesReport(object? sender, EventArgs e)
        {
            LoadReport(_view.Year, _view.Month);
        }
    }
}
