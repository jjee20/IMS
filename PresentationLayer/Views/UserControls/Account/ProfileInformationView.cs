using DomainLayer.ViewModels.PayrollViewModels;
using MaterialSkin.Controls;
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
    public partial class ProfileInformationView: MaterialForm
    {
        private readonly UserInformationViewModel _employee;

        public ProfileInformationView(UserInformationViewModel employee)
        {
            _employee = employee;
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            txtId.Text = _employee.EmployeeId.ToString();
            txtName.Text = _employee.Name;
            txtDateOfBirth.Text = _employee.DateOfBirth.ToString();
            txtGender.Text = _employee.Gender;
            txtContactNo.Text = _employee.ContactNumber;
            txtEmail.Text = _employee.Email;
            txtBasicSalary.Text = _employee.BasicSalary.ToString();
            txtLeaveCredits.Text = _employee.LeaveCredits.ToString();
            txtAddress.Text = _employee.Address;
            txtDepartment.Text = _employee.Department;
            txtJobPosition.Text = _employee.JobPosition;
            txtShift.Text = _employee.Shift;
            txtIsDeducted.Text = _employee.isDeducted;
            txtSSSS.Text = _employee.Contribution.SSS.ToString();
            txtPhilHealth.Text = _employee.Contribution.PhilHealth.ToString();
            txtPagibig.Text = _employee.Contribution.PagIbig.ToString();
            txtSSSWISP.Text = _employee.Contribution.SSSWISP.ToString();
            dgAllowances.DataSource = _employee.Allowances.OrderByDescending(c => c.AllowanceId).ToList();
            dgAttendances.DataSource = _employee.Attendances.OrderByDescending(c => c.AttendanceId).ToList();
            dgBenefits.DataSource = _employee.Benefits.OrderByDescending(c => c.BenefitId).ToList();
            dgBonuses.DataSource = _employee.Bonuses.OrderByDescending(c => c.BonusId).ToList();
            dgDeductions.DataSource = _employee.Deductions.OrderByDescending(c => c.DeductionId).ToList();
            dgLeaves.DataSource = _employee.Leaves.OrderByDescending(c => c.LeaveId).ToList();
        }
    }
}
