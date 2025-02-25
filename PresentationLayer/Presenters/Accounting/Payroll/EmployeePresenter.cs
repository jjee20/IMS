using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories.IInventory;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
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

            //Load

            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();
            LoadAllShiftList();
            LoadAllEmployeeList();

            //Source Binding
            _view.SetGenderListBindingSource(GenderBindingSource);
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
            _view.SetJobPositionListBindingSource(JobPositionBindingSource);
            _view.SetShiftListBindingSource(ShiftBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }

        private void ReloadAll(object? sender, EventArgs e)
        {
            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();
            LoadAllShiftList();
            LoadAllEmployeeList();
        }
        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            _view.SaveButton = false;

            var model = _unitOfWork.Employee.Get(c => c.EmployeeId == _view.EmployeeId, tracked: true);
            if (model == null) model = new Employee();
            else _unitOfWork.Employee.Detach(model);

            model.EmployeeId = _view.EmployeeId;
            model.FirstName = _view.EmployeeFirstName;
            model.LastName = _view.EmployeeLastName;
            model.DateOfBirth = _view.DateOfBirth;
            model.Gender = _view.Gender;
            model.ContactNumber = _view.ContactNumber;
            model.Email = _view.Email;
            model.Address = _view.Address;
            model.DepartmentId = _view.DepartmentId;
            model.JobPositionId = _view.JobPositionId;
            model.ShiftId = _view.ShiftId;
            model.BasicSalary = _view.BasicSalary;
            model.isDeducted = _view.isDeducted;
            model.LeaveCredits = _view.LeaveCredits;

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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
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
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
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
