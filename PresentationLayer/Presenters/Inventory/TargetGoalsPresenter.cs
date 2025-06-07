using DomainLayer.Models.Inventory;
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
    public class TargetGoalsPresenter
    {
        private ITargetGoalsView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;

        public TargetGoalsPresenter(ITargetGoalsView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            this._eventAggregator = eventAggregator;
            _view.SaveClicked -= Save;
            _view.SaveClicked += Save;

            LoadAll();

        }

        private void LoadAll()
        {
            var targetGoals = _unitOfWork.TargetGoals.Value.GetAll().FirstOrDefault();

            if (targetGoals == null)
            {
                targetGoals = new TargetGoals
                {
                    MonthlyItemSold = 0,
                    MonthlySales = 0,
                    AnnualSales = 0
                };
                _unitOfWork.TargetGoals.Value.Add(targetGoals);
                _unitOfWork.Save();
            }

            var monthlyItemSoldTarget = targetGoals.MonthlyItemSold;
            var monthlySalesTarget = targetGoals.MonthlySales;
            var annualSalesTarget = targetGoals.AnnualSales;

            _view.ItemSoldTarget = monthlyItemSoldTarget;
            _view.SalesTarget = monthlySalesTarget;
            _view.YearTarget = annualSalesTarget;

            var date = DateTime.Now;
            var salesOrders = _unitOfWork.SalesOrder.Value.GetAll(c => c.OrderDate.Date.Year == date.Date.Year, includeProperties: "SalesOrderLines");
            var salesOrdersMonthly = salesOrders.Where(c => c.OrderDate.Date.Month == date.Date.Month);
            var itemSold = salesOrdersMonthly.SelectMany(c => c.SalesOrderLines).Sum(c => c.Quantity);
            var sales = salesOrdersMonthly.Sum(c => c.Total);
            var annualSales = salesOrders.Sum(c => c.Total);
            _view.SalesCurrent = sales;
            _view.ItemSoldCurrent = itemSold;
            _view.YearCurrent = annualSales;
            _view.Year = date.Year.ToString();
            _view.SalesRemaining = sales - monthlySalesTarget;
            _view.ItemSoldRemaining = itemSold - monthlyItemSoldTarget;
            _view.YearRemaining = annualSales - annualSalesTarget;

            _eventAggregator.Publish<InventoryCompletedEvent>();
        }

        private void Save(object? sender, EventArgs e)
        {
            var targetGoals = _unitOfWork.TargetGoals.Value.GetAll().FirstOrDefault();

            if (targetGoals == null)
            {
                targetGoals = new TargetGoals
                {
                    MonthlyItemSold = 0,
                    MonthlySales = 0,
                    AnnualSales = 0
                };
                _unitOfWork.TargetGoals.Value.Add(targetGoals);
            }
            else
            {
                targetGoals.MonthlyItemSold = _view.ItemSoldTarget;
                targetGoals.MonthlySales = _view.SalesTarget;
                targetGoals.AnnualSales = _view.YearTarget;
                _unitOfWork.TargetGoals.Value.Detach(targetGoals);
                _unitOfWork.TargetGoals.Value.Update(targetGoals);
            }
            _unitOfWork.Save();

            _view.Message = "Target goals successfully updated.";
            LoadAll();
        }
    }
}
