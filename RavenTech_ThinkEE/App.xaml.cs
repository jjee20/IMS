﻿using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.DataAccess.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using RavenTech_ThinkEE.Activation;
using RavenTech_ThinkEE.Contracts.Services;
using RavenTech_ThinkEE.Core.Contracts.Services;
using RavenTech_ThinkEE.Core.Services;
using RavenTech_ThinkEE.Helpers;
using RavenTech_ThinkEE.Models;
using RavenTech_ThinkEE.Services;
using RavenTech_ThinkEE.ViewModels;
using RavenTech_ThinkEE.Views;

using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RavenTech_ThinkEE;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar { get; set; }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddDbContext<ApplicationDataContext>();
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();
            services.AddAutoMapper(typeof(MappingProfile));

            // Other Activation Handlers
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JEaF5cXmtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXhedHRWRmdfUUFwWkZWYEk=");

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<ExamDetailViewModel>();
            services.AddTransient<ExamDetailPage>();
            services.AddTransient<ExamViewModel>();
            services.AddTransient<ExamPage>();
            services.AddTransient<ReviewTopicViewModel>();
            services.AddTransient<ReviewTopicPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
