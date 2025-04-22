using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin.Controls;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Account
{
    public partial class EmployeeInformationView: SfForm
    {
        private readonly UserInformationViewModel _employee;

        public EmployeeInformationView(UserInformationViewModel employee)
        {
            _employee = employee;
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            txtId.Text = _employee.EmployeeId.ToString();
            txtName.Text = _employee.Name ?? "{Needs Updating}";
            txtDateOfBirth.Text = _employee.DateOfBirth.ToString() ?? "{Needs Updating}";
            txtGender.Text = _employee.Gender ?? "{Needs Updating}";
            txtContactNo.Text = _employee.ContactNumber ?? "{Needs Updating}";
            txtEmail.Text = _employee.Email ?? "{Needs Updating}";
            txtBasicSalary.Text = _employee.BasicSalary.ToString() ?? "{Needs Updating}";
            txtLeaveCredits.Text = _employee.LeaveCredits.ToString() ?? "{Needs Updating}";
            txtAddress.Text = _employee.Address ?? "{Needs Updating}";
            txtDepartment.Text = _employee.Department ?? "{Needs Updating}";
            txtJobPosition.Text = _employee.JobPosition ?? "{Needs Updating}";
            txtShift.Text = _employee.Shift ?? "{Needs Updating}";
            txtIsDeducted.Text = _employee.isDeducted ?? "{Needs Updating}";
            txtSSSS.Text = _employee.Contribution.SSS.ToString() ?? "{Needs Updating}";
            txtPhilHealth.Text = _employee.Contribution.PhilHealth.ToString() ?? "{Needs Updating}";
            txtPagibig.Text = _employee.Contribution.PagIbig.ToString() ?? "{Needs Updating}";
            txtSSSWISP.Text = _employee.Contribution.SSSWISP.ToString() ?? "{Needs Updating}";
            dgAllowances.DataSource = _employee.Allowances.OrderByDescending(c => c.AllowanceId).ToList();
            dgAttendances.DataSource = _employee.Attendances.OrderByDescending(c => c.AttendanceId).ToList();
            dgBenefits.DataSource = _employee.Benefits.OrderByDescending(c => c.BenefitId).ToList();
            dgBonuses.DataSource = _employee.Bonuses.OrderByDescending(c => c.BonusId).ToList();
            dgDeductions.DataSource = _employee.Deductions.OrderByDescending(c => c.DeductionId).ToList();
            dgLeaves.DataSource = _employee.Leaves.OrderByDescending(c => c.LeaveId).ToList();
        }
    }
}
