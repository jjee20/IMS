using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RavenTechV2.Core.Models.UserManagement;
using RavenTechV2.Core.Services;
using RavenTechV2.Services;
using RavenTechV2.Views;

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
    private readonly IUnitOfService _unitOfService;
    private readonly PasswordHasher<User> _passwordHasher = new(); 
    private readonly NotificationService _notificationService;
    private readonly IUserSessionService _userSessionService;

    public LoginViewModel(NotificationService notificationService, IUserSessionService userSessionService)
    {
        LoginCommand = new AsyncRelayCommand(OnLogin);
        _unitOfService = App.GetService<IUnitOfService>();
        _notificationService = notificationService;
        _userSessionService = userSessionService;
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

            var user = await _unitOfService.User.Value.GetAsync(c => c.UserName == Username || c.Email == Username, includeProperties: "UserRoles");

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
                List<string> roles;

                if (user.UserRoles != null && user.UserRoles.Any())
                    roles = user.UserRoles.Select(ur => ur.Name).ToList();
                else
                    roles = new List<string> { "N/A" };

                
                _userSessionService.SetUser(user, roles);
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
