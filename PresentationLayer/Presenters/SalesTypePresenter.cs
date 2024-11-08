using DomainLayer.Models;
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
        private BindingSource SalesTypeBindingSource;
        private IEnumerable<SalesType> SalesTypeList;
        public SalesTypePresenter(ISalesTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            SalesTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetSalesTypeListBindingSource(SalesTypeBindingSource);

            //Load

            LoadAllSalesTypeList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.SalesType.Get(c => c.SalesTypeName == _view.SalesTypeName);
            if (Entity != null)
            {
                _view.Message = "Sales type is already added.";
                return;
            }

            var model = new SalesType()
            {
                
                SalesTypeId = _view.SalesTypeId,
                SalesTypeName = _view.SalesTypeName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.SalesType.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Sales type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.SalesType.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Sales type added sucessfully";
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
                SalesTypeList = _unitOfWork.SalesType.GetAll(c => c.SalesTypeName.Contains(_view.SearchValue));
                SalesTypeBindingSource.DataSource = SalesTypeList;
            }
            else
            {
                SalesTypeList = _unitOfWork.SalesType.GetAll();
                SalesTypeBindingSource.DataSource = SalesTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (SalesType)SalesTypeBindingSource.Current;
            _view.SalesTypeId = entity.SalesTypeId;
            _view.SalesTypeName = entity.SalesTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (SalesType)SalesTypeBindingSource.Current;
                _unitOfWork.SalesType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Sales type deleted successfully";
                LoadAllSalesTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Sales type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
        
        private void LoadAllSalesTypeList()
        {
            SalesTypeList = _unitOfWork.SalesType.GetAll();
            SalesTypeBindingSource.DataSource = SalesTypeList;//Set data source.
        }
    }
}
