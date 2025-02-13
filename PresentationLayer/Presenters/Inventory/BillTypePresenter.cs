using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters
{
    public class BillTypePresenter
    {
        public IBillTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BillTypeBindingSource;
        private IEnumerable<BillType> BillTypeList;
        public BillTypePresenter(IBillTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BillTypeBindingSource = new BindingSource();

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
            _view.SetBillTypeListBindingSource(BillTypeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.BillType.Get(c => c.BillTypeId == _view.BillTypeId, tracked: true);
            if (model == null) model = new BillType();
            else _unitOfWork.BillType.Detach(model);

            model.BillTypeId = _view.BillTypeId;
            model.BillTypeName = _view.BillTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.BillType.Update(model);
                    _view.Message = "Bill type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.BillType.Add(model);
                    _view.Message = "Bill type added successfully";
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
            if (!emptyValue)
            {
                BillTypeList = _unitOfWork.BillType.GetAll(c => c.BillTypeName.Contains(_view.SearchValue));
                BillTypeBindingSource.DataSource = BillTypeList;
            }
            else
            {
                LoadAllBillTypeList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (BillType)BillTypeBindingSource.Current;
            _view.BillTypeId = entity.BillTypeId;
            _view.BillTypeName = entity.BillTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (BillType)BillTypeBindingSource.Current;
                _unitOfWork.BillType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill type deleted successfully";
                LoadAllBillTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BillTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
        
        private void LoadAllBillTypeList()
        {
            BillTypeList = _unitOfWork.BillType.GetAll();
            BillTypeBindingSource.DataSource = BillTypeList;//Set data source.
        }
    }
}
