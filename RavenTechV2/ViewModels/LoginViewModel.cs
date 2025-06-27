using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Contracts.Services;
using RavenTechV2.Services;
using RavenTechV2.Views;
using ServiceLayer.Services.IRepositories;

namespace RavenTechV2.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    private bool isBusy;

    public ICommand LoginCommand
    {
        get;
    }

    private UIElement? _shell = null;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PasswordHasher<ApplicationUser> _passwordHasher = new(); 
    private readonly NotificationService _notificationService;

    public LoginViewModel(IUnitOfWork unitOfWork, NotificationService notificationService)
    {
        LoginCommand = new AsyncRelayCommand(OnLogin);
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
    }

    private async Task OnLogin()
    {
        ErrorMessage = "";

        IsBusy = true;

        try
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both username and password.";
                _notificationService.Show(ErrorMessage, NotificationType.Error);
                IsBusy = false;
                return;
            }

            var user = await _unitOfWork.ApplicationUser.Value.GetAsync(c => c.UserName == Username || c.Email == Username);

            if (user == null)
            {
                ErrorMessage = "User not found. Please try again.";
                _notificationService.Show(ErrorMessage, NotificationType.Error);
                IsBusy = false;
                return;
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, Password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                _notificationService.Show($"Login Successful, welcome {user.UserName}!", NotificationType.Success);
                _shell = App.GetService<ShellPage>();
                App.MainWindow.Content = _shell ?? new Frame();
            }
            else
            {
                ErrorMessage = "Invalid credentials. Please try again.";
                _notificationService.Show(ErrorMessage, NotificationType.Error);
                IsBusy = false;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.ToString();
            IsBusy = false;
        }
    }
}
