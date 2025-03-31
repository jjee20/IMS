using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PurchaseOrderPresenter
    {
        public IPurchaseOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PurchaseOrderBindingSource;
        private BindingSource PurchaseOrderLineBindingSource;
        private BindingSource PurchaseTypeBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource VendorBindingSource;
        private BindingSource ProductBindingSource;
        private IEnumerable<PurchaseOrderViewModel> PurchaseOrderList;
        private PurchaseOrderViewModel PurchaseOrderVM;
        private IEnumerable<PurchaseType> PurchaseTypeList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Vendor> VendorList;
        private IEnumerable<Product> ProductList;
        public PurchaseOrderPresenter(IPurchaseOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PurchaseOrderBindingSource = new BindingSource();
            PurchaseOrderLineBindingSource = new BindingSource();
            PurchaseTypeBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            VendorBindingSource = new BindingSource();
            ProductBindingSource = new BindingSource();
            PurchaseOrderVM = new PurchaseOrderViewModel();

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
            _view.PrintPOEvent += PrintPO;
            _view.DeleteProductEvent += ProductDelete;
            _view.UpdateComputationEvent += UpdateComputation;
            _view.GRNEvent += GRN;
            _view.BillEvent += GenerateBill;
            _view.PaymentVoucherEvent += GeneratePaymentVoucher;

            //Load
            LoadAllPurchaseOrderList();
            LoadAllPurchaseTypeList();
            LoadAllBranchList();
            LoadAllVendorList();
            LoadAllProductList();

            //Source Binding
        }

        private void OpenPurchaseOrderView<T>(Func<PurchaseOrder, T> viewCreator, string titlePrefix) where T : Form
        {
            try
            {
                var purchaseOrder = (PurchaseOrderViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.PurchaseOrder.Value.Get(
                    c => c.PurchaseOrderId == purchaseOrder.PurchaseOrderId,
                    includeProperties: "PurchaseOrderLines,GoodsReceivedNote,Bill,PaymentVoucher",
                    tracked: true
                );

                var form = viewCreator(entity);
                form.Text = $"{titlePrefix} Details for P.O.#: {entity.PurchaseOrderName}";
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                _view.Message = ex.Message;
            }
        }

        private void GeneratePaymentVoucher(object? sender, EventArgs e)
        {
            OpenPurchaseOrderView(entity => new PaymentVoucherView(entity, _unitOfWork), "Payment Voucher");
        }

        private void GenerateBill(object? sender, EventArgs e)
        {
            OpenPurchaseOrderView(entity => new BillView(entity, _unitOfWork), "Bill");
        }

        private void GRN(object? sender, EventArgs e)
        {
            OpenPurchaseOrderView(entity => new GoodsReceivedNoteView(entity, _unitOfWork), "Goods Received Note");
        }


        private void UpdateComputation(object? sender, EventArgs e)
        {
            _view.Amount = _view.PurchaseOrderLines.Select(c => c.SubTotal).Sum();
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

        private void PrintPO(object? sender, EventArgs e)
        {
            var PurchaseOrder = (PurchaseOrderViewModel)_view.DataGrid.SelectedItem;
            var PurchaseOrderLine = _unitOfWork.PurchaseOrderLine.Value.GetAll(c => c.PurchaseOrderId == PurchaseOrder.PurchaseOrderId, includeProperties: "Product", tracked: true);
            var purchaseOrderLineVM = PurchaseOrderLine.Select(c => new PurchaseOrderLineViewModel
            {
                ProductId = (int)c.ProductId,
                ProductName = c.Product.ProductName,
                Price = c.Price,
                DiscountPercentage = c.DiscountPercentage * 100,
                Quantity = c.Quantity,
                SubTotal = c.SubTotal,
            });
            PurchaseOrderVM = PurchaseOrder;

            string reportFileName = "PurchaseOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);

            var localReport = new LocalReport();

            var reportDataSource = new ReportDataSource("PurchaseOrderLine", purchaseOrderLineVM);
            //localReport.DataSources.Add(reportDataSource);

            var parameters = new List<ReportParameter>
            {
                new ReportParameter("PurchaseOrderName", PurchaseOrderVM.PurchaseOrderName ?? string.Empty),
                new ReportParameter("OrderDate", PurchaseOrderVM.OrderDate.ToString("MMM dd, yyyy")),
                new ReportParameter("DeliveryDate", PurchaseOrderVM.DeliveryDate.ToString("MMM dd, yyyy")),
                new ReportParameter("Remarks", PurchaseOrderVM.Remarks ?? string.Empty),
                new ReportParameter("Amount", PurchaseOrderVM.Amount.ToString("N2")),
                new ReportParameter("SubTotal", PurchaseOrderVM.SubTotal.ToString("N2")),
                new ReportParameter("Discount", $"{(PurchaseOrderVM.Discount*100).ToString("N2")}%"),
                new ReportParameter("Tax", PurchaseOrderVM.Tax.ToString("N2")),
                new ReportParameter("Freight", PurchaseOrderVM.Freight.ToString("N2")),
                new ReportParameter("Total", PurchaseOrderVM.Total.ToString("N2")),
                new ReportParameter("Branch", PurchaseOrderVM.Branch ?? string.Empty),
                new ReportParameter("Vendor", PurchaseOrderVM.Vendor ?? string.Empty),
                new ReportParameter("PurchaseType", PurchaseOrderVM.PurchaseType ?? string.Empty),
            };

            //localReport.SetParameters(parameters);

            var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
            reportView.ShowDialog();
        }

        private void ProductDelete(object? sender, EventArgs e)
        {
            try
            {
                PurchaseOrderLineBindingSource.RemoveCurrent();
                _view.SetPurchaseOrderLineListBindingSource(PurchaseOrderLineBindingSource);
                _view.Message = "Item removed from the list successfully";
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Purchase Order";
            }
        }

        private void ProductAdd(object? sender, EventArgs e)
        {
            var product = _unitOfWork.Product.Value.Get(c => c.ProductId == _view.ProductId);

            // Initialize PurchaseOrderLines if it's null
            _view.PurchaseOrderLines ??= new List<PurchaseOrderLineViewModel>();

            var name = "";
            var price = 0.00;

            if (_view.NonStock)
            {
                _view.ProductId = 0;
                name = _view.NonStockProductName.Trim();
                price = 0.00;
            }
            else
            {
                name = product.ProductName;
                price = product.DefaultSellingPrice;

                var checkOrder = _view.PurchaseOrderLines.Where(c => c.ProductId == _view.ProductId);

                if (checkOrder.Any())
                {
                    _view.Message = "Item is already added.";
                    return;
                }
            }
            // Calculate values
            var productprice = price;
            var productItem = name;
            var quantity = _view.ProductQuantity;
            var amount = productprice * quantity;
            var discount = _view.ProductDiscount / 100;
            var discountAmount = productprice * discount;
            _view.PurchaseOrderLines.Add(new PurchaseOrderLineViewModel
            {
                ProductId = _view.ProductId,
                ProductName = productItem,
                Price = productprice,
                Quantity = quantity,
                DiscountPercentage = discount,
                SubTotal = amount - discountAmount
            });
            // Bind the data source
            PurchaseOrderLineBindingSource.DataSource = null; // Reset the binding source
            PurchaseOrderLineBindingSource.DataSource = _view.PurchaseOrderLines;
            _view.SetPurchaseOrderLineListBindingSource(PurchaseOrderLineBindingSource);

            _view.Amount = _view.PurchaseOrderLines.Select(c => c.SubTotal).Sum();
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
            var model = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == _view.PurchaseOrderId, tracked: true);
            if (model == null) model = new PurchaseOrder();
            else _unitOfWork.PurchaseOrder.Value.Detach(model);

            model.PurchaseOrderId = _view.PurchaseOrderId;
            model.PurchaseOrderName = _view.PurchaseOrderName;
            model.BranchId = _view.BranchId;
            model.VendorId = _view.VendorId;
            model.OrderDate = _view.OrderDate;
            model.DeliveryDate = _view.DeliveryDate;
            model.PurchaseTypeId = _view.PurchaseTypeId;
            model.Remarks = _view.Remarks;
            model.Amount = _view.Amount;
            model.SubTotal = _view.SubTotal;
            model.Discount = _view.Discount;
            model.Tax = _view.Tax;
            model.Freight = _view.Freight;
            model.Total = _view.Total;
            model.PurchaseOrderLines = _view.PurchaseOrderLines
                .Select(ToPurchaseOrderLine)
                .ToList();

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PurchaseOrder.Value.Update(model);
                    _view.Message = "Purchase Order edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.PurchaseOrder.Value.Add(model);
                    _view.Message = "Purchase Order added successfully";
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
        public static PurchaseOrderLine ToPurchaseOrderLine(PurchaseOrderLineViewModel viewModel)
        {
            return new PurchaseOrderLine
            {
                ProductId = viewModel.ProductId,
                ProductName = viewModel.ProductName,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
                DiscountPercentage = viewModel.DiscountPercentage,
                SubTotal = viewModel.SubTotal
            };
        }
        public static List<PurchaseOrderLineViewModel> ToPurchaseOrderLineViewModels(IEnumerable<PurchaseOrderLine> PurchaseOrderLines)
        {
            return PurchaseOrderLines.Select(line => new PurchaseOrderLineViewModel
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
                PurchaseOrderList = Program.Mapper.Map<IEnumerable<PurchaseOrderViewModel>>(_unitOfWork.PurchaseOrder.Value.GetAll(c => c.PurchaseOrderName.Contains(_view.SearchValue), includeProperties: "Branch,PurchaseType,Vendor"));
                PurchaseOrderBindingSource.DataSource = PurchaseOrderList;
            }
            else
            {
                LoadAllPurchaseOrderList();
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

            var PurchaseOrder = (PurchaseOrderViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == PurchaseOrder.PurchaseOrderId);
            var PurchaseOrderLines = _unitOfWork.PurchaseOrderLine.Value.GetAll(c => c.PurchaseOrderId == PurchaseOrder.PurchaseOrderId, includeProperties: "Product");
            _view.PurchaseOrderId = entity.PurchaseOrderId;
            _view.PurchaseOrderName = entity.PurchaseOrderName;
            _view.BranchId = entity.BranchId;
            _view.VendorId = entity.VendorId;
            _view.OrderDate = entity.OrderDate;
            _view.DeliveryDate = entity.DeliveryDate;
            _view.PurchaseTypeId = entity.PurchaseTypeId;
            _view.Remarks = entity.Remarks;
            _view.Amount = entity.Amount;
            _view.SubTotal = entity.SubTotal;
            _view.Discount = entity.Discount * 100;
            _view.Tax = entity.Tax;
            _view.Freight = entity.Freight;
            _view.Total = entity.Total;
            _view.PurchaseOrderLines = ToPurchaseOrderLineViewModels(PurchaseOrderLines);
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

                var PurchaseOrder = (PurchaseOrderViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == PurchaseOrder.PurchaseOrderId);
                _unitOfWork.PurchaseOrder.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Purchase Order deleted successfully";
                LoadAllPurchaseOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Purchase Order";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);

            var localReport = new LocalReport();

            var reportDataSource = new ReportDataSource("PurchaseOrder", PurchaseOrderList);

            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPurchaseOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllPurchaseOrderList();
            _view.PurchaseOrderId = 0;
            _view.PurchaseOrderName = "";
            _view.BranchId = 0;
            _view.VendorId = 0;
            _view.OrderDate = DateTime.Now;
            _view.DeliveryDate = DateTime.Now;
            _view.PurchaseTypeId = 0;
            _view.Remarks = "";
            _view.Amount = 0;
            _view.SubTotal = 0;
            _view.Discount = 0;
            _view.Tax = 0;
            _view.Freight = 0;
            _view.Total = 0;
            _view.PurchaseOrderLines = new List<PurchaseOrderLineViewModel>();
        }

        private void LoadAllPurchaseOrderList()
        {
            PurchaseOrderBindingSource.DataSource = PurchaseOrderList = Program.Mapper.Map<IEnumerable<PurchaseOrderViewModel>>(_unitOfWork.PurchaseOrder.Value.GetAll(includeProperties: "Branch,PurchaseType,Vendor"));

            _view.SetPurchaseOrderListBindingSource(PurchaseOrderBindingSource);
        }
        private void LoadAllPurchaseTypeList() {
            PurchaseTypeBindingSource.DataSource = PurchaseTypeList = _unitOfWork.PurchaseType.Value.GetAll();
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeBindingSource);
        }
        private void LoadAllBranchList() {
            BranchBindingSource.DataSource = BranchList = _unitOfWork.Branch.Value.GetAll();
            _view.SetBranchListBindingSource(BranchBindingSource);
        }
        private void LoadAllVendorList() {
            VendorBindingSource.DataSource = VendorList = _unitOfWork.Vendor.Value.GetAll();
            _view.SetVendorListBindingSource(VendorBindingSource);
        }
        private void LoadAllProductList() {
            ProductBindingSource.DataSource =  ProductList = _unitOfWork.Product.Value.GetAll();
            _view.SetProductListBindingSource(ProductBindingSource);
        }
    }
}
