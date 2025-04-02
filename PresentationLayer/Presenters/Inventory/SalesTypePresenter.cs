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
            //Load

            LoadAllSalesTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            try
            {
                // Check if SalesType already exists
                var model = _unitOfWork.SalesType.Value.Get(c => c.SalesTypeId == _view.SalesTypeId, tracked: true);
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
                    _unitOfWork.SalesType.Value.Add(model); // Add new entity
                    _view.Message = "Sales type added successfully.";
                }

                // Save changes to database
                _unitOfWork.Save();
                _view.IsSuccessful = true;

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
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to delete";
                    return;
                }

                var entity = (SalesType)_view.DataGrid.SelectedItem; 
                _unitOfWork.SalesType.Value.Remove(entity);
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

            if (emptyValue)
            {
                SalesTypeList = SalesTypeList.Where(C => C.SalesTypeName.Contains(_view.SearchValue));
            }

            SalesTypeBindingSource.DataSource = SalesTypeList;//Set data source.
            _view.SetSalesTypeListBindingSource(SalesTypeBindingSource);
        }
    }
}
