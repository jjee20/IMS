using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PurchaseOrderPresenter
    {
        public IPurchaseOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PurchaseOrderBindingSource;
        private IEnumerable<PurchaseOrder> PurchaseOrderList;
        public PurchaseOrderPresenter(IPurchaseOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PurchaseOrderBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPurchaseOrderListBindingSource(PurchaseOrderBindingSource);

            //Load

            LoadAllPurchaseOrderList();
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
                // Check if the PurchaseOrder already exists by name
                var existingEntity = _unitOfWork.PurchaseOrder.Get(c => c.PurchaseOrderName == _view.PurchaseOrderName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.PurchaseOrderId != _view.PurchaseOrderId)
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

                // Create or update the PurchaseOrder entity
                PurchaseOrder entity;
                if (_view.PurchaseOrderId == 0)
                {
                    entity = new PurchaseOrder()
                    {
                        PurchaseOrderName = _view.PurchaseOrderName,
                        //Description = _view.Description
                    };
                    _unitOfWork.PurchaseOrder.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.PurchaseOrder.Get(c => c.PurchaseOrderId == _view.PurchaseOrderId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.PurchaseOrderName = _view.PurchaseOrderName;
                    //entity.Description = _view.Description;
                    _unitOfWork.PurchaseOrder.Update(entity);
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
        //   var Entity = _unitOfWork.PurchaseOrder.Get(c => c.PurchaseOrderName == _view.PurchaseOrderName);
        //   if (Entity != null && _view.PurchaseOrderId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.PurchaseOrderId == 0)
        //        {

        //        Entity = new PurchaseOrder()
        //        {
        //            PurchaseOrderId = _view.PurchaseOrderId,
        //            PurchaseOrderName = _view.PurchaseOrderName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.PurchaseOrderName = _view.PurchaseOrderName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.PurchaseOrder.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.PurchaseOrder.Add(Entity);
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
                PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll(c => c.PurchaseOrderName.Contains(_view.SearchValue));
                PurchaseOrderBindingSource.DataSource = PurchaseOrderList;
            }
            else
            {
                PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll();
                PurchaseOrderBindingSource.DataSource = PurchaseOrderList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PurchaseOrder)PurchaseOrderBindingSource.Current;
            _view.PurchaseOrderId = entity.PurchaseOrderId;
            _view.PurchaseOrderName = entity.PurchaseOrderName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PurchaseOrder)PurchaseOrderBindingSource.Current;
                _unitOfWork.PurchaseOrder.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllPurchaseOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseOrderListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseOrderList", PurchaseOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPurchaseOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllPurchaseOrderList();
            _view.PurchaseOrderId = 0;
            _view.PurchaseOrderName = "";
            _view.Description = "";
        }
        
        private void LoadAllPurchaseOrderList()
        {
            PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll();
            PurchaseOrderBindingSource.DataSource = PurchaseOrderList;//Set data source.
        }
    }
}
