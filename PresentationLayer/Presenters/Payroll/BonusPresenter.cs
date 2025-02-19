﻿using DomainLayer.Enums;
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
    public class BonusPresenter
    {
        public IBonusView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BonusBindingSource;
        private BindingSource BonusTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<Bonus> BonusList;
        private IEnumerable<EnumItemViewModel> BonusTypeList;
        private IEnumerable<Employee> EmployeeList;
        public BonusPresenter(IBonusView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BonusBindingSource = new BindingSource();
            BonusTypeBindingSource = new BindingSource();
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

            LoadAllBonusList();
            LoadAllBonusTypeList();
            LoadAllEmployeeList();

            //Source Binding
            _view.SetBonusListBindingSource(BonusBindingSource);
            _view.SetBonusTypeListBindingSource(BonusTypeBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = new Bonus
            {
                BonusId = _view.BonusId,
                BonusType = _view.BonusType,
                Amount = _view.Amount,
                EmployeeId = _view.EmployeeId,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Bonus.Update(model);
                    _view.Message = "Bonus edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Bonus.Add(model);
                    _view.Message = "Bonus added successfully";
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
                BonusList = _unitOfWork.Bonus.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee");
                BonusBindingSource.DataSource = BonusList;
            }
            else
            {
                LoadAllBonusList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Bonus)BonusBindingSource.Current;
            _view.BonusId = entity.BonusId;
            _view.BonusType = entity.BonusType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Bonus)BonusBindingSource.Current;
                _unitOfWork.Bonus.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bonus deleted successfully";
                LoadAllBonusList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bonus";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BonusReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Bonus", BonusList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBonusList();
        }
        private void CleanviewFields()
        {
            LoadAllBonusList();
            _view.BonusId = 0;
            _view.BonusType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
            _view.Description = "";
        }

        private void LoadAllBonusList()
        {
            BonusList = _unitOfWork.Bonus.GetAll();
            BonusBindingSource.DataSource = BonusList;//Set data source.
        }
        private void LoadAllBonusTypeList()
        {
            BonusTypeList = EnumHelper.EnumToEnumerable<BonusType>();
            BonusTypeBindingSource.DataSource = BonusTypeList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
    }
}
