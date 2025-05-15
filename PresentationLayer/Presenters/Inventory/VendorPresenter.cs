using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
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
    public class VendorPresenter
    {
        public IVendorView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<VendorViewModel> VendorList;
        public VendorPresenter(IVendorView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllVendorList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertVendorView(_unitOfWork))
            {
                form.Text = "Add Vendor";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllVendorList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllVendorList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is VendorViewModel row)
            {
                var entity = _unitOfWork.Vendor.Value.Get(c => c.VendorId == row.VendorId);
                using (var form = new UpsertVendorView(_unitOfWork,entity))
                {
                    form.Text = "Edit Vendor";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllVendorList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is VendorViewModel row)
            {
                var entity = _unitOfWork.Vendor.Value.Get(c => c.VendorId == row.VendorId);
                if (entity != null)
                {
                    _unitOfWork.Vendor.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Vendor deleted successfully.");

                    LoadAllVendorList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<VendorViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.VendorId).ToList();

                var entities = _unitOfWork.Vendor.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.VendorId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Vendor.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllVendorList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "VendorReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Vendor", VendorList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllVendorList(bool emptyValue = false)
        {
            VendorList = Program.Mapper.Map<IEnumerable<VendorViewModel>>(_unitOfWork.Vendor.Value.GetAll(includeProperties:"VendorType"));

            if (!emptyValue) VendorList = VendorList.Where(c => c.VendorName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetVendorListBindingSource(VendorList);
        }
    }
}
