using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ProjectManagementPresenter
    {
        public IProjectManagementView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProjectBindingSource;
        private BindingSource ProjectLineBindingSource;
        private BindingSource SalesTypeBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource CustomerBindingSource;
        private BindingSource ProductBindingSource;
        private IEnumerable<ProjectViewModel> ProjectList;
        private ProjectViewModel ProjectVM;
        private IEnumerable<Product> ProductList;
        public ProjectManagementPresenter(IProjectManagementView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProjectBindingSource = new BindingSource();
            ProjectLineBindingSource = new BindingSource();
            SalesTypeBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            CustomerBindingSource = new BindingSource();
            ProductBindingSource = new BindingSource();
            ProjectVM = new ProjectViewModel();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            _view.ProductAddEvent += ProductAdd;
            _view.PrintProjectEvent += PrintProject;
            _view.DeleteProductEvent += ProductDelete;
            _view.UpdateComputationEvent += UpdateComputation;

            //Load
            LoadAllProjectList();
            LoadAllProductList();

            //Source Binding
        }
        private void UpdateComputation(object? sender, EventArgs e)
        {
            _view.Total = _view.ProjectLines.Select(c => c.SubTotal).Sum();
        }

        private void PrintProject(object? sender, EventArgs e)
        {
            try
            {
                var Project = (ProjectViewModel)ProjectBindingSource.Current;
                var ProjectLine = _unitOfWork.ProjectLine.Value.GetAll(c => c.ProjectId == Project.ProjectId, includeProperties: "Product", tracked: true);
                var projectLineVM = ProjectLine.Select(c => new ProjectLineViewModel
                {
                    ProductId = (int)c.ProductId,
                    ProductName = c.Product.ProductName,
                    Price = c.Price,
                    DiscountPercentage = c.DiscountPercentage * 100,
                    Quantity = c.Quantity,
                    SubTotal = c.SubTotal,
                });
                ProjectVM = Project;

                string reportFileName = "ProjectReport.rdlc";
                string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
                string reportPath = Path.Combine(reportDirectory, reportFileName);

                var localReport = new LocalReport();

                var reportDataSource = new ReportDataSource("ProjectLine", projectLineVM);
                //localReport.DataSources.Add(reportDataSource);

                var parameters = new List<ReportParameter>
            {
                new ReportParameter("ProjectName", ProjectVM.ProjectName ?? string.Empty),
                new ReportParameter("StartDate", ProjectVM.StartDate.Value.ToString("MMM dd, yyyy")),
                new ReportParameter("EndDate", ProjectVM.EndDate.Value.ToString("MMM dd, yyyy")),
                new ReportParameter("Description", ProjectVM.Description ?? string.Empty),
                new ReportParameter("Client", ProjectVM.Client ?? string.Empty),
                new ReportParameter("Budget", ProjectVM.Budget.Value.ToString("N2")),
                new ReportParameter("Revenue", ProjectVM.Revenue.Value.ToString("N2")),
            };

                //localReport.SetParameters(parameters);

                var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
                reportView.ShowDialog();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void ProductDelete(object? sender, EventArgs e)
        {
            try
            {
                ProjectLineBindingSource.RemoveCurrent();
                _view.SetProjectLineListBindingSource(ProjectLineBindingSource);
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
            var product = _unitOfWork.Product.Value.Get(c => c.ProductId == _view.ProductId);

            // Initialize ProjectLines if it's null
            _view.ProjectLines ??= new List<ProjectLineViewModel>();

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

                var checkOrder = _view.ProjectLines.Where(c => c.ProductId == _view.ProductId);

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
            var discount = _view.ProductDiscount/100;
            var discountAmount = productprice * discount;

            _view.ProjectLines.Add(new ProjectLineViewModel
            {
                ProductId = _view.ProductId,
                ProductName = productItem,
                Price = productprice,
                Quantity = quantity,
                DiscountPercentage = discount,
                SubTotal = amount - discountAmount
            });
            // Bind the data source
            ProjectLineBindingSource.DataSource = null; // Reset the binding source
            ProjectLineBindingSource.DataSource = _view.ProjectLines;
            _view.SetProjectLineListBindingSource(ProjectLineBindingSource);
        }


        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Project.Value.Get(c => c.ProjectId == _view.ProjectId, tracked: true);
            if (model == null) model = new Project();
            else _unitOfWork.Project.Value.Detach(model);

            model.ProjectId = _view.ProjectId;
            model.ProjectName = _view.ProjectName;
            model.Description = _view.Description;
            model.Client = _view.Client;
            model.StartDate = _view.StartDate;
            model.EndDate = _view.EndDate;
            model.Budget = _view.Budget;
            model.Revenue = _view.Revenue;
            model.ProjectLines = _view.ProjectLines
                .Select(ToProjectLine)
                .ToList();

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Project.Value.Update(model);
                    _view.Message = "Project edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Project.Value.Add(model);
                    _view.Message = "Project added successfully";
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
        public static ProjectLine ToProjectLine(ProjectLineViewModel viewModel)
        {
            return new ProjectLine
            {
                ProductId = viewModel.ProductId,
                ProductName = viewModel.ProductName,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
                DiscountPercentage = viewModel.DiscountPercentage,
                SubTotal = viewModel.SubTotal
            };
        }
        public static List<ProjectLineViewModel> ToProjectLineViewModels(IEnumerable<ProjectLine> ProjectLines)
        {
            return ProjectLines.Select(line => new ProjectLineViewModel
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
                ProjectList = Program.Mapper.Map<IEnumerable<ProjectViewModel>>(_unitOfWork.Project.Value.GetAll(c => c.ProjectName.Contains(_view.SearchValue)));
                ProjectBindingSource.DataSource = ProjectList;
            }
            else
            {
                LoadAllProjectList();
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

            var Project = (ProjectViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId == Project.ProjectId);
            var ProjectLines = _unitOfWork.ProjectLine.Value.GetAll(c => c.ProjectId == Project.ProjectId, includeProperties: "Product");
            _view.ProjectId = entity.ProjectId;
            _view.ProjectName = entity.ProjectName;
            _view.Description = entity.Description;
            _view.Client = entity.Client ?? "No Client";
            _view.Budget = (double)(entity.Budget ?? 0);
            _view.Revenue = (double)(entity.Revenue ?? 0);
            _view.StartDate = entity.StartDate ?? DateTime.Now;
            _view.EndDate = entity.EndDate ?? DateTime.Now;
            _view.ProjectLines = ToProjectLineViewModels(ProjectLines);
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

                var Project = (ProjectViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId ==  Project.ProjectId);
                _unitOfWork.Project.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Project deleted successfully";
                LoadAllProjectList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Project";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            var project = (ProjectViewModel)ProjectBindingSource.Current;
            var entity = _unitOfWork.Project.Value.Get(c => c.ProjectId == project.ProjectId, includeProperties: "ProjectLines");

            var projectInformation = new ProjectInformationView(entity, project, _unitOfWork);
            projectInformation.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProjectList();
        }
        private void CleanviewFields()
        {
            LoadAllProjectList();
            _view.ProjectId = 0;
            _view.ProjectName = "";
            _view.Description = "";
            _view.Client = "";
            _view.StartDate = DateTime.Now;
            _view.EndDate = DateTime.Now;
            _view.Budget = 0;
            _view.Revenue = 0;
            _view.ProjectLines = new List<ProjectLineViewModel>();
        }

        private void LoadAllProjectList()
        {
            ProjectBindingSource.DataSource = ProjectList = Program.Mapper.Map<IEnumerable<ProjectViewModel>>(
            _unitOfWork.Project.Value.GetAll());

            _view.SetProjectListBindingSource(ProjectBindingSource);
        }
        private void LoadAllProductList()
        {
            ProductBindingSource.DataSource = ProductList = _unitOfWork.Product.Value.GetAll();
            _view.SetProductListBindingSource(ProductBindingSource);
        }
}
