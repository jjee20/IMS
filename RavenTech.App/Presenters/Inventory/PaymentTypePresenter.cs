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
        private BindingSource PaymentTypeBindingSource;
        private IEnumerable<PaymentType> PaymentTypeList;
        public PaymentTypePresenter(IPaymentTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentTypeBindingSource = new BindingSource();

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
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.PaymentType.Value.Get(c => c.PaymentTypeId == _view.PaymentTypeId, tracked: true);
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
                    _unitOfWork.PaymentType.Value.Add(model);
                    _view.Message = "Payment type added successfully";
                }
                _unitOfWork.Save();
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
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to edit";
                    return;
                }

                var entity = (PaymentType)_view.DataGrid.SelectedItem;
                _unitOfWork.PaymentType.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Payment type deleted successfully";
                LoadAllPaymentTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Payment type";
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

            if (emptyValue)
            {
                PaymentTypeList = PaymentTypeList.Where(c => c.PaymentTypeName.Contains(_view.SearchValue));
            }

            PaymentTypeBindingSource.DataSource = PaymentTypeList;//Set data source.
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);
        }
    }
}
