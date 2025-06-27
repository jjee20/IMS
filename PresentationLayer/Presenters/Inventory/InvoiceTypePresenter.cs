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
    public class InvoiceTypePresenter
    {
        public IInvoiceTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<InvoiceTypeViewModel> InvoiceTypeList;
        public InvoiceTypePresenter(IInvoiceTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllInvoiceTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertInvoiceTypeView(_unitOfWork))
            {
                form.Text = "Add Invoice Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllInvoiceTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllInvoiceTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is InvoiceTypeViewModel row)
            {
                var entity = _unitOfWork.InvoiceType.Value.Get(c => c.InvoiceTypeId == row.InvoiceTypeId);
                using (var form = new UpsertInvoiceTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Invoice Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllInvoiceTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is InvoiceTypeViewModel row)
            {
                var entity = _unitOfWork.InvoiceType.Value.Get(c => c.InvoiceTypeId == row.InvoiceTypeId);
                if (entity != null)
                {
                    _unitOfWork.InvoiceType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Invoice Type deleted successfully.");

                    LoadAllInvoiceTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<InvoiceTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.InvoiceTypeId).ToList();

                var entities = _unitOfWork.InvoiceType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.InvoiceTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.InvoiceType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllInvoiceTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "InvoiceTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("InvoiceType", InvoiceTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllInvoiceTypeList(bool emptyValue = false)
        {
            InvoiceTypeList = Program.Mapper.Map<IEnumerable<InvoiceTypeViewModel>>(await _unitOfWork.InvoiceType.Value.GetAllAsync());

            if (!emptyValue) InvoiceTypeList = InvoiceTypeList.Where(c => c.InvoiceTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetInvoiceTypeListBindingSource(InvoiceTypeList);
        }
    }
}
