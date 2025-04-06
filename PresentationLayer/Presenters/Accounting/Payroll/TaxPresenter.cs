using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class TaxPresenter
    {
        public ITaxView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<Tax> TaxList;
        public TaxPresenter(ITaxView view, IUnitOfWork unitOfWork)
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

            LoadAllTaxList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.Tax.Value.GetAsync(c => c.TaxId == _view.TaxId, tracked: true);

            if (model == null) model = new Tax();
            else _unitOfWork.Tax.Value.Detach(model);

            model.TaxId = _view.TaxId;
            model.MinimumSalary = _view.MinimumSalary;
            model.MaximumSalary = _view.MaximumSalary;
            model.TaxRate = _view.TaxRate;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Tax.Value.Update(model);
                    _view.Message = "Tax edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.Tax.Value.AddAsync(model);
                    _view.Message = "Tax added successfully";
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
            LoadAllTaxList(emptyValue);
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

            var entity = (Tax)_view.DataGrid.SelectedItem;
            _view.TaxId = entity.TaxId;
            _view.MinimumSalary = entity.MinimumSalary;
            _view.MaximumSalary = entity.MaximumSalary;
            _view.TaxRate = entity.TaxRate;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select tax record(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedTaxes = _view.DataGrid.SelectedItems.Cast<Tax>().ToList();

                if (!selectedTaxes.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid tax records selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.Tax.Value.RemoveRange(selectedTaxes);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedTaxes.Count} tax record(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllTaxList();
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
            string reportFileName = "TaxReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Tax", TaxList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllTaxList();
        }
        private void CleanviewFields()
        {
            LoadAllTaxList();
            _view.TaxId = 0;
            _view.MinimumSalary = 0;
            _view.MaximumSalary = 0;
            _view.TaxRate = 0;
        }

        private void LoadAllTaxList(bool emptyValue = false)
        {
            TaxList = _unitOfWork.Tax.Value.GetAll();

            if(!emptyValue) TaxList = TaxList.Where(c => c.TaxRate.ToString().Contains(_view.SearchValue));
            _view.SetTaxListBindingSource(TaxList);
        }
    }
}
