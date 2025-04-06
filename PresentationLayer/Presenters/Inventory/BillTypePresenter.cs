using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using System.Linq;

namespace PresentationLayer.Presenters
{
    public class BillTypePresenter
    {
        public IBillTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<BillType> BillTypeList;
        public BillTypePresenter(IBillTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllBillTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.BillType.Value.GetAsync(c => c.BillTypeId == _view.BillTypeId, tracked: true);
            if (model == null) model = new BillType();
            else _unitOfWork.BillType.Value.Detach(model);

            model.BillTypeId = _view.BillTypeId;
            model.BillTypeName = _view.BillTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.BillType.Value.Update(model);
                    _view.Message = "Bill type edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.BillType.Value.AddAsync(model);
                    _view.Message = "Bill type added successfully";
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
            LoadAllBillTypeList(emptyValue);
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

            var entity = (BillType)_view.DataGrid.SelectedItem;
            _view.BillTypeId = entity.BillTypeId;
            _view.BillTypeName = entity.BillTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select item(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selected = _view.DataGrid.SelectedItems.Cast<BillType>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.BillTypeId).ToList();

                var entities = _unitOfWork.BillType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.BillTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Selected records could not be found.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.BillType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{entities.Count} bill type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllBillTypeList();
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
            string reportFileName = "BillTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("BillType", BillTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
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
        
        private void LoadAllBillTypeList(bool emptyValue = false)
        {
            BillTypeList = _unitOfWork.BillType.Value.GetAll();

            if (!emptyValue) BillTypeList = BillTypeList.Where(c => c.BillTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetBillTypeListBindingSource(BillTypeList);
        }
    }
}
