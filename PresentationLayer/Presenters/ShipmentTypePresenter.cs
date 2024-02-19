using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ShipmentTypePresenter
    {
        public IShipmentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ShipmentTypeBindingSource;
        private IEnumerable<ShipmentType> ShipmentTypeList;
        public ShipmentTypePresenter(IShipmentTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ShipmentTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetShipmentTypeListBindingSource(ShipmentTypeBindingSource);

            //Load

            LoadAllShipmentTypeList();
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
                // Check if the ShipmentType already exists by name
                var existingEntity = _unitOfWork.ShipmentType.Get(c => c.ShipmentTypeName == _view.ShipmentTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.ShipmentTypeId != _view.ShipmentTypeId)
                        {
                            _view.Message = "Another Shipment type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Shipment type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the ShipmentType entity
                ShipmentType entity;
                if (_view.ShipmentTypeId == 0)
                {
                    entity = new ShipmentType()
                    {
                        ShipmentTypeName = _view.ShipmentTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.ShipmentType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.ShipmentType.Get(c => c.ShipmentTypeId == _view.ShipmentTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Shipment type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.ShipmentTypeName = _view.ShipmentTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.ShipmentType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Shipment type edited successfully" : "Shipment type added successfully";
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
        //   var Entity = _unitOfWork.ShipmentType.Get(c => c.ShipmentTypeName == _view.ShipmentTypeName);
        //   if (Entity != null && _view.ShipmentTypeId == 0)
        //        {
        //            _view.Message = "Shipment type is already added.";
        //            return;
        //        }
        //        if(_view.ShipmentTypeId == 0)
        //        {

        //        Entity = new ShipmentType()
        //        {
        //            ShipmentTypeId = _view.ShipmentTypeId,
        //            ShipmentTypeName = _view.ShipmentTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.ShipmentTypeName = _view.ShipmentTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.ShipmentType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Shipment type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.ShipmentType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Shipment type added sucessfully";
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
                ShipmentTypeList = _unitOfWork.ShipmentType.GetAll(c => c.ShipmentTypeName.Contains(_view.SearchValue));
                ShipmentTypeBindingSource.DataSource = ShipmentTypeList;
            }
            else
            {
                ShipmentTypeList = _unitOfWork.ShipmentType.GetAll();
                ShipmentTypeBindingSource.DataSource = ShipmentTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (ShipmentType)ShipmentTypeBindingSource.Current;
            _view.ShipmentTypeId = entity.ShipmentTypeId;
            _view.ShipmentTypeName = entity.ShipmentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (ShipmentType)ShipmentTypeBindingSource.Current;
                _unitOfWork.ShipmentType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shipment type deleted successfully";
                LoadAllShipmentTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shipment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ShipmentTypeList", ShipmentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllShipmentTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllShipmentTypeList();
            _view.ShipmentTypeId = 0;
            _view.ShipmentTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllShipmentTypeList()
        {
            ShipmentTypeList = _unitOfWork.ShipmentType.GetAll();
            ShipmentTypeBindingSource.DataSource = ShipmentTypeList;//Set data source.
        }
    }
}
