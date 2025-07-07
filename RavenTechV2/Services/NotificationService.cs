using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Services;
public class NotificationService
{
    public event Action<string, NotificationType>? NotificationRaised;

    public void Show(string message, NotificationType type = NotificationType.Info)
    {
        NotificationRaised?.Invoke(message, type);
    }
}

public enum NotificationType
{
    Info,
    Success,
    Warning,
    Error
}