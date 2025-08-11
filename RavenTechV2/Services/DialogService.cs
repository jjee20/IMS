using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace RavenTechV2.Services;
public class DialogService : IDialogService
{
    public async Task<bool> ShowDialogAsync(Func<ContentDialog> dialogFactory, XamlRoot xamlRoot)
    {
        var dialog = dialogFactory();
        dialog.XamlRoot = xamlRoot;
        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}


public interface IDialogService
{
    Task<bool> ShowDialogAsync(Func<ContentDialog> dialogFactory, XamlRoot xamlRoot);
}

