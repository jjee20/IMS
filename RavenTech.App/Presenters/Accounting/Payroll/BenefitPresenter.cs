﻿using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class BenefitPresenter
    {
        public IBenefitView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BenefitBindingSource;
        private BindingSource BenefitTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<BenefitViewModel> BenefitList;
        private IEnumerable<EnumItemViewModel> BenefitTypeList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public BenefitPresenter(IBenefitView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BenefitBindingSource = new BindingSource();
            BenefitTypeBindingSource = new BindingSource();
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

            LoadAllBenefitList();
            LoadAllBenefitTypeList();
            LoadAllEmployeeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Benefit.Value.Get(c => c.BenefitId == _view.BenefitId, tracked: true);
            if (model == null) model = new Benefit();
            else _unitOfWork.Benefit.Value.Detach(model);

            model.BenefitId = _view.BenefitId;
            model.BenefitType = _view.BenefitType;
            model.Amount = _view.Amount;
            model.EmployeeId = _view.EmployeeId;
            model.Other = _view.Other;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Benefit.Value.Update(model);
                    _view.Message = "Benefit edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Benefit.Value.Add(model);
                    _view.Message = "Benefit added successfully";
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
            LoadAllBenefitList(emptyValue);
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

            var benefit = (BenefitViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Benefit.Value.Get(c => c.BenefitId == benefit.BenefitId);
            _view.BenefitId = entity.BenefitId;
            _view.BenefitType = entity.BenefitType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
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

                var benefit = (BenefitViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Benefit.Value.Get(c => c.BenefitId == benefit.BenefitId);
                _unitOfWork.Benefit.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Benefit deleted successfully";
                LoadAllBenefitList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Benefit";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BenefitReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Benefit", BenefitList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBenefitList();
        }
        private void CleanviewFields()
        {
            LoadAllBenefitList();
            _view.BenefitId = 0;
            _view.BenefitType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
        }

        private void LoadAllBenefitList(bool emptyValue = false)
        {
            BenefitList = Program.Mapper.Map<IEnumerable<BenefitViewModel>>(_unitOfWork.Benefit.Value.GetAll(includeProperties: "Employee"));

            if (!emptyValue)
            {
                BenefitList = BenefitList.Where(c => c.Employee.ToLower().Contains(_view.SearchValue.ToLower()));
            }

            BenefitBindingSource.DataSource = BenefitList;//Set data source.
            _view.SetBenefitListBindingSource(BenefitBindingSource);
        }
        private void LoadAllBenefitTypeList()
        {
            BenefitTypeList = EnumHelper.EnumToEnumerable<BenefitType>();
            BenefitTypeBindingSource.DataSource = BenefitTypeList;//Set data source.
            _view.SetBenefitTypeListBindingSource(BenefitTypeBindingSource);
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
    }
}
