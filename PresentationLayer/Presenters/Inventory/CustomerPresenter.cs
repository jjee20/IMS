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
using static ServiceLayer.Services.CommonServices.EventClasses;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class CustomerPresenter
    {
        public ICustomerView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<CustomerViewModel> CustomerList;
        public CustomerPresenter(ICustomerView view, IUnitOfWork unitOfWork) {

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

            LoadAllCustomerList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertCustomerView(_unitOfWork))
            {
                form.Text = "Add Customer";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCustomerList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllCustomerList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CustomerViewModel row)
            {
                var entity = _unitOfWork.Customer.Value.Get(c => c.CustomerId == row.CustomerId);
                using (var form = new UpsertCustomerView(_unitOfWork,entity))
                {
                    form.Text = "Edit Customer";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllCustomerList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CustomerViewModel row)
            {
                var entity = _unitOfWork.Customer.Value.Get(c => c.CustomerId == row.CustomerId);
                if (entity != null)
                {
                    _unitOfWork.Customer.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Customer deleted successfully.");

                    LoadAllCustomerList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<CustomerViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.CustomerId).ToList();

                var entities = _unitOfWork.Customer.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.CustomerId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Customer.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllCustomerList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CustomerReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Customer", CustomerList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private async void LoadAllCustomerList(bool emptyValue = false)
        {
            CustomerList = Program.Mapper.Map<IEnumerable<CustomerViewModel>>(await _unitOfWork.Customer.Value.GetAllAsync());

            if (!emptyValue) CustomerList = CustomerList.Where(c => c.CustomerName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetCustomerListBindingSource(CustomerList); 
        }
    }
}
