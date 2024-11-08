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
            var Entity = _unitOfWork.CashBank.Get(c => c.CashBankName == _view.CashBankName);
            if (Entity != null)
            {
                _view.Message = "Bill type is already added.";
                return;
            }

            var model = new CashBank()
            {
                
                CashBankId = _view.CashBankId,
                CashBankName = _view.CashBankName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.CashBank.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.CashBank.Add(model);
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
            string reportFileName = "CashBankReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CashBank", CashBankList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
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
