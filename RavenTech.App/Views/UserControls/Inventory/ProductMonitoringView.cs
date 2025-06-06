﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductMonitoringView : UserControl, IProductMonitoringView
    {
        public ProductMonitoringView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Print
            btnPrint.Click += delegate
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        public double InStock
        {
            set { txtInStock.Text = value.ToString(); }
        }
        public double LowStock
        {
            set { txtLowStock.Text = value.ToString(); }
        }
        public double OutOfStock
        {
            set { txtOutOfStock.Text = value.ToString(); }
        }

        public void SetInStockListBindingSource(BindingSource source)
        {
            dgInStock.DataSource = source;
            DataGridHelper.ApplyDisplayNames<StockViewModel>(source, dgInStock);
        }
        public void SetLowStockListBindingSource(BindingSource source)
        {
            dgLowStock.DataSource = source;
            DataGridHelper.ApplyDisplayNames<StockViewModel>(source, dgLowStock);
        }
        public void SetOutOfStockListBindingSource(BindingSource source)
        {
            dgOutOfStock.DataSource = source;
            DataGridHelper.ApplyDisplayNames<StockViewModel>(source, dgOutOfStock);
        }

        public event EventHandler PrintEvent;

        private static ProductMonitoringView? instance;
        public static ProductMonitoringView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductMonitoringView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
