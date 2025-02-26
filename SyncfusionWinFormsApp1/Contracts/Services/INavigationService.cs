using System;
using System.Windows.Forms;

namespace SyncfusionWinFormsApp1.Contracts.Services
{
    public interface INavigationService
    {

        void Initialize(Panel shellFrame);


        bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false);
    }
}
