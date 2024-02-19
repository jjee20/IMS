using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ShipmentPresenter
    {
        public IShipmentView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ShipmentBindingSource;
        private IEnumerable<Shipment> ShipmentList;
        public ShipmentPresenter(IShipmentView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ShipmentBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetShipmentListBindingSource(ShipmentBindingSource);

            //Load

            LoadAllShipmentList();
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
                // Check if the Shipment already exists by name
                var existingEntity = _unitOfWork.Shipment.Get(c => c.ShipmentName == _view.ShipmentName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.ShipmentId != _view.ShipmentId)
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

                // Create or update the Shipment entity
                Shipment entity;
                if (_view.ShipmentId == 0)
                {
                    entity = new Shipment()
                    {
                        ShipmentName = _view.ShipmentName,
                        //Description = _view.Description
                    };
                    _unitOfWork.Shipment.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Shipment.Get(c => c.ShipmentId == _view.ShipmentId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Shipment type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.ShipmentName = _view.ShipmentName;
                    //entity.Description = _view.Description;
                    _unitOfWork.Shipment.Update(entity);
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
        //   var Entity = _unitOfWork.Shipment.Get(c => c.ShipmentName == _view.ShipmentName);
        //   if (Entity != null && _view.ShipmentId == 0)
        //        {
        //            _view.Message = "Shipment type is already added.";
        //            return;
        //        }
        //        if(_view.ShipmentId == 0)
        //        {

        //        Entity = new Shipment()
        //        {
        //            ShipmentId = _view.ShipmentId,
        //            ShipmentName = _view.ShipmentName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.ShipmentName = _view.ShipmentName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Shipment.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Shipment type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Shipment.Add(Entity);
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
                ShipmentList = _unitOfWork.Shipment.GetAll(c => c.ShipmentName.Contains(_view.SearchValue));
                ShipmentBindingSource.DataSource = ShipmentList;
            }
            else
            {
                ShipmentList = _unitOfWork.Shipment.GetAll();
                ShipmentBindingSource.DataSource = ShipmentList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Shipment)ShipmentBindingSource.Current;
            _view.ShipmentId = entity.ShipmentId;
            _view.ShipmentName = entity.ShipmentName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Shipment)ShipmentBindingSource.Current;
                _unitOfWork.Shipment.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shipment type deleted successfully";
                LoadAllShipmentList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shipment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ShipmentList", ShipmentList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllShipmentList();
        }
        private void CleanviewFields()
        {
            LoadAllShipmentList();
            _view.ShipmentId = 0;
            _view.ShipmentName = "";
            _view.Description = "";
        }
        
        private void LoadAllShipmentList()
        {
            ShipmentList = _unitOfWork.Shipment.GetAll();
            ShipmentBindingSource.DataSource = ShipmentList;//Set data source.
        }
    }
}
