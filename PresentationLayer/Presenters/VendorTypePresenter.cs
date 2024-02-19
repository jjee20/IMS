using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class VendorTypePresenter
    {
        public IVendorTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource VendorTypeBindingSource;
        private IEnumerable<VendorType> VendorTypeList;
        public VendorTypePresenter(IVendorTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            VendorTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetVendorTypeListBindingSource(VendorTypeBindingSource);

            //Load

            LoadAllVendorTypeList();
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
                // Check if the VendorType already exists by name
                var existingEntity = _unitOfWork.VendorType.Get(c => c.VendorTypeName == _view.VendorTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.VendorTypeId != _view.VendorTypeId)
                        {
                            _view.Message = "Another Vendor type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Vendor type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the VendorType entity
                VendorType entity;
                if (_view.VendorTypeId == 0)
                {
                    entity = new VendorType()
                    {
                        VendorTypeName = _view.VendorTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.VendorType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.VendorType.Get(c => c.VendorTypeId == _view.VendorTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Vendor type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.VendorTypeName = _view.VendorTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.VendorType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Vendor type edited successfully" : "Vendor type added successfully";
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
        //   var Entity = _unitOfWork.VendorType.Get(c => c.VendorTypeName == _view.VendorTypeName);
        //   if (Entity != null && _view.VendorTypeId == 0)
        //        {
        //            _view.Message = "Vendor type is already added.";
        //            return;
        //        }
        //        if(_view.VendorTypeId == 0)
        //        {

        //        Entity = new VendorType()
        //        {
        //            VendorTypeId = _view.VendorTypeId,
        //            VendorTypeName = _view.VendorTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.VendorTypeName = _view.VendorTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.VendorType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Vendor type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.VendorType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Vendor type added sucessfully";
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
                VendorTypeList = _unitOfWork.VendorType.GetAll(c => c.VendorTypeName.Contains(_view.SearchValue));
                VendorTypeBindingSource.DataSource = VendorTypeList;
            }
            else
            {
                VendorTypeList = _unitOfWork.VendorType.GetAll();
                VendorTypeBindingSource.DataSource = VendorTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (VendorType)VendorTypeBindingSource.Current;
            _view.VendorTypeId = entity.VendorTypeId;
            _view.VendorTypeName = entity.VendorTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (VendorType)VendorTypeBindingSource.Current;
                _unitOfWork.VendorType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Vendor type deleted successfully";
                LoadAllVendorTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Vendor type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "VendorTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("VendorTypeList", VendorTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllVendorTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllVendorTypeList();
            _view.VendorTypeId = 0;
            _view.VendorTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllVendorTypeList()
        {
            VendorTypeList = _unitOfWork.VendorType.GetAll();
            VendorTypeBindingSource.DataSource = VendorTypeList;//Set data source.
        }
    }
}
