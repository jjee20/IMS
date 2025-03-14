﻿using PresentationLayer.Presenters.Account;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Inventory;
using RavenTech_ERP.Presenters.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories.IInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Inventory
{
    public class InventoryPresenter
    {
        private IInventoryView _view;
        private IUnitOfWork _unitOfWork;
        public InventoryPresenter(IInventoryView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowDashboard += ShowDashboard;
            _view.ShowSales += ShowSales;
            _view.ShowPurchase += ShowPurchase;
            _view.ShowInventory += ShowInventory;
            _view.ShowProject += ShowProject;
            _view.ShowTargetGoals += ShowTargetGoals;
            _view.ShowSalesReport += ShowSalesReport;
            _view.ShowPurchaseReport += ShowPurchaseReport;
            ShowDashboard(this, EventArgs.Empty);
        }

        private void ShowPurchaseReport(object? sender, EventArgs e)
        {
            IPurchasesReportView view = PurchasesReportView.GetInstance(_view.Guna2TabControlPage);
            new PurchasesReportPresenter(view, _unitOfWork);
        }

        private void ShowSalesReport(object? sender, EventArgs e)
        {
            ISalesReportView view = SalesReportView.GetInstance(_view.Guna2TabControlPage);
            new SalesReportPresenter(view, _unitOfWork);
        }

        private void ShowTargetGoals(object? sender, EventArgs e)
        {
            ITargetGoalsView view = TargetGoalsView.GetInstance(_view.Guna2TabControlPage);
            new TargetGoalsPresenter(view, _unitOfWork);
        }

        private void ShowDashboard(object? sender, EventArgs e)
        {
            IDashboardView view = DashboardView.GetInstance(_view.Guna2TabControlPage);
            new DashboardPresenter(view, _unitOfWork);
        }
        private void ShowSales(object? sender, EventArgs e)
        {
            ISalesView view = SalesView.GetInstance(_view.Guna2TabControlPage);
            new SalesPresenter(view, _unitOfWork);
        }
        private void ShowPurchase(object? sender, EventArgs e)
        {
            IPurchaseView view = PurchaseView.GetInstance(_view.Guna2TabControlPage);
            new PurchasePresenter(view, _unitOfWork);
        }
        private void ShowInventory(object? sender, EventArgs e)
        {
            IProductInventoryView view = ProductInventoryView.GetInstance(_view.Guna2TabControlPage);
            new ProductInventoryPresenter(view, _unitOfWork);
        }
        private void ShowProject(object? sender, EventArgs e)
        {
            IProjectManagementView view = ProjectManagementView.GetInstance(_view.Guna2TabControlPage);
            new ProjectManagementPresenter(view, _unitOfWork);
        }
    }
}
