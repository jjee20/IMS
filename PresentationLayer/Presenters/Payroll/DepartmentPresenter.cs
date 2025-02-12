using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class DepartmentPresenter
    {
        public IDepartmentView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource DepartmentBindingSource;
        private IEnumerable<Department> DepartmentList;
        public DepartmentPresenter(IDepartmentView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            DepartmentBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllDepartmentList();

            //Source Binding
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Department.Get(c => c.DepartmentId == _view.DepartmentId, tracked: true);
            if (model == null) model = new Department();
            else _unitOfWork.Department.Detach(model);

            model.DepartmentId = _view.DepartmentId;
            model.Name = _view.DepartmentName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Department.Update(model);
                    _view.Message = "Department edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Department.Add(model);
                    _view.Message = "Department added successfully";
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
                DepartmentList = _unitOfWork.Department.GetAll(c => c.Name.Contains(_view.SearchValue));
                DepartmentBindingSource.DataSource = DepartmentList;
            }
            else
            {
                LoadAllDepartmentList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Department)DepartmentBindingSource.Current;
            _view.DepartmentId = entity.DepartmentId;
            _view.DepartmentName = entity.Name;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Department)DepartmentBindingSource.Current;
                _unitOfWork.Department.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Department deleted successfully";
                LoadAllDepartmentList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Department";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "DepartmentReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Department", DepartmentList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllDepartmentList();
        }
        private void CleanviewFields()
        {
            LoadAllDepartmentList();
            _view.DepartmentId = 0;
            _view.DepartmentName = "";
            _view.Description = "";
        }

        private void LoadAllDepartmentList()
        {
            DepartmentList = _unitOfWork.Department.GetAll();
            DepartmentBindingSource.DataSource = DepartmentList;//Set data source.
        }
    }
}
