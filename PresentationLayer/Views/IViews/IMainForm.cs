using Syncfusion.Windows.Forms.Tools;

namespace RavenTech_ERP.Views.IViews
{
    public interface IMainForm
    {
        event EventHandler ProjectDashboardEvent;
        event EventHandler ExamEvent;
        event EventHandler ExamFormatEvent;
        event EventHandler ExamTopicEvent;
        event EventHandler ReviewTopicEvent;
        event EventHandler AllowanceEvent;
        event EventHandler AttendanceEvent;
        event EventHandler BenefitEvent;
        event EventHandler BillTypeEvent;
        event EventHandler BonusEvent;
        event EventHandler BranchEvent;
        event EventHandler CashBankEvent;
        event EventHandler ContributionEvent;
        event EventHandler CustomerEvent;
        event EventHandler CustomerTypeEvent;
        event EventHandler DashboardEvent;
        event EventHandler DeductionEvent;
        event EventHandler DepartmentEvent;
        event EventHandler EmployeeEvent;
        event EventHandler InvoiceTypeEvent;
        event EventHandler JobPositionEvent;
        event EventHandler LeaveEvent;
        event EventHandler PaymentTypeEvent;
        event EventHandler PayrollEvent;
        event EventHandler ProductEvent;
        event EventHandler ProductMonitoringEvent;
        event EventHandler ProductTypeEvent;
        event EventHandler ProjectEvent;
        event EventHandler PurchaseOrderEvent;
        event EventHandler PurchaseReportEvent;
        event EventHandler PurchaseTypeEvent;
        event EventHandler SalesOrderEvent;
        event EventHandler SalesReportEvent;
        event EventHandler SalesTypeEvent;
        event EventHandler ShiftEvent;
        event EventHandler ShipmentTypeEvent;
        event EventHandler StockInLogEvent;
        event EventHandler TargetGoalsEvent;
        event EventHandler TaxEvent;
        event EventHandler UnitOfMeasureEvent;
        event EventHandler VendorEvent;
        event EventHandler VendorTypeEvent;
        event EventHandler WarehouseEvent;
        event EventHandler HolidayEvent;
        event EventHandler ProductPulloutLogEvent;

        event EventHandler ProfileEvent;
        event EventHandler EditProfileEvent;
        event EventHandler ChangePasswordEvent;
        event EventHandler RegisterAccountEvent;
        RibbonControlAdv ribbonControl { get; }
        ToolStripTabItem InventoryTab { get; set; }
        ToolStripTabItem PayrollTab { get; set; }
        ToolStripEx RegisterButton { get; set; }
        void ShowForm();
    }
}