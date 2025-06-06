﻿using AutoMapper;
using DomainLayer.Models;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class BranchPresenter
    {
        public IBranchView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BranchBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<BranchViewModel> BranchList;
       
        public BranchPresenter(IBranchView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BranchBindingSource = new BindingSource();
            CurrencyBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load
            LoadAllBranchList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Branch.Value.Get(c => c.BranchId == _view.BranchId, tracked: true);
            if (model == null) model = new Branch();
            else _unitOfWork.Branch.Value.Detach(model);

            model.BranchId = _view.BranchId;
            model.BranchName = _view.BranchName;
            model.Description = _view.Description;
            model.Address = _view.Address;
            model.Phone = _view.Phone;
            model.Email = _view.Email;
            model.ContactPerson = _view.ContactPerson;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Branch.Value.Update(model);
                    _view.Message = "Branch edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Branch.Value.Add(model);
                    _view.Message = "Branch added successfully";
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
            LoadAllBranchList(emptyValue);
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

            var branch = (BranchViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Branch.Value.Get(c => c.BranchId == branch.BranchId);
            _view.BranchId = entity.BranchId;
            _view.BranchName = entity.BranchName;
            _view.Description = entity.Description;
            _view.Address = entity.Address;
            _view.Phone = entity.Phone;
            _view.Email = entity.Email;
            _view.ContactPerson = entity.ContactPerson;
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

                var branch = (BranchViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Branch.Value.Get(c => c.BranchId == branch.BranchId);
                _unitOfWork.Branch.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Branch deleted successfully";
                LoadAllBranchList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Branch";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BranchReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Branch", BranchList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBranchList();
        }
        private void CleanviewFields()
        {
            LoadAllBranchList();
            _view.BranchId = 0;
            _view.BranchName = "";
            _view.Description = "";
            _view.Address = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }
        
        private void LoadAllBranchList(bool emptyValue = false)
        {
            BranchList = Program.Mapper.Map<IEnumerable<BranchViewModel>>(_unitOfWork.Branch.Value.GetAll());

            if (!emptyValue)
            {
                BranchList = BranchList.Where(c => c.BranchName.ToLower().Contains(_view.SearchValue.ToLower()));
            }

            BranchBindingSource.DataSource = BranchList;//Set data source.
            _view.SetBranchListBindingSource(BranchBindingSource);
        }
    }
}
