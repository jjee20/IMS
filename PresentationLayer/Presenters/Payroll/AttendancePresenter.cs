﻿using CsvHelper;
using CsvHelper.Configuration;
using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using PresentationLayer.Views.UserControls.Payroll;
using ServiceLayer.Services.IRepositories;
using System.Formats.Asn1;
using System.Globalization;
using Windows.Devices.Usb;

namespace PresentationLayer.Presenters.Payroll
{
    public class AttendancePresenter
    {
        public IAttendanceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource AttendanceBindingSource;
        private BindingSource IndividualAttendanceBindingSource;
        private BindingSource EmployeeBindingSource;
        private BindingSource ProjectBindingSource;
        private IEnumerable<AttendanceViewModel> AttendanceList;
        private IEnumerable<IndividualAttendanceViewModel> IndividualAttendanceList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        private IEnumerable<Project> ProjectList;
        public AttendancePresenter(IAttendanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AttendanceBindingSource = new BindingSource();
            IndividualAttendanceBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();
            ProjectBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            _view.ShowAttendanceEvent += ShowAttendance;
            _view.ImportEvent += Import;

            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 1);
            startDate = startDate.DayOfWeek == DayOfWeek.Saturday ? startDate : startDate.AddDays(7);
            DateTime endDate = startDate.AddDays(6).Date;

            _view.StartDate = startDate;
            _view.EndDate = endDate;

            //Load

            LoadAllAttendanceList();
            LoadAllEmployeeList();
            LoadAllProjectList();

            //Source Binding
            _view.SetAttendanceListBindingSource(AttendanceBindingSource);
            _view.SetIndividualAttendanceListBindingSource(IndividualAttendanceBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
            _view.SetProjectListBindingSource(ProjectBindingSource);
        }

        private void Import(object? sender, EventArgs e)
        {
            _unitOfWork.Attendance.AddRange(ImportAttendance());
            _unitOfWork.Save();

            _view.Message = "Attendance imported successfully.";
        }

        public static List<Attendance> ImportAttendance()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Attendance CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName; // Get selected file path
                    return ReadCsv(filePath);
                }
            }

            return new List<Attendance>(); // Return empty list if no file is selected
        }

        private static List<Attendance> ReadCsv(string filePath)
        {
            var attendanceList = new List<Attendance>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Ensure headers exist
                Delimiter = ",", // Define CSV delimiter
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var record = new Attendance
                    {
                        AttendanceId = csv.GetField<int>("AttendanceId"),
                        EmployeeId = csv.GetField<int>("EmployeeId"),
                        Date = csv.GetField<DateTime>("Date"),
                        TimeIn = TimeSpan.Parse(csv.GetField<string>("TimeIn")),
                        TimeOut = TimeSpan.Parse(csv.GetField<string>("TimeOut")),
                        IsPresent = csv.GetField<bool>("IsPresent"),
                        HoursWorked = csv.GetField<double>("HoursWorked")
                    };

                    attendanceList.Add(record);
                }
            }

            return attendanceList;
        }

        private void ShowAttendance(object? sender, DataGridViewCellEventArgs e)
        {
            var attendanceVM = (AttendanceViewModel)AttendanceBindingSource.Current;

            if (attendanceVM == null)
            {
                MessageBox.Show("No attendance record selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.EmployeeName = attendanceVM.Employee;
            LoadAllIndividualAttendanceList(attendanceVM.EmployeeId);

            //var showIndividualAttendance = new IndividualAttendance();

            //// Use the new constructor
            //var presenter = new IndividualAttendancePresenter(showIndividualAttendance, _unitOfWork,
            //    attendanceVM.EmployeeId, _view.StartDate, _view.EndDate);

            //showIndividualAttendance.Name = attendanceVM.Employee;
            //showIndividualAttendance.EmployeeId = attendanceVM.EmployeeId;
            //showIndividualAttendance.StartDate = _view.StartDate;
            //showIndividualAttendance.EndDate = _view.EndDate;

            //showIndividualAttendance.ShowDialog();
        }



        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {

            var model = new Attendance
            {
                AttendanceId = _view.AttendanceId,
                EmployeeId = _view.EmployeeId,
                ProjectId = _view.ProjectId,
                TimeIn = _view.TimeIn,
                TimeOut = _view.TimeOut,
                Date = _view.Date,
                IsPresent = _view.IsPresent,
                HoursWorked = _view.HoursWorked
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Attendance.Update(model);
                    _view.Message = "Attendance edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Attendance.Add(model);
                    _view.Message = "Attendance added successfully";
                }
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                CleanviewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            bool hasDateRange = _view.StartDate != null && _view.EndDate != null;

            AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date);

            if (!emptyValue || hasDateRange)
            {
                AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date).Where(c => emptyValue || c.Employee.Contains(_view.SearchValue) || c.Employee.Contains(_view.SearchValue));
                AttendanceBindingSource.DataSource = AttendanceList;
            }
            else
            {
                // Load all attendance records if no filters are applied
                LoadAllAttendanceList();
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "AttendanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Attendance", AttendanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllAttendanceList();
        }
        private void CleanviewFields()
        {
            LoadAllAttendanceList();
            _view.AttendanceId = 0;
            _view.IsPresent = true;
            _view.HoursWorked = 8;
        }

        public List<AttendanceViewModel> GetAttendanceSummary(DateTime startDate, DateTime endDate)
        {
            var employees = _unitOfWork.Employee.GetAll(includeProperties: "Attendances,Leaves,Shift,Attendances.Project");

            var summaryList = new List<AttendanceViewModel>();

            int totalDays = 0;
            DateTime currentDate = startDate.Date;

            do
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday) // Exclude Sundays
                {
                    totalDays++;
                }

                currentDate = currentDate.AddDays(1);
            } while (currentDate <= endDate.Date);

            foreach (var employee in employees)
            {
                var attendances = employee.Attendances
                    .Where(a => a.Date.Date >= startDate && a.Date.Date <= endDate)
                    .ToList();

                var approvedLeaves = employee.Leaves
                    .Where(l => l.StartDate.Date <= startDate && l.EndDate.Date >= endDate && l.Status == Status.Approved)
                    .ToList();

                int daysPresent = attendances.Count(a => a.IsPresent);
                int daysLate = attendances.Count(a => a.TimeIn > employee.Shift.StartTime);
                int daysEarlyOut = attendances.Count(a => a.TimeOut < employee.Shift.EndTime);
                int daysOnLeave = approvedLeaves.Sum(l => (l.EndDate - l.StartDate).Days + 1);
                int daysAbsent = totalDays - (daysPresent + daysOnLeave);

                summaryList.Add(new AttendanceViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    Employee = $"{employee.LastName}, {employee.FirstName}",
                    TotalDays = totalDays,
                    DaysPresent = daysPresent,
                    DaysLate = daysLate,
                    DaysEarlyOut = daysEarlyOut,
                    DaysAbsent = daysAbsent,
                    DaysOnLeave = daysOnLeave
                });
            }

            return summaryList.OrderBy(c => c.Employee).ToList();
        }


        private void LoadAllAttendanceList()
        {
            AttendanceList = GetAttendanceSummary(_view.StartDate.Date, _view.EndDate.Date);
            AttendanceBindingSource.DataSource = AttendanceList.OrderBy(c => c.Employee);//Set data source.
        }
        private void LoadAllIndividualAttendanceList(int id)
        {
            IndividualAttendanceList = Program.Mapper.Map<IEnumerable<IndividualAttendanceViewModel>>(_unitOfWork.Attendance.GetAll(c => c.EmployeeId == id && 
                c.Date.Date >= _view.StartDate.Date && c.Date.Date <= _view.EndDate.Date, includeProperties: "Project"));
            IndividualAttendanceBindingSource.DataSource = IndividualAttendanceList.OrderBy(c => c.Date);//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
        private void LoadAllProjectList()
        {
            ProjectList = _unitOfWork.Project.GetAll();
            ProjectBindingSource.DataSource = ProjectList;//Set data source.
        }
    }
}
