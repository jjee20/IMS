using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class JobPositionPresenter
    {
        public IJobPositionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource JobPositionBindingSource;
        private IEnumerable<JobPosition> JobPositionList;
        public JobPositionPresenter(IJobPositionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            JobPositionBindingSource = new BindingSource();

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
            _view.SetJobPositionListBindingSource(JobPositionBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.JobPosition.Get(c => c.Title == _view.Title);
            if (Entity != null)
            {
                _view.Message = "JobPosition is already added.";
                return;
            }

            var model = new JobPosition
            {
                JobPositionId = _view.JobPositionId,
                Title = _view.Title,
                Salary = _view.Salary,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.JobPosition.Update(model);
                    _view.Message = "JobPosition edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.JobPosition.Add(model);
                    _view.Message = "JobPosition added successfully";
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
                JobPositionList = _unitOfWork.JobPosition.GetAll(c => c.Title.Contains(_view.SearchValue));
                JobPositionBindingSource.DataSource = JobPositionList;
            }
            else
            {
                LoadAllJobPositionList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (JobPosition)JobPositionBindingSource.Current;
            _view.JobPositionId = entity.JobPositionId;
            _view.Title = entity.Title;
            _view.Salary = entity.Salary;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (JobPosition)JobPositionBindingSource.Current;
                _unitOfWork.JobPosition.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Job Position deleted successfully";
                LoadAllJobPositionList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Job Position";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "JobPositionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
            _view.Salary = 0;
        }

        private void LoadAllJobPositionList()
        {
            JobPositionList = _unitOfWork.JobPosition.GetAll();
            JobPositionBindingSource.DataSource = JobPositionList;//Set data source.
        }
    }
}
