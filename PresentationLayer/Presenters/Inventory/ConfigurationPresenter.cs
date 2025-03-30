using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Inventory
{
    public class ConfigurationPresenter
    {
        private IConfigurationView _view;
        private IUnitOfWork _unitOfWork;
        public ConfigurationPresenter(IConfigurationView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _view.ShowUserRole += ShowUserRole;
            ShowUserRole(this, EventArgs.Empty);
        }

        private void ShowUserRole(object? sender, EventArgs e)
        {
            //IUserRoleView view = UserRoleView.GetInstance((TabPage)_view.Guna2TabControlPage);
            //new UserRolePresenter(view, _unitOfWork);
        }
    }
}
