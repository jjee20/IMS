using System.Resources;using System.Resources;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.ListView;
using SyncfusionWinFormsApp1.Properties;
namespace SyncfusionWinFormsApp1.Views
{
    partial class NavigationDrawerPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.navigationDrawer1 = new Syncfusion.Windows.Forms.Tools.NavigationDrawer();
            this.header = new Syncfusion.Windows.Forms.Tools.DrawerHeader();
            this.drawerMenuItem1 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            this.drawerMenuItem2 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            this.drawerMenuItem3 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            this.drawerMenuItem4 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            this.drawerMenuItem5 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            this.imageListAdv1 = new Syncfusion.Windows.Forms.Tools.ImageListAdv(this.components);
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new Syncfusion.WinForms.ListView.SfListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationDrawer1
            // 
            this.navigationDrawer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.navigationDrawer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationDrawer1.DrawerWidth = 200;
            this.navigationDrawer1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.navigationDrawer1.Items.Add(this.header);
            this.navigationDrawer1.Items.Add(this.drawerMenuItem1);
            this.navigationDrawer1.Items.Add(this.drawerMenuItem2);
            this.navigationDrawer1.Items.Add(this.drawerMenuItem3);
            this.navigationDrawer1.Items.Add(this.drawerMenuItem4);
            this.navigationDrawer1.Items.Add(this.drawerMenuItem5);
            this.navigationDrawer1.Location = new System.Drawing.Point(0, 41);
            this.navigationDrawer1.Margin = new System.Windows.Forms.Padding(4);
            this.navigationDrawer1.Name = "navigationDrawer1";
            this.navigationDrawer1.Size = new System.Drawing.Size(1288, 832);
            this.navigationDrawer1.Style = Syncfusion.Windows.Forms.Tools.NavigationDrawerStyle.Office2016Colorful;
            this.navigationDrawer1.TabIndex = 0;
            this.navigationDrawer1.Text = "navigationDrawer1";
            this.navigationDrawer1.ThemeName = "Office2016Colorful";
            //customisation
            this.navigationDrawer1.AnimationDuration = 10;
            this.navigationDrawer1.Transition = Syncfusion.Windows.Forms.Tools.Transition.SlideOnTop;
            this.navigationDrawer1.Position = Syncfusion.Windows.Forms.Tools.SlidePosition.Left;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.header.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.header.HeaderText = "Outlook";
            this.header.Location = new System.Drawing.Point(2, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "Outlook";
            this.header.Size = new System.Drawing.Size(267, 148);
            this.header.TabIndex = 0;
            this.header.Text = "Outlook";
            this.header.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // drawerMenuItem1
            // 
            this.drawerMenuItem1.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.drawerMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.drawerMenuItem1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.drawerMenuItem1.ItemText = "Inbox";
            this.drawerMenuItem1.Location = new System.Drawing.Point(2, 148);
            this.drawerMenuItem1.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem1.MinimumSize = new System.Drawing.Size(267, 62);
            this.drawerMenuItem1.Name = "drawerMenuItem1";
            this.drawerMenuItem1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawerMenuItem1.Size = new System.Drawing.Size(267, 62);
            this.drawerMenuItem1.TabIndex = 0;
            this.drawerMenuItem1.Text = "Inbox";
            this.drawerMenuItem1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.drawerMenuItem1.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
            // 
            // drawerMenuItem2
            // 
            this.drawerMenuItem2.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem2.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.drawerMenuItem2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.drawerMenuItem2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.drawerMenuItem2.ItemText = "Drafts";
            this.drawerMenuItem2.Location = new System.Drawing.Point(2, 210);
            this.drawerMenuItem2.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem2.MinimumSize = new System.Drawing.Size(267, 62);
            this.drawerMenuItem2.Name = "drawerMenuItem2";
            this.drawerMenuItem2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawerMenuItem2.Size = new System.Drawing.Size(267, 62);
            this.drawerMenuItem2.TabIndex = 1;
            this.drawerMenuItem2.Text = "Drafts";
            this.drawerMenuItem2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.drawerMenuItem2.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
            // 
            // drawerMenuItem3
            // 
            this.drawerMenuItem3.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem3.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.drawerMenuItem3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.drawerMenuItem3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.drawerMenuItem3.ItemText = "Sent";
            this.drawerMenuItem3.Location = new System.Drawing.Point(2, 272);
            this.drawerMenuItem3.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem3.MinimumSize = new System.Drawing.Size(267, 62);
            this.drawerMenuItem3.Name = "drawerMenuItem3";
            this.drawerMenuItem3.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawerMenuItem3.Size = new System.Drawing.Size(267, 62);
            this.drawerMenuItem3.TabIndex = 2;
            this.drawerMenuItem3.Text = "Sent";
            this.drawerMenuItem3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.drawerMenuItem3.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
            // 
            // drawerMenuItem4
            // 
            this.drawerMenuItem4.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem4.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.drawerMenuItem4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.drawerMenuItem4.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.drawerMenuItem4.ItemText = "Outbox";
            this.drawerMenuItem4.Location = new System.Drawing.Point(2, 334);
            this.drawerMenuItem4.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem4.MinimumSize = new System.Drawing.Size(267, 62);
            this.drawerMenuItem4.Name = "drawerMenuItem4";
            this.drawerMenuItem4.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawerMenuItem4.Size = new System.Drawing.Size(267, 62);
            this.drawerMenuItem4.TabIndex = 3;
            this.drawerMenuItem4.Text = "Outbox";
            this.drawerMenuItem4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.drawerMenuItem4.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
            // 
            // drawerMenuItem5
            // 
            this.drawerMenuItem5.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem5.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.drawerMenuItem5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.drawerMenuItem5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.drawerMenuItem5.ItemText = "Profile";
            this.drawerMenuItem5.Location = new System.Drawing.Point(2, 396);
            this.drawerMenuItem5.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem5.MinimumSize = new System.Drawing.Size(267, 62);
            this.drawerMenuItem5.Name = "drawerMenuItem5";
            this.drawerMenuItem5.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drawerMenuItem5.Size = new System.Drawing.Size(267, 62);
            this.drawerMenuItem5.TabIndex = 4;
            this.drawerMenuItem5.Text = "Profile";
            this.drawerMenuItem5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.drawerMenuItem5.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Center;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Controls.Add(this.listView1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1288, 41);
            this.gradientPanel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Inbox";
            // 
            // pictureBox1
            // 
            ResourceManager rm = new ResourceManager("SyncfusionWinFormsApp1.Properties.Resources", typeof(Resources).Assembly);
	        var imgValue= rm.GetObject("Icon_menu_Colorful") as System.Drawing.Image;
            this.pictureBox1.Image = imgValue;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.AccessibleName = "ScrollControl";
            this.listView1.ItemHeight = 70D;
            this.listView1.Location = new System.Drawing.Point(173, 225);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.listView1.Size = new System.Drawing.Size(161, 119);
            this.listView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.navigationDrawer1);
            this.panel2.Controls.Add(this.gradientPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1288, 873);
            this.panel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1298, 10);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(11, 873);
            this.panel5.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 893);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
           // this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigation Drawer";
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private Syncfusion.Windows.Forms.Tools.NavigationDrawer navigationDrawer1;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem1;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem2;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem3;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem4;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem5;
        private Syncfusion.Windows.Forms.Tools.ImageListAdv imageListAdv1;
        private DrawerHeader header;
        private GradientPanel gradientPanel1;
        private Panel panel5;
        private SfListView listView1;
        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox1;
    }
}
