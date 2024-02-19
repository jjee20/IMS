using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class BillTypePresenter
    {
        public IBillTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BillTypeBindingSource;
        private IEnumerable<BillType> BillTypeList;
        public BillTypePresenter(IBillTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BillTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetBillTypeListBindingSource(BillTypeBindingSource);

            //Load

            LoadAllBillTypeList();
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
                // Check if the BillType already exists by name
                var existingEntity = _unitOfWork.BillType.Get(c => c.BillTypeName == _view.BillTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.BillTypeId != _view.BillTypeId)
                        {
                            _view.Message = "Another Bill type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Bill type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the BillType entity
                BillType entity;
                if (_view.BillTypeId == 0)
                {
                    entity = new BillType()
                    {
                        BillTypeName = _view.BillTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.BillType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.BillType.Get(c => c.BillTypeId == _view.BillTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Bill type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.BillTypeName = _view.BillTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.BillType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Bill type edited successfully" : "Bill type added successfully";
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
        //   var Entity = _unitOfWork.BillType.Get(c => c.BillTypeName == _view.BillTypeName);
        //   if (Entity != null && _view.BillTypeId == 0)
        //        {
        //            _view.Message = "Bill type is already added.";
        //            return;
        //        }
        //        if(_view.BillTypeId == 0)
        //        {

        //        Entity = new BillType()
        //        {
        //            BillTypeId = _view.BillTypeId,
        //            BillTypeName = _view.BillTypeName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.BillTypeName = _view.BillTypeName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.BillType.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Bill type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.BillType.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Bill type added sucessfully";
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
                BillTypeList = _unitOfWork.BillType.GetAll(c => c.BillTypeName.Contains(_view.SearchValue));
                BillTypeBindingSource.DataSource = BillTypeList;
            }
            else
            {
                BillTypeList = _unitOfWork.BillType.GetAll();
                BillTypeBindingSource.DataSource = BillTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (BillType)BillTypeBindingSource.Current;
            _view.BillTypeId = entity.BillTypeId;
            _view.BillTypeName = entity.BillTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (BillType)BillTypeBindingSource.Current;
                _unitOfWork.BillType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill type deleted successfully";
                LoadAllBillTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BillTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("BillTypeList", BillTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBillTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllBillTypeList();
            _view.BillTypeId = 0;
            _view.BillTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllBillTypeList()
        {
            BillTypeList = _unitOfWork.BillType.GetAll();
            BillTypeBindingSource.DataSource = BillTypeList;//Set data source.
        }
    }
}
