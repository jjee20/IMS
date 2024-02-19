using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class CashBankPresenter
    {
        public ICashBankView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CashBankBindingSource;
        private IEnumerable<CashBank> CashBankList;
        public CashBankPresenter(ICashBankView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CashBankBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetCashBankListBindingSource(CashBankBindingSource);

            //Load

            LoadAllCashBankList();
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
                // Check if the CashBank already exists by name
                var existingEntity = _unitOfWork.CashBank.Get(c => c.CashBankName == _view.CashBankName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.CashBankId != _view.CashBankId)
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

                // Create or update the CashBank entity
                CashBank entity;
                if (_view.CashBankId == 0)
                {
                    entity = new CashBank()
                    {
                        CashBankName = _view.CashBankName,
                        Description = _view.Description
                    };
                    _unitOfWork.CashBank.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.CashBank.Get(c => c.CashBankId == _view.CashBankId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Bill type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.CashBankName = _view.CashBankName;
                    entity.Description = _view.Description;
                    _unitOfWork.CashBank.Update(entity);
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
        //   var Entity = _unitOfWork.CashBank.Get(c => c.CashBankName == _view.CashBankName);
        //   if (Entity != null && _view.CashBankId == 0)
        //        {
        //            _view.Message = "Bill type is already added.";
        //            return;
        //        }
        //        if(_view.CashBankId == 0)
        //        {

        //        Entity = new CashBank()
        //        {
        //            CashBankId = _view.CashBankId,
        //            CashBankName = _view.CashBankName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.CashBankName = _view.CashBankName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.CashBank.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Bill type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.CashBank.Add(Entity);
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
                CashBankList = _unitOfWork.CashBank.GetAll(c => c.CashBankName.Contains(_view.SearchValue));
                CashBankBindingSource.DataSource = CashBankList;
            }
            else
            {
                CashBankList = _unitOfWork.CashBank.GetAll();
                CashBankBindingSource.DataSource = CashBankList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (CashBank)CashBankBindingSource.Current;
            _view.CashBankId = entity.CashBankId;
            _view.CashBankName = entity.CashBankName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (CashBank)CashBankBindingSource.Current;
                _unitOfWork.CashBank.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill type deleted successfully";
                LoadAllCashBankList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CashBankListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CashBankList", CashBankList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCashBankList();
        }
        private void CleanviewFields()
        {
            LoadAllCashBankList();
            _view.CashBankId = 0;
            _view.CashBankName = "";
            _view.Description = "";
        }
        
        private void LoadAllCashBankList()
        {
            CashBankList = _unitOfWork.CashBank.GetAll();
            CashBankBindingSource.DataSource = CashBankList;//Set data source.
        }
    }
}
