using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentVoucherPresenter
    {
        public IPaymentVoucherView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentVoucherBindingSource;
        private IEnumerable<PaymentVoucher> PaymentVoucherList;
        public PaymentVoucherPresenter(IPaymentVoucherView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentVoucherBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPaymentVoucherListBindingSource(PaymentVoucherBindingSource);

            //Load

            LoadAllPaymentVoucherList();
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
                // Check if the PaymentVoucher already exists by name
                var existingEntity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherName == _view.PaymentVoucherName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.PaymentVoucherId != _view.PaymentVoucherId)
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

                // Create or update the PaymentVoucher entity
                PaymentVoucher entity;
                if (_view.PaymentVoucherId == 0)
                {
                    entity = new PaymentVoucher()
                    {
                        PaymentVoucherName = _view.PaymentVoucherName,
                        //Description = _view.Description
                    };
                    _unitOfWork.PaymentVoucher.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherId == _view.PaymentVoucherId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.PaymentVoucherName = _view.PaymentVoucherName;
                   // entity.Description = _view.Description;
                    _unitOfWork.PaymentVoucher.Update(entity);
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
        //   var Entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherName == _view.PaymentVoucherName);
        //   if (Entity != null && _view.PaymentVoucherId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.PaymentVoucherId == 0)
        //        {

        //        Entity = new PaymentVoucher()
        //        {
        //            PaymentVoucherId = _view.PaymentVoucherId,
        //            PaymentVoucherName = _view.PaymentVoucherName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.PaymentVoucherName = _view.PaymentVoucherName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.PaymentVoucher.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.PaymentVoucher.Add(Entity);
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
                PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll(c => c.PaymentVoucherName.Contains(_view.SearchValue));
                PaymentVoucherBindingSource.DataSource = PaymentVoucherList;
            }
            else
            {
                PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll();
                PaymentVoucherBindingSource.DataSource = PaymentVoucherList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PaymentVoucher)PaymentVoucherBindingSource.Current;
            _view.PaymentVoucherId = entity.PaymentVoucherId;
            _view.PaymentVoucherName = entity.PaymentVoucherName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PaymentVoucher)PaymentVoucherBindingSource.Current;
                _unitOfWork.PaymentVoucher.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllPaymentVoucherList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentVoucherListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentVoucherList", PaymentVoucherList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentVoucherList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentVoucherList();
            _view.PaymentVoucherId = 0;
            _view.PaymentVoucherName = "";
            _view.Description = "";
        }
        
        private void LoadAllPaymentVoucherList()
        {
            PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll();
            PaymentVoucherBindingSource.DataSource = PaymentVoucherList;//Set data source.
        }
    }
}
