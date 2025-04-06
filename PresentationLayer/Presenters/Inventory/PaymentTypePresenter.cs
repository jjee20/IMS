using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentTypePresenter
    {
        public IPaymentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<PaymentType> PaymentTypeList;
        public PaymentTypePresenter(IPaymentTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllPaymentTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.PaymentType.Value.GetAsync(c => c.PaymentTypeId == _view.PaymentTypeId, tracked: true);
            if (model == null) model = new PaymentType();
            else _unitOfWork.PaymentType.Value.Detach(model);

            model.PaymentTypeId = _view.PaymentTypeId;
            model.PaymentTypeName = _view.PaymentTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentType.Value.Update(model);
                    _view.Message = "Payment type edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.PaymentType.Value.AddAsync(model);
                    _view.Message = "Payment type added successfully";
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
            LoadAllPaymentTypeList(emptyValue);
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

            var entity = (PaymentType)_view.DataGrid.SelectedItem;
            _view.PaymentTypeId = entity.PaymentTypeId;
            _view.PaymentTypeName = entity.PaymentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select payment type(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<PaymentType>().ToList();

                if (!selectedItems.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid payment types selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.PaymentType.Value.RemoveRange(selectedItems);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedItems.Count} payment type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllPaymentTypeList();
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
            string reportFileName = "PaymentTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentType", PaymentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentTypeList();
            _view.PaymentTypeId = 0;
            _view.PaymentTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllPaymentTypeList(bool emptyValue = false)
        {
            PaymentTypeList = _unitOfWork.PaymentType.Value.GetAll();

            if (!emptyValue) PaymentTypeList = PaymentTypeList.Where(c => c.PaymentTypeName.Contains(_view.SearchValue));
            _view.SetPaymentTypeListBindingSource(PaymentTypeList);
        }
    }
}
