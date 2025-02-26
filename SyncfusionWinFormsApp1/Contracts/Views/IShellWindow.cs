using System.Windows.Forms;

namespace SyncfusionWinFormsApp1.Contracts.Views
{
    public interface IShellWindow
    {


        Panel GetNavigationFrame();

        void ShowWindow();

        void CloseWindow();
    }
}
