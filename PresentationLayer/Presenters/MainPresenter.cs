using DomainLayer.Enums;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.Account;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Presenters.Inventory;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Account;
using RavenTech_ERP.Views.UserControls.Inventory;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters
{
    public class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly IUnitOfWork _unitOfWork;

        public MainPresenter(IMainForm mainForm, IUnitOfWork unitOfWork)
        {
            _mainForm = mainForm;
            _unitOfWork = unitOfWork;

            _mainForm.AllowanceEvent += AllowanceEvent;
            _mainForm.AttendanceEvent += AttendanceEvent;
            _mainForm.BenefitEvent += BenefitEvent;
            _mainForm.BonusEvent += BonusEvent;
            _mainForm.ContributionEvent += ContributionEvent;
            _mainForm.DeductionEvent += DeductionEvent;
            _mainForm.JobPositionEvent += JobPositionEvent;
            _mainForm.LeaveEvent += LeaveEvent;
            _mainForm.ProjectEvent += ProjectEvent;
            _mainForm.ShiftEvent += ShiftEvent;
            _mainForm.TaxEvent += TaxEvent;
            _mainForm.BillTypeEvent += BillTypeEvent;
            _mainForm.BranchEvent += BranchEvent;
            _mainForm.CashBankEvent += CashBankEvent;
            _mainForm.InvoiceTypeEvent += InvoiceTypeEvent;
            _mainForm.PaymentTypeEvent += PaymentTypeEvent;
            _mainForm.ProductEvent += ProductEvent;
            _mainForm.StockInLogEvent += StockInLogEvent;
            _mainForm.ProductTypeEvent += ProductTypeEvent;
            _mainForm.PurchaseOrderEvent += PurchaseOrderEvent;
            _mainForm.PurchaseReportEvent += PurchaseReportEvent;
            _mainForm.PurchaseTypeEvent += PurchaseTypeEvent;
            _mainForm.SalesOrderEvent += SalesOrderEvent;
            _mainForm.SalesReportEvent += SalesReportEvent;
            _mainForm.SalesTypeEvent += SalesTypeEvent;
            _mainForm.ShipmentTypeEvent += ShipmentTypeEvent;
            _mainForm.TargetGoalsEvent += TargetGoalsEvent;
            _mainForm.UnitOfMeasureEvent += UnitOfMeasureEvent;
            _mainForm.VendorEvent += VendorEvent;
            _mainForm.VendorTypeEvent += VendorTypeEvent;
            _mainForm.WarehouseEvent += WarehouseEvent;
            _mainForm.DashboardEvent += DashboardEvent;
            _mainForm.ProductMonitoringEvent += ProductMonitoringEvent;
            _mainForm.ProfileEvent += ProfileEvent;
            _mainForm.RegisterAccountEvent += RegisterAccountEvent;
            _mainForm.PayrollEvent += PayrollEvent;

            if(!(Settings.Default.Department == Departments.Payroll.ToString()))
            {
                _mainForm.ribbonControl.SelectedTab = _mainForm.InventoryTab;
                DashboardEvent(this, EventArgs.Empty);
            }
            else
            {
                _mainForm.ribbonControl.SelectedTab = _mainForm.PayrollTab;
                AttendanceEvent(this, EventArgs.Empty);
            }
        }

        private void PayrollEvent(object? sender, EventArgs e)
        {
            IPayrollView _view = ChildManager<PayrollView>.GetChildInstance((MainForm)_mainForm);
            new PayrollPresenter(_view, _unitOfWork);
        }

        private void RegisterAccountEvent(object? sender, EventArgs e)
        {
            IRegisterView _view = ChildManager<RegisterView>.GetChildInstance((MainForm)_mainForm);
            new RegisterPresenter(_view, _unitOfWork);
        }

        private void ProfileEvent(object? sender, EventArgs e)
        {
            IProfileView _view = ChildManager<ProfileView>.GetChildInstance((MainForm)_mainForm);
            new ProfilePresenter(_view, _unitOfWork);
        }

        private void ProductMonitoringEvent(object? sender, EventArgs e)
        {
            IProductMonitoringView _view = ChildManager<ProductMonitoringView>.GetChildInstance((MainForm)_mainForm);
            new ProductMonitoringPresenter(_view, _unitOfWork);
        }

        private void DashboardEvent(object? sender, EventArgs e)
        {
            IDashboardView _view = ChildManager<DashboardView>.GetChildInstance((MainForm)_mainForm);
            new DashboardPresenter(_view, _unitOfWork);
        }

        private void WarehouseEvent(object? sender, EventArgs e)
        {
            IWarehouseView _view = ChildManager<WarehouseView>.GetChildInstance((MainForm)_mainForm);
            new WarehousePresenter(_view, _unitOfWork);
        }

        private void VendorTypeEvent(object? sender, EventArgs e)
        {
            IVendorTypeView _view = ChildManager<VendorTypeView>.GetChildInstance((MainForm)_mainForm);
            new VendorTypePresenter(_view, _unitOfWork);
        }

        private void VendorEvent(object? sender, EventArgs e)
        {
            IVendorView _view = ChildManager<VendorView>.GetChildInstance((MainForm)_mainForm);
            new VendorPresenter(_view, _unitOfWork);
        }

        private void UnitOfMeasureEvent(object? sender, EventArgs e)
        {
            IUnitOfMeasureView _view = ChildManager<UnitOfMeasureView>.GetChildInstance((MainForm)_mainForm);
            new UnitOfMeasurePresenter(_view, _unitOfWork);
        }

        private void TargetGoalsEvent(object? sender, EventArgs e)
        {
            ITargetGoalsView _view = ChildManager<TargetGoalsView>.GetChildInstance((MainForm)_mainForm);
            new TargetGoalsPresenter(_view, _unitOfWork);
        }

        private void ShipmentTypeEvent(object? sender, EventArgs e)
        {
            IShipmentTypeView _view = ChildManager<ShipmentTypeView>.GetChildInstance((MainForm)_mainForm);
            new ShipmentTypePresenter(_view, _unitOfWork);
        }

        private void SalesTypeEvent(object? sender, EventArgs e)
        {
            ISalesTypeView _view = ChildManager<SalesTypeView>.GetChildInstance((MainForm)_mainForm);
            new SalesTypePresenter(_view, _unitOfWork);
        }

        private void SalesReportEvent(object? sender, EventArgs e)
        {
            ISalesReportView _view = ChildManager<SalesReportView>.GetChildInstance((MainForm)_mainForm);
            new SalesReportPresenter(_view, _unitOfWork);
        }

        private void SalesOrderEvent(object? sender, EventArgs e)
        {
            ISalesOrderView _view = ChildManager<SalesOrderView>.GetChildInstance((MainForm)_mainForm);
            new SalesOrderPresenter(_view, _unitOfWork);
        }

        private void PurchaseTypeEvent(object? sender, EventArgs e)
        {
            IPurchaseTypeView _view = ChildManager<PurchaseTypeView>.GetChildInstance((MainForm)_mainForm);
            new PurchaseTypePresenter(_view, _unitOfWork);
        }

        private void PurchaseReportEvent(object? sender, EventArgs e)
        {
            IPurchasesReportView _view = ChildManager<PurchasesReportView>.GetChildInstance((MainForm)_mainForm);
            new PurchasesReportPresenter(_view, _unitOfWork);
        }

        private void PurchaseOrderEvent(object? sender, EventArgs e)
        {
            IPurchaseOrderView _view = ChildManager<PurchaseOrderView>.GetChildInstance((MainForm)_mainForm);
            new PurchaseOrderPresenter(_view, _unitOfWork);
        }

        private void ProductTypeEvent(object? sender, EventArgs e)
        {
            IProductTypeView _view = ChildManager<ProductTypeView>.GetChildInstance((MainForm)_mainForm);
            new ProductTypePresenter(_view, _unitOfWork);
        }

        private void StockInLogEvent(object? sender, EventArgs e)
        {
            IProductStockInLogView _view = ChildManager<ProductStockInLogView>.GetChildInstance((MainForm)_mainForm);
            new ProductStockInLogPresenter(_view, _unitOfWork);
        }

        private void ProductEvent(object? sender, EventArgs e)
        {
            IProductView _view = ChildManager<ProductView>.GetChildInstance((MainForm)_mainForm);
            new ProductPresenter(_view, _unitOfWork);
        }

        private void PaymentTypeEvent(object? sender, EventArgs e)
        {
            IPaymentTypeView _view = ChildManager<PaymentTypeView>.GetChildInstance((MainForm)_mainForm);
            new PaymentTypePresenter(_view, _unitOfWork);
        }

        private void InvoiceTypeEvent(object? sender, EventArgs e)
        {
            IInvoiceTypeView _view = ChildManager<InvoiceTypeView>.GetChildInstance((MainForm)_mainForm);
            new InvoiceTypePresenter(_view, _unitOfWork);
        }

        private void CashBankEvent(object? sender, EventArgs e)
        {
            ICashBankView _view = ChildManager<CashBankView>.GetChildInstance((MainForm)_mainForm);
            new CashBankPresenter(_view, _unitOfWork);
        }

        private void BranchEvent(object? sender, EventArgs e)
        {
            IBranchView _view = ChildManager<BranchView>.GetChildInstance((MainForm)_mainForm);
            new BranchPresenter(_view, _unitOfWork);
        }

        private void BillTypeEvent(object? sender, EventArgs e)
        {
            IBillTypeView _view = ChildManager<BillTypeView>.GetChildInstance((MainForm)_mainForm);
            new BillTypePresenter(_view, _unitOfWork);
        }

        private void TaxEvent(object? sender, EventArgs e)
        {
            ITaxView _view = ChildManager<TaxView>.GetChildInstance((MainForm)_mainForm);
            new TaxPresenter(_view, _unitOfWork);
        }

        private void ShiftEvent(object? sender, EventArgs e)
        {
            IShiftView _view = ChildManager<ShiftView>.GetChildInstance((MainForm)_mainForm);
            new ShiftPresenter(_view, _unitOfWork);
        }

        private void ProjectEvent(object? sender, EventArgs e)
        {
            IProjectView _view = ChildManager<ProjectManagementView>.GetChildInstance((MainForm)_mainForm);
            new ProjectPresenter(_view, _unitOfWork);
        }

        private void LeaveEvent(object? sender, EventArgs e)
        {
            ILeaveView _view = ChildManager<LeaveView>.GetChildInstance((MainForm)_mainForm);
            new LeavePresenter(_view, _unitOfWork);
        }

        private void JobPositionEvent(object? sender, EventArgs e)
        {
            IJobPositionView _view = ChildManager<JobPositionView>.GetChildInstance((MainForm)_mainForm);
            new JobPositionPresenter(_view, _unitOfWork);
        }

        private void DeductionEvent(object? sender, EventArgs e)
        {
            IDeductionView _view = ChildManager<DeductionView>.GetChildInstance((MainForm)_mainForm);
            new DeductionPresenter(_view, _unitOfWork);
        }

        private void ContributionEvent(object? sender, EventArgs e)
        {
            IEmployeeContributionView _view = ChildManager<EmployeeContributionView>.GetChildInstance((MainForm)_mainForm);
            new EmployeeContributionPresenter(_view, _unitOfWork);
        }

        private void BonusEvent(object? sender, EventArgs e)
        {
            IBonusView _view = ChildManager<BonusView>.GetChildInstance((MainForm)_mainForm);
            new BonusPresenter(_view, _unitOfWork);
        }

        private void BenefitEvent(object? sender, EventArgs e)
        {
            IBenefitView _view = ChildManager<BenefitView>.GetChildInstance((MainForm)_mainForm);
            new BenefitPresenter(_view, _unitOfWork);
        }

        private void AttendanceEvent(object? sender, EventArgs e)
        {
            IAttendanceView _view = ChildManager<AttendanceView>.GetChildInstance((MainForm)_mainForm);
            new AttendancePresenter(_view, _unitOfWork);
        }

        private void AllowanceEvent(object? sender, EventArgs e)
        {
            IAllowanceView _view = ChildManager<AllowanceView>.GetChildInstance((MainForm)_mainForm);
            new AllowancePresenter(_view, _unitOfWork);
        }
    }
}
