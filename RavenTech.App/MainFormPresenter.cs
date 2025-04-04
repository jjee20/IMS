using PresentationLayer.Views.UserControls;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech.App
{
    public class MainFormPresenter
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainForm _mainForm;
        public MainFormPresenter(IMainForm mainForm, IUnitOfWork unitOfWork)
        {
            _mainForm = mainForm;
            _mainForm.AllowanceEvent += AllowanceEvent;
            _unitOfWork = unitOfWork;
        }
        private void AllowanceEvent(object sender, EventArgs e)
        {
            
        }
    }
}
