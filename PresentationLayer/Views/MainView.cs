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
    public partial class MainView : SfForm
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void btnThinkEEDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnReviewTopic_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnExam_Click(object sender, EventArgs e)
        {

        }

        private void btnExamTopic_Click(object sender, EventArgs e)
        {

        }

        private void btnExamFormat_Click(object sender, EventArgs e)
        {

        }

        private void btnAvailableExam_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboardHome_Click(object sender, EventArgs e)
        {

        }

        private void btnSalesOrders_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnInvoices_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCustomers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPayments_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPurchaseOrders_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnBillsOrVouchers_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnVendors_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnProducts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnStockOperations_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnWarehouses_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnBranches_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnUnits_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCashOrBank_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnJournalEntry_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnChartOfAccounts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnBudgets_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnEmployees_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAttendance_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAllowancesOrBenefits_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnDeductionsOrContributions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPayrollRun_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPaylips_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnTax_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnProjectDashboard_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnProjects_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewSalesOrder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnApproveOrCancel_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewInvoice_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPrintOrEmail_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewCustomer_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnReceivePayment_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSalesReceipt_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewPurchaseOrder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewBill_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPayBill_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewVendor_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewProduct_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAdjustStock_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnStockIn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnStockOut_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnTransfers_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewWarehouse_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewBranch_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewUnit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewTransaction_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnReconcile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewEntry_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewAccount_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewBudget_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewEmployee_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAddNewAttendance_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewAllowanceOrBenefit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewDeduction_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnProcessPayroll_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPostToLedger_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnGenerateOrPrintPayslips_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewTax_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNewProject_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnBalanceSheet_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnIncomeStatement_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnTrialBalance_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSalesReports_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnTopProducts_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCustomerStatements_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPurchaseReports_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnVendorStatements_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnInventoryValuation_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnStockReports_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPayrollSummaries_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnContributionReports_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}