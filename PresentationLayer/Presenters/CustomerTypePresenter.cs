using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class CustomerTypePresenter
    {
        public ICustomerTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CustomerTypeBindingSource;
        private IEnumerable<CustomerType> CustomerTypeList;
        public CustomerTypePresenter(ICustomerTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CustomerTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetCustomerTypeListBindingSource(CustomerTypeBindingSource);

            //Load

            LoadAllCustomerTypeList();
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
                // Check if the CustomerType already exists by name
                var existingEntity = _unitOfWork.CustomerType.Get(c => c.CustomerTypeName == _view.CustomerTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.CustomerTypeId != _view.CustomerTypeId)
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

                // Create or update the CustomerType entity
                CustomerType entity;
                if (_view.CustomerTypeId == 0)
                {
                    entity = new CustomerType()
                    {
                        CustomerTypeName = _view.CustomerTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.CustomerType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.CustomerType.Get(c => c.CustomerTypeId == _view.CustomerTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.CustomerTypeName = _view.CustomerTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.CustomerType.Update(entity);
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
        //   var Entity = _unitOfWork.CustomerType.Get(c => c.CustomerTypeName == _view.CustomerTypeName);
        //   if (Entity != null && _view.CustomerTypeId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.CustomerTypeId == 0)
        //        {

        //        Entity = new CustomerType()
        //        {
        //            CustomerTypeId = _view.CustomerTypeId,
        //            CustomerTypeName = _view.CustomerTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.CustomerTypeName = _view.CustomerTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.CustomerType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.CustomerType.Add(Entity);
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
                CustomerTypeList = _unitOfWork.CustomerType.GetAll(c => c.CustomerTypeName.Contains(_view.SearchValue));
                CustomerTypeBindingSource.DataSource = CustomerTypeList;
            }
            else
            {
                CustomerTypeList = _unitOfWork.CustomerType.GetAll();
                CustomerTypeBindingSource.DataSource = CustomerTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (CustomerType)CustomerTypeBindingSource.Current;
            _view.CustomerTypeId = entity.CustomerTypeId;
            _view.CustomerTypeName = entity.CustomerTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (CustomerType)CustomerTypeBindingSource.Current;
                _unitOfWork.CustomerType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllCustomerTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CustomerTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CustomerTypeList", CustomerTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCustomerTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllCustomerTypeList();
            _view.CustomerTypeId = 0;
            _view.CustomerTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllCustomerTypeList()
        {
            CustomerTypeList = _unitOfWork.CustomerType.GetAll();
            CustomerTypeBindingSource.DataSource = CustomerTypeList;//Set data source.
        }
    }
}
