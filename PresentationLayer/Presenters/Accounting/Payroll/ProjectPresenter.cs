using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class ProjectPresenter
    {
        public IProjectView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProjectBindingSource;
        private IEnumerable<Project> ProjectList;
        public ProjectPresenter(IProjectView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProjectBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllProjectList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Project.Value.Get(c => c.ProjectId == _view.ProjectId, tracked: true);

            if (model == null) model = new Project();
            else _unitOfWork.Project.Value.Detach(model);

            model.ProjectId = _view.ProjectId;
            model.ProjectName = _view.ProjectName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Project.Value.Update(model);
                    _view.Message = "Project edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Project.Value.Add(model);
                    _view.Message = "Project added successfully";
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
                ProjectList = _unitOfWork.Project.Value.GetAll(c => c.ProjectName.Contains(_view.SearchValue));
                ProjectBindingSource.DataSource = ProjectList;
            }
            else
            {
                LoadAllProjectList();
            }
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

            var entity = (Project)_view.DataGrid.SelectedItem;
            _view.ProjectId = entity.ProjectId;
            _view.ProjectName = entity.ProjectName;
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

                var entity = (Project)_view.DataGrid.SelectedItem;
                _unitOfWork.Project.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Project deleted successfully";
                LoadAllProjectList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Project";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProjectReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Project", ProjectList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProjectList();
        }
        private void CleanviewFields()
        {
            LoadAllProjectList();
            _view.ProjectId = 0;
            _view.ProjectName = "";
            _view.Description = "";
        }

        private void LoadAllProjectList()
        {
            ProjectList = _unitOfWork.Project.Value.GetAll();
            ProjectBindingSource.DataSource = ProjectList;//Set data source.
            _view.SetProjectListBindingSource(ProjectBindingSource);
        }
    }
}
