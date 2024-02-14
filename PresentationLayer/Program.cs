using InfastructureLayer.DataAccess.Data;
using PresentationLayer.Views;
using ServiceLayer.Services.IRepositories;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;
using InfastructureLayer.DataAccess.Repositories;
using PresentationLayer.Views.IViews;
using PresentationLayer.Presenters;
using System.Configuration;

namespace PresentationLayer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;

            UnityC = new UnityContainer()
                .RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            
            var unitOfWork = UnityC.Resolve<IUnitOfWork>(new DependencyOverride(typeof(string), sqlConnectionString));

            ApplicationConfiguration.Initialize();

            IInventoryView mainView = new InventoryView();
            new InventoryPresenter(mainView, unitOfWork);

            Application.Run((Form)mainView);
        }
    }
}
