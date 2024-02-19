using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentReceivePresenter
    {
        public IPaymentReceiveView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentReceiveBindingSource;
        private IEnumerable<PaymentReceive> PaymentReceiveList;
        public PaymentReceivePresenter(IPaymentReceiveView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentReceiveBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPaymentReceiveListBindingSource(PaymentReceiveBindingSource);

            //Load

            LoadAllPaymentReceiveList();
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
                // Check if the PaymentReceive already exists by name
                var existingEntity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveName == _view.PaymentReceiveName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.PaymentReceiveId != _view.PaymentReceiveId)
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

                // Create or update the PaymentReceive entity
                PaymentReceive entity;
                if (_view.PaymentReceiveId == 0)
                {
                    entity = new PaymentReceive()
                    {
                        PaymentReceiveName = _view.PaymentReceiveName,
                        //Description = _view.Description
                    };
                    _unitOfWork.PaymentReceive.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveId == _view.PaymentReceiveId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.PaymentReceiveName = _view.PaymentReceiveName;
                    //entity.Description = _view.Description;
                    _unitOfWork.PaymentReceive.Update(entity);
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
        //   var Entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveName == _view.PaymentReceiveName);
        //   if (Entity != null && _view.PaymentReceiveId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.PaymentReceiveId == 0)
        //        {

        //        Entity = new PaymentReceive()
        //        {
        //            PaymentReceiveId = _view.PaymentReceiveId,
        //            PaymentReceiveName = _view.PaymentReceiveName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.PaymentReceiveName = _view.PaymentReceiveName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.PaymentReceive.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.PaymentReceive.Add(Entity);
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
                PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll(c => c.PaymentReceiveName.Contains(_view.SearchValue));
                PaymentReceiveBindingSource.DataSource = PaymentReceiveList;
            }
            else
            {
                PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll();
                PaymentReceiveBindingSource.DataSource = PaymentReceiveList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PaymentReceive)PaymentReceiveBindingSource.Current;
            _view.PaymentReceiveId = entity.PaymentReceiveId;
            _view.PaymentReceiveName = entity.PaymentReceiveName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PaymentReceive)PaymentReceiveBindingSource.Current;
                _unitOfWork.PaymentReceive.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllPaymentReceiveList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentReceiveListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentReceiveList", PaymentReceiveList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentReceiveList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentReceiveList();
            _view.PaymentReceiveId = 0;
            _view.PaymentReceiveName = "";
            _view.Description = "";
        }
        
        private void LoadAllPaymentReceiveList()
        {
            PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll();
            PaymentReceiveBindingSource.DataSource = PaymentReceiveList;//Set data source.
        }
    }
}
