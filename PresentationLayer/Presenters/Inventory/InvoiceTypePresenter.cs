using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews.Inventory;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class InvoiceTypePresenter
    {
        public IInvoiceTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<InvoiceType> InvoiceTypeList;
        public InvoiceTypePresenter(IInvoiceTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllInvoiceTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.InvoiceType.Value.Get(c => c.InvoiceTypeId == _view.InvoiceTypeId, tracked: true);
            if (model == null) model = new InvoiceType();
            else _unitOfWork.InvoiceType.Value.Detach(model);

            model.InvoiceTypeId = _view.InvoiceTypeId;
            model.InvoiceTypeName = _view.InvoiceTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.InvoiceType.Value.Update(model);
                    _view.Message = "Invoice edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.InvoiceType.Value.Add(model);
                    _view.Message = "Invoice added successfully";
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
            LoadAllInvoiceTypeList(emptyValue);
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

            var entity = (InvoiceType)_view.DataGrid.SelectedItem;
            _view.InvoiceTypeId = entity.InvoiceTypeId;
            _view.InvoiceTypeName = entity.InvoiceTypeName;
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

                var entity = (InvoiceType)_view.DataGrid.SelectedItem;
                _unitOfWork.InvoiceType.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Invoice deleted successfully";
                LoadAllInvoiceTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Invoice";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "InvoiceTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("InvoiceType", InvoiceTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllInvoiceTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllInvoiceTypeList();
            _view.InvoiceTypeId = 0;
            _view.InvoiceTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllInvoiceTypeList(bool emptyValue = false)
        {
            InvoiceTypeList = _unitOfWork.InvoiceType.Value.GetAll();

            if (!emptyValue) InvoiceTypeList = InvoiceTypeList.Where(c => c.InvoiceTypeName.Contains(_view.SearchValue));
            _view.SetInvoiceTypeListBindingSource(InvoiceTypeList);
        }
    }
}
