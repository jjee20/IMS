using DomainLayer.Models;
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
        private IEnumerable<Warehouse> WarehouseList;
        public WarehousePresenter(IWarehouseView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            WarehouseBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);

            //Load

            LoadAllWarehouseList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            try
            {
                // Check if the Warehouse already exists by name
                var existingEntity = _unitOfWork.Warehouse.Get(c => c.WarehouseName == _view.WarehouseName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.WarehouseId != _view.WarehouseId)
                        {
                            _view.Message = "Another Bill type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Bill type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the Warehouse entity
                Warehouse entity;
                if (_view.WarehouseId == 0)
                {
                    entity = new Warehouse()
                    {
                        WarehouseName = _view.WarehouseName,
                        Description = _view.Description
                    };
                    _unitOfWork.Warehouse.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Warehouse.Get(c => c.WarehouseId == _view.WarehouseId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Bill type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.WarehouseName = _view.WarehouseName;
                    entity.Description = _view.Description;
                    _unitOfWork.Warehouse.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Bill type edited successfully" : "Bill type added successfully";
                _view.IsSuccessful = true;

                // Clear view fields
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        //private void Save(object? sender, EventArgs e)
        //{
        //   var Entity = _unitOfWork.Warehouse.Get(c => c.WarehouseName == _view.WarehouseName);
        //   if (Entity != null && _view.WarehouseId == 0)
        //        {
        //            _view.Message = "Bill type is already added.";
        //            return;
        //        }
        //        if(_view.WarehouseId == 0)
        //        {

        //        Entity = new Warehouse()
        //        {
        //            WarehouseId = _view.WarehouseId,
        //            WarehouseName = _view.WarehouseName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.WarehouseName = _view.WarehouseName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Warehouse.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Bill type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Warehouse.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Bill type added sucessfully";
        //            }
        //            _view.IsSuccessful = true;
        //            CleanviewFields();
        //        }
        //        catch (Exception ex)
        //        {
        //            _view.IsSuccessful = false;
        //            _view.Message = ex.Message;
        //        }
        //}
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (emptyValue == false)
            {
                WarehouseList = _unitOfWork.Warehouse.GetAll(c => c.WarehouseName.Contains(_view.SearchValue));
                WarehouseBindingSource.DataSource = WarehouseList;
            }
            else
            {
                WarehouseList = _unitOfWork.Warehouse.GetAll();
                WarehouseBindingSource.DataSource = WarehouseList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Warehouse)WarehouseBindingSource.Current;
            _view.WarehouseId = entity.WarehouseId;
            _view.WarehouseName = entity.WarehouseName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Warehouse)WarehouseBindingSource.Current;
                _unitOfWork.Warehouse.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill type deleted successfully";
                LoadAllWarehouseList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "WarehouseListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("WarehouseList", WarehouseList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
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
        
        private void LoadAllWarehouseList()
        {
            WarehouseList = _unitOfWork.Warehouse.GetAll();
            WarehouseBindingSource.DataSource = WarehouseList;//Set data source.
        }
    }
}
