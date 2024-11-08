using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

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

            //Source Binding
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureBindingSource);

            //Load

            LoadAllUnitOfMeasureList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.UnitOfMeasure.Get(c => c.UnitOfMeasureName == _view.UnitOfMeasureName);
            if (Entity != null)
            {
                _view.Message = "Bill type is already added.";
                return;
            }

            var model = new UnitOfMeasure()
            {
                
                UnitOfMeasureId = _view.UnitOfMeasureId,
                UnitOfMeasureName = _view.UnitOfMeasureName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.UnitOfMeasure.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.UnitOfMeasure.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type added sucessfully";
                }
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
                UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll();
                UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
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
                _view.Message = "Bill type deleted successfully";
                LoadAllUnitOfMeasureList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "UnitOfMeasureReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
