﻿using DomainLayer.Models.Inventory;
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
    public class TaxPresenter
    {
        public ITaxView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource TaxBindingSource;
        private IEnumerable<Tax> TaxList;
        public TaxPresenter(ITaxView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            TaxBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllTaxList();

            //Source Binding
            _view.SetTaxListBindingSource(TaxBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Tax.Get(c => c.MinimumSalary == _view.MinimumSalary);
            if (Entity != null)
            {
                _view.Message = "Tax is already added.";
                return;
            }

            var model = new Tax
            {
                TaxId = _view.TaxId,
                MinimumSalary = _view.MinimumSalary,
                MaximumSalary = _view.MaximumSalary,
                TaxRate = _view.TaxRate,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Tax.Update(model);
                    _view.Message = "Tax edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Tax.Add(model);
                    _view.Message = "Tax added successfully";
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
                TaxList = _unitOfWork.Tax.GetAll(c => c.MinimumSalary == Convert.ToDouble(_view.SearchValue));
                TaxBindingSource.DataSource = TaxList;
            }
            else
            {
                LoadAllTaxList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Tax)TaxBindingSource.Current;
            _view.TaxId = entity.TaxId;
            _view.MinimumSalary = entity.MinimumSalary;
            _view.MaximumSalary = entity.MaximumSalary;
            _view.TaxRate = entity.TaxRate;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Tax)TaxBindingSource.Current;
                _unitOfWork.Tax.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Tax deleted successfully";
                LoadAllTaxList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Tax";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "TaxReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Tax", TaxList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllTaxList();
        }
        private void CleanviewFields()
        {
            LoadAllTaxList();
            _view.TaxId = 0;
            _view.MinimumSalary = 0;
            _view.MaximumSalary = 0;
            _view.TaxRate = 0;
        }

        private void LoadAllTaxList()
        {
            TaxList = _unitOfWork.Tax.GetAll();
            TaxBindingSource.DataSource = TaxList;//Set data source.
        }
    }
}
