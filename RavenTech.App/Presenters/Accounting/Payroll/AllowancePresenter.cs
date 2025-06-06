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
using RavenTech_ERP.Properties;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class AllowancePresenter
    {
        public IAllowanceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource AllowanceBindingSource;
        private BindingSource AllowanceTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<AllowanceViewModel> AllowanceList;
        private IEnumerable<EnumItemViewModel> AllowanceTypeList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public AllowancePresenter(IAllowanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AllowanceBindingSource = new BindingSource();
            AllowanceTypeBindingSource = new BindingSource();
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

            LoadAllAllowanceList();
            LoadAllAllowanceTypeList();
            LoadAllEmployeeList();

            _view.DateGranted = DateTime.Now;

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Allowance.Value.Get(c => c.AllowanceId == _view.AllowanceId, tracked: true);
            if (model == null) model = new Allowance();
            else _unitOfWork.Allowance.Value.Detach(model);

            model.AllowanceId = _view.AllowanceId;
            model.AllowanceType = _view.AllowanceType;
            model.Amount = _view.Amount;
            model.DateGranted = _view.DateGranted;
            model.EmployeeId = _view.EmployeeId;
            model.Description = _view.Description;
            model.IsRecurring = _view.IsRecurring;
            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Allowance.Value.Update(model);
                    _view.Message = "Allowance edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Allowance.Value.Add(model);
                    _view.Message = "Allowance added successfully";
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
            LoadAllAllowanceList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;

            if(_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var allowance = (AllowanceViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Allowance.Value.Get(c => c.AllowanceId == allowance.AllowanceId);
            _view.AllowanceId = entity.AllowanceId;
            _view.AllowanceType = entity.AllowanceType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
            _view.DateGranted = entity.DateGranted;
            _view.Description = entity.Description;
            _view.IsRecurring = entity.IsRecurring;
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

                var allowance = (AllowanceViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Allowance.Value.Get(c => c.AllowanceId == allowance.AllowanceId);
                _unitOfWork.Allowance.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Allowance deleted successfully";
                LoadAllAllowanceList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Allowance";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "AllowanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Allowance", AllowanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllAllowanceList();
        }
        private void CleanviewFields()
        {
            LoadAllAllowanceList();
            _view.AllowanceId = 0;
            _view.AllowanceType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
            _view.Description = "";
        }

        private void LoadAllAllowanceList(bool emptyValue = false)
        {
            AllowanceList = Program.Mapper.Map<IEnumerable<AllowanceViewModel>>(_unitOfWork.Allowance.Value.GetAll(c => c.DateGranted.Date >= _view.StartDate.Date && c.DateGranted.Date <= _view.EndDate.Date,
                includeProperties: "Employee"));
            if (!emptyValue)
                AllowanceList = AllowanceList.Where(c => c.Employee.Contains(_view.SearchValue));
            AllowanceBindingSource.DataSource = AllowanceList.OrderByDescending(c => c.DateGranted); ;//Set data source.
            _view.SetAllowanceListBindingSource(AllowanceBindingSource);
        }
        private void LoadAllAllowanceTypeList()
        {
            AllowanceTypeList = EnumHelper.EnumToEnumerable<AllowanceType>();
            AllowanceTypeBindingSource.DataSource = AllowanceTypeList;//Set data source.
            _view.SetAllowanceTypeListBindingSource(AllowanceTypeBindingSource);
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
    }
}
