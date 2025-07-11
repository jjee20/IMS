using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class PaymentReceiveListView : SfForm
    {
        private readonly IEnumerable<PaymentReceiveViewModel> _paymentReceive;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentReceiveListView(IEnumerable<PaymentReceiveViewModel> paymentReceive, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _paymentReceive = paymentReceive;

            LoadAllPaymentReceiveList();
            _unitOfWork = unitOfWork;
            SetPermissions();
        }
        public void SetPermissions()
        {
            var appUserRoles = AppUserHelper.TaskRoles(Settings.Default.Roles);
            dgList.Columns["Delete"].Visible = appUserRoles.Contains(TaskRoles.Delete);
        }

        private void LoadAllPaymentReceiveList()
        {

            dgPager.DataSource = _paymentReceive;

            foreach (var item in _paymentReceive)
            {
                item.Delete = Resources.delete;
            }

            dgList.DataSource = dgPager.PagedSource;
        }
        private void dg_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow)
            {
                if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PaymentReceiveViewModel row)
                {
                    var entity = _unitOfWork.PaymentReceive.Value.Get(c => c.PaymentReceiveId == row.PaymentReceiveId);

                    var result = MessageBox.Show("Are you sure you want to delete the selected payment?", "Warning",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _unitOfWork.PaymentReceive.Value.Detach(entity);
                        _unitOfWork.PaymentReceive.Value.Remove(entity);
                        _unitOfWork.Save();

                        MessageBox.Show("Payment deleted successfully", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _paymentReceive.ToList().Remove(row);

                        dgList.DataSource = null;
                        dgList.DataSource = _paymentReceive;
                    }
                }
            }
            }
        }
    }
}
