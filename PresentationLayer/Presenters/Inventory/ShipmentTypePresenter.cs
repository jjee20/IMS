using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class ShipmentTypePresenter
    {
        public IShipmentTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<ShipmentTypeViewModel> ShipmentTypeList;
        public ShipmentTypePresenter(IShipmentTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllShipmentTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertShipmentTypeView(_unitOfWork))
            {
                form.Text = "Add Shipment Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllShipmentTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllShipmentTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ShipmentTypeViewModel row)
            {
                var entity = _unitOfWork.ShipmentType.Value.Get(c => c.ShipmentTypeId == row.ShipmentTypeId);
                using (var form = new UpsertShipmentTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Shipment Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllShipmentTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ShipmentTypeViewModel row)
            {
                var entity = _unitOfWork.ShipmentType.Value.Get(c => c.ShipmentTypeId == row.ShipmentTypeId);
                if (entity != null)
                {
                    _unitOfWork.ShipmentType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Shipment Type deleted successfully.");

                    LoadAllShipmentTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ShipmentTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ShipmentTypeId).ToList();

                var entities = _unitOfWork.ShipmentType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ShipmentTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ShipmentType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllShipmentTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ShipmentType", ShipmentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllShipmentTypeList(bool emptyValue = false)
        {
            ShipmentTypeList = Program.Mapper.Map<IEnumerable<ShipmentTypeViewModel>>(await _unitOfWork.ShipmentType.Value.GetAllAsync());

            if (!emptyValue) ShipmentTypeList = ShipmentTypeList.Where(c => c.ShipmentTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetShipmentTypeListBindingSource(ShipmentTypeList);
        }
    }
}
