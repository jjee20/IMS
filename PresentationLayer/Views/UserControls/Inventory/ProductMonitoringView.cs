﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.Helpers;
using Syncfusion.WinForms.Controls;
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
    public partial class ProductMonitoringView : SfForm, IProductMonitoringView
    {
        public ProductMonitoringView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Print
            //btnPrint.Click += delegate
            //{
            //    PrintEvent?.Invoke(this, EventArgs.Empty);
            //};
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double InStock
        {
            set { txtInStock.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double LowStock
        {
            set { txtLowStock.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double OutOfStock
        {
            set { txtOutOfStock.Text = value.ToString(); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ProjectFlow
        {
            set { txtPulledOut.Text = value.ToString(); }
        }

        public void SetInStockListBindingSource(BindingSource source)
        {
            dgInStock.DataSource = source;
        }
        public void SetLowStockListBindingSource(BindingSource source)
        {
            dgLowStock.DataSource = source;
        }
        public void SetOutOfStockListBindingSource(BindingSource source)
        {
            dgOutOfStock.DataSource = source;
        }
        public void SetProjectFlowListBindingSource(BindingSource source)
        {
            dgPulledOut.DataSource = source;
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
