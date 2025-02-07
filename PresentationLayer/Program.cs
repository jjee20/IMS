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
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services.CommonServices;
using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Views.UserControls.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PresentationLayer.Presenters.Account;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.IViews.Admin;
using PresentationLayer.Presenters.Admin;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Presenters.Inventory;
using PresentationLayer.Presenters.Payroll;
using PresentationLayer.Views.IViews.Payroll;
using PresentationLayer.Views.UserControls.Payroll;
using Microsoft.Data.SqlClient;

namespace PresentationLayer
{
    internal static class Program
    {
        public static IMapper Mapper { get; private set; }
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC = new UnityContainer();

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

            // Pass dependencies to the presenter
            ILoginView mainView = new LoginView();
            var presenter = new LoginPresenter(mainView, unitOfWork);
            Application.Run((Form)mainView);
        }

    }
}
