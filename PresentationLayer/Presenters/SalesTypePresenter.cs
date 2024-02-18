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
            try
            {
                // Check if the SalesType already exists by name
                var existingEntity = _unitOfWork.SalesType.Get(c => c.SalesTypeName == _view.SalesTypeName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.SalesTypeId != _view.SalesTypeId)
                        {
                            _view.Message = "Another Sales type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Sales type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the SalesType entity
                SalesType entity;
                if (_view.SalesTypeId == 0)
                {
                    entity = new SalesType()
                    {
                        SalesTypeName = _view.SalesTypeName,
                        Description = _view.Description
                    };
                    _unitOfWork.SalesType.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.SalesType.Get(c => c.SalesTypeId == _view.SalesTypeId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Sales type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.SalesTypeName = _view.SalesTypeName;
                    entity.Description = _view.Description;
                    _unitOfWork.SalesType.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Sales type edited successfully" : "Sales type added successfully";
                _view.IsSuccessful = true;

                // Clear view fields
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle exceptions
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
            _view.IsEdit = true;
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
            string reportFileName = "SalesTypeListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesTypeList", SalesTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
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
