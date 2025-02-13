using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class PayrollView : UserControl, IPayrollView
    {
        private string message;
        public PayrollView()
        {
            InitializeComponent();

            btnPrint.Click += delegate
            {
                PrintPayrollEvent?.Invoke(this, EventArgs.Empty);
            };
            txtStartDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtEndDate.ValueChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            btnContribution.CheckedChanged += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            dgList.CellDoubleClick += (sender, e) =>
            {
                PrintPayslipEvent?.Invoke(this, e);
            };
        }

        public void SetPayrollListBindingSource(BindingSource PayrollList)
        {
            dgList.DataSource = PayrollList;
            DataGridHelper.ApplyDisplayNames<DomainLayer.ViewModels.PayrollViewModels.PayrollViewModel>(PayrollList, dgList);
        }

        private static PayrollView? instance;

        public DateTime StartDate { get => txtStartDate.Value.Date; set => txtStartDate.Value = value; }
        public DateTime EndDate { get => txtEndDate.Value.Date; set => txtEndDate.Value = value; }
        public bool IncludeContribution { get => btnContribution.Checked; }
        public bool IncludeBenefits { get => btnBenefits.Checked; }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler PrintPayrollEvent;
        public event DataGridViewCellEventHandler PrintPayslipEvent;
        public event EventHandler SearchEvent;

        public static PayrollView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PayrollView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
