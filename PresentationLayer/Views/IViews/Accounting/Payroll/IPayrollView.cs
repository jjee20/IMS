﻿using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace RevenTech_ERP.Views.IViews.Accounting.Payroll
{
    public interface IPayrollView
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeContribution { get; }
        public bool IncludeBenefits { get; }
        string Message { get; set; }
        event EventHandler PrintPayrollEvent;
        event DataGridViewCellEventHandler PrintPayslipEvent;
        event EventHandler SearchEvent; 
        event EventHandler IncludeBenefitsEvent;
        void SetPayrollListBindingSource(BindingSource PayrollList);
    }
}