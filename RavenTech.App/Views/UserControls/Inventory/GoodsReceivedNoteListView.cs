﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
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
    public partial class GoodsReceivedNoteListVView : MaterialForm
    {
        private readonly BindingSource _bindingSource;
        private readonly IUnitOfWork _unitOfWork;
        public GoodsReceivedNoteListVView(BindingSource bindingSource, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _bindingSource = bindingSource;

            LoadAllGoodsReceivedNoteList();
            _unitOfWork = unitOfWork;
        }

        private void LoadAllGoodsReceivedNoteList()
        {

            dgPager.DataSource = _bindingSource.ToList<GoodsReceiveNoteViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }

        private void dgList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var GoodsReceivedNote = (GoodsReceiveNoteViewModel)dgList.SelectedItem;
            var entity = _unitOfWork.GoodsReceivedNote.Value.Get(c => c.GoodsReceivedNoteId == GoodsReceivedNote.GoodsReceivedNoteId, tracked: true);

            var result = MessageBox.Show("Are you sure you want to delete the selected GRN?", "Warning",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _unitOfWork.GoodsReceivedNote.Value.Detach(entity);
                _unitOfWork.GoodsReceivedNote.Value.Remove(entity);
                _unitOfWork.Save();

                MessageBox.Show("GRN deleted successfully", "Delete GRN", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _bindingSource.Remove(GoodsReceivedNote);
            }
        }
    }
}
