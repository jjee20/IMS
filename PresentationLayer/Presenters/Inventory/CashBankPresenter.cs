using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using System.Linq;

namespace PresentationLayer.Presenters
{
    public class CashBankPresenter
    {
        public ICashBankView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<CashBank> CashBankList;
        public CashBankPresenter(ICashBankView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load
            LoadAllCashBankList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.CashBank.Value.GetAsync(c => c.CashBankId == _view.CashBankId, tracked: true);
            if (model == null) model = new CashBank();
            else _unitOfWork.CashBank.Value.Detach(model);

            model.CashBankId = _view.CashBankId;
            model.CashBankName = _view.CashBankName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.CashBank.Value.Update(model);
                    _view.Message = "Cash bank edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.CashBank.Value.AddAsync(model);
                    _view.Message = "Cash bank added successfully";
                }
                    await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);
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
            LoadAllCashBankList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var entity = (CashBank)_view.DataGrid.SelectedItem;
            _view.CashBankId = entity.CashBankId;
            _view.CashBankName = entity.CashBankName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select items to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<CashBank>().ToList();
                var ids = selectedItems.Select(c => c.CashBankId).ToList();

                var entities = _unitOfWork.CashBank.Value
                    .GetAll()
                    .Where(c => ids.Contains(c.CashBankId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Selected records could not be found in the database.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.CashBank.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{entities.Count} cash bank record(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllCashBankList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"An error occurred while deleting: {ex.Message}";
                _view.ShowMessage(_view.Message);
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CashBankReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
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
        
        private void LoadAllCashBankList(bool emptyValue = false)
        {
            CashBankList = _unitOfWork.CashBank.Value.GetAll();

            if (!emptyValue) CashBankList = CashBankList.Where(c => c.CashBankName.Contains(_view.SearchValue));
            _view.SetCashBankListBindingSource(CashBankList);
        }
    }
}
