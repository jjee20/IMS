using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class SalesOrderPresenter
    {
        public ISalesOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource SalesOrderBindingSource;
        private IEnumerable<SalesOrder> SalesOrderList;
        public SalesOrderPresenter(ISalesOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            SalesOrderBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);

            //Load

            LoadAllSalesOrderList();
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
                // Check if the SalesOrder already exists by name
                var existingEntity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderName == _view.SalesOrderName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.SalesOrderId != _view.SalesOrderId)
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

                // Create or update the SalesOrder entity
                SalesOrder entity;
                if (_view.SalesOrderId == 0)
                {
                    entity = new SalesOrder()
                    {
                        SalesOrderName = _view.SalesOrderName,
                        //Description = _view.Description
                    };
                    _unitOfWork.SalesOrder.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderId == _view.SalesOrderId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.SalesOrderName = _view.SalesOrderName;
                    //entity.Description = _view.Description;
                    _unitOfWork.SalesOrder.Update(entity);
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
        //   var Entity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderName == _view.SalesOrderName);
        //   if (Entity != null && _view.SalesOrderId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.SalesOrderId == 0)
        //        {

        //        Entity = new SalesOrder()
        //        {
        //            SalesOrderId = _view.SalesOrderId,
        //            SalesOrderName = _view.SalesOrderName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.SalesOrderName = _view.SalesOrderName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.SalesOrder.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.SalesOrder.Add(Entity);
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
                SalesOrderList = _unitOfWork.SalesOrder.GetAll(c => c.SalesOrderName.Contains(_view.SearchValue));
                SalesOrderBindingSource.DataSource = SalesOrderList;
            }
            else
            {
                SalesOrderList = _unitOfWork.SalesOrder.GetAll();
                SalesOrderBindingSource.DataSource = SalesOrderList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (SalesOrder)SalesOrderBindingSource.Current;
            _view.SalesOrderId = entity.SalesOrderId;
            _view.SalesOrderName = entity.SalesOrderName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (SalesOrder)SalesOrderBindingSource.Current;
                _unitOfWork.SalesOrder.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllSalesOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesOrderListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesOrderList", SalesOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllSalesOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllSalesOrderList();
            _view.SalesOrderId = 0;
            _view.SalesOrderName = "";
            _view.Description = "";
        }
        
        private void LoadAllSalesOrderList()
        {
            SalesOrderList = _unitOfWork.SalesOrder.GetAll();
            SalesOrderBindingSource.DataSource = SalesOrderList;//Set data source.
        }
    }
}
