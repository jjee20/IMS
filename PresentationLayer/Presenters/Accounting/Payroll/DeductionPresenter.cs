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
    public class DeductionPresenter
    {
        public IDeductionView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<DeductionViewModel> DeductionList;
        public DeductionPresenter(IDeductionView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator) {

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

            LoadAllDeductionList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertDeductionView(_unitOfWork))
            {
                form.Text = "Add Deduction";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllDeductionList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllDeductionList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is DeductionViewModel row)
            {
                var entity = _unitOfWork.Deduction.Value.Get(c => c.DeductionId == row.DeductionId);
                using (var form = new UpsertDeductionView(_unitOfWork,entity))
                {
                    form.Text = "Edit Deduction";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllDeductionList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is DeductionViewModel row)
            {
                var entity = _unitOfWork.Deduction.Value.Get(c => c.DeductionId == row.DeductionId);
                if (entity != null)
                {
                    _unitOfWork.Deduction.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Deduction deleted successfully.");

                    LoadAllDeductionList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<DeductionViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.DeductionId).ToList();

                var entities = _unitOfWork.Deduction.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.DeductionId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Deduction.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllDeductionList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "DeductionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Deduction", DeductionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllDeductionList(bool emptyValue = false)
        {
            DeductionList = Program.Mapper.Map<IEnumerable<DeductionViewModel>>(await _unitOfWork.Deduction.Value.GetAllAsync(includeProperties: "Employee"));

            if (!emptyValue) DeductionList = DeductionList.Where(c => c.Employee.Contains(_view.SearchValue));
            _view.SetDeductionListBindingSource(DeductionList.OrderByDescending(c => c.DateDeducted));
            _eventAggregator.Publish<PayrollUpdateEvent>();
        }
    }
}
