using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Views.IViews;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using System.ComponentModel;

namespace RavenTech_ERP
{
    public partial class MainForm : SfForm, IMainForm
    {
        public MainForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            btnAllowance.Click += delegate { AllowanceEvent?.Invoke(this, EventArgs.Empty); };
            btnAttendance.Click += delegate { AttendanceEvent?.Invoke(this, EventArgs.Empty); };
            btnBenefit.Click += delegate { BenefitEvent?.Invoke(this, EventArgs.Empty); };
            btnBonus.Click += delegate { BonusEvent?.Invoke(this, EventArgs.Empty); };
            btnContribution.Click += delegate { ContributionEvent?.Invoke(this, EventArgs.Empty); };
            btnDeduction.Click += delegate { DeductionEvent?.Invoke(this, EventArgs.Empty); };
            btnDepartment.Click += delegate { DepartmentEvent?.Invoke(this, EventArgs.Empty); };
            btnEmployee.Click += delegate { EmployeeEvent?.Invoke(this, EventArgs.Empty); };
            btnJobPosition.Click += delegate { JobPositionEvent?.Invoke(this, EventArgs.Empty); };
            btnLeave.Click += delegate { LeaveEvent?.Invoke(this, EventArgs.Empty); };
            btnPayroll.Click += delegate { PayrollEvent?.Invoke(this, EventArgs.Empty); };
            btnProject.Click += delegate { ProjectEvent?.Invoke(this, EventArgs.Empty); };
            btnShift.Click += delegate { ShiftEvent?.Invoke(this, EventArgs.Empty); };
            btnTax.Click += delegate { TaxEvent?.Invoke(this, EventArgs.Empty); };
            btnBillType.Click += delegate { BillTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnBranch.Click += delegate { BranchEvent?.Invoke(this, EventArgs.Empty); };
            btnCashBank.Click += delegate { CashBankEvent?.Invoke(this, EventArgs.Empty); };
            btnCustomerType.Click += delegate { CustomerTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnCustomer.Click += delegate { CustomerEvent?.Invoke(this, EventArgs.Empty); };
            btnInvoiceType.Click += delegate { InvoiceTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnPaymentType.Click += delegate { PaymentTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnStockInLog.Click += delegate { StockInLogEvent?.Invoke(this, EventArgs.Empty); };
            btnProductType.Click += delegate { ProductTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnProduct.Click += delegate { ProductEvent?.Invoke(this, EventArgs.Empty); };
            btnProject.Click += delegate { ProjectEvent?.Invoke(this, EventArgs.Empty); };
            btnPurchaseOrder.Click += delegate { PurchaseOrderEvent?.Invoke(this, EventArgs.Empty); };
            btnPurchaseType.Click += delegate { PurchaseTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnSalesOrder.Click += delegate { SalesOrderEvent?.Invoke(this, EventArgs.Empty); };
            btnSalesType.Click += delegate { SalesTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnShipmentType.Click += delegate { ShipmentTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnTargetGoals.Click += delegate { TargetGoalsEvent?.Invoke(this, EventArgs.Empty); };
            btnUOM.Click += delegate { UnitOfMeasureEvent?.Invoke(this, EventArgs.Empty); };
            btnVendorType.Click += delegate { VendorTypeEvent?.Invoke(this, EventArgs.Empty); };
            btnVendor.Click += delegate { VendorEvent?.Invoke(this, EventArgs.Empty); };
            btnWarehouse.Click += delegate { WarehouseEvent?.Invoke(this, EventArgs.Empty); };
            btnPurchaseReport.Click += delegate { PurchaseReportEvent?.Invoke(this, EventArgs.Empty); };
            btnSalesReport.Click += delegate { SalesReportEvent?.Invoke(this, EventArgs.Empty); };
            btnProfile.Click += delegate { ProfileEvent?.Invoke(this, EventArgs.Empty); };
            btnRegisterAccount.Click += delegate { RegisterAccountEvent?.Invoke(this, EventArgs.Empty); };
            btnDashboard.Click += delegate { DashboardEvent?.Invoke(this, EventArgs.Empty); };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RibbonControlAdv ribbonControl { get => ribbonControlMain ; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTabItem InventoryTab { get => btnInventory; set => btnInventory = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTabItem PayrollTab { get => btnPayrollMain; set => btnPayrollMain = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripEx RegisterButton { get => btnRegisterAccount; set => btnRegisterAccount = value; }

        public event EventHandler ProfileEvent;
        public event EventHandler EditProfileEvent;
        public event EventHandler ChangePasswordEvent;
        public event EventHandler RegisterAccountEvent;
        public event EventHandler AllowanceEvent;
        public event EventHandler AttendanceEvent;
        public event EventHandler BenefitEvent;
        public event EventHandler BonusEvent;
        public event EventHandler ContributionEvent;
        public event EventHandler DeductionEvent;
        public event EventHandler DepartmentEvent;
        public event EventHandler EmployeeEvent;
        public event EventHandler JobPositionEvent;
        public event EventHandler LeaveEvent;
        public event EventHandler PayrollEvent;
        public event EventHandler ProjectEvent;
        public event EventHandler ShiftEvent;
        public event EventHandler TaxEvent;
        public event EventHandler BillTypeEvent;
        public event EventHandler BranchEvent;
        public event EventHandler CashBankEvent;
        public event EventHandler CustomerTypeEvent;
        public event EventHandler CustomerEvent;
        public event EventHandler DashboardEvent;
        public event EventHandler InvoiceTypeEvent;
        public event EventHandler PaymentTypeEvent;
        public event EventHandler StockInLogEvent;
        public event EventHandler ProductEvent;
        public event EventHandler ProductMonitoringEvent;
        public event EventHandler ProductTypeEvent;
        public event EventHandler PurchaseOrderEvent;
        public event EventHandler PurchaseTypeEvent;
        public event EventHandler PurchaseReportEvent;
        public event EventHandler SalesOrderEvent;
        public event EventHandler SalesReportEvent;
        public event EventHandler SalesTypeEvent;
        public event EventHandler ShipmentTypeEvent;
        public event EventHandler TargetGoalsEvent;
        public event EventHandler UnitOfMeasureEvent;
        public event EventHandler VendorTypeEvent;
        public event EventHandler VendorEvent;
        public event EventHandler WarehouseEvent;

        public void ShowForm()
        {
            Show();
        }
    }
}
