
using MaterialSkin;
using MaterialSkin.Controls;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
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
                                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            materialSkinManager.ColorScheme = colorScheme;

            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbAttendance)
                {
                    ShowAttendance?.Invoke(this, EventArgs.Empty);
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
                else if (tcMain.SelectedTab == tbEmployeeContribution)
                {
                    ShowEmployeeContribution?.Invoke(this, EventArgs.Empty);
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
                else if (tcMain.SelectedTab == tbBenefit)
                {
                    ShowBenefit?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbAllowance)
                {
                    ShowAllowance?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProfile)
                {
                    ShowProfile?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public TabPage Guna2TabControlPage
        {
            get { return tcMain.SelectedTab; }
        }

        public event EventHandler ShowAttendance;
        public event EventHandler ShowDeduction;
        public event EventHandler ShowDepartment;
        public event EventHandler ShowEmployee;
        public event EventHandler ShowJobPosition;
        public event EventHandler ShowLeave;
        public event EventHandler ShowPayroll;
        public event EventHandler ShowProfile;
        public event EventHandler ShowShift;
        public event EventHandler ShowTax;
        public event EventHandler ShowProject;
        public event EventHandler ShowBenefit;
        public event EventHandler ShowAllowance;
        public event EventHandler ShowEmployeeContribution;

        public void ShowForm()
        {
            Show();
        }

        private void PayrollSystemView_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
