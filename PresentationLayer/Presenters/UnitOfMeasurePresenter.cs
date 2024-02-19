using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class UnitOfMeasurePresenter
    {
        public IUnitOfMeasureView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource UnitOfMeasureBindingSource;
        private IEnumerable<UnitOfMeasure> UnitOfMeasureList;
        public UnitOfMeasurePresenter(IUnitOfMeasureView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            UnitOfMeasureBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureBindingSource);

            //Load

            LoadAllUnitOfMeasureList();
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
                // Check if the UnitOfMeasure already exists by name
                var existingEntity = _unitOfWork.UnitOfMeasure.Get(c => c.UnitOfMeasureName == _view.UnitOfMeasureName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.UnitOfMeasureId != _view.UnitOfMeasureId)
                        {
                            _view.Message = "Another Customer type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Customer type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the UnitOfMeasure entity
                UnitOfMeasure entity;
                if (_view.UnitOfMeasureId == 0)
                {
                    entity = new UnitOfMeasure()
                    {
                        UnitOfMeasureName = _view.UnitOfMeasureName,
                        Description = _view.Description
                    };
                    _unitOfWork.UnitOfMeasure.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.UnitOfMeasure.Get(c => c.UnitOfMeasureId == _view.UnitOfMeasureId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.UnitOfMeasureName = _view.UnitOfMeasureName;
                    entity.Description = _view.Description;
                    _unitOfWork.UnitOfMeasure.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Customer type edited successfully" : "Customer type added successfully";
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
        //   var Entity = _unitOfWork.UnitOfMeasure.Get(c => c.UnitOfMeasureName == _view.UnitOfMeasureName);
        //   if (Entity != null && _view.UnitOfMeasureId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.UnitOfMeasureId == 0)
        //        {

        //        Entity = new UnitOfMeasure()
        //        {
        //            UnitOfMeasureId = _view.UnitOfMeasureId,
        //            UnitOfMeasureName = _view.UnitOfMeasureName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.UnitOfMeasureName = _view.UnitOfMeasureName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.UnitOfMeasure.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.UnitOfMeasure.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type added sucessfully";
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
                UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll(c => c.UnitOfMeasureName.Contains(_view.SearchValue));
                UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;
            }
            else
            {
                UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll();
                UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (UnitOfMeasure)UnitOfMeasureBindingSource.Current;
            _view.UnitOfMeasureId = entity.UnitOfMeasureId;
            _view.UnitOfMeasureName = entity.UnitOfMeasureName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (UnitOfMeasure)UnitOfMeasureBindingSource.Current;
                _unitOfWork.UnitOfMeasure.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllUnitOfMeasureList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "UnitOfMeasureListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("UnitOfMeasureList", UnitOfMeasureList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllUnitOfMeasureList();
        }
        private void CleanviewFields()
        {
            LoadAllUnitOfMeasureList();
            _view.UnitOfMeasureId = 0;
            _view.UnitOfMeasureName = "";
            _view.Description = "";
        }
        
        private void LoadAllUnitOfMeasureList()
        {
            UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll();
            UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;//Set data source.
        }
    }
}
