﻿using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Account;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class EmployeePresenter
    {
        public IEmployeeView _view;
        private IUnitOfWork _unitOfWork;
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
            _view.UserInformationEvent += UserInformation;

            //Load

            LoadAllGenderList();
            LoadAllDepartmentList();
            LoadAllJobPositionList();
            LoadAllShiftList();
            LoadAllEmployeeList();

            //Source Binding
        }

        private void UserInformation(object? sender, EventArgs e)
        {
            var employee = (EmployeeViewModel)_view.DataGrid.SelectedItem;
            var user = Program.Mapper.Map<UserInformationViewModel>(_unitOfWork.Employee.Value.Get(c => c.EmployeeId == employee.EmployeeId, includeProperties: "Department,JobPosition,Shift,Attendances.Project,Leaves,Bonuses,Benefits,Deductions,Allowances,Contribution"));
            var userInformation = new EmployeeInformationView(user);
            userInformation.ShowDialog();   
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

            var model = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == _view.EmployeeId, tracked: true);
            if (model == null) model = new Employee();
            else _unitOfWork.Employee.Value.Detach(model);

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
                    _unitOfWork.Employee.Value.Update(model);
                    _view.Message = "Employee edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Employee.Value.Add(model);
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
            LoadAllEmployeeList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var employee = (EmployeeViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == employee.EmployeeId);

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
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to delete";
                    return;
                }

                var employee = (EmployeeViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == employee.EmployeeId);
                _unitOfWork.Employee.Value.Remove(entity);
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

        private void LoadAllEmployeeList(bool emptyValue = false)
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll(includeProperties: "Department,JobPosition,Shift"));

            if (!emptyValue) EmployeeList = EmployeeList.Where(c => c.Name.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetEmployeeListBindingSource(EmployeeList.OrderBy(c => c.Name));
        }
        private void LoadAllGenderList()
        {
            GenderList = EnumHelper.EnumToEnumerable<Gender>();
            GenderBindingSource.DataSource = GenderList;//Set data source.
            _view.SetGenderListBindingSource(GenderBindingSource);
        }
        private void LoadAllDepartmentList()
        {
            DepartmentList = _unitOfWork.Department.Value.GetAll();
            DepartmentBindingSource.DataSource = DepartmentList;//Set data source.
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
        }
        private void LoadAllJobPositionList()
        {
            JobPositionList = _unitOfWork.JobPosition.Value.GetAll();
            JobPositionBindingSource.DataSource = JobPositionList;//Set data source.
            _view.SetJobPositionListBindingSource(JobPositionBindingSource);
        }
        private void LoadAllShiftList()
        {
            ShiftList = _unitOfWork.Shift.Value.GetAll();
            ShiftBindingSource.DataSource = ShiftList;//Set data source.
            _view.SetShiftListBindingSource(ShiftBindingSource);
        }
    }
}
