﻿using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class CashBankPresenter
    {
        public ICashBankView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CashBankBindingSource;
        private IEnumerable<CashBank> CashBankList;
        public CashBankPresenter(ICashBankView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CashBankBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load
            LoadAllCashBankList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.CashBank.Value.Get(c => c.CashBankId == _view.CashBankId, tracked: true);
            if (model == null) model = new CashBank();
            else _unitOfWork.CashBank.Value.Detach(model);

            model.CashBankId = _view.CashBankId;
            model.CashBankName = _view.CashBankName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.CashBank.Value.Update(model);
                    _view.Message = "Cash bank edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.CashBank.Value.Add(model);
                    _view.Message = "Cash bank added successfully";
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
            LoadAllCashBankList(emptyValue);
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

            var entity = (CashBank)_view.DataGrid.SelectedItem;
            _view.CashBankId = entity.CashBankId;
            _view.CashBankName = entity.CashBankName;
            _view.Description = entity.Description;
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

                var entity = (CashBank)_view.DataGrid.SelectedItem;
                _unitOfWork.CashBank.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Cash bank deleted successfully";
                LoadAllCashBankList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Cash bank";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CashBankReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CashBank", CashBankList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCashBankList();
        }
        private void CleanviewFields()
        {
            LoadAllCashBankList();
            _view.CashBankId = 0;
            _view.CashBankName = "";
            _view.Description = "";
        }
        
        private void LoadAllCashBankList(bool emptyValue = false)
        {
            CashBankList = _unitOfWork.CashBank.Value.GetAll();

            if (emptyValue)
            {
                CashBankList = CashBankList.Where(c => c.CashBankName.Contains(_view.SearchValue));
            }

            CashBankBindingSource.DataSource = CashBankList;//Set data source.
            _view.SetCashBankListBindingSource(CashBankBindingSource);
        }
    }
}
