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
    public class PaymentTypePresenter
    {
        public IPaymentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<PaymentTypeViewModel> PaymentTypeList;
        public PaymentTypePresenter(IPaymentTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllPaymentTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertPaymentTypeView(_unitOfWork))
            {
                form.Text = "Add Payment Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllPaymentTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllPaymentTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PaymentTypeViewModel row)
            {
                var entity = _unitOfWork.PaymentType.Value.Get(c => c.PaymentTypeId == row.PaymentTypeId);
                using (var form = new UpsertPaymentTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Payment Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllPaymentTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PaymentTypeViewModel row)
            {
                var entity = _unitOfWork.PaymentType.Value.Get(c => c.PaymentTypeId == row.PaymentTypeId);
                if (entity != null)
                {
                    _unitOfWork.PaymentType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Payment Type deleted successfully.");

                    LoadAllPaymentTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<PaymentTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.PaymentTypeId).ToList();

                var entities = _unitOfWork.PaymentType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.PaymentTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.PaymentType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllPaymentTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentType", PaymentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllPaymentTypeList(bool emptyValue = false)
        {
            PaymentTypeList = Program.Mapper.Map<IEnumerable<PaymentTypeViewModel>>(_unitOfWork.PaymentType.Value.GetAll());

            if (!emptyValue) PaymentTypeList = PaymentTypeList.Where(c => c.PaymentTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetPaymentTypeListBindingSource(PaymentTypeList);
        }
    }
}
