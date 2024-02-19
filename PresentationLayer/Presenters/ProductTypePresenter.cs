using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ProductTypePresenter
    {
        public IProductTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProductTypeBindingSource;
        private IEnumerable<ProductType> ProductTypeList;
        public ProductTypePresenter(IProductTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProductTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetProductTypeListBindingSource(ProductTypeBindingSource);

            //Load

            LoadAllProductTypeList();
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
                // Check if the ProductType already exists by name
                var existingEntity = _unitOfWork.ProductType.Get(c => c.ProductTypeName == _view.ProductTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.ProductTypeId != _view.ProductTypeId)
                        {
                            _view.Message = "Another Product type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Product type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the ProductType entity
                ProductType entity;
                if (_view.ProductTypeId == 0)
                {
                    entity = new ProductType()
                    {
                        ProductTypeName = _view.ProductTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.ProductType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.ProductType.Get(c => c.ProductTypeId == _view.ProductTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Product type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.ProductTypeName = _view.ProductTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.ProductType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Product type edited successfully" : "Product type added successfully";
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
        //   var Entity = _unitOfWork.ProductType.Get(c => c.ProductTypeName == _view.ProductTypeName);
        //   if (Entity != null && _view.ProductTypeId == 0)
        //        {
        //            _view.Message = "Product type is already added.";
        //            return;
        //        }
        //        if(_view.ProductTypeId == 0)
        //        {

        //        Entity = new ProductType()
        //        {
        //            ProductTypeId = _view.ProductTypeId,
        //            ProductTypeName = _view.ProductTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.ProductTypeName = _view.ProductTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.ProductType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Product type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.ProductType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Product type added sucessfully";
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
                ProductTypeList = _unitOfWork.ProductType.GetAll(c => c.ProductTypeName.Contains(_view.SearchValue));
                ProductTypeBindingSource.DataSource = ProductTypeList;
            }
            else
            {
                ProductTypeList = _unitOfWork.ProductType.GetAll();
                ProductTypeBindingSource.DataSource = ProductTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (ProductType)ProductTypeBindingSource.Current;
            _view.ProductTypeId = entity.ProductTypeId;
            _view.ProductTypeName = entity.ProductTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (ProductType)ProductTypeBindingSource.Current;
                _unitOfWork.ProductType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Product type deleted successfully";
                LoadAllProductTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Product type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductTypeList", ProductTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProductTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllProductTypeList();
            _view.ProductTypeId = 0;
            _view.ProductTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllProductTypeList()
        {
            ProductTypeList = _unitOfWork.ProductType.GetAll();
            ProductTypeBindingSource.DataSource = ProductTypeList;//Set data source.
        }
    }
}
