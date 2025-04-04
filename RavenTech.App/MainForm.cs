using PresentationLayer.Views.UserControls;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;

namespace RavenTech.App
{
    public partial class MainForm : SfForm
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            btnAllowance.Click += BtnAllowance_Click;
            _unitOfWork = unitOfWork;
        }

        private void BtnAllowance_Click(object? sender, EventArgs e)
        {
            IAllowanceView view = (IAllowanceView)AllowanceView.GetMdiInstance(this);
            new AllowancePresenter(view, _unitOfWork);
        }

        private void ribbonControlAdv1_MenuButtonClick(object sender, EventArgs e)
        {

        }
    }
}
