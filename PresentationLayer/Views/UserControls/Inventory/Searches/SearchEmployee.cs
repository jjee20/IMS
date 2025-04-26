using DomainLayer.Models.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Windows.Forms;
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

namespace RavenTech_ERP.Views.UserControls.Inventory.Searches
{
    public partial class SearchEmployee : SfForm
    {
        public Employee _entity;
        private readonly IUnitOfWork _unitOfWork;
        public SearchEmployee(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            dgList.DataSource = _unitOfWork.Employee.Value.GetAll();
        }

        private void dgList_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
           _entity = (Employee)dgList.SelectedItem;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
