using DomainLayer.Models.Accounts;
using DomainLayer.ViewModels.PayrollViewModels;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll
{
    public partial class _13thMonthView : SfForm
    {
        private PayrollViewModel _employee;
        private IUnitOfWork _unitOfWork;
        public _13thMonthView(PayrollViewModel employee, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _employee = employee;
            _unitOfWork = unitOfWork;

            txtName.Text = employee.Employee;
        }
    }
}
