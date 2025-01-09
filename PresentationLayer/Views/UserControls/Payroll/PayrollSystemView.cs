using DomainLayer.Models.Payroll;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.Payroll
{
    public partial class PayrollSystemView : MaterialForm, IPayrollSystemView
    {
        public PayrollSystemView()
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

            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbAttendance)
                {
                    ShowAttendance?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbContribution)
                {
                    ShowContribution?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbDeduction)
                {
                    ShowDeduction?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbDepartment)
                {
                    ShowDepartment?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbEmployee)
                {
                    ShowEmployee?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbJobPosition)
                {
                    ShowJobPosition?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbLeave)
                {
                    ShowLeave?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPayroll)
                {
                    ShowPayroll?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbShift)
                {
                    ShowShift?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbTax)
                {
                    ShowTax?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProject)
                {
                    ShowProject?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public TabPage Guna2TabControlPage
        {
            get { return tcMain.SelectedTab; }
        }

        public event EventHandler ShowAttendance;
        public event EventHandler ShowAuditLog;
        public event EventHandler ShowContribution;
        public event EventHandler ShowDashboard;
        public event EventHandler ShowDeduction;
        public event EventHandler ShowDepartment;
        public event EventHandler ShowEmployee;
        public event EventHandler ShowJobPosition;
        public event EventHandler ShowLeave;
        public event EventHandler ShowPayroll;
        public event EventHandler ShowPerformanceReview;
        public event EventHandler ShowProfile;
        public event EventHandler ShowShift;
        public event EventHandler ShowTax;
        public event EventHandler ShowProject;

        public void ShowForm()
        {
            Show();
        }
    }
}
