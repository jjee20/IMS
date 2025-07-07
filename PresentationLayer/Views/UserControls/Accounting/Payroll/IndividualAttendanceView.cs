using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Accounting.Payroll.Upserts;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
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
    public partial class IndividualAttendanceView : SfForm
    {
        private readonly IUnitOfWork _unitOfWork;
        private Employee _employee;
        private Attendance _entity;
        private DateTime _startDate;
        private DateTime _endndDate;
        private IEnumerable<IndividualAttendanceViewModel> _attendanceList;

        public IndividualAttendanceView(IUnitOfWork unitOfWork, Employee employee, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _employee = employee;
            _startDate = startDate;
            _endndDate = endDate;

            txtStartDate.Value = startDate;
            txtEndDate.Value = endDate;
            LoadAllAttendance(employee.EmployeeId, startDate.Date, endDate.Date);
        }
        public SfDataGrid DataGrid => dgList;


        private void LoadAllAttendance(int employeeId, DateTime startDate, DateTime endDate)
        {
            _attendanceList = Program.Mapper.Map<IEnumerable<IndividualAttendanceViewModel>>(_unitOfWork.Attendance.Value.GetAll(
                c => c.EmployeeId == employeeId &&
                c.Date.Date >= startDate.Date && c.Date.Date <= endDate.Date, includeProperties: "Employee,Project"));

            dgPager.DataSource = _attendanceList.ToList();

            foreach (var item in _attendanceList)
            {
                item.Edit = Resources.edit;
                item.Delete = Resources.delete;
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Edit")
            {
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is IndividualAttendanceViewModel row)
                {
                    var attendance = _unitOfWork.Attendance.Value.Get(
                        c => c.AttendanceId == row.AttendanceId);

                    using (var upsertAttendance = new UpsertAttendanceView(_unitOfWork, attendance))
                    {
                        upsertAttendance.Text = "Edit Attendance";
                        if (upsertAttendance.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllAttendance(_employee.EmployeeId, _startDate.Date, _endndDate.Date);
                        }
                    }
                }
            }
            else if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is IndividualAttendanceViewModel row)
                    {
                        var attendance = _unitOfWork.Attendance.Value.Get(
                            c => c.AttendanceId == row.AttendanceId);

                        _unitOfWork.Attendance.Value.Remove(attendance);
                        _unitOfWork.Save();

                        LoadAllAttendance(_employee.EmployeeId, _startDate.Date, _endndDate.Date);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var attendance = new UpsertAttendanceView(_unitOfWork, employeeId: _employee.EmployeeId))
            {
                attendance.Text = $"Add Attendance for {_employee.LastName}, {_employee.FirstName}";
                if (attendance.ShowDialog() == DialogResult.OK)
                {
                    LoadAllAttendance(_employee.EmployeeId, _startDate.Date, _endndDate.Date);
                }
            }
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            LoadAllAttendance(_entity.EmployeeId, _startDate.Date, _endndDate.Date);
        }

        private void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            txtStartDate_TextChanged(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string reportFileName = "IndividualAttendanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Attendance", _attendanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private void IndividualAttendanceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected items?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (dgList.SelectedItems == null || dgList.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Please select item(s) to delete.");
                        return;
                    }

                    var selected = dgList.SelectedItems.Cast<IndividualAttendanceViewModel>().ToList(); // If you're using view models
                    var ids = selected.Select(b => b.AttendanceId).ToList();

                    var entities = _unitOfWork.Attendance.Value
                        .GetAll()
                        .Where(b => ids.Contains(b.AttendanceId))
                        .ToList();

                    if (!entities.Any())
                    {
                        MessageBox.Show("Selected records could not be found.");
                        return;
                    }

                    _unitOfWork.Attendance.Value.RemoveRange(entities);
                    _unitOfWork.Save();

                    MessageBox.Show($"{entities.Count} entries deleted successfully.");
                }
            }
        }

        public event EventHandler? SearchEvent;
        public event EventHandler? PrintEvent;
        public event EventHandler? AddEvent;
        public event CellClickEventHandler? EditEvent;
        public event CellClickEventHandler? DeleteEvent;
        public event EventHandler? MultipleDeleteEvent;

    }
}
