using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using static ServiceLayer.Services.CommonServices.EventClasses;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class BonusPresenter
    {
        public IBonusView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<BonusViewModel> BonusList;
        public BonusPresenter(IBonusView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            this._eventAggregator = eventAggregator;

            //Events
            _view.SearchEvent -= Search;
            _view.AddEvent -= AddNew;
            _view.EditEvent -= Edit;
            _view.DeleteEvent -= Delete;
            _view.MultipleDeleteEvent -= MultipleDelete;
            _view.PrintEvent -= Print;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllBonusList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertBonusView(_unitOfWork))
            {
                form.Text = "Add Bonus";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllBonusList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllBonusList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is BonusViewModel row)
            {
                var entity = _unitOfWork.Bonus.Value.Get(c => c.BonusId == row.BonusId);
                using (var form = new UpsertBonusView(_unitOfWork,entity))
                {
                    form.Text = "Edit Bonus";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllBonusList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is BonusViewModel row)
            {
                var entity = _unitOfWork.Bonus.Value.Get(c => c.BonusId == row.BonusId);
                if (entity != null)
                {
                    _unitOfWork.Bonus.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Bonus deleted successfully.");

                    LoadAllBonusList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<BonusViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.BonusId).ToList();

                var entities = _unitOfWork.Bonus.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.BonusId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Bonus.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllBonusList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BonusReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Bonus", BonusList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllBonusList(bool emptyValue = false)
        {
            BonusList = Program.Mapper.Map<IEnumerable<BonusViewModel>>(await _unitOfWork.Bonus.Value.GetAllAsync(includeProperties: "Employee"));

            if (!emptyValue) BonusList = BonusList.Where(c => c.Employee.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetBonusListBindingSource(BonusList.OrderByDescending(c => c.DateGranted));
            _eventAggregator.Publish<PayrollUpdateEvent>();
        }
    }
}
