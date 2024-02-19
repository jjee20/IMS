using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class BillPresenter
    {
        public IBillView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BillBindingSource;
        private IEnumerable<Bill> BillList;
        public BillPresenter(IBillView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BillBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetBillListBindingSource(BillBindingSource);

            //Load

            LoadAllBillList();
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
                // Check if the Bill already exists by name
                var existingEntity = _unitOfWork.Bill.Get(c => c.BillName == _view.BillName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.BillId != _view.BillId)
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

                // Create or update the Bill entity
                Bill entity;
                if (_view.BillId == 0)
                {
                    entity = new Bill()
                    {
                        BillName = _view.BillName,
                        //Description = _view.Description
                    };
                    _unitOfWork.Bill.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Bill.Get(c => c.BillId == _view.BillId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.BillName = _view.BillName;
                    //entity.Description = _view.Description;
                    _unitOfWork.Bill.Update(entity);
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
        //   var Entity = _unitOfWork.Bill.Get(c => c.BillName == _view.BillName);
        //   if (Entity != null && _view.BillId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.BillId == 0)
        //        {

        //        Entity = new Bill()
        //        {
        //            BillId = _view.BillId,
        //            BillName = _view.BillName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.BillName = _view.BillName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Bill.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Bill.Add(Entity);
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
                BillList = _unitOfWork.Bill.GetAll(c => c.BillName.Contains(_view.SearchValue));
                BillBindingSource.DataSource = BillList;
            }
            else
            {
                BillList = _unitOfWork.Bill.GetAll();
                BillBindingSource.DataSource = BillList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Bill)BillBindingSource.Current;
            _view.BillId = entity.BillId;
            _view.BillName = entity.BillName;
            //_view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Bill)BillBindingSource.Current;
                _unitOfWork.Bill.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllBillList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BillListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("BillList", BillList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBillList();
        }
        private void CleanviewFields()
        {
            LoadAllBillList();
            _view.BillId = 0;
            _view.BillName = "";
            _view.Description = "";
        }
        
        private void LoadAllBillList()
        {
            BillList = _unitOfWork.Bill.GetAll();
            BillBindingSource.DataSource = BillList;//Set data source.
        }
    }
}
