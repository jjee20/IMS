﻿using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class LeavePresenter
    {
        public ILeaveView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource LeaveBindingSource;
        private BindingSource EmployeeBindingSource;
        private BindingSource LeaveTypeBindingSource;
        private BindingSource StatusBindingSource;
        private IEnumerable<LeaveViewModel> LeaveList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        private IEnumerable<EnumItemViewModel> LeaveTypeList;
        private IEnumerable<EnumItemViewModel> StatusList;
        public LeavePresenter(ILeaveView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            LeaveBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();
            LeaveTypeBindingSource = new BindingSource();
            StatusBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllLeaveList();
            LoadAllEmployeeList();
            LoadAllLeaveTypeList();
            LoadAllStatusList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {

            var year = DateTime.Now.Year;
            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31);

            var employee = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == _view.EmployeeId, includeProperties: "Leaves");
            var totalLeave = employee.Leaves.Where(c => c.StartDate >= startDate && c.EndDate <= endDate).Count();

            if (totalLeave > employee.LeaveCredits)
            {
                _view.Message = $"Employee has {employee.LeaveCredits} leave credits left. You cannot proceed its request.";
                return;
            }

            var model = _unitOfWork.Leave.Value.Get(c => c.LeaveId == _view.LeaveId, tracked: true);

            if (model == null) model = new Leave();
            else _unitOfWork.Leave.Value.Detach(model);

            model.LeaveId = _view.LeaveId;
            model.EmployeeId = _view.EmployeeId;
            model.StartDate = _view.StartDate;
            model.EndDate = _view.EndDate;
            model.LeaveType = _view.LeaveType;
            model.Status = _view.Status;
            model.Notes = _view.Notes;
            model.Other = _view.Other;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Leave.Value.Update(model);
                    _view.Message = "Leave edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Leave.Value.Add(model);
                    _view.Message = "Leave added successfully";
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
            LoadAllLeaveList(emptyValue);
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

            var leave = (LeaveViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Leave.Value.Get(c => c.LeaveId == leave.LeaveId);
            _view.LeaveId = entity.LeaveId;
            _view.EmployeeId = entity.EmployeeId;
            _view.StartDate = entity.StartDate;
            _view.EndDate = entity.EndDate;
            _view.LeaveType = entity.LeaveType;
            _view.Status = entity.Status;
            _view.Notes = entity.Notes;
            _view.Other = entity.Other;
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

                var leave = (LeaveViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Leave.Value.Get(c => c.LeaveId == leave.LeaveId);
                _unitOfWork.Leave.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Leave deleted successfully";
                LoadAllLeaveList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Leave";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "LeaveReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Leave", LeaveList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllLeaveList();
        }
        private void CleanviewFields()
        {
            LoadAllLeaveList();
            _view.LeaveId = 0;
            _view.StartDate = DateTime.Now;
            _view.EndDate = DateTime.Now;
            _view.Notes = "";
            _view.Other = "";
        }

        private void LoadAllLeaveList(bool emptyValue = false)
        {
            LeaveList = Program.Mapper.Map<IEnumerable<LeaveViewModel>>(
                _unitOfWork.Leave.Value.GetAll(c => c.StartDate.Date >= _view.StartDate.Date && c.EndDate.Date <= _view.EndDate.Date,
                    includeProperties: "Employee"));

            if (!emptyValue)
                LeaveList = LeaveList.Where(c => c.Employee.Contains(_view.SearchValue) || c.LeaveType.Contains(_view.SearchValue));

            LeaveBindingSource.DataSource = LeaveList.OrderByDescending(c => c.StartDate);//Set data source.
            _view.SetLeaveListBindingSource(LeaveBindingSource);
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
        private void LoadAllLeaveTypeList()
        {
            LeaveTypeList = EnumHelper.EnumToEnumerable<LeaveType>();
            LeaveTypeBindingSource.DataSource = LeaveTypeList;//Set data source.
            _view.SetLeaveTypeListBindingSource(LeaveTypeBindingSource);
        }
        private void LoadAllStatusList()
        {
            StatusList = EnumHelper.EnumToEnumerable<Status>();
            StatusBindingSource.DataSource = StatusList;//Set data source.
            _view.SetStatusListBindingSource(StatusBindingSource);
        }
    }
}
