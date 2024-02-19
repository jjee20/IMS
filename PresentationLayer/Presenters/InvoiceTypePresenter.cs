using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class InvoiceTypePresenter
    {
        public IInvoiceTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource InvoiceTypeBindingSource;
        private IEnumerable<InvoiceType> InvoiceTypeList;
        public InvoiceTypePresenter(IInvoiceTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            InvoiceTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetInvoiceTypeListBindingSource(InvoiceTypeBindingSource);

            //Load

            LoadAllInvoiceTypeList();
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
                // Check if the InvoiceType already exists by name
                var existingEntity = _unitOfWork.InvoiceType.Get(c => c.InvoiceTypeName == _view.InvoiceTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.InvoiceTypeId != _view.InvoiceTypeId)
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

                // Create or update the InvoiceType entity
                InvoiceType entity;
                if (_view.InvoiceTypeId == 0)
                {
                    entity = new InvoiceType()
                    {
                        InvoiceTypeName = _view.InvoiceTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.InvoiceType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.InvoiceType.Get(c => c.InvoiceTypeId == _view.InvoiceTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.InvoiceTypeName = _view.InvoiceTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.InvoiceType.Update(entity);
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
        //   var Entity = _unitOfWork.InvoiceType.Get(c => c.InvoiceTypeName == _view.InvoiceTypeName);
        //   if (Entity != null && _view.InvoiceTypeId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.InvoiceTypeId == 0)
        //        {

        //        Entity = new InvoiceType()
        //        {
        //            InvoiceTypeId = _view.InvoiceTypeId,
        //            InvoiceTypeName = _view.InvoiceTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.InvoiceTypeName = _view.InvoiceTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.InvoiceType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.InvoiceType.Add(Entity);
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
                InvoiceTypeList = _unitOfWork.InvoiceType.GetAll(c => c.InvoiceTypeName.Contains(_view.SearchValue));
                InvoiceTypeBindingSource.DataSource = InvoiceTypeList;
            }
            else
            {
                InvoiceTypeList = _unitOfWork.InvoiceType.GetAll();
                InvoiceTypeBindingSource.DataSource = InvoiceTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (InvoiceType)InvoiceTypeBindingSource.Current;
            _view.InvoiceTypeId = entity.InvoiceTypeId;
            _view.InvoiceTypeName = entity.InvoiceTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (InvoiceType)InvoiceTypeBindingSource.Current;
                _unitOfWork.InvoiceType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllInvoiceTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "InvoiceTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("InvoiceTypeList", InvoiceTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllInvoiceTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllInvoiceTypeList();
            _view.InvoiceTypeId = 0;
            _view.InvoiceTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllInvoiceTypeList()
        {
            InvoiceTypeList = _unitOfWork.InvoiceType.GetAll();
            InvoiceTypeBindingSource.DataSource = InvoiceTypeList;//Set data source.
        }
    }
}
