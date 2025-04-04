using MaterialSkin;
using MaterialSkin.Controls;
using RavenTech_ERP.Views.IViews.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Accounting
{
    public partial class AccountingView : MaterialForm, IAccountingView
    {
        public AccountingView()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var colorScheme = new ColorScheme(
                                ColorTranslator.FromHtml("#457b9d"),
                                ColorTranslator.FromHtml("#1d3557"),
                                ColorTranslator.FromHtml("#f1faee"),
                                ColorTranslator.FromHtml("#457b9d"),
                                TextShade.WHITE // text shade
            );

            materialSkinManager.ColorScheme = colorScheme;

            if (tcMain.SelectedTab == tbPayroll)
            {
                ShowPayrollEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbAccount)
            {
                ShowAccountEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbBudget)
            {
                ShowBudgetEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbChartOfAccount)
            {
                ShowChartOfAccountEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbFinancialTransaction)
            {
                ShowFinancialTransactionEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbInvoice)
            {
                ShowInvoiceEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (tcMain.SelectedTab == tbLedgerEntry)
            {
                ShowLedgerEntryEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ShowPayrollEvent;
        public event EventHandler ShowAccountEvent;
        public event EventHandler ShowBudgetEvent;
        public event EventHandler ShowChartOfAccountEvent;
        public event EventHandler ShowFinancialTransactionEvent;
        public event EventHandler ShowInvoiceEvent;
        public event EventHandler ShowLedgerEntryEvent;
    }
}
