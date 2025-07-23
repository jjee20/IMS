using System.ComponentModel;
using DomainLayer.Enums;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Helpers;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP
{
    public partial class MainForm : SfForm, IMainForm
    {

        private List<TaskRoles> appUserRoles = new();
        private Departments department;
        public MainForm()
        {
            appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);
            department = (Departments)Enum.Parse(typeof(Departments), Settings.Default.Department);
            InitializeComponent();

            SetPermissions();
        }

        private void SetPermissions()
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                btnRegisterAccount.Visible = false;
                btnAllowance.Visible = false;
                btnAttendance.Visible = false;
                btnBenefit.Visible = false;
                btnBonus.Visible = false;
                btnContribution.Visible = false;
                btnDeduction.Visible = false;
                btnDepartment.Visible = false;
                btnEmployee.Visible = false;
                btnJobPosition.Visible = false;
                btnLeave.Visible = false;
                btnPayroll.Visible = false;
                btnShift.Visible = false;
                btnTax.Visible = false;
                btnBillType.Visible = false;
                btnBranch.Visible = false;
                btnCashBank.Visible = false;
                btnCustomerType.Visible = false;
                btnCustomer.Visible = false;
                btnDashboard.Visible = false;
                btnInvoiceType.Visible = false;
                btnPaymentType.Visible = false;
                btnStockMonitoring.Visible = false;
                btnProductType.Visible = false;
                btnPurchaseOrder.Visible = false;
                btnPurchaseType.Visible = false;
                btnPurchaseReport.Visible = false;
                btnSalesOrder.Visible = false;
                btnSalesReport.Visible = false;
                btnSalesType.Visible = false;
                btnShipmentType.Visible = false;
                btnTargetGoals.Visible = false;
                btnUOM.Visible = false;
                btnVendorType.Visible = false;
                btnVendor.Visible = false;
                btnWarehouse.Visible = false;
                btnHoliday.Visible = false;
                btnPullOutLog.Visible = false;
                btnStockInLog.Visible = false;
                btnProjectDashboard.Visible = false;
                btnProject.Visible = false;
            }
            else if (appUserRoles != null && appUserRoles.Contains(TaskRoles.Taker))
            {
                btnRegisterAccount.Visible = false;
                btnAllowance.Visible = false;
                btnAttendance.Visible = false;
                btnBenefit.Visible = false;
                btnBonus.Visible = false;
                btnContribution.Visible = false;
                btnDeduction.Visible = false;
                btnDepartment.Visible = false;
                btnEmployee.Visible = false;
                btnJobPosition.Visible = false;
                btnLeave.Visible = false;
                btnPayroll.Visible = false;
                btnShift.Visible = false;
                btnTax.Visible = false;
                btnBillType.Visible = false;
                btnBranch.Visible = false;
                btnCashBank.Visible = false;
                btnCustomerType.Visible = false;
                btnCustomer.Visible = false;
                btnDashboard.Visible = false;
                btnInvoiceType.Visible = false;
                btnPaymentType.Visible = false;
                btnStockMonitoring.Visible = false;
                btnProductType.Visible = false;
                btnPurchaseOrder.Visible = false;
                btnPurchaseType.Visible = false;
                btnPurchaseReport.Visible = false;
                btnSalesOrder.Visible = false;
                btnSalesReport.Visible = false;
                btnSalesType.Visible = false;
                btnShipmentType.Visible = false;
                btnTargetGoals.Visible = false;
                btnUOM.Visible = false;
                btnVendorType.Visible = false;
                btnVendor.Visible = false;
                btnWarehouse.Visible = false;
                btnHoliday.Visible = false;
                btnPullOutLog.Visible = false;
                btnStockInLog.Visible = false;
                btnProjectDashboard.Visible = false;
                btnProject.Visible = false;
                btnExam.Visible = false;
                btnExamFormat.Visible = false;
                btnExamTopic.Visible = false;
                btnReviewTopic.Visible = false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RibbonControlAdv ribbonControl { get => ribbonControlMain; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTabItem InventoryTab { get => btnInventory; set => btnInventory = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTabItem PayrollTab { get => btnPayrollMain; set => btnPayrollMain = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripEx RegisterButton { get => btnRegisterAccount; set => btnRegisterAccount = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTabItem ThinkEETab { get => btnThinkEE; set => btnThinkEE = value; }

        public event EventHandler ThinkEEDashboardEvent;
        public event EventHandler AvailableExamEvent;
        public event EventHandler ProjectDashboardEvent;
        public event EventHandler ExamEvent;
        public event EventHandler ExamFormatEvent;
        public event EventHandler ExamTopicEvent;
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
        public event EventHandler HolidayEvent;
        public event EventHandler ProductPulloutLogEvent;
        public event EventHandler ReviewTopicEvent;

        public void ShowForm()
        {
            Show();
        }

        private void btnProjectDashboard_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProjectDashboardEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnThinkEEDashboard_Click(object sender, EventArgs e)
        {
            ThinkEEDashboardEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnAvailableExam_Click(object sender, EventArgs e)
        {
            AvailableExamEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            ExamEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnExamFormat_Click(object sender, EventArgs e)
        {
            ExamFormatEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnExamTopic_Click(object sender, EventArgs e)
        {
            ExamTopicEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnReviewTopic_Click(object sender, EventArgs e)
        {
            ReviewTopicEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DashboardEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrderEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PurchaseOrderEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProjectEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            WarehouseEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BranchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VendorEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnCashBank_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CashBankEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesReportEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PurchaseReportEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnTargetGoals_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TargetGoalsEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnAllowance_Click(object sender, EventArgs e)
        {
            AllowanceEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnBenefit_Click(object sender, EventArgs e)
        {
            BenefitEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnBonus_Click(object sender, EventArgs e)
        {
            BonusEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnContribution_Click(object sender, EventArgs e)
        {
            ContributionEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            DeductionEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            LeaveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnJobPosition_Click(object sender, EventArgs e)
        {
            JobPositionEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            TaxEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            ShiftEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnHoliday_Click(object sender, EventArgs e)
        {
            HolidayEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            PayrollEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            RegisterAccountEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnStockMonitoring_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductMonitoringEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnStockInLog_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StockInLogEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnProductType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnUOM_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnitOfMeasureEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnSalesType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnShipmentType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShipmentTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnPaymentType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PaymentTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnPurchaseType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PurchaseTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnInvoiceType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InvoiceTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnBillType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BillTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnCustomerType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnVendorType_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VendorTypeEvent?.Invoke(this, EventArgs.Empty);
        }
        private void btnPullOutLog_Click(object sender, EventArgs e)
        {
            if (appUserRoles != null && (department == Departments.Inventory || department == Departments.Guest) && appUserRoles.Contains(TaskRoles.View))
            {
                MessageBox.Show("You are not authorized to execute this operation. Please contact your administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductPulloutLogEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
