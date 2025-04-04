using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
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

            txtProject.SelectionChangeCommitted += delegate
            {
                ProjectEvent?.Invoke(this, EventArgs.Empty);
            };
            btnAll.CheckedChanged += delegate
            {
                AllEvent?.Invoke(this, EventArgs.Empty);
            };

            btnBenifits.CheckedChanged += (s, e) => IncludeBenefitsEvent?.Invoke(this, EventArgs.Empty);
        }

        public void SetPayrollListBindingSource(IEnumerable<PayrollViewModel> PayrollList)
        {
            dgPager.DataSource = PayrollList;
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
        public int ProjectId {
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

        public event EventHandler PrintPayrollEvent;
        public event EventHandler PrintPayslipEvent;
        public event EventHandler SearchEvent;
        public event EventHandler IncludeBenefitsEvent;
        public event EventHandler ProjectEvent;
        public event EventHandler AllEvent;

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
        }
    }
}
