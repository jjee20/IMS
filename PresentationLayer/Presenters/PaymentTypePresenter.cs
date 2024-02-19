using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentTypePresenter
    {
        public IPaymentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentTypeBindingSource;
        private IEnumerable<PaymentType> PaymentTypeList;
        public PaymentTypePresenter(IPaymentTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);

            //Load

            LoadAllPaymentTypeList();
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
                // Check if the PaymentType already exists by name
                var existingEntity = _unitOfWork.PaymentType.Get(c => c.PaymentTypeName == _view.PaymentTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.PaymentTypeId != _view.PaymentTypeId)
                        {
                            _view.Message = "Another Payment type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Payment type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the PaymentType entity
                PaymentType entity;
                if (_view.PaymentTypeId == 0)
                {
                    entity = new PaymentType()
                    {
                        PaymentTypeName = _view.PaymentTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.PaymentType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.PaymentType.Get(c => c.PaymentTypeId == _view.PaymentTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Payment type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.PaymentTypeName = _view.PaymentTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.PaymentType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Payment type edited successfully" : "Payment type added successfully";
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
        //   var Entity = _unitOfWork.PaymentType.Get(c => c.PaymentTypeName == _view.PaymentTypeName);
        //   if (Entity != null && _view.PaymentTypeId == 0)
        //        {
        //            _view.Message = "Payment type is already added.";
        //            return;
        //        }
        //        if(_view.PaymentTypeId == 0)
        //        {

        //        Entity = new PaymentType()
        //        {
        //            PaymentTypeId = _view.PaymentTypeId,
        //            PaymentTypeName = _view.PaymentTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.PaymentTypeName = _view.PaymentTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.PaymentType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Payment type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.PaymentType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Payment type added sucessfully";
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
                PaymentTypeList = _unitOfWork.PaymentType.GetAll(c => c.PaymentTypeName.Contains(_view.SearchValue));
                PaymentTypeBindingSource.DataSource = PaymentTypeList;
            }
            else
            {
                PaymentTypeList = _unitOfWork.PaymentType.GetAll();
                PaymentTypeBindingSource.DataSource = PaymentTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PaymentType)PaymentTypeBindingSource.Current;
            _view.PaymentTypeId = entity.PaymentTypeId;
            _view.PaymentTypeName = entity.PaymentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PaymentType)PaymentTypeBindingSource.Current;
                _unitOfWork.PaymentType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Payment type deleted successfully";
                LoadAllPaymentTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Payment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentTypeList", PaymentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentTypeList();
            _view.PaymentTypeId = 0;
            _view.PaymentTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllPaymentTypeList()
        {
            PaymentTypeList = _unitOfWork.PaymentType.GetAll();
            PaymentTypeBindingSource.DataSource = PaymentTypeList;//Set data source.
        }
    }
}
