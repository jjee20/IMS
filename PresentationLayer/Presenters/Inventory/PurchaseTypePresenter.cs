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
        private BindingSource PurchaseTypeBindingSource;
        private IEnumerable<PurchaseType> PurchaseTypeList;
        public PurchaseTypePresenter(IPurchaseTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PurchaseTypeBindingSource = new BindingSource();

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
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.PurchaseType.Get(c => c.PurchaseTypeId == _view.PurchaseTypeId, tracked: true);
            if (model == null) model = new PurchaseType();
            else _unitOfWork.PurchaseType.Detach(model);

            model.PurchaseTypeId = _view.PurchaseTypeId;
            model.PurchaseTypeName = _view.PurchaseTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PurchaseType.Update(model);
                    _view.Message = "Purchase type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.PurchaseType.Add(model);
                    _view.Message = "Purchase type added successfully";
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
            if (emptyValue == false)
            {
                PurchaseTypeList = _unitOfWork.PurchaseType.GetAll(c => c.PurchaseTypeName.Contains(_view.SearchValue));
                PurchaseTypeBindingSource.DataSource = PurchaseTypeList;
            }
            else
            {
                LoadAllPurchaseTypeList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (PurchaseType)PurchaseTypeBindingSource.Current;
            _view.PurchaseTypeId = entity.PurchaseTypeId;
            _view.PurchaseTypeName = entity.PurchaseTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PurchaseType)PurchaseTypeBindingSource.Current;
                _unitOfWork.PurchaseType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Purchase type deleted successfully";
                LoadAllPurchaseTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Purchase type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
        
        private void LoadAllPurchaseTypeList()
        {
            PurchaseTypeList = _unitOfWork.PurchaseType.GetAll();
            PurchaseTypeBindingSource.DataSource = PurchaseTypeList;//Set data source.
        }
    }
}
