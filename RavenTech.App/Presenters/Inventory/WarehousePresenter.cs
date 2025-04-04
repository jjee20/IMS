﻿using DomainLayer.Models;
using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class WarehousePresenter
    {
        public IWarehouseView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource WarehouseBindingSource;
        private BindingSource BranchBindingSource;
        private IEnumerable<WarehouseViewModel> WarehouseList;
        private IEnumerable<Branch> BranchList;
        public WarehousePresenter(IWarehouseView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            WarehouseBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllWarehouseList();
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
            var model = _unitOfWork.Warehouse.Value.Get(c => c.WarehouseId == _view.WarehouseId, tracked: true);
            if (model == null) model = new Warehouse();
            else _unitOfWork.Warehouse.Value.Detach(model);

            model.WarehouseId = _view.WarehouseId;
            model.WarehouseName = _view.WarehouseName;
            model.Description = _view.Description;
            model.BranchId = _view.BranchId;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Warehouse.Value.Update(model);
                    _view.Message = "Warehouse edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Warehouse.Value.Add(model);
                    _view.Message = "Warehouse added successfully";
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
            LoadAllWarehouseList(emptyValue);
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

            var warehouse = (WarehouseViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Warehouse.Value.Get(c => c.WarehouseId == warehouse.WarehouseId);
            _view.WarehouseId = entity.WarehouseId;
            _view.WarehouseName = entity.WarehouseName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to edit";
                    return;
                }

                var warehouse = (WarehouseViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Warehouse.Value.Get(c => c.WarehouseId == warehouse.WarehouseId);
                _unitOfWork.Warehouse.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Warehouse deleted successfully";
                LoadAllWarehouseList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Warehouse";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "WarehouseReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Warehouse", WarehouseList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllWarehouseList();
        }
        private void CleanviewFields()
        {
            LoadAllWarehouseList();
            _view.WarehouseId = 0;
            _view.WarehouseName = "";
            _view.Description = "";
        }
        
        private void LoadAllWarehouseList(bool emptyValue = false)
        {
            WarehouseList = Program.Mapper.Map<IEnumerable<WarehouseViewModel>>(_unitOfWork.Warehouse.Value.GetAll(includeProperties: "Branch")); ;

            if (!emptyValue)
            {
                WarehouseList = WarehouseList.Where(c => c.WarehouseName.Contains(_view.SearchValue));
            }

            WarehouseBindingSource.DataSource = WarehouseList;//Set data source.
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);
        }

        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.Value.GetAll(); ;
            BranchBindingSource.DataSource = BranchList;//Set data source.
            _view.SetBranchListBindingSource(BranchBindingSource);
        }
    }
}
