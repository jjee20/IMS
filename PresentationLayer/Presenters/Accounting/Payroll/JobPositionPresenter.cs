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
    public class JobPositionPresenter
    {
        public IJobPositionView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<JobPosition> JobPositionList;
        public JobPositionPresenter(IJobPositionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllJobPositionList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.JobPosition.Value.GetAsync(c => c.JobPositionId == _view.JobPositionId, tracked: true);

            if (model == null) model = new JobPosition();
            else _unitOfWork.JobPosition.Value.Detach(model);

            model.JobPositionId = _view.JobPositionId;
            model.Title = _view.Title;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.JobPosition.Value.Update(model);
                    _view.Message = "JobPosition edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.JobPosition.Value.AddAsync(model);
                    _view.Message = "JobPosition added successfully";
                }
                await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);
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
            LoadAllJobPositionList(emptyValue);
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

            var entity = (JobPosition)_view.DataGrid.SelectedItem;
            _view.JobPositionId = entity.JobPositionId;
            _view.Title = entity.Title;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select job position(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedPositions = _view.DataGrid.SelectedItems.Cast<JobPosition>().ToList();

                if (!selectedPositions.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid job positions selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.JobPosition.Value.RemoveRange(selectedPositions);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedPositions.Count} job position(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllJobPositionList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"An error occurred while deleting: {ex.Message}";
                _view.ShowMessage(_view.Message);
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "JobPositionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("JobPosition", JobPositionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllJobPositionList();
        }
        private void CleanviewFields()
        {
            LoadAllJobPositionList();
            _view.JobPositionId = 0;
            _view.Title = "";
            _view.Description = "";
        }

        private void LoadAllJobPositionList(bool emptyValue = false)
        {
            JobPositionList = _unitOfWork.JobPosition.Value.GetAll();

            if (!emptyValue) JobPositionList = JobPositionList.Where(c => c.Title.Contains(_view.SearchValue)); 
            _view.SetJobPositionListBindingSource(JobPositionList);
        }
    }
}
