using DomainLayer.Enums;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.Account;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Presenters.Accounting.Payroll;
using RavenTech_ERP.Presenters.Inventory;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RavenTech_ERP.Views.IViews.Accounting;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Account;
using RavenTech_ERP.Views.UserControls.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Inventory;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
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
        private DepartmentPresenter? _departmentPresenter;
        private EmployeePresenter? _employeePresenter;
        private HolidayPresenter? _holidayPresenter;
        private CustomerTypePresenter? _customerTypePresenter;
        private CustomerPresenter? _customerPresenter;
        private PayrollPresenter? _payrollPresenter;
        private RegisterPresenter? _registerPresenter;
        private ProfilePresenter? _profilePresenter;
        private ProductMonitoringPresenter? _productMonitoringPresenter;
        private DashboardPresenter? _dashboardPresenter;
        private WarehousePresenter? _warehousePresenter;
        private VendorTypePresenter? _vendorTypePresenter;
        private VendorPresenter? _vendorPresenter;
        private UnitOfMeasurePresenter? _unitOfMeasurePresenter;
        private TargetGoalsPresenter? _targetGoalsPresenter;
        private ShipmentTypePresenter? _shipmentTypePresenter;
        private SalesTypePresenter? _salesTypePresenter;
        private SalesReportPresenter? _salesReportPresenter;
        private SalesOrderPresenter? _salesOrderPresenter;
        private PurchaseTypePresenter? _purchaseTypePresenter;
        private PurchasesReportPresenter? _purchasesReportPresenter;
        private PurchaseOrderPresenter? _purchaseOrderPresenter;
        private ProductTypePresenter? _productTypePresenter;
        private ProductStockInLogPresenter? _productStockInLogPresenter;
        private ProductPullOutLogPresenter? _productPullOutLogPresenter;
        private ProductPresenter? _productPresenter;
        private PaymentTypePresenter? _paymentTypePresenter;
        private InvoiceTypePresenter? _invoiceTypePresenter;
        private CashBankPresenter? _cashBankPresenter;
        private BranchPresenter? _branchPresenter;
        private BillTypePresenter? _billTypePresenter;
        private TaxPresenter? _taxPresenter;
        private ShiftPresenter? _shiftPresenter;
        private ProjectPresenter? _projectPresenter;
        private LeavePresenter? _leavePresenter;
        private JobPositionPresenter? _jobPositionPresenter;
        private DeductionPresenter? _deductionPresenter;
        private EmployeeContributionPresenter? _employeeContributionPresenter;
        private BonusPresenter? _bonusPresenter;
        private BenefitPresenter? _benefitPresenter;
        private AttendancePresenter? _attendancePresenter;
        private AllowancePresenter? _allowancePresenter;
        private readonly IEventAggregator _eventAggregator;
        public MainPresenter(IMainForm mainForm, IUnitOfWork unitOfWork)
        {
            _mainForm = mainForm;
            _unitOfWork = unitOfWork;
            _eventAggregator = new EventAggregator();
            //_mainForm.AllowanceEvent -= AllowanceEvent;
            //_mainForm.AttendanceEvent -= AttendanceEvent;
            //_mainForm.BenefitEvent -= BenefitEvent;
            //_mainForm.BonusEvent -= BonusEvent;
            //_mainForm.ContributionEvent -= ContributionEvent;
            //_mainForm.CustomerEvent -= CustomerEvent;
            //_mainForm.CustomerTypeEvent -= CustomerTypeEvent;
            //_mainForm.DeductionEvent -= DeductionEvent;
            //_mainForm.JobPositionEvent -= JobPositionEvent;
            //_mainForm.LeaveEvent -= LeaveEvent;
            //_mainForm.ProjectEvent -= ProjectEvent;
            //_mainForm.ShiftEvent -= ShiftEvent;
            //_mainForm.TaxEvent -= TaxEvent;
            //_mainForm.BillTypeEvent -= BillTypeEvent;
            //_mainForm.BranchEvent -= BranchEvent;
            //_mainForm.CashBankEvent -= CashBankEvent;
            //_mainForm.InvoiceTypeEvent -= InvoiceTypeEvent;
            //_mainForm.PaymentTypeEvent -= PaymentTypeEvent;
            //_mainForm.ProductEvent -= ProductEvent;
            //_mainForm.StockInLogEvent -= StockInLogEvent;
            //_mainForm.ProductTypeEvent -= ProductTypeEvent;
            //_mainForm.PurchaseOrderEvent -= PurchaseOrderEvent;
            //_mainForm.PurchaseReportEvent -= PurchaseReportEvent;
            //_mainForm.PurchaseTypeEvent -= PurchaseTypeEvent;
            //_mainForm.SalesOrderEvent -= SalesOrderEvent;
            //_mainForm.SalesReportEvent -= SalesReportEvent;
            //_mainForm.SalesTypeEvent -= SalesTypeEvent;
            //_mainForm.ShipmentTypeEvent -= ShipmentTypeEvent;
            //_mainForm.TargetGoalsEvent -= TargetGoalsEvent;
            //_mainForm.UnitOfMeasureEvent -= UnitOfMeasureEvent;
            //_mainForm.VendorEvent -= VendorEvent;
            //_mainForm.VendorTypeEvent -= VendorTypeEvent;
            //_mainForm.WarehouseEvent -= WarehouseEvent;
            //_mainForm.DashboardEvent -= DashboardEvent;
            //_mainForm.ProductMonitoringEvent -= ProductMonitoringEvent;
            //_mainForm.ProfileEvent -= ProfileEvent;
            //_mainForm.RegisterAccountEvent -= RegisterAccountEvent;
            //_mainForm.PayrollEvent -= PayrollEvent;
            //_mainForm.HolidayEvent -= HolidayEvent;
            //_mainForm.EmployeeEvent -= EmployeeEvent;
            //_mainForm.DepartmentEvent -= DepartmentEvent;
            //_mainForm.ProductPulloutLogEvent -= ProductPulloutLogEvent;

            _mainForm.AllowanceEvent += AllowanceEvent;
            _mainForm.AttendanceEvent += AttendanceEvent;
            _mainForm.BenefitEvent += BenefitEvent;
            _mainForm.BonusEvent += BonusEvent;
            _mainForm.ContributionEvent += ContributionEvent;
            _mainForm.CustomerEvent += CustomerEvent;
            _mainForm.CustomerTypeEvent += CustomerTypeEvent;
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
            _mainForm.HolidayEvent += HolidayEvent;
            _mainForm.EmployeeEvent += EmployeeEvent;
            _mainForm.DepartmentEvent += DepartmentEvent;
            _mainForm.ProductPulloutLogEvent += ProductPulloutLogEvent;

            if (!(Settings.Default.Department == Departments.Payroll.ToString()))
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

        private void DepartmentEvent(object? sender, EventArgs e)
        {
            IDepartmentView view = ChildManager<DepartmentView>.GetChildInstance((MainForm)_mainForm);
            if (_departmentPresenter == null || ((Form)view).IsDisposed)
                _departmentPresenter = new DepartmentPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void EmployeeEvent(object? sender, EventArgs e)
        {
            IEmployeeView view = ChildManager<EmployeeView>.GetChildInstance((MainForm)_mainForm);
            if (_employeePresenter == null || ((Form)view).IsDisposed)
                _employeePresenter = new EmployeePresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void HolidayEvent(object? sender, EventArgs e)
        {
            IHolidayView view = (IHolidayView)ChildManager<HolidayView>.GetChildInstance((MainForm)_mainForm);
            if (_holidayPresenter == null || ((Form)view).IsDisposed)
                _holidayPresenter = new HolidayPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void CustomerTypeEvent(object? sender, EventArgs e)
        {
            ICustomerTypeView view = (ICustomerTypeView)ChildManager<CustomerTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_customerTypePresenter == null || ((Form)view).IsDisposed)
                _customerTypePresenter = new CustomerTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void CustomerEvent(object? sender, EventArgs e)
        {
            ICustomerView view = (ICustomerView)ChildManager<CustomerView>.GetChildInstance((MainForm)_mainForm);
            if (_customerPresenter == null || ((Form)view).IsDisposed)
                _customerPresenter = new CustomerPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void PayrollEvent(object? sender, EventArgs e)
        {
            IPayrollView view = (IPayrollView)ChildManager<PayrollView>.GetChildInstance((MainForm)_mainForm);
            if (_payrollPresenter == null || ((Form)view).IsDisposed)
                _payrollPresenter = new PayrollPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void RegisterAccountEvent(object? sender, EventArgs e)
        {
            IRegisterView view = (IRegisterView)ChildManager<RegisterView>.GetChildInstance((MainForm)_mainForm);
            if (_registerPresenter == null || ((Form)view).IsDisposed)
                _registerPresenter = new RegisterPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void ProfileEvent(object? sender, EventArgs e)
        {
            IProfileView view = (IProfileView)ChildManager<ProfileView>.GetChildInstance((MainForm)_mainForm);
            if (_profilePresenter == null || ((Form)view).IsDisposed)
                _profilePresenter = new ProfilePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void ProductMonitoringEvent(object? sender, EventArgs e)
        {
            IProductMonitoringView view = ChildManager<ProductMonitoringView>.GetChildInstance((MainForm)_mainForm);
            if (_productMonitoringPresenter == null || ((Form)view).IsDisposed)
                _productMonitoringPresenter = new ProductMonitoringPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void DashboardEvent(object? sender, EventArgs e)
        {
            IDashboardView view = (IDashboardView)ChildManager<DashboardView>.GetChildInstance((MainForm)_mainForm);
            if (_dashboardPresenter == null || ((Form)view).IsDisposed)
                _dashboardPresenter = new DashboardPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void WarehouseEvent(object? sender, EventArgs e)
        {
            IWarehouseView view = (IWarehouseView)ChildManager<WarehouseView>.GetChildInstance((MainForm)_mainForm);
            if (_warehousePresenter == null || ((Form)view).IsDisposed)
                _warehousePresenter = new WarehousePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void VendorTypeEvent(object? sender, EventArgs e)
        {
            IVendorTypeView view = (IVendorTypeView)ChildManager<VendorTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_vendorTypePresenter == null || ((Form)view).IsDisposed)
                _vendorTypePresenter = new VendorTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void VendorEvent(object? sender, EventArgs e)
        {
            IVendorView view = (IVendorView)ChildManager<VendorView>.GetChildInstance((MainForm)_mainForm);
            if (_vendorPresenter == null || ((Form)view).IsDisposed)
                _vendorPresenter = new VendorPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void UnitOfMeasureEvent(object? sender, EventArgs e)
        {
            IUnitOfMeasureView view = (IUnitOfMeasureView)ChildManager<UnitOfMeasureView>.GetChildInstance((MainForm)_mainForm);
            if (_unitOfMeasurePresenter == null || ((Form)view).IsDisposed)
                _unitOfMeasurePresenter = new UnitOfMeasurePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void TargetGoalsEvent(object? sender, EventArgs e)
        {
            ITargetGoalsView view = (ITargetGoalsView)ChildManager<TargetGoalsView>.GetChildInstance((MainForm)_mainForm);
            if (_targetGoalsPresenter == null || ((Form)view).IsDisposed)
                _targetGoalsPresenter = new TargetGoalsPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ShipmentTypeEvent(object? sender, EventArgs e)
        {
            IShipmentTypeView view = (IShipmentTypeView)ChildManager<ShipmentTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_shipmentTypePresenter == null || ((Form)view).IsDisposed)
                _shipmentTypePresenter = new ShipmentTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void SalesTypeEvent(object? sender, EventArgs e)
        {
            ISalesTypeView view = (ISalesTypeView)ChildManager<SalesTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_salesTypePresenter == null || ((Form)view).IsDisposed)
                _salesTypePresenter = new SalesTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void SalesReportEvent(object? sender, EventArgs e)
        {
            ISalesReportView view = (ISalesReportView)ChildManager<SalesReportView>.GetChildInstance((MainForm)_mainForm);
            if (_salesReportPresenter == null || ((Form)view).IsDisposed)
                _salesReportPresenter = new SalesReportPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void SalesOrderEvent(object? sender, EventArgs e)
        {
            ISalesOrderView view = (ISalesOrderView)ChildManager<SalesOrderView>.GetChildInstance((MainForm)_mainForm);
            if (_salesOrderPresenter == null || ((Form)view).IsDisposed)
                _salesOrderPresenter = new SalesOrderPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void PurchaseTypeEvent(object? sender, EventArgs e)
        {
            IPurchaseTypeView view = (IPurchaseTypeView)ChildManager<PurchaseTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_purchaseTypePresenter == null || ((Form)view).IsDisposed)
                _purchaseTypePresenter = new PurchaseTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void PurchaseReportEvent(object? sender, EventArgs e)
        {
            IPurchasesReportView view = (IPurchasesReportView)ChildManager<PurchasesReportView>.GetChildInstance((MainForm)_mainForm);
            if (_purchasesReportPresenter == null || ((Form)view).IsDisposed)
                _purchasesReportPresenter = new PurchasesReportPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void PurchaseOrderEvent(object? sender, EventArgs e)
        {
            IPurchaseOrderView view = (IPurchaseOrderView)ChildManager<PurchaseOrderView>.GetChildInstance((MainForm)_mainForm);
            if (_purchaseOrderPresenter == null || ((Form)view).IsDisposed)
                _purchaseOrderPresenter = new PurchaseOrderPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ProductTypeEvent(object? sender, EventArgs e)
        {
            IProductTypeView view = (IProductTypeView)ChildManager<ProductTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_productTypePresenter == null || ((Form)view).IsDisposed)
                _productTypePresenter = new ProductTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void StockInLogEvent(object? sender, EventArgs e)
        {
            IProductStockInLogView view = (IProductStockInLogView)ChildManager<ProductStockInLogView>.GetChildInstance((MainForm)_mainForm);
            if (_productStockInLogPresenter == null || ((Form)view).IsDisposed)
                _productStockInLogPresenter = new ProductStockInLogPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ProductPulloutLogEvent(object? sender, EventArgs e)
        {
            IProductPullOutLogView view = (IProductPullOutLogView)ChildManager<ProductPullOutLogView>.GetChildInstance((MainForm)_mainForm);
            if (_productPullOutLogPresenter == null || ((Form)view).IsDisposed)
                _productPullOutLogPresenter = new ProductPullOutLogPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ProductEvent(object? sender, EventArgs e)
        {
            IProductView view = (IProductView)ChildManager<ProductView>.GetChildInstance((MainForm)_mainForm);
            if (_productPresenter == null || ((Form)view).IsDisposed)
                _productPresenter = new ProductPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void PaymentTypeEvent(object? sender, EventArgs e)
        {
            IPaymentTypeView view = (IPaymentTypeView)ChildManager<PaymentTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_paymentTypePresenter == null || ((Form)view).IsDisposed)
                _paymentTypePresenter = new PaymentTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void InvoiceTypeEvent(object? sender, EventArgs e)
        {
            IInvoiceTypeView view = (IInvoiceTypeView)ChildManager<InvoiceTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_invoiceTypePresenter == null || ((Form)view).IsDisposed)
                _invoiceTypePresenter = new InvoiceTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void CashBankEvent(object? sender, EventArgs e)
        {
            ICashBankView view = (ICashBankView)ChildManager<CashBankView>.GetChildInstance((MainForm)_mainForm);
            if (_cashBankPresenter == null || ((Form)view).IsDisposed)
                _cashBankPresenter = new CashBankPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void BranchEvent(object? sender, EventArgs e)
        {
            IBranchView view = (IBranchView)ChildManager<BranchView>.GetChildInstance((MainForm)_mainForm);
            if (_branchPresenter == null || ((Form)view).IsDisposed)
                _branchPresenter = new BranchPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void BillTypeEvent(object? sender, EventArgs e)
        {
            IBillTypeView view = (IBillTypeView)ChildManager<BillTypeView>.GetChildInstance((MainForm)_mainForm);
            if (_billTypePresenter == null || ((Form)view).IsDisposed)
                _billTypePresenter = new BillTypePresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void TaxEvent(object? sender, EventArgs e)
        {
            ITaxView view = (ITaxView)ChildManager<TaxView>.GetChildInstance((MainForm)_mainForm);
            if (_taxPresenter == null || ((Form)view).IsDisposed)
                _taxPresenter = new TaxPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ShiftEvent(object? sender, EventArgs e)
        {
            IShiftView view = (IShiftView)ChildManager<ShiftView>.GetChildInstance((MainForm)_mainForm);
            if (_shiftPresenter == null || ((Form)view).IsDisposed)
                _shiftPresenter = new ShiftPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void ProjectEvent(object? sender, EventArgs e)
        {
            IProjectView view = (IProjectView)ChildManager<ProjectView>.GetChildInstance((MainForm)_mainForm);
            if (_projectPresenter == null || ((Form)view).IsDisposed)
                _projectPresenter = new ProjectPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void LeaveEvent(object? sender, EventArgs e)
        {
            ILeaveView view = (ILeaveView)ChildManager<LeaveView>.GetChildInstance((MainForm)_mainForm);
            if (_leavePresenter == null || ((Form)view).IsDisposed)
                _leavePresenter = new LeavePresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void JobPositionEvent(object? sender, EventArgs e)
        {
            IJobPositionView view = (IJobPositionView)ChildManager<JobPositionView>.GetChildInstance((MainForm)_mainForm);
            if (_jobPositionPresenter == null || ((Form)view).IsDisposed)
                _jobPositionPresenter = new JobPositionPresenter(view, _unitOfWork);
            ((Form)view).BringToFront();
        }

        private void DeductionEvent(object? sender, EventArgs e)
        {
            IDeductionView view = (IDeductionView)ChildManager<DeductionView>.GetChildInstance((MainForm)_mainForm);
            if (_deductionPresenter == null || ((Form)view).IsDisposed)
                _deductionPresenter = new DeductionPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void ContributionEvent(object? sender, EventArgs e)
        {
            IEmployeeContributionView view = (IEmployeeContributionView)ChildManager<EmployeeContributionView>.GetChildInstance((MainForm)_mainForm);
            if (_employeeContributionPresenter == null || ((Form)view).IsDisposed)
                _employeeContributionPresenter = new EmployeeContributionPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void BonusEvent(object? sender, EventArgs e)
        {
            IBonusView view = (IBonusView)ChildManager<BonusView>.GetChildInstance((MainForm)_mainForm);
            if (_bonusPresenter == null || ((Form)view).IsDisposed)
                _bonusPresenter = new BonusPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void BenefitEvent(object? sender, EventArgs e)
        {
            IBenefitView view = (IBenefitView)ChildManager<BenefitView>.GetChildInstance((MainForm)_mainForm);
            if (_benefitPresenter == null || ((Form)view).IsDisposed)
                _benefitPresenter = new BenefitPresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void AttendanceEvent(object? sender, EventArgs e)
        {
            IAttendanceView view = (IAttendanceView)ChildManager<AttendanceView>.GetChildInstance((MainForm)_mainForm);
            if (_attendancePresenter == null || ((Form)view).IsDisposed)
                _attendancePresenter = new AttendancePresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }

        private void AllowanceEvent(object? sender, EventArgs e)
        {
            IAllowanceView view = (IAllowanceView)ChildManager<AllowanceView>.GetChildInstance((MainForm)_mainForm);
            if (_allowancePresenter == null || ((Form)view).IsDisposed)
                _allowancePresenter = new AllowancePresenter(view, _unitOfWork, _eventAggregator);
            ((Form)view).BringToFront();
        }
    }
}
