using System.Globalization;
using AutoMapper;
using InfastructureLayer.DataAccess.Repositories;
using PresentationLayer.Presenters.Account;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Account;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Unity;
using Unity.Lifetime;

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
            CultureInfo phCulture = new CultureInfo("en-PH");
            Thread.CurrentThread.CurrentCulture = phCulture;
            Thread.CurrentThread.CurrentUICulture = phCulture;
            UnityC.RegisterType<IUnitOfWork, UnitOfWork>(new TransientLifetimeManager());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = mapperConfig.CreateMapper();

            UnityC.RegisterInstance(Mapper);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            //Pass dependencies to the presenter
            ILoginView mainView = new LoginView();
            var presenter = new LoginPresenter(mainView, UnityC);

            Application.Run((Form)mainView);
            //Application.Run(new UpsertProjectView());
        }

    }
}
