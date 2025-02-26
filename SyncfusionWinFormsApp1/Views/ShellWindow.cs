using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

using SyncfusionWinFormsApp1.Contracts.Services;
using SyncfusionWinFormsApp1.Contracts.Views;

namespace SyncfusionWinFormsApp1.Views
{
    public partial class ShellWindow : RibbonForm,IShellWindow
    {
        private Syncfusion.Windows.Forms.BackStageTab openExportBackStageTab;
        private Syncfusion.Windows.Forms.BackStageTab saveAttachmentsBackStageTab;
        private Syncfusion.Windows.Forms.BackStageTab openBackStageTab;
        private Syncfusion.Windows.Forms.BackStageTab officeAccountsBackStageTab;
        private Syncfusion.Windows.Forms.BackStageSeparator backStageSeparator;
        private Syncfusion.Windows.Forms.BackStageTab printBackStageTab;
        private Syncfusion.Windows.Forms.BackStageButton closeBackStageButton;
        private INavigationService navigationService;
             
        public ShellWindow(INavigationService navigation)
        {
            InitializeComponent();
            navigationService=navigation;
            toolStripComboBox1.Items.AddRange(new object[] { "Office2007", "Office2010", "Office2013", "Office2016", "TouchStyle" });
            toolStripComboBox2.Items.AddRange(new object[] { "Simplified", "Normal" });
            toolStripComboBox3.Items.AddRange(new object[] { "AutoHide", "ShowTabs", "ShowTabsAndCommand" });
            toolStripComboBox4.Items.AddRange(new object[] { 

            "Main",
            "NavigationDrawer",
            });
            toolStripComboBox1.SelectedIndexChanged += SfComboBox1_SelectedValueChanged;
            toolStripComboBox2.SelectedIndexChanged += ToolStripComboBox2_SelectedIndexChanged;
            toolStripComboBox3.SelectedIndexChanged += ToolStripComboBox3_SelectedIndexChanged;
            toolStripComboBox4.SelectedIndexChanged += ToolStripComboBox4_SelectedIndexChanged;
            this.toolStripCheckBox1.CheckedChanged += ToolStripCheckBox1_CheckedChanged;
            this.toolStripCheckBox2.CheckedChanged += ToolStripCheckBox2_CheckedChanged;
        }

        private void ToolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sender!=null)
            {
                var selectedControl = sender as ToolStripComboBox;
                if(selectedControl!=null)
                {
                    if (panel1.Controls.Count != 0)
                    {
                        foreach (Control control in panel1.Controls)
                        {
                          control.Dispose();
                        }
                    }
                    if (selectedControl.SelectedItem!=null)
                    {
                        navigationService.NavigateTo(selectedControl.SelectedItem.ToString());
                    }
                }
            }
        }

        private void ToolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox3.SelectedIndex == 0)
            {
                this.ribbonControlAdv1.DisplayOption = RibbonDisplayOption.AutoHide;
            }
            if (toolStripComboBox3.SelectedIndex == 1)
            {
                this.ribbonControlAdv1.DisplayOption = RibbonDisplayOption.ShowTabs;
            }
            if (toolStripComboBox3.SelectedIndex == 2)
            {
                this.ribbonControlAdv1.DisplayOption = RibbonDisplayOption.ShowTabsAndCommands;
            }
        }

        private void ToolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedIndex == 0)
            {
                this.ribbonControlAdv1.LayoutMode = RibbonLayoutMode.Simplified;
            }
            else
            {
                this.ribbonControlAdv1.LayoutMode = RibbonLayoutMode.Normal;
            }
        }

        private void ToolStripCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripCheckBox2.Checked)
            {
                this.ribbonControlAdv1.MenuButtonVisible = true;
                this.openExportBackStageTab = new Syncfusion.Windows.Forms.BackStageTab();
                this.saveAttachmentsBackStageTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.openBackStageTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.officeAccountsBackStageTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.backStageSeparator = new Syncfusion.Windows.Forms.BackStageSeparator();
            this.printBackStageTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.closeBackStageButton = new Syncfusion.Windows.Forms.BackStageButton();

            this.ribbonControlAdv1.BackStageView = this.backStageView1;
            this.ribbonControlAdv1.MenuButtonText = "File";
                this.openExportBackStageTab.Text = "Open/Export";
                this.saveAttachmentsBackStageTab.Text = "Save Attachments";
                this.openBackStageTab.Text = "Open";
                this.officeAccountsBackStageTab.Text = "Office Accounts";
                this.printBackStageTab.Text = "Print";
                this.closeBackStageButton.Text = "Exit";
                this.backStageSeparator.Placement = Syncfusion.Windows.Forms.BackStageItemPlacement.Bottom;
            this.printBackStageTab.Placement = Syncfusion.Windows.Forms.BackStageItemPlacement.Bottom;
            this.closeBackStageButton.Placement = Syncfusion.Windows.Forms.BackStageItemPlacement.Bottom;

            this.backStage1.Controls.Add(openExportBackStageTab);
            this.backStage1.Controls.Add(saveAttachmentsBackStageTab);
            this.backStage1.Controls.Add(openBackStageTab);
            this.backStage1.Controls.Add(officeAccountsBackStageTab);
            this.backStage1.Controls.Add(backStageSeparator);
            this.backStage1.Controls.Add(printBackStageTab);
            this.backStage1.Controls.Add(closeBackStageButton);
            }
            else
            {
                this.ribbonControlAdv1.MenuButtonVisible = false;
            }
        }

        private void ToolStripCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripCheckBox1.Checked)
            {
                this.ribbonControlAdv1.ShowMinimizeButton = true;
            }
            else
            {
                this.ribbonControlAdv1.ShowMinimizeButton= false;
            }
        }

        private void SfComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                this.ribbonControlAdv1.RibbonStyle = RibbonStyle.Office2007;
            }
            else if(toolStripComboBox1.SelectedIndex == 1)
            {
                this.ribbonControlAdv1.RibbonStyle = RibbonStyle.Office2010;
            }
            else if(toolStripComboBox1.SelectedIndex == 2)
            {
                this.ribbonControlAdv1.RibbonStyle = RibbonStyle.Office2013;
            }
            else if(toolStripComboBox1.SelectedIndex == 3)
            {
                this.ribbonControlAdv1.RibbonStyle = RibbonStyle.Office2016;
            }
            else if(toolStripComboBox1.SelectedIndex == 4)
            {
                this.ribbonControlAdv1.RibbonStyle = RibbonStyle.TouchStyle;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.ribbonControlAdv1.LoadState();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.ribbonControlAdv1.SaveState();
        }

        public void CloseWindow()
        {
           
        }

        public Panel GetNavigationFrame()
            => this.panel1;

        public void ShowWindow()
            => Show();

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
