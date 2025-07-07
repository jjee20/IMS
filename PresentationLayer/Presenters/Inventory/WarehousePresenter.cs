using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
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
    public class WarehousePresenter
    {
        public IWarehouseView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<WarehouseViewModel> WarehouseList;
        public WarehousePresenter(IWarehouseView view, IUnitOfWork unitOfWork) {

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

            LoadAllWarehouseList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertWarehouseView(_unitOfWork))
            {
                form.Text = "Add Warehouse";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllWarehouseList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllWarehouseList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is WarehouseViewModel row)
            {
                var entity = _unitOfWork.Warehouse.Value.Get(c => c.WarehouseId == row.WarehouseId);
                using (var form = new UpsertWarehouseView(_unitOfWork,entity))
                {
                    form.Text = "Edit Warehouse";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllWarehouseList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is WarehouseViewModel row)
            {
                var entity = _unitOfWork.Warehouse.Value.Get(c => c.WarehouseId == row.WarehouseId);
                if (entity != null)
                {
                    _unitOfWork.Warehouse.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Warehouse deleted successfully.");

                    LoadAllWarehouseList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<WarehouseViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.WarehouseId).ToList();

                var entities = _unitOfWork.Warehouse.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.WarehouseId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Warehouse.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllWarehouseList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "WarehouseReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Warehouse", WarehouseList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllWarehouseList(bool emptyValue = false)
        {
            WarehouseList = Program.Mapper.Map<IEnumerable<WarehouseViewModel>>(await _unitOfWork.Warehouse.Value.GetAllAsync());

            if (!emptyValue) WarehouseList = WarehouseList.Where(c => c.WarehouseName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetWarehouseListBindingSource(WarehouseList);
        }
    }
}
