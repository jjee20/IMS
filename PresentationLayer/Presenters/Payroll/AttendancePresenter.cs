using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class AttendancePresenter
    {
        public IAttendanceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource AttendanceBindingSource;
        private BindingSource EmployeeBindingSource;
        private BindingSource ShiftBindingSource;
        private IEnumerable<Attendance> AttendanceList;
        private IEnumerable<Employee> EmployeeList;
        private IEnumerable<Shift> ShiftList;
        public AttendancePresenter(IAttendanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AttendanceBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();
            ShiftBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllAttendanceList();
            LoadAllEmployeeList();
            LoadAllShiftList();

            //Source Binding
            _view.SetAttendanceListBindingSource(AttendanceBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
            _view.SetShiftListBindingSource(ShiftBindingSource);
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
                TimeIn = _view.TimeIn,
                TimeOut = _view.TimeOut,
                Date = _view.Date,
                IsPresent = _view.IsPresent,
                HoursWorked = _view.HoursWorked,
                ShiftId = _view.ShiftId,
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
            if (!emptyValue)
            {
                AttendanceList = _unitOfWork.Attendance.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee");
                AttendanceBindingSource.DataSource = AttendanceList;
            }
            else
            {
                LoadAllAttendanceList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Attendance)AttendanceBindingSource.Current;
            _view.AttendanceId = entity.AttendanceId;
            _view.EmployeeId = entity.EmployeeId;
            _view.TimeIn = entity.TimeIn;
            _view.TimeOut = entity.TimeOut;
            _view.Date = entity.Date;
            _view.IsPresent = entity.IsPresent;
            _view.HoursWorked = entity.HoursWorked;
            _view.ShiftId = entity.ShiftId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Attendance)AttendanceBindingSource.Current;
                _unitOfWork.Attendance.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Attendance deleted successfully";
                LoadAllAttendanceList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Attendance";
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
            _view.EmployeeId = 0;
            _view.Date = DateTime.Now;
            _view.IsPresent = true;
            _view.HoursWorked = 0;
            _view.ShiftId = 0;
        }

        private void LoadAllAttendanceList()
        {
            AttendanceList = _unitOfWork.Attendance.GetAll();
            AttendanceBindingSource.DataSource = AttendanceList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
        private void LoadAllShiftList()
        {
            ShiftList = _unitOfWork.Shift.GetAll();
            ShiftBindingSource.DataSource = ShiftList;//Set data source.
        }
    }
}
