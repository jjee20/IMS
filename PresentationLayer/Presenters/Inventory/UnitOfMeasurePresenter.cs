using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters
{
    public class UnitOfMeasurePresenter
    {
        public IUnitOfMeasureView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource UnitOfMeasureBindingSource;
        private IEnumerable<UnitOfMeasure> UnitOfMeasureList;
        public UnitOfMeasurePresenter(IUnitOfMeasureView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            UnitOfMeasureBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllUnitOfMeasureList();

            //Source Binding
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.UnitOfMeasure.Get(c => c.UnitOfMeasureId == _view.UnitOfMeasureId, tracked: true);
            if (model == null) model = new UnitOfMeasure();
            else _unitOfWork.UnitOfMeasure.Detach(model);

            model.UnitOfMeasureId = _view.UnitOfMeasureId;
            model.UnitOfMeasureName = _view.UnitOfMeasureName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.UnitOfMeasure.Update(model);
                    _view.Message = "Unit Of Measure edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.UnitOfMeasure.Add(model);
                    _view.Message = "Unit Of Measure added successfully";
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
                UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll(c => c.UnitOfMeasureName.Contains(_view.SearchValue));
                UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;
            }
            else
            {
                LoadAllUnitOfMeasureList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (UnitOfMeasure)UnitOfMeasureBindingSource.Current;
            _view.UnitOfMeasureId = entity.UnitOfMeasureId;
            _view.UnitOfMeasureName = entity.UnitOfMeasureName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (UnitOfMeasure)UnitOfMeasureBindingSource.Current;
                _unitOfWork.UnitOfMeasure.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Unit Of Measure deleted successfully";
                LoadAllUnitOfMeasureList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Unit Of Measure";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "UnitOfMeasureReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("UnitOfMeasure", UnitOfMeasureList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllUnitOfMeasureList();
        }
        private void CleanviewFields()
        {
            LoadAllUnitOfMeasureList();
            _view.UnitOfMeasureId = 0;
            _view.UnitOfMeasureName = "";
            _view.Description = "";
        }

        private void LoadAllUnitOfMeasureList()
        {
            UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll();
            UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;//Set data source.
        }
    }
}
