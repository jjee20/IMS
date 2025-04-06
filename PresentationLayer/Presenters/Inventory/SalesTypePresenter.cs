using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class SalesTypePresenter
    {
        public ISalesTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<SalesType> SalesTypeList;
        public SalesTypePresenter(ISalesTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllSalesTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            try
            {
                // Check if SalesType already exists
                var model = await _unitOfWork.SalesType.Value.GetAsync(c => c.SalesTypeId == _view.SalesTypeId, tracked: true);
                if (model == null) model = new SalesType();
                else _unitOfWork.SalesType.Value.Detach(model);

                model.SalesTypeId = _view.SalesTypeId;
                model.SalesTypeName = _view.SalesTypeName;
                model.Description = _view.Description;

                // Validate entity
                new ModelDataValidation().Validate(model);

                if (_view.IsEdit)
                {
                    _unitOfWork.SalesType.Value.Update(model); // Update existing entity
                    _view.Message = "Sales type edited successfully.";
                }
                else
                {
                    await _unitOfWork.SalesType.Value.AddAsync(model); // Add new entity
                    _view.Message = "Sales type added successfully.";
                }

                // Save changes to database
                await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);

                // Clean fields
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
            LoadAllSalesTypeList(emptyValue);
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

            var entity = (SalesType)_view.DataGrid.SelectedItem;
            _view.SalesTypeId = entity.SalesTypeId;
            _view.SalesTypeName = entity.SalesTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select sales type(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<SalesType>().ToList();

                if (!selectedItems.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid sales types selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.SalesType.Value.RemoveRange(selectedItems);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedItems.Count} sales type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllSalesTypeList();
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
            string reportFileName = "SalesTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesType", SalesTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllSalesTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllSalesTypeList();
            _view.SalesTypeId = 0;
            _view.SalesTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllSalesTypeList(bool emptyValue = false)
        {
            SalesTypeList = _unitOfWork.SalesType.Value.GetAll();

            if (!emptyValue) SalesTypeList = SalesTypeList.Where(C => C.SalesTypeName.Contains(_view.SearchValue));
            _view.SetSalesTypeListBindingSource(SalesTypeList);
        }
    }
}
