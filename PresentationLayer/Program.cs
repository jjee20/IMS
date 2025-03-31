using Unity;
using Unity.Lifetime;
using InfastructureLayer.DataAccess.Repositories;
using ServiceLayer.Services.CommonServices;
using AutoMapper;
using PresentationLayer.Views.UserControls.Inventory;
using PresentationLayer.Presenters.Account;
using PresentationLayer.Views.IViews.Inventory;
using ServiceLayer.Services.IRepositories;
using PresentationLayer.Views.IViews.Admin;
using PresentationLayer.Views;
using PresentationLayer.Presenters.Admin;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using PresentationLayer.Views.UserControls;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using PresentationLayer.Presenters.Inventory;

namespace PresentationLayer
{
    internal static class Program
    {
        public static IMapper Mapper { get; private set; }
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC = new UnityContainer();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXxdcHZUR2BZUkVyWEVWYUA=");

            UnityC.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = mapperConfig.CreateMapper();

            UnityC.RegisterInstance(Mapper);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            // Resolve InventoryView and Presenter
            var unitOfWork = UnityC.Resolve<IUnitOfWork>();

            //Pass dependencies to the presenter
            //ILoginView mainView = new LoginView();
            //var presenter = new LoginPresenter(mainView, unitOfWork);
            //IPayrollView mainView = new PayrollView();
            //var presenter = new PayrollPresenter(mainView, unitOfWork);
            IInventoryView mainView = new InventoryView();
            var presenter = new InventoryPresenter(mainView, unitOfWork);
            //IAdminView mainView = new AdminView();
            //var presenter = new AdminPresenter(mainView, unitOfWork);

            Application.Run((Form)mainView);
            //Application.Run(new POSView());
        }

    }
}
