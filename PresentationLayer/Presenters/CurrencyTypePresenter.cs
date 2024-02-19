using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class CurrencyPresenter
    {
        public ICurrencyView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<Currency> CurrencyList;
        public CurrencyPresenter(ICurrencyView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CurrencyBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);

            //Load

            LoadAllCurrencyList();
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
                // Check if the Currency already exists by name
                var existingEntity = _unitOfWork.Currency.Get(c => c.CurrencyName == _view.CurrencyName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.CurrencyId != _view.CurrencyId)
                        {
                            _view.Message = "Another Currency with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Currency with the same name already exists.";
                        return;
                    }
                }

                // Create or update the Currency entity
                Currency entity;
                if (_view.CurrencyId == 0)
                {
                    entity = new Currency()
                    {
                        CurrencyName = _view.CurrencyName,
                        CurrencyCode = _view.CurrencyCode,
                        Description = _view.Description
                    };
                    _unitOfWork.Currency.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Currency.Get(c => c.CurrencyId == _view.CurrencyId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Currency not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.CurrencyName = _view.CurrencyName;
                    entity.CurrencyCode = _view.CurrencyCode;
                    entity.Description = _view.Description;
                    _unitOfWork.Currency.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Currency edited successfully" : "Currency added successfully";
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
        //   var Entity = _unitOfWork.Currency.Get(c => c.CurrencyName == _view.CurrencyName);
        //   if (Entity != null && _view.CurrencyId == 0)
        //        {
        //            _view.Message = "Currency is already added.";
        //            return;
        //        }
        //        if(_view.CurrencyId == 0)
        //        {

        //        Entity = new Currency()
        //        {
        //            CurrencyId = _view.CurrencyId,
        //            CurrencyName = _view.CurrencyName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.CurrencyName = _view.CurrencyName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Currency.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Currency edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Currency.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Currency added sucessfully";
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
                CurrencyList = _unitOfWork.Currency.GetAll(c => c.CurrencyName.Contains(_view.SearchValue));
                CurrencyBindingSource.DataSource = CurrencyList;
            }
            else
            {
                CurrencyList = _unitOfWork.Currency.GetAll();
                CurrencyBindingSource.DataSource = CurrencyList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Currency)CurrencyBindingSource.Current;
            _view.CurrencyId = entity.CurrencyId;
            _view.CurrencyName = entity.CurrencyName;
            _view.CurrencyCode = entity.CurrencyCode;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Currency)CurrencyBindingSource.Current;
                _unitOfWork.Currency.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Currency deleted successfully";
                LoadAllCurrencyList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Currency";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CurrencyListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CurrencyList", CurrencyList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCurrencyList();
        }
        private void CleanviewFields()
        {
            LoadAllCurrencyList();
            _view.CurrencyId = 0;
            _view.CurrencyName = "";
            _view.CurrencyCode = "";
            _view.Description = "";
        }
        
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
