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
    public class PurchaseTypePresenter
    {
        public IPurchaseTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<PurchaseTypeViewModel> PurchaseTypeList;
        public PurchaseTypePresenter(IPurchaseTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllPurchaseTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertPurchaseTypeView(_unitOfWork))
            {
                form.Text = "Add Purchase Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllPurchaseTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllPurchaseTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseTypeViewModel row)
            {
                var entity = _unitOfWork.PurchaseType.Value.Get(c => c.PurchaseTypeId == row.PurchaseTypeId);
                using (var form = new UpsertPurchaseTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Purchase Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllPurchaseTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseTypeViewModel row)
            {
                var entity = _unitOfWork.PurchaseType.Value.Get(c => c.PurchaseTypeId == row.PurchaseTypeId);
                if (entity != null)
                {
                    _unitOfWork.PurchaseType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Purchase Type deleted successfully.");

                    LoadAllPurchaseTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<PurchaseTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.PurchaseTypeId).ToList();

                var entities = _unitOfWork.PurchaseType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.PurchaseTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.PurchaseType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllPurchaseTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseType", PurchaseTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllPurchaseTypeList(bool emptyValue = false)
        {
            PurchaseTypeList = Program.Mapper.Map<IEnumerable<PurchaseTypeViewModel>>(await _unitOfWork.PurchaseType.Value.GetAllAsync());

            if (!emptyValue) PurchaseTypeList = PurchaseTypeList.Where(c => c.PurchaseTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeList);
        }
    }
}
