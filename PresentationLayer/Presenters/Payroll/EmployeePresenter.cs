using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class EmployeePresenter
    {
        public IEmployeeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource EmployeeBindingSource;
        private BindingSource GenderBindingSource;
        private BindingSource DepartmentBindingSource;
        private BindingSource JobPositionBindingSource;
        private IEnumerable<Employee> EmployeeList;
        private IEnumerable<EnumItemViewModel> GenderList;
        private IEnumerable<Department> DepartmentList;
        private IEnumerable<JobPosition> JobPositionList;
        public EmployeePresenter(IEmployeeView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            EmployeeBindingSource = new BindingSource();
            GenderBindingSource = new BindingSource();
            DepartmentBindingSource = new BindingSource();
            JobPositionBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllEmployeeList();
            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();

            //Source Binding
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
            _view.SetGenderListBindingSource(GenderBindingSource);
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
            _view.SetJobPositionListBindingSource(JobPositionBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Employee.Get(c => c.FirstName == _view.EmployeeFirstName && c.LastName == _view.EmployeeLastName);
            if (Entity != null)
            {
                _view.Message = "Employee is already added.";
                return;
            }

            var model = new Employee
            {
                EmployeeId = _view.EmployeeId,
                FirstName = _view.EmployeeFirstName,
                LastName = _view.EmployeeLastName,
                DateOfBirth = _view.DateOfBirth,
                Gender = _view.Gender,
                ContactNumber = _view.ContactNumber,
                Email = _view.Email,
                Address = _view.Address,
                DepartmentId = _view.DepartmentId,
                JobPositionId = _view.JobPositionId,
                isDeducted = _view.isDeducted,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Employee.Update(model);
                    _view.Message = "Employee edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Employee.Add(model);
                    _view.Message = "Employee added successfully";
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
                EmployeeList = _unitOfWork.Employee.GetAll(c => c.FirstName.Contains(_view.SearchValue) || c.LastName.Contains(_view.SearchValue));
                EmployeeBindingSource.DataSource = EmployeeList;
            }
            else
            {
                LoadAllEmployeeList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Employee)EmployeeBindingSource.Current;
            _view.EmployeeId = entity.EmployeeId;
            _view.EmployeeFirstName = entity.FirstName;
            _view.EmployeeLastName = entity.LastName;
            _view.DateOfBirth = entity.DateOfBirth;
            _view.Gender = entity.Gender;
            _view.ContactNumber = entity.ContactNumber;
            _view.Email = entity.Email;
            _view.Address = entity.Address;
            _view.DepartmentId = entity.DepartmentId;
            _view.JobPositionId = entity.JobPositionId;
            _view.isDeducted = entity.isDeducted;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Employee)EmployeeBindingSource.Current;
                _unitOfWork.Employee.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Employee deleted successfully";
                LoadAllEmployeeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Employee";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "EmployeeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Employee", EmployeeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllEmployeeList();
        }
        private void CleanviewFields()
        {
            LoadAllEmployeeList();
            _view.EmployeeId = 0;
            _view.EmployeeFirstName = "";
            _view.EmployeeLastName = "";
            _view.DateOfBirth = DateTime.Now;
            _view.Gender = Gender.Male;
            _view.ContactNumber = "";
            _view.Email = "";
            _view.Address = "";
            _view.DepartmentId = 0;
            _view.JobPositionId = 0;
            _view.isDeducted = true;
        }

        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
        private void LoadAllGenderList()
        {
            GenderList = EnumHelper.EnumToEnumerable<Gender>();
            GenderBindingSource.DataSource = GenderList;//Set data source.
        }
        private void LoadAllDepartmentList()
        {
            DepartmentList = _unitOfWork.Department.GetAll();
            DepartmentBindingSource.DataSource = DepartmentList;//Set data source.
        }
        private void LoadAllJobPositionList()
        {
            JobPositionList = _unitOfWork.JobPosition.GetAll();
            JobPositionBindingSource.DataSource = JobPositionList;//Set data source.
        }
    }
}
