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
    public class TaxPresenter
    {
        public ITaxView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<TaxViewModel> TaxList;
        public TaxPresenter(ITaxView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator) {

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

            LoadAllTaxList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertTaxView(_unitOfWork))
            {
                form.Text = "Add Tax";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllTaxList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllTaxList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is TaxViewModel row)
            {
                var entity = _unitOfWork.Tax.Value.Get(c => c.TaxId == row.TaxId);
                using (var form = new UpsertTaxView(_unitOfWork,entity))
                {
                    form.Text = "Edit Tax";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllTaxList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is TaxViewModel row)
            {
                var entity = _unitOfWork.Tax.Value.Get(c => c.TaxId == row.TaxId);
                if (entity != null)
                {
                    _unitOfWork.Tax.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Tax deleted successfully.");

                    LoadAllTaxList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<TaxViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.TaxId).ToList();

                var entities = _unitOfWork.Tax.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.TaxId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Tax.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllTaxList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "TaxReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Tax", TaxList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllTaxList(bool emptyValue = false)
        {
            TaxList = Program.Mapper.Map<IEnumerable<TaxViewModel>>(_unitOfWork.Tax.Value.GetAll());

            if (!emptyValue) TaxList = TaxList.Where(c => c.MinimumSalary.ToString().Contains(_view.SearchValue) || c.MaximumSalary.ToString().Contains(_view.SearchValue) || c.TaxRate.ToString().Contains(_view.SearchValue));
            _view.SetTaxListBindingSource(TaxList);
            _eventAggregator.Publish<PayrollUpdateEvent>();
        }
    }
}
