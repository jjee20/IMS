using DomainLayer.ViewModels;
using DomainLayer.ViewModels.InventoryViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static ServiceLayer.Services.CommonServices.EventClasses;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class ProjectPresenter
    {
        public IProjectView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<ProjectViewModel> ProjectList;
        public ProjectPresenter(IProjectView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            this._eventAggregator = eventAggregator;

            //Events
            _view.SearchEvent -= Search;
            _view.AddEvent -= AddNew;
            _view.EditEvent -= Edit;
            _view.DeleteEvent -= Delete;
            _view.ProjectEvent -= Project;
            _view.MultipleDeleteEvent -= MultipleDelete;
            _view.PrintEvent -= Print;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.ProjectEvent += Project;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllProjectList();

            //Source Binding
        }

        private void Project(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProjectViewModel row)
            {
                var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId == row.ProjectId, includeProperties: "ProjectLines");
                using (var form = new ProjectInformationView(row, _unitOfWork, entity))
                {
                    form.Text = "Edit Project";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProjectList();
                    }
                }
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertProjectView(_unitOfWork))
            {
                form.Text = "Add Project";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllProjectList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProjectList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProjectViewModel row)
            {
                var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId == row.ProjectId, includeProperties: "ProjectLines");
                using (var form = new UpsertProjectView(_unitOfWork, entity))
                {
                    form.Text = "Edit Project";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProjectList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProjectViewModel row)
            {
                var lineEntity = _unitOfWork.ProjectLine.Value.GetAll().Where(c => c.ProjectId == row.ProjectId).ToList();

                _unitOfWork.ProjectLine.Value.RemoveRange(lineEntity);

                var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId == row.ProjectId);
                if (entity != null)
                {
                    _unitOfWork.Project.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Project deleted successfully.");

                    LoadAllProjectList();
                }
            }
        }
        private void MultipleDelete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.ShowMessage("Please select item(s) to delete.");
                    return;
                }

                var selected = _view.DataGrid.SelectedItems.Cast<ProjectViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ProjectId).ToList();

                var entities = _unitOfWork.Project.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ProjectId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Project.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllProjectList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProjectReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Project", ProjectList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllProjectList(bool emptyValue = false)
        {
            var projects = await _unitOfWork.Project.Value.GetAllAsync();

            ProjectList = Program.Mapper.Map<IEnumerable<ProjectViewModel>>(projects);

            if (!emptyValue) ProjectList = ProjectList.Where(c => c.ProjectName.ToLower().Contains(_view.SearchValue.ToLower()));


            _view.SetProjectListBindingSource(ProjectList.OrderByDescending(c => c.StartDate));
            _eventAggregator.Publish<InventoryCompletedEvent>();
        }
    }
}
