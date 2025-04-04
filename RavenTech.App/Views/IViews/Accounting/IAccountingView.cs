namespace RavenTech_ERP.Views.IViews.Accounting
{
    public interface IAccountingView
    {
        event EventHandler ShowAccountEvent;
        event EventHandler ShowBudgetEvent;
        event EventHandler ShowChartOfAccountEvent;
        event EventHandler ShowFinancialTransactionEvent;
        event EventHandler ShowInvoiceEvent;
        event EventHandler ShowLedgerEntryEvent;
        event EventHandler ShowPayrollEvent;
    }
}