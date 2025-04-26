using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class GoodsReceivedNoteListVView : SfForm
    {
        private readonly IEnumerable<GoodsReceiveNoteViewModel> _goodsReceiveNotes;
        private readonly IUnitOfWork _unitOfWork;
        public GoodsReceivedNoteListVView(IEnumerable<GoodsReceiveNoteViewModel> goodsReceiveNotes, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _goodsReceiveNotes = goodsReceiveNotes;

            LoadAllGoodsReceivedNoteList();
            _unitOfWork = unitOfWork;
        }

        private void LoadAllGoodsReceivedNoteList()
        {
            dgPager.DataSource = _goodsReceiveNotes;

            foreach (var item in _goodsReceiveNotes)
            {
                item.Delete = Resources.delete;
            }

            dgList.DataSource = dgPager.PagedSource;
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is GoodsReceiveNoteViewModel row)
                {
                    var entity = _unitOfWork.GoodsReceivedNote.Value.Get(c => c.GoodsReceivedNoteId == row.GoodsReceivedNoteId, tracked: true);

                    var result = MessageBox.Show("Are you sure you want to delete the selected GRN?", "Warning",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _unitOfWork.GoodsReceivedNote.Value.Remove(entity);
                        _unitOfWork.Save();

                        MessageBox.Show("GRN deleted successfully", "Delete GRN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _goodsReceiveNotes.ToList().Remove(row);

                        dgList.DataSource = null;
                        dgList.DataSource = _goodsReceiveNotes;
                    }
                }
            }
        }
    }
}
