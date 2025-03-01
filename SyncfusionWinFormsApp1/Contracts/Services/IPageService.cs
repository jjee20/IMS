using System;
using System.Windows.Forms;

namespace SyncfusionWinFormsApp1.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        UserControl GetPage(string key);
    }
}
