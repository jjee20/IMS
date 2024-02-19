using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class InvoicePresenter
    {
        public IInvoiceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource InvoiceBindingSource;
        private IEnumerable<Invoice> InvoiceList;
        public InvoicePresenter(IInvoiceView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            InvoiceBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetInvoiceListBindingSource(InvoiceBindingSource);

            //Load

            LoadAllInvoiceList();
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
                // Check if the Invoice already exists by name
                var existingEntity = _unitOfWork.Invoice.Get(c => c.InvoiceName == _view.InvoiceName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.InvoiceId != _view.InvoiceId)
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

                // Create or update the Invoice entity
                Invoice entity;
                if (_view.InvoiceId == 0)
                {
                    entity = new Invoice()
                    {
                        InvoiceName = _view.InvoiceName,
                        //Description = _view.Description
                    };
                    _unitOfWork.Invoice.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Invoice.Get(c => c.InvoiceId == _view.InvoiceId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.InvoiceName = _view.InvoiceName;
                    //entity.Description = _view.Description;
                    _unitOfWork.Invoice.Update(entity);
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
        //   var Entity = _unitOfWork.Invoice.Get(c => c.InvoiceName == _view.InvoiceName);
        //   if (Entity != null && _view.InvoiceId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.InvoiceId == 0)
        //        {

        //        Entity = new Invoice()
        //        {
        //            InvoiceId = _view.InvoiceId,
        //            InvoiceName = _view.InvoiceName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.InvoiceName = _view.InvoiceName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Invoice.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Invoice.Add(Entity);
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
                InvoiceList = _unitOfWork.Invoice.GetAll(c => c.InvoiceName.Contains(_view.SearchValue));
                InvoiceBindingSource.DataSource = InvoiceList;
            }
            else
            {
                InvoiceList = _unitOfWork.Invoice.GetAll();
                InvoiceBindingSource.DataSource = InvoiceList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Invoice)InvoiceBindingSource.Current;
            _view.InvoiceId = entity.InvoiceId;
            _view.InvoiceName = entity.InvoiceName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Invoice)InvoiceBindingSource.Current;
                _unitOfWork.Invoice.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllInvoiceList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "InvoiceListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("InvoiceList", InvoiceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllInvoiceList();
        }
        private void CleanviewFields()
        {
            LoadAllInvoiceList();
            _view.InvoiceId = 0;
            _view.InvoiceName = "";
            _view.Description = "";
        }
        
        private void LoadAllInvoiceList()
        {
            InvoiceList = _unitOfWork.Invoice.GetAll();
            InvoiceBindingSource.DataSource = InvoiceList;//Set data source.
        }
    }
}
