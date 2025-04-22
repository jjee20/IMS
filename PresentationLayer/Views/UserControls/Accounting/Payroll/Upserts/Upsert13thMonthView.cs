using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.ViewModels.PayrollViewModels;
using RavenTech_ERP.Helpers;
using ServiceLayer.Services.IRepositories;
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

namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll
{
    public partial class _Upsert13thMonthView : SfForm
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Employee _employeeDetails;

        public _Upsert13thMonthView(PayrollViewModel employeePayroll, IUnitOfWork unitOfWork, Employee employeeDetails)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _employeeDetails = employeeDetails;
            txtId.Text = employeeDetails.EmployeeId.ToString();
            txtName.Text = employeePayroll.Employee ?? "{Needs Updating}";
            txtDepartment.Text = employeeDetails.Department.Name ?? "{Needs Updating}";
            txtRoles.Text = employeeDetails.JobPosition.Title ?? "{Needs Updating}";
            txtRate.Text = employeePayroll.BasicSalary.ToString() ?? "{Needs Updating}";
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year - 1, 11, 1); // Nov 1, previous year
            var approvedLeaves = _employeeDetails.Leaves.Where(a => a.LeaveType != LeaveType.UnpaidLeave && a.Status == Status.Approved);
            // End at Resignation or current Nov
            var endMonth = now.Month;
            var endYear = now.Year;
            var endDate = new DateTime(endYear, endMonth, DateTime.DaysInMonth(endYear, endMonth));

            var coveredAttendances = _employeeDetails.Attendances
                .Where(a => a.Date >= startDate && a.Date <= endDate && a.IsPresent)
                .ToList();

            var monthlyBreakdowns = coveredAttendances
                .GroupBy(a => a.Date.ToString("yyyy-MM"))
                .Select(g => new MonthlyBreakdown
                {
                    Month = g.Key,
                    DaysWorked = g.Count(),
                    Amount = g.Sum(a => _employeeDetails.BasicSalary * (a.IsHalfDay ? 0.5 : 1.0))
                })
                .ToList();

            dgList.DataSource = monthlyBreakdowns;
            txtTotal.Text = (monthlyBreakdowns.Sum(c => c.Amount) / 12).ToString("N2");

        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var existingThirteenthMonth = await _unitOfWork.ThirteenthMonth.Value.GetAsync(c => c.EmployeeId == _employeeDetails.EmployeeId);

                if (existingThirteenthMonth != null)
                {
                    MessageBox.Show("13th Month Pay already exists for this employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var _13thMonth = new ThirteenthMonth
                {
                    EmployeeId = _employeeDetails.EmployeeId,
                    Amount = decimal.Parse(txtTotal.Text),
                    DateGranted = DateTime.Now,
                    IsPaid = false,
                    Status = Status.Pending
                };

                await _unitOfWork.ThirteenthMonth.Value.AddAsync(_13thMonth);
                await _unitOfWork.SaveAsync();

                MessageBox.Show("13th Month Pay successfully recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving 13th Month Pay: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
