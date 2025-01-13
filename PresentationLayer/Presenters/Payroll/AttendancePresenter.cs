using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
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
        private IEnumerable<AttendanceViewModel> AttendanceList;
        private IEnumerable<Employee> EmployeeList;
        public AttendancePresenter(IAttendanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AttendanceBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();

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

            //Source Binding
            _view.SetAttendanceListBindingSource(AttendanceBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
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

            if (!emptyValue || hasDateRange)
            {
                // Apply filters based on SearchValue and Date Range
                AttendanceList = Program.Mapper.Map<IEnumerable<AttendanceViewModel>>(_unitOfWork.Attendance.GetAll(c =>
                    (emptyValue || c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue)) &&
                    (!hasDateRange || (c.Date.Date >= _view.StartDate.Date && c.Date <= _view.EndDate.Date)),
                    includeProperties: "Employee"));

                AttendanceBindingSource.DataSource = AttendanceList;
            }
            else
            {
                // Load all attendance records if no filters are applied
                LoadAllAttendanceList();
            }
        }

        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var attendance = (AttendanceViewModel)AttendanceBindingSource.Current;
            var entity = _unitOfWork.Attendance.Get(c => c.AttendanceId == attendance.AttendanceId);
            
            _view.AttendanceId = entity.AttendanceId;
            _view.EmployeeId = entity.EmployeeId;
            _view.TimeIn = entity.TimeIn;
            _view.TimeOut = entity.TimeOut;
            _view.Date = entity.Date;
            _view.IsPresent = entity.IsPresent;
            _view.HoursWorked = entity.HoursWorked;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var attendance = (AttendanceViewModel)AttendanceBindingSource.Current;
                var entity = _unitOfWork.Attendance.Get(c => c.AttendanceId == attendance.AttendanceId);
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
            _view.IsPresent = true;
            _view.HoursWorked = 0;
        }

        private void LoadAllAttendanceList()
        {
            AttendanceList = Program.Mapper.Map<IEnumerable<AttendanceViewModel>>(_unitOfWork.Attendance.GetAll(includeProperties: "Employee"));
            AttendanceBindingSource.DataSource = AttendanceList.OrderBy(c => c.Date);//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
    }
}
