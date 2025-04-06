using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PurchaseTypePresenter
    {
        public IPurchaseTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<PurchaseType> PurchaseTypeList;
        public PurchaseTypePresenter(IPurchaseTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllPurchaseTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.PurchaseType.Value.GetAsync(c => c.PurchaseTypeId == _view.PurchaseTypeId, tracked: true);
            if (model == null) model = new PurchaseType();
            else _unitOfWork.PurchaseType.Value.Detach(model);

            model.PurchaseTypeId = _view.PurchaseTypeId;
            model.PurchaseTypeName = _view.PurchaseTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PurchaseType.Value.Update(model);
                    _view.Message = "Purchase type edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.PurchaseType.Value.AddAsync(model);
                    _view.Message = "Purchase type added successfully";
                }
                await _unitOfWork.SaveAsync();
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
            LoadAllPurchaseTypeList(emptyValue);
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

            var entity = (PurchaseType)_view.DataGrid.SelectedItem;
            _view.PurchaseTypeId = entity.PurchaseTypeId;
            _view.PurchaseTypeName = entity.PurchaseTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select purchase type(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<PurchaseType>().ToList();

                if (!selectedItems.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid purchase types selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.PurchaseType.Value.RemoveRange(selectedItems);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedItems.Count} purchase type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllPurchaseTypeList();
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
            string reportFileName = "PurchaseTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseType", PurchaseTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPurchaseTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllPurchaseTypeList();
            _view.PurchaseTypeId = 0;
            _view.PurchaseTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllPurchaseTypeList(bool emptyValue = false)
        {
            PurchaseTypeList = _unitOfWork.PurchaseType.Value.GetAll();

            if (!emptyValue) PurchaseTypeList = PurchaseTypeList.Where(c => c.PurchaseTypeName.Contains(_view.SearchValue));
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeList);
        }
    }
}
