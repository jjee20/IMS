using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Properties;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
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
    public partial class PayrollView : SfForm, IPayrollView
    {
        private string message;
        private bool success;
        public PayrollView()
        {
            InitializeComponent();

            btnPrint.Click += (s, e) =>
            {

                PrintPayrollEvent?.Invoke(s, e);
            };
            dgList.CellClick += (s, e) =>
            {

                if (e.DataColumn.GridColumn.MappingName == "Payslip")
                {
                    PrintPaySlipEvent?.Invoke(s, e);
                }
                else if (e.DataColumn.GridColumn.MappingName == "TMonth")
                {
                    TMonthEvent?.Invoke(s, e);
                }
            };
        }

        public void SetPayrollListBindingSource(IEnumerable<PayrollViewModel> PayrollList)
        {
            dgPager.DataSource = PayrollList;

            foreach (var e in PayrollList)
            {
                e.TMonth = Resources.thirteen; // Or any other image per row
                e.Payslip = Resources.payslip;
            }
            dgList.DataSource = dgPager.PagedSource;
        }
        public void SetProjectListBindingSource(BindingSource ProjectList)
        {
            txtProject.DataSource = ProjectList;
            txtProject.DisplayMember = "ProjectName";
            txtProject.ValueMember = "ProjectId";
        }

        private static PayrollView? instance;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartDate { get => txtStartDate.Value.Date; set => txtStartDate.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EndDate { get => txtEndDate.Value.Date; set => txtEndDate.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProjectId
        {
            get
            {
                if (txtProject.SelectedItem is Project project)
                    return project.ProjectId;
                return 0;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IncludeContribution { get => btnContribution.Checked; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IncludeBenefits { get => btnBenifits.Checked; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool All { get => btnAll.Checked; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }


        public SfDataGrid DataGrid => dgList;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful { get => success; set => success = value; }

        public event EventHandler PrintPayrollEvent;
        public event EventHandler SearchEvent;
        public event CellClickEventHandler TMonthEvent;
        public event CellClickEventHandler PrintPaySlipEvent;

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

        private void PayrollView_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            txtStartDate.Value = startDate;
            txtEndDate.Value = endDate;

            panelProject.Width = 153;
        }

        private void btnAll_CheckedChanged(object sender, EventArgs e)
        {
            txtProject.Visible = !btnAll.Checked;
            panelProject.Width = btnAll.Checked ? btnAll.Width : btnAll.Width + txtProject.Width;
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtStartDate_ValueChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtEndDate_ValueChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnBenifits_CheckedChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnContribution_CheckedChanged(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        private void txtProject_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
