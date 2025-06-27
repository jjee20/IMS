using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class UnitOfMeasurePresenter
    {
        public IUnitOfMeasureView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<UnitOfMeasureViewModel> UnitOfMeasureList;
        public UnitOfMeasurePresenter(IUnitOfMeasureView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

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

            LoadAllUnitOfMeasureList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertUnitOfMeasureView(_unitOfWork))
            {
                form.Text = "Add Unit Of Measure";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllUnitOfMeasureList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllUnitOfMeasureList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is UnitOfMeasureViewModel row)
            {
                var entity = _unitOfWork.UnitOfMeasure.Value.Get(c => c.UnitOfMeasureId == row.UnitOfMeasureId);
                using (var form = new UpsertUnitOfMeasureView(_unitOfWork,entity))
                {
                    form.Text = "Edit Unit Of Measure";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllUnitOfMeasureList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is UnitOfMeasureViewModel row)
            {
                var entity = _unitOfWork.UnitOfMeasure.Value.Get(c => c.UnitOfMeasureId == row.UnitOfMeasureId);
                if (entity != null)
                {
                    _unitOfWork.UnitOfMeasure.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Unit Of Measure deleted successfully.");

                    LoadAllUnitOfMeasureList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<UnitOfMeasureViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.UnitOfMeasureId).ToList();

                var entities = _unitOfWork.UnitOfMeasure.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.UnitOfMeasureId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.UnitOfMeasure.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllUnitOfMeasureList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "UnitOfMeasureReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("UnitOfMeasure", UnitOfMeasureList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllUnitOfMeasureList(bool emptyValue = false)
        {
            UnitOfMeasureList = Program.Mapper.Map<IEnumerable<UnitOfMeasureViewModel>>(await _unitOfWork.UnitOfMeasure.Value.GetAllAsync());

            if (!emptyValue) UnitOfMeasureList = UnitOfMeasureList.Where(c => c.UnitOfMeasureName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureList);
        }
    }
}
