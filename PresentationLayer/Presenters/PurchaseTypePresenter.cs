using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PurchaseTypePresenter
    {
        public IPurchaseTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PurchaseTypeBindingSource;
        private IEnumerable<PurchaseType> PurchaseTypeList;
        public PurchaseTypePresenter(IPurchaseTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PurchaseTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeBindingSource);

            //Load

            LoadAllPurchaseTypeList();
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
                // Check if the PurchaseType already exists by name
                var existingEntity = _unitOfWork.PurchaseType.Get(c => c.PurchaseTypeName == _view.PurchaseTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.PurchaseTypeId != _view.PurchaseTypeId)
                        {
                            _view.Message = "Another Purchase type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Purchase type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the PurchaseType entity
                PurchaseType entity;
                if (_view.PurchaseTypeId == 0)
                {
                    entity = new PurchaseType()
                    {
                        PurchaseTypeName = _view.PurchaseTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.PurchaseType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.PurchaseType.Get(c => c.PurchaseTypeId == _view.PurchaseTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Purchase type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.PurchaseTypeName = _view.PurchaseTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.PurchaseType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Purchase type edited successfully" : "Purchase type added successfully";
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
        //   var Entity = _unitOfWork.PurchaseType.Get(c => c.PurchaseTypeName == _view.PurchaseTypeName);
        //   if (Entity != null && _view.PurchaseTypeId == 0)
        //        {
        //            _view.Message = "Purchase type is already added.";
        //            return;
        //        }
        //        if(_view.PurchaseTypeId == 0)
        //        {

        //        Entity = new PurchaseType()
        //        {
        //            PurchaseTypeId = _view.PurchaseTypeId,
        //            PurchaseTypeName = _view.PurchaseTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.PurchaseTypeName = _view.PurchaseTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.PurchaseType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Purchase type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.PurchaseType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Purchase type added sucessfully";
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
                PurchaseTypeList = _unitOfWork.PurchaseType.GetAll(c => c.PurchaseTypeName.Contains(_view.SearchValue));
                PurchaseTypeBindingSource.DataSource = PurchaseTypeList;
            }
            else
            {
                PurchaseTypeList = _unitOfWork.PurchaseType.GetAll();
                PurchaseTypeBindingSource.DataSource = PurchaseTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PurchaseType)PurchaseTypeBindingSource.Current;
            _view.PurchaseTypeId = entity.PurchaseTypeId;
            _view.PurchaseTypeName = entity.PurchaseTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PurchaseType)PurchaseTypeBindingSource.Current;
                _unitOfWork.PurchaseType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Purchase type deleted successfully";
                LoadAllPurchaseTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Purchase type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseTypeList", PurchaseTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPurchaseTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllPurchaseTypeList();
            _view.PurchaseTypeId = 0;
            _view.PurchaseTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllPurchaseTypeList()
        {
            PurchaseTypeList = _unitOfWork.PurchaseType.GetAll();
            PurchaseTypeBindingSource.DataSource = PurchaseTypeList;//Set data source.
        }
    }
}
