using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories.IInventory;

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
        private IEnumerable<SalesOrderViewModel> SalesOrderList;
        private SalesOrderViewModel SalesOrderVM;
        private IEnumerable<SalesType> SalesTypeList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Customer> CustomerList;
        private IEnumerable<Product> ProductList;
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

            //Load
            LoadAllSalesOrderList();
            LoadAllSalesTypeList();
            LoadAllBranchList();
            LoadAllCustomerList();
            LoadAllProductList();

            //Source Binding
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);
            _view.SetSalesTypeListBindingSource(SalesTypeBindingSource);
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetCustomerListBindingSource(CustomerBindingSource);
            _view.SetProductListBindingSource(ProductBindingSource);
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

        private void PrintSO(object? sender, DataGridViewCellEventArgs e)
        {
            var salesOrder = (SalesOrderViewModel)SalesOrderBindingSource.Current;
            var salesOrderLine = _unitOfWork.SalesOrderLine.GetAll(c => c.SalesOrderId == salesOrder.SalesOrderId, includeProperties: "Product", tracked: true);
            var selesOrderLineVM = salesOrderLine.Select(c => new SalesOrderLineViewModel
            {
                ProductId = (int)c.ProductId,
                ProductName = c.Product.ProductName,
                Price = c.Price,
                DiscountPercentage = c.DiscountPercentage * 100,
                Quantity = c.Quantity,
                SubTotal = c.SubTotal,  
            });
            SalesOrderVM = salesOrder;

            string reportFileName = "SalesOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);

            var localReport = new LocalReport();

            var reportDataSource = new ReportDataSource("SalesOrderLine", selesOrderLineVM);
            //localReport.DataSources.Add(reportDataSource);

            var parameters = new List<ReportParameter>
            {
                new ReportParameter("SalesOrderName", SalesOrderVM.SalesOrderName ?? string.Empty),
                new ReportParameter("OrderDate", SalesOrderVM.OrderDate.ToString("MMM dd, yyyy")),
                new ReportParameter("DeliveryDate", SalesOrderVM.DeliveryDate.ToString("MMM dd, yyyy")),
                new ReportParameter("CustomerRefNumber", SalesOrderVM.CustomerRefNumber ?? string.Empty),
                new ReportParameter("Remarks", SalesOrderVM.Remarks ?? string.Empty),
                new ReportParameter("Amount", SalesOrderVM.Amount.ToString("N2")),
                new ReportParameter("SubTotal", SalesOrderVM.SubTotal.ToString("N2")),
                new ReportParameter("Discount", $"{(SalesOrderVM.Discount*100).ToString("N2")}%"),
                new ReportParameter("Tax", SalesOrderVM.Tax.ToString("N2")),
                new ReportParameter("Freight", SalesOrderVM.Freight.ToString("N2")),
                new ReportParameter("Total", SalesOrderVM.Total.ToString("N2")),
                new ReportParameter("Branch", SalesOrderVM.Branch ?? string.Empty),
                new ReportParameter("Customer", SalesOrderVM.Customer ?? string.Empty),
                new ReportParameter("SalesType", SalesOrderVM.SalesType ?? string.Empty),
            };

            //localReport.SetParameters(parameters);

            var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
            reportView.ShowDialog();
        }

        private void ProductDelete(object? sender, DataGridViewCellEventArgs e)
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
            var product = _unitOfWork.Product.Get(c => c.ProductId == _view.ProductId);

            // Initialize SalesOrderLines if it's null
            _view.SalesOrderLines ??= new List<SalesOrderLineViewModel>();

            var name = "";
            var price = 0.00;

            if (_view.NonStock)
            {
                name = _view.NonStockProductName.Trim();
                price = 0.00;
            }
            else
            {
                name = product.ProductName;
                price = product.DefaultSellingPrice;
            }
            // Calculate values
            var productprice = price;
            var productItem = name;
            var quantity = _view.ProductQuantity;
            var amount = productprice * quantity;
            var discount = _view.ProductDiscount/100;
            var discountAmount = productprice * discount;

            var checkOrder = _view.SalesOrderLines.Where(c => c.ProductId == _view.ProductId);

            if (checkOrder.Any())
            {
                _view.Message = "Item is already added.";
                return;
            }
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
            var model = _unitOfWork.SalesOrder.Get(c => c.SalesOrderId == _view.SalesOrderId);
            if (model == null) model = new SalesOrder();
            else _unitOfWork.SalesOrder.Detach(model);

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

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.SalesOrder.Update(model);
                    _view.Message = "Sales Order edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.SalesOrder.Add(model);
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
                SalesOrderList = Program.Mapper.Map<IEnumerable<SalesOrderViewModel>>(_unitOfWork.SalesOrder.GetAll(c => c.SalesOrderName.Contains(_view.SearchValue), includeProperties: "Branch,SalesType,Customer"));
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
            var salesOrder = (SalesOrderViewModel)SalesOrderBindingSource.Current;
            var entity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderId == salesOrder.SalesOrderId);
            var salesOrderLines = _unitOfWork.SalesOrderLine.GetAll(c => c.SalesOrderId == salesOrder.SalesOrderId, includeProperties: "Product");
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
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var salesOrder = (SalesOrderViewModel)SalesOrderBindingSource.Current;
                var entity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderId ==  salesOrder.SalesOrderId);
                _unitOfWork.SalesOrder.Remove(entity);
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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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

        private void LoadAllSalesOrderList() => SalesOrderBindingSource.DataSource = SalesOrderList = Program.Mapper.Map<IEnumerable<SalesOrderViewModel>>(_unitOfWork.SalesOrder.GetAll(includeProperties: "Branch,SalesType,Customer"));
        private void LoadAllSalesTypeList() => SalesTypeBindingSource.DataSource = SalesTypeList = _unitOfWork.SalesType.GetAll();
        private void LoadAllBranchList() => BranchBindingSource.DataSource = BranchList = _unitOfWork.Branch.GetAll();
        private void LoadAllCustomerList() => CustomerBindingSource.DataSource = CustomerList = _unitOfWork.Customer.GetAll();
        private void LoadAllProductList() => ProductBindingSource.DataSource =  ProductList = _unitOfWork.Product.GetAll();
    }
}
