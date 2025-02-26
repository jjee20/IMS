using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Hosting;

using SyncfusionWinFormsApp1.Contracts.Services;
using SyncfusionWinFormsApp1.Contracts.Views;
using SyncfusionWinFormsApp1.Views;

namespace SyncfusionWinFormsApp1.Services
{
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;
        private IShellWindow _shellWindow;

        public ApplicationHostService(IServiceProvider serviceProvider, INavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            if (Application.OpenForms.Count == 0)
            {
                // Default activation that navigates to the apps default page
                _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
                _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                _shellWindow.ShowWindow();
                _navigationService.NavigateTo(typeof(MainPage).FullName);
                await Task.CompletedTask;

            }
        }
    }
}
