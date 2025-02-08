using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Windows.Networking;
using static Unity.Storage.RegistrationSet;

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
        private BindingSource ShiftBindingSource;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        private IEnumerable<EnumItemViewModel> GenderList;
        private IEnumerable<Department> DepartmentList;
        private IEnumerable<JobPosition> JobPositionList;
        private IEnumerable<Shift> ShiftList;
        public EmployeePresenter(IEmployeeView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            EmployeeBindingSource = new BindingSource();
            GenderBindingSource = new BindingSource();
            DepartmentBindingSource = new BindingSource();
            JobPositionBindingSource = new BindingSource();
            ShiftBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            _view.AddDepartmentEvent += AddDepartment;
            _view.AddJobPositionEvent += AddJobPosition;
            _view.AddShiftEvent += AddShift;
            _view.ReloadEvent += ReloadAll;

            //Load

            LoadAllEmployeeList();
            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();
            LoadAllShiftList();

            //Source Binding
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
            _view.SetGenderListBindingSource(GenderBindingSource);
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
            _view.SetJobPositionListBindingSource(JobPositionBindingSource);
            _view.SetShiftListBindingSource(ShiftBindingSource);
        }

        private void ReloadAll(object? sender, EventArgs e)
        {
            LoadAllEmployeeList();
            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();
            LoadAllShiftList();
        }

        private void AddShift(object? sender, EventArgs e)
        {
            var formDialog = new FormDialog();
            IShiftView view = ShiftView.GetInstanceAsDialog(formDialog);

            new ShiftPresenter(view, _unitOfWork);
            formDialog.ShowDialog();
        }

        private void AddJobPosition(object? sender, EventArgs e)
        {
            var formDialog = new FormDialog();
            IJobPositionView view =  JobPositionView.GetInstanceAsDialog(formDialog);
            new JobPositionPresenter(view, _unitOfWork);

            formDialog.ShowDialog();
        }

        private void AddDepartment(object? sender, EventArgs e)
        {
            var formDialog = new FormDialog();
            IDepartmentView view = DepartmentView.GetInstanceAsDialog(formDialog);
            new DepartmentPresenter(view, _unitOfWork);

            formDialog.ShowDialog();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            _view.SaveButton = false;

            var  employee = _unitOfWork.Employee.Get(c => c.EmployeeId == _view.EmployeeId, tracked: true);
            if (employee == null) employee = new Employee();
            else
                _unitOfWork.Employee.Detach(employee);

            employee.EmployeeId = _view.EmployeeId;
            employee.FirstName = _view.EmployeeFirstName;
            employee.LastName = _view.EmployeeLastName;
            employee.DateOfBirth = _view.DateOfBirth;
            employee.Gender = _view.Gender ?? Gender.Female;
            employee.ContactNumber = _view.ContactNumber;
            employee.Email = _view.Email;
            employee.Address = _view.Address;
            employee.DepartmentId = _view.DepartmentId;
            employee.JobPositionId = _view.JobPositionId;
            employee.ShiftId = _view.ShiftId;
            employee.BasicSalary = _view.BasicSalary;
            employee.isDeducted = _view.isDeducted;
            employee.LeaveCredits = _view.LeaveCredits;

            try
            {
                new ModelDataValidation().Validate(employee);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Employee.Update(employee);
                    _view.Message = "Employee edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Employee.Add(employee);
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
            finally
            {
                _view.SaveButton = true;
            }
        }
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (!emptyValue)
            {
                EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll(
                    c => c.FirstName.Contains(_view.SearchValue) || 
                    c.LastName.Contains(_view.SearchValue), includeProperties: "Department,JobPosition,Shift"));
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
            var employee = (EmployeeViewModel)EmployeeBindingSource.Current;
            var entity = _unitOfWork.Employee.Get(c => c.EmployeeId == employee.EmployeeId);

            if (entity == null)
            {
                _view.Message = "Employee record not found.";
                return;
            }

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
            _view.BasicSalary = entity.BasicSalary;
            _view.ShiftId = entity.ShiftId;
            _view.isDeducted = entity.isDeducted;
            _view.LeaveCredits = entity.LeaveCredits;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var employee = (EmployeeViewModel)EmployeeBindingSource.Current;
                var entity = _unitOfWork.Employee.Get(c => c.EmployeeId == employee.EmployeeId);
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
            _view.ShiftId = 0;
            _view.BasicSalary = 0;
            _view.LeaveCredits = 0;
            _view.isDeducted = true;
        }

        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll(includeProperties: "Department,JobPosition,Shift"));
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
        private void LoadAllShiftList()
        {
            ShiftList = _unitOfWork.Shift.GetAll();
            ShiftBindingSource.DataSource = ShiftList;//Set data source.
        }
    }
}
