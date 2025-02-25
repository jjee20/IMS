using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories.IInventory;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class ContributionPresenter
    {
        public IContributionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ContributionBindingSource;
        private BindingSource ContributionTypeBindingSource;
        private IEnumerable<Contribution> ContributionList;
        private IEnumerable<EnumItemViewModel> ContributionTypeList;
        public ContributionPresenter(IContributionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ContributionBindingSource = new BindingSource();
            ContributionTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllContributionList();
            LoadAllContributionTypeList();

            //Source Binding
            _view.SetContributionListBindingSource(ContributionBindingSource);
            _view.SetContributionTypeListBindingSource(ContributionTypeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Contribution.Get(c => c.ContributionId == _view.ContributionId, tracked: true);
            if (model == null) model = new Contribution();
            else _unitOfWork.Contribution.Detach(model);

            model.ContributionId = _view.ContributionId;
            model.ContributionType = _view.ContributionType;
            model.EmployeeRate = _view.Rate;
            model.MinimumLimit = _view.MinimumLimit;
            model.MaximumLimit = _view.MaximumLimit;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Contribution.Update(model);
                    _view.Message = "Contribution edited successfully";
                }
                else //Add new model
                {
                    var Entity = _unitOfWork.Contribution.Get(c => c.ContributionType == _view.ContributionType && c.MinimumLimit == _view.MinimumLimit && c.MaximumLimit == _view.MaximumLimit);
                    if (Entity != null)
                    {
                        _view.Message = "Contribution is already added.";
                        return;
                    }

                    _unitOfWork.Contribution.Add(model);
                    _view.Message = "Contribution added successfully";
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
                // Safely parse and filter contributions
                if (Enum.TryParse(typeof(ContributionType), _view.SearchValue?.ToString(), out var parsedType))
                {
                    ContributionList = _unitOfWork.Contribution.GetAll(c => c.ContributionType == (ContributionType)parsedType);
                }
                else
                {
                    // Handle invalid search value (e.g., set an empty list or log an error)
                    ContributionList = new List<Contribution>();
                }

                ContributionBindingSource.DataSource = ContributionList;
            }
            else
            {
                LoadAllContributionList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Contribution)ContributionBindingSource.Current;
            _view.ContributionId = entity.ContributionId;
            _view.ContributionType = entity.ContributionType;
            _view.Rate = entity.EmployeeRate;
            _view.MinimumLimit = entity.MinimumLimit;
            _view.MaximumLimit = entity.MaximumLimit;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Contribution)ContributionBindingSource.Current;
                _unitOfWork.Contribution.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Contribution deleted successfully";
                LoadAllContributionList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Contribution";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ContributionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Contribution", ContributionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllContributionList();
        }
        private void CleanviewFields()
        {
            LoadAllContributionList();
            _view.ContributionId = 0;
            _view.ContributionType = 0;
            _view.Rate = 0;
            _view.MinimumLimit = 0;
            _view.MaximumLimit = 0;
        }

        private void LoadAllContributionList()
        {
            ContributionList = _unitOfWork.Contribution.GetAll();
            ContributionBindingSource.DataSource = ContributionList;//Set data source.
        }
        private void LoadAllContributionTypeList()
        {
            ContributionTypeList = EnumHelper.EnumToEnumerable<ContributionType>();
            ContributionTypeBindingSource.DataSource = ContributionTypeList;//Set data source.
        }
    }
}
