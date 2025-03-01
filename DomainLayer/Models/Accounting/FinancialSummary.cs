using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Accounting
{
    public class FinancialSummary
    {
        public decimal TotalAssets { get; private set; }
        public decimal TotalLiabilities { get; private set; }
        public decimal TotalEquity { get; private set; }
        public decimal TotalRevenue { get; private set; }
        public decimal TotalExpenses { get; private set; }
        public decimal NetProfit => TotalRevenue - TotalExpenses;

        public void Calculate(List<ChartOfAccount> accounts)
        {
            TotalAssets = accounts.Where(a => a.Category == AccountCategory.Asset).Sum(a => a.Balance);
            TotalLiabilities = accounts.Where(a => a.Category == AccountCategory.Liability).Sum(a => a.Balance);
            TotalEquity = accounts.Where(a => a.Category == AccountCategory.Equity).Sum(a => a.Balance);
            TotalRevenue = accounts.Where(a => a.Category == AccountCategory.Revenue).Sum(a => a.Balance);
            TotalExpenses = accounts.Where(a => a.Category == AccountCategory.Expense).Sum(a => a.Balance);
        }
    }
}
