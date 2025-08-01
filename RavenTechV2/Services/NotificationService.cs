using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using WinUIEx.Messaging;

namespace RavenTechV2.Services;
public partial class NotificationService : ObservableObject
{
    [ObservableProperty] private bool isOpen;
    [ObservableProperty] private string? message;
    [ObservableProperty] private InfoBarSeverity severity = InfoBarSeverity.Informational;

    public void Show(string msg, InfoBarSeverity severity = InfoBarSeverity.Informational, int milliseconds = 2000)
    {
        Message = msg;
        Severity = severity;
        IsOpen = true;
        if (milliseconds > 0)
            DismissAfter(milliseconds);
    }

    private async void DismissAfter(int ms)
    {
        await Task.Delay(ms);
        IsOpen = false;
    }
}
