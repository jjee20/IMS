using PresentationLayer.Presenters.Account;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Inventory;
using RavenTech_ERP.Presenters.Inventory;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
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
            _view.ShowCustomers += ShowCustomers;
            _view.ShowCashBank += ShowCashBank;
            _view.ShowVendors += ShowVendors;
            _view.ShowWarehouse += ShowWarehouse;
            _view.ShowSettings += ShowSettings;
            _view.ShowProfile += ShowProfile;
            ShowDashboard(this, EventArgs.Empty);
        }

        private void ShowProfile(object? sender, EventArgs e)
        {
            IProfileView view = ProfileView.GetInstance(_view.Guna2TabControlPage);
            new ProfilePresenter(view, _unitOfWork);
        }

        private void ShowSettings(object? sender, EventArgs e)
        {
            ISettingsView view = SettingsView.GetInstance(_view.Guna2TabControlPage);
            new SettingsPresenter(view, _unitOfWork);
        }

        private void ShowWarehouse(object? sender, EventArgs e)
        {
            IWarehouseView view = WarehouseView.GetInstance(_view.Guna2TabControlPage);
            new WarehousePresenter(view, _unitOfWork);
        }

        private void ShowVendors(object? sender, EventArgs e)
        {
            IVendorView view = VendorView.GetInstance(_view.Guna2TabControlPage);
            new VendorPresenter(view, _unitOfWork);
        }

        private void ShowCashBank(object? sender, EventArgs e)
        {
            ICashBankView view = CashBankView.GetInstance(_view.Guna2TabControlPage);
            new CashBankPresenter(view, _unitOfWork);
        }

        private void ShowCustomers(object? sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance(_view.Guna2TabControlPage);
            new CustomerPresenter(view, _unitOfWork);
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
            ISalesOrderView view = SalesOrderView.GetInstance(_view.Guna2TabControlPage);
            new SalesOrderPresenter(view, _unitOfWork);
        }
        private void ShowPurchase(object? sender, EventArgs e)
        {
            IPurchaseOrderView view = PurchaseOrderView.GetInstance(_view.Guna2TabControlPage);
            new PurchaseOrderPresenter(view, _unitOfWork);
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
