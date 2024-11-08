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
            var Entity = _unitOfWork.Currency.Get(c => c.CurrencyName == _view.CurrencyName);
            if (Entity != null)
            {
                _view.Message = "Bill type is already added.";
                return;
            }

            var model = new Currency()
            {
                
                CurrencyId = _view.CurrencyId,
                CurrencyName = _view.CurrencyName,
                CurrencyCode = _view.CurrencyCode,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Currency.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.Currency.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type added sucessfully";
                }
                _view.IsSuccessful = true;
                CleanviewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }
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
                _view.Message = "Bill type deleted successfully";
                LoadAllCurrencyList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CurrencyReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Currency", CurrencyList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
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
