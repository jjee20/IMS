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
    public class VendorTypePresenter
    {
        public IVendorTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<VendorTypeViewModel> VendorTypeList;
        public VendorTypePresenter(IVendorTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllVendorTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertVendorTypeView(_unitOfWork))
            {
                form.Text = "Add Vendor Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllVendorTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllVendorTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is VendorTypeViewModel row)
            {
                var entity = _unitOfWork.VendorType.Value.Get(c => c.VendorTypeId == row.VendorTypeId);
                using (var form = new UpsertVendorTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Vendor Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllVendorTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is VendorTypeViewModel row)
            {
                var entity = _unitOfWork.VendorType.Value.Get(c => c.VendorTypeId == row.VendorTypeId);
                if (entity != null)
                {
                    _unitOfWork.VendorType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Vendor Type deleted successfully.");

                    LoadAllVendorTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<VendorTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.VendorTypeId).ToList();

                var entities = _unitOfWork.VendorType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.VendorTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.VendorType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllVendorTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "VendorTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("VendorType", VendorTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllVendorTypeList(bool emptyValue = false)
        {
            VendorTypeList = Program.Mapper.Map<IEnumerable<VendorTypeViewModel>>(await _unitOfWork.VendorType.Value.GetAllAsync());

            if (!emptyValue) VendorTypeList = VendorTypeList.Where(c => c.VendorTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetVendorTypeListBindingSource(VendorTypeList);
        }
    }
}
