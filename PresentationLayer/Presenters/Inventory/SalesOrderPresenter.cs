using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class SalesOrderPresenter
    {
        public ISalesOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource SalesOrderBindingSource;
        private BindingSource SalesOrderLineBindingSource;
        private BindingSource SalesTypeBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource CustomerBindingSource;
        private BindingSource ProductBindingSource;
        private BindingSource ShipmentTypeBindingSource;
        private BindingSource WarehouseBindingSource;
        private IEnumerable<SalesOrderViewModel> SalesOrderList;
        private SalesOrderViewModel SalesOrderVM;
        private IEnumerable<SalesType> SalesTypeList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Customer> CustomerList;
        private IEnumerable<Product> ProductList;
        private IEnumerable<ShipmentType> ShipmentTypeList;
        private IEnumerable<Warehouse> WarehouseList;
        public SalesOrderPresenter(ISalesOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            SalesOrderBindingSource = new BindingSource();
            SalesOrderLineBindingSource = new BindingSource();
            SalesTypeBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            CustomerBindingSource = new BindingSource();
            ProductBindingSource = new BindingSource();
            SalesOrderVM = new SalesOrderViewModel();
            ShipmentTypeBindingSource = new BindingSource();
            WarehouseBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            _view.ProductAddEvent += ProductAdd;
            _view.PaymentDiscountEvent += PaymentDiscount;
            _view.FreightEvent += Freight;
            _view.PrintSOEvent += PrintSO;
            _view.DeleteProductEvent += ProductDelete;
            _view.UpdateComputationEvent += UpdateComputation;
            _view.InvoiceEvent += ShowInvoice;
            _view.PaymentEvent += ShowPayment;

            //Load
            LoadAllSalesOrderList();
            LoadAllSalesTypeList();
            LoadAllBranchList();
            LoadAllCustomerList();
            LoadAllProductList();
            LoadAllShipmentTypeList();
            LoadAllWarehouseList();

            //Source Binding
        }

        private void ShowSalesOrderView<T>(Func<SalesOrder, T> viewCreator, string titlePrefix) where T : Form
        {
            var salesOrder = (SalesOrderViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.SalesOrder.Value.Get(
                c => c.SalesOrderId == salesOrder.SalesOrderId,
                includeProperties: "SalesOrderLines,Invoice,Customer,Shipment,PaymentReceive",
                tracked: true
            );

            var form = viewCreator(entity);
            form.Text = $"{titlePrefix} for S.O.#: {entity.SalesOrderName}";
            form.ShowDialog();
        }

        private void ShowPayment(object? sender, EventArgs e)
        {
            ShowSalesOrderView(entity => new PaymentReceiveView(entity, _unitOfWork), "Payment Details");
        }

        private void ShowInvoice(object? sender, EventArgs e)
        {
            ShowSalesOrderView(entity => new InvoiceView(entity, _unitOfWork), "Generate Invoice");
        }

        private void UpdateComputation(object? sender, EventArgs e)
        {
            _view.Amount = _view.SalesOrderLines.Select(c => c.SubTotal).Sum();
            _view.Tax = _view.SubTotal * 0.12;
            _view.SubTotal = _view.Amount - (_view.Amount * _view.Discount) - _view.Tax;
            _view.Total = _view.SubTotal + _view.Tax + _view.Freight;
        }

        private void Freight(object? sender, EventArgs e)
        {
            _view.Total = _view.SubTotal + _view.Tax + _view.Freight;
        }

        private void PaymentDiscount(object? sender, EventArgs e)
        {
            _view.SubTotal = _view.Amount - (_view.Amount * _view.Discount);
            _view.Tax = _view.SubTotal * 0.12;
            _view.Total = _view.SubTotal + _view.Tax + _view.Freight;
        }

        private void PrintSO(object? sender, EventArgs e)
        {
            var salesOrder = (SalesOrderViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == salesOrder.SalesOrderId, includeProperties: "SalesOrderLines,Shipment.ShipmentType,Invoice.InvoiceType,PaymentReceive.PaymentType");

            var salesOrderInformation = new SalesOrderInformationView(entity, salesOrder, _unitOfWork);
            salesOrderInformation.ShowDialog();
        }

        private void ProductDelete(object? sender, EventArgs e)
        {
            try
            {
                SalesOrderLineBindingSource.RemoveCurrent();
                _view.SetSalesOrderLineListBindingSource(SalesOrderLineBindingSource);
                _view.Message = "Item removed from the list successfully";
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Sales Order";
            }
        }

        private void ProductAdd(object? sender, EventArgs e)
        {
            var product = _unitOfWork.Product.Value.Get(c => c.ProductId == _view.ProductId, includeProperties: "ProductStockInLogs");

            if (product.ProductStockInLogs.Sum(c => c.StockQuantity) == 0)
            {
                _view.Message = "Not enough stocks. Please contact administrator.";
            }

            // Initialize SalesOrderLines if it's null
            _view.SalesOrderLines ??= new List<SalesOrderLineViewModel>();

            var checkOrder = _view.SalesOrderLines.Where(c => c.ProductId == _view.ProductId);

            if (checkOrder.Any() && !_view.NonStock)
            {
                _view.Message = "Item is already added.";
                return;
            }

            // Calculate values
            var productId = _view.NonStock ? (int?)null : _view.ProductId;
            var productprice = _view.NonStock ? 0.00 : product.DefaultSellingPrice;
            var productItem = _view.NonStock ? _view.NonStockProductName.Trim() : product.ProductName;
            var quantity = _view.ProductQuantity;
            var amount = productprice * quantity;
            var discount = _view.ProductDiscount/100;
            var discountAmount = productprice * discount;
            _view.SalesOrderLines.Add(new SalesOrderLineViewModel
            {
                ProductId = _view.ProductId,
                ProductName = productItem,
                Price = productprice,
                Quantity = quantity,
                DiscountPercentage = discount,
                SubTotal = amount - discountAmount
            });
            // Bind the data source
            SalesOrderLineBindingSource.DataSource = null; // Reset the binding source
            SalesOrderLineBindingSource.DataSource = _view.SalesOrderLines;
            _view.SetSalesOrderLineListBindingSource(SalesOrderLineBindingSource);

            _view.Amount = _view.SalesOrderLines.Select(c => c.SubTotal).Sum();
            _view.SubTotal = _view.Amount - (_view.Amount * _view.Discount);
            _view.Tax = _view.SubTotal * 0.12;
            _view.Total = _view.SubTotal + _view.Tax + _view.Freight;
        }


        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.SalesOrder.Value.Get(
                c => c.SalesOrderId == _view.SalesOrderId,
                includeProperties: "Shipment",
                tracked: true
            );

            if (model == null)
                model = new SalesOrder();
            else
                _unitOfWork.SalesOrder.Value.Detach(model);

            // Update SalesOrder properties
            model.SalesOrderId = _view.SalesOrderId;
            model.SalesOrderName = _view.SalesOrderName;
            model.BranchId = _view.BranchId;
            model.CustomerId = _view.CustomerId;
            model.OrderDate = _view.OrderDate;
            model.DeliveryDate = _view.DeliveryDate;
            model.CustomerRefNumber = _view.CustomerRefNumber;
            model.SalesTypeId = _view.SalesTypeId;
            model.Remarks = _view.Remarks;
            model.Amount = _view.Amount;
            model.SubTotal = _view.SubTotal;
            model.Discount = _view.Discount;
            model.Tax = _view.Tax;
            model.Freight = _view.Freight;
            model.Total = _view.Total;
            model.SalesOrderLines = _view.SalesOrderLines
                .Select(ToSalesOrderLine)
                .ToList();

            // Handling Shipment
            if (_view.NoShipment)
            {
                if (model.Shipment != null)
                {
                    _unitOfWork.Shipment.Value.Remove(model.Shipment);
                    _unitOfWork.Save();
                    model.Shipment = null;
                }
            }
            else
            {
                if (model.Shipment == null)
                    model.Shipment = new Shipment();

                model.Shipment.ShipmentId = _view.ShipmentId;
                model.Shipment.ShipmentName = Guid.NewGuid().ToString();
                model.Shipment.ShipmentTypeId = _view.ShipmentTypeId; // Nullable int
                model.Shipment.WarehouseId = _view.WarehouseId;       // Nullable int
                model.Shipment.IsFullShipment = _view.IsFullShipment;
                model.Shipment.ShipmentDate = _view.ShipmentDate == default(DateTime)
                    ? new DateTime(1753, 1, 1) // Default SQL min date
                    : _view.ShipmentDate;
            }

            try
            {
                new ModelDataValidation().Validate(model);

                if (_view.IsEdit)
                {
                    _unitOfWork.SalesOrder.Value.Update(model);
                    _view.Message = "Sales Order edited successfully";
                }
                else
                {
                    _unitOfWork.SalesOrder.Value.Add(model);
                    _view.Message = "Sales Order added successfully";
                }

                _unitOfWork.Save();
                _view.IsSuccessful = true;
                CleanviewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        public static SalesOrderLine ToSalesOrderLine(SalesOrderLineViewModel viewModel)
        {
            return new SalesOrderLine
            {
                ProductId = viewModel.ProductId,
                ProductName = viewModel.ProductName,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
                DiscountPercentage = viewModel.DiscountPercentage,
                SubTotal = viewModel.SubTotal
            };
        }
        public static List<SalesOrderLineViewModel> ToSalesOrderLineViewModels(IEnumerable<SalesOrderLine> salesOrderLines)
        {
            return salesOrderLines.Select(line => new SalesOrderLineViewModel
            {
                ProductId = (int)line.ProductId,
                ProductName = line.Product.ProductName,
                Quantity = line.Quantity,
                Price = line.Price,
                DiscountPercentage = line.DiscountPercentage,
                SubTotal = line.SubTotal
            }).ToList();
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (emptyValue == false)
            {
                SalesOrderList = Program.Mapper.Map<IEnumerable<SalesOrderViewModel>>(_unitOfWork.SalesOrder.Value.GetAll(c => c.SalesOrderName.Contains(_view.SearchValue), includeProperties: "Branch,SalesType,Customer"));
                SalesOrderBindingSource.DataSource = SalesOrderList;
            }
            else
            {
                LoadAllSalesOrderList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var salesOrder = (SalesOrderViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == salesOrder.SalesOrderId, includeProperties: "Shipment");
            var salesOrderLines = _unitOfWork.SalesOrderLine.Value.GetAll(c => c.SalesOrderId == salesOrder.SalesOrderId, includeProperties: "Product");
            _view.SalesOrderId = entity.SalesOrderId;
            _view.SalesOrderName = entity.SalesOrderName;
            _view.BranchId = entity.BranchId;
            _view.CustomerId = entity.CustomerId;
            _view.OrderDate = entity.OrderDate;
            _view.DeliveryDate = entity.DeliveryDate;
            _view.CustomerRefNumber = entity.CustomerRefNumber;
            _view.SalesTypeId = entity.SalesTypeId;
            _view.Remarks = entity.Remarks;
            _view.Amount = entity.Amount;
            _view.SubTotal = entity.SubTotal;
            _view.Discount = entity.Discount * 100;
            _view.Tax = entity.Tax;
            _view.Freight = entity.Freight;
            _view.Total = entity.Total;
            _view.SalesOrderLines = ToSalesOrderLineViewModels(salesOrderLines);

            if (entity.Shipment == null) _view.NoShipment = true;
            else
            {
                _view.ShipmentName = entity.Shipment.ShipmentName;
                _view.ShipmentTypeId = (int)(entity.Shipment.ShipmentTypeId ?? 0);
                _view.WarehouseId = (int)(entity.Shipment.WarehouseId ?? 0);
                _view.IsFullShipment = entity.Shipment.IsFullShipment;
                _view.ShipmentDate = entity.Shipment.ShipmentDate;
                _view.ShipmentId = entity.Shipment.ShipmentId;
                _view.SalesOrderId = entity.Shipment.SalesOrderId;
            }
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to delete";
                    return;
                }

                var salesOrder = (SalesOrderViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId ==  salesOrder.SalesOrderId);
                _unitOfWork.SalesOrder.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Sales Order deleted successfully";
                LoadAllSalesOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Sales Order";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);

            var localReport = new LocalReport();

            var reportDataSource = new ReportDataSource("SalesOrder", SalesOrderList);

            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllSalesOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllSalesOrderList();
            _view.SalesOrderId = 0;
            _view.SalesOrderName = "";
            _view.BranchId = 0;
            _view.CustomerId = 0;
            _view.OrderDate = DateTime.Now;
            _view.DeliveryDate = DateTime.Now;
            _view.CustomerRefNumber = "";
            _view.SalesTypeId = 0;
            _view.Remarks = "";
            _view.Amount = 0;
            _view.SubTotal = 0;
            _view.Discount = 0;
            _view.Tax = 0;
            _view.Freight = 0;
            _view.Total = 0;
            _view.SalesOrderLines = new List<SalesOrderLineViewModel>();
        }
        private void LoadAllSalesOrderList()
        {
            SalesOrderBindingSource.DataSource = SalesOrderList = Program.Mapper.Map<IEnumerable<SalesOrderViewModel>>(_unitOfWork.SalesOrder.Value.GetAll(includeProperties: "Branch,SalesType,Customer"));
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);
        }
        private void LoadAllSalesTypeList() {
            SalesTypeBindingSource.DataSource = SalesTypeList = _unitOfWork.SalesType.Value.GetAll();
            _view.SetSalesTypeListBindingSource(SalesTypeBindingSource);
        }
        private void LoadAllBranchList() {
            BranchBindingSource.DataSource = BranchList = _unitOfWork.Branch.Value.GetAll();
            _view.SetBranchListBindingSource(BranchBindingSource);
        }
        private void LoadAllCustomerList() {
            CustomerBindingSource.DataSource = CustomerList = _unitOfWork.Customer.Value.GetAll();
            _view.SetCustomerListBindingSource(CustomerBindingSource);
        }
        private void LoadAllProductList() {
            ProductBindingSource.DataSource = ProductList = _unitOfWork.Product.Value.GetAll();
            _view.SetProductListBindingSource(ProductBindingSource);
        }

        private void LoadAllShipmentTypeList()
        {
            ShipmentTypeList = _unitOfWork.ShipmentType.Value.GetAll();
            ShipmentTypeBindingSource.DataSource = ShipmentTypeList;//Set data source.
            _view.SetShipmentTypeListBindingSource(ShipmentTypeBindingSource);
        }
        private void LoadAllWarehouseList()
        {
            WarehouseList = _unitOfWork.Warehouse.Value.GetAll();
            WarehouseBindingSource.DataSource = WarehouseList;//Set data source.
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);
        }
    }
}
