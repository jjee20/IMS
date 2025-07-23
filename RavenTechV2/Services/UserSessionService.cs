using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enums;
using RavenTechV2.Core.Models.UserManagement;

namespace RavenTechV2.Services;
public class UserSessionService : IUserSessionService
{
    private User _currentUser;
    private List<string> _currentRoles = new();

    public User CurrentUser => _currentUser;
    public IReadOnlyList<string> CurrentUserRoles => _currentRoles.AsReadOnly();
    public bool IsAuthenticated => _currentUser != null;

    public void SetUser(User user, IEnumerable<string> roles)
    {
        _currentUser = user;
        _currentRoles = roles?.ToList() ?? new List<string>();
    }

    public void Logout()
    {
        _currentUser = null;
        _currentRoles.Clear();
    }

    public bool HasRole(string role) => _currentRoles.Contains(role);

    public bool HasAnyRole(params string[] roles)
    {
        return _currentRoles.Any(r => roles.Contains(r));
    }
}

public interface IUserSessionService
{
    User CurrentUser
    {
        get;
    }
    IReadOnlyList<string> CurrentUserRoles
    {
        get;
    }
    void SetUser(User user, IEnumerable<string> roles);
    void Logout();
    bool HasRole(string role);
    bool HasAnyRole(params string[] roles);
    bool IsAuthenticated
    {
        get;
    }
}
