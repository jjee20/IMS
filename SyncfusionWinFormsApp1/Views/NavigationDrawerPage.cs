using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using SyncfusionWinFormsApp1.Models;
namespace SyncfusionWinFormsApp1.Views
{
    public partial class NavigationDrawerPage : UserControl
    {
        public NavigationDrawerPage()
        {
            InitializeComponent();
            sfListView = new Syncfusion.WinForms.ListView.SfListView();
            var filter = navigationDrawer1.GetType().GetField("filter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            dynamic navigationDrawerMouseMessageFilter = filter.GetValue(navigationDrawer1);
            NavigationDrawerMouseMessageFilter MouseMessageFilter = navigationDrawerMouseMessageFilter;
            Application.RemoveMessageFilter(MouseMessageFilter);
            ds = new DataSet();
            ReadXml(ds,  AppDomain.CurrentDomain.BaseDirectory+"Resources\\data.xml");
            ds.DataSetName = "DataSet1";
            #region SfListView
            this.listView1.VerticalScrollBarVisible = false;
            this.listView1.SelectionMode = SelectionMode.One;
            this.listView1.DrawItem += sfListView_DrawItem;
            this.listView1.MouseUp += sfListView_MouseUp;
            this.listView1.HotTracking = true;
            listView1.DataSource = ds.Tables[0];
            listView1.DisplayMember = "Today";
            listView1.View.GroupDescriptors.Add(new Syncfusion.DataSource.GroupDescriptor()
            {
                PropertyName = "Today",
            });
            dt = ds.Tables[0];
            this.listView1.View.LiveDataUpdateMode = Syncfusion.DataSource.LiveDataUpdateMode.AllowDataShaping;
            this.listView1.Dock = DockStyle.Fill;
            this.listView1.Refresh();
            this.listView1.SelectedIndex = 3;
            #endregion
            #region Customizations
            if (this.navigationDrawer1.Items[0] is DrawerHeader)
            {
                //(this.navigationDrawer1.Items[0] as DrawerHeader).HeaderImage = this.imageListAdv1.Images[1];
                //(this.navigationDrawer1.Items[0] as DrawerHeader).HeaderText = "Anderson";
            }
            inboxPanel.Controls.Add(listView1);
            inboxPanel.Dock = DockStyle.Fill;
            this.navigationDrawer1.ContentViewContainer.Controls.Add(inboxPanel);
            this.navigationDrawer1.ContentViewContainer.Controls.Add(profilePanel);
            this.profilePanel.Dock = DockStyle.Fill;
            this.profilePanel.BackColor = Color.Red;
            if (this.navigationDrawer1.Items[0] is DrawerHeader)
            {
                (this.navigationDrawer1.Items[0] as DrawerHeader).TextAlign = TextAlignment.Center;
            }
            this.navigationDrawer1.DrawerPanelContainer.BorderStyle = BorderStyle.None;
            this.navigationDrawer1.TouchThreshold = 500;
            #endregion
            #region Events
            this.drawerMenuItem1.Click += new EventHandler(drawerMenuItem1_Click);
            this.drawerMenuItem2.Click += new EventHandler(drawerMenuItem2_Click);
            this.drawerMenuItem3.Click += new EventHandler(drawerMenuItem3_Click);
            this.drawerMenuItem4.Click += new EventHandler(drawerMenuItem4_Click);
            this.drawerMenuItem5.Click += new EventHandler(drawerMenuItem5_Click);
            #endregion
            AddControlsInProfilePanel();
            this.navigationDrawer1.DrawerHeight = this.navigationDrawer1.DisplayRectangle.Height;
            this.SizeChanged += MainForm_SizeChanged;
            SkinManager.SetVisualStyle(this, "Office2019Colorful");
            this.gradientPanel1.BorderStyle = BorderStyle.None;
            this.listView1.Style.BorderColor = Color.FromArgb(210, 210, 210);
            this.listView1.BackColor = Color.White;
            this.listView1.Style.BorderSides = Border3DSide.Bottom | Border3DSide.Left | Border3DSide.Right;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.navigationDrawer1.DrawerHeight = this.navigationDrawer1.DisplayRectangle.Height;
        }
        #region Variable 
        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);
        /// <summary>
        /// Inbox Panel
        /// </summary>
        Panel inboxPanel = new Panel();
        /// <summary>
        /// Profile Panel
        /// </summary>
        Panel profilePanel = new Panel();
        private Syncfusion.WinForms.ListView.SfListView sfListView;
        DataSet ds;
        DataTable dt;
        int rowIndex = 0;
        Rectangle closeImageRect = new Rectangle();
        Rectangle flagImageRect = new Rectangle();
        int firstrowHeight = 25;
        int secondrowHeight = 20;
        int thirdrowHeight = 15;
        object mouseHoverItemData = null;
        TileControl profile1 = new TileControl();
        #endregion
        #region Events
        #region SfListView Events
        private void sfListView_DrawItem(object sender, Syncfusion.WinForms.ListView.Events.DrawItemEventArgs e)
        {
            int rowCount = dt.Rows.Count + listView1.View.Groups.Count;
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.EllipsisCharacter;
            if (e.ItemType == Syncfusion.WinForms.ListView.Enums.ItemType.Record)
            {
                var record = (e.ItemData as DataRowView).Row;
                if (e.ItemIndex < rowCount)
                {
                    Graphics g = e.Graphics;
                    Rectangle clRect = e.Bounds;
                    rowIndex = e.ItemIndex;
                    Point mousePosition = listView1.PointToClient(Cursor.Position);
                    bool isHover = false;
                    if (e.Bounds.Contains(mousePosition))
                    {
                        isHover = true;
                        mouseHoverItemData = e.ItemData;
                    }
                    if (rowIndex == this.listView1.SelectedIndex)
                    {
                        isHover = true;
                        Rectangle paintRect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);
                        g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#c7e0f4")), paintRect);
                    }
                    else if (isHover)
                    {
                        Rectangle paintRect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);
                        g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#deecf9")), paintRect);
                    }
                    if (isHover)
                    {
                        closeImageRect = new Rectangle(clRect.X + clRect.Width - 25, clRect.Y + 20, 20, 20);
                        flagImageRect = new Rectangle(clRect.X + clRect.Width - 60, clRect.Y + 5, 20, 20);
                        //g.DrawImage(global::NavigationDrawer.Properties.Resources.flag, flagImageRect);
                        //g.DrawImage(global::NavigationDrawer.Properties.Resources.delete, closeImageRect);
                    }
                    Rectangle firstDrawString = new Rectangle(clRect.X + 2, clRect.Y + 1, clRect.Width - 110, firstrowHeight);
                    Rectangle secondDrawString = new Rectangle(clRect.X + 2, clRect.Y + firstrowHeight, clRect.Width - 110, secondrowHeight);
                    Rectangle thirdDrawString = new Rectangle(clRect.X + 2, clRect.Y + firstrowHeight + secondrowHeight, clRect.Width - 110, thirdrowHeight);
                    Rectangle fourthDrawString = new Rectangle(clRect.Width - 100, clRect.Y + firstrowHeight, 100, secondrowHeight);
                    Font firstFont;
                    Font secondFont;
                    Font thirdFont;
                    Font fourthFont;
                    using (Graphics g1 = Graphics.FromImage(new Bitmap(10, 10)))
                    {
                        firstFont = new Font("Segoe UI", 11.5f);
                        secondFont = new Font("Segoe UI", 9f);
                        thirdFont = new Font("Segoe UI", 7.55f);
                        fourthFont = new Font("Segoe UI", 8f);
                    }
                    Color brush = this.ForeColor;
                    SolidBrush firstBrush = new SolidBrush(brush);
                    string firstString = "Customer Support";
                    string secondString = "Please schedule the meeting on tomorrow";
                    string thirdString = "<http.customersupport.com>";
                    string fourthString = "11.58 AM";
                    firstString = record.ItemArray[2].ToString();
                    secondString = record.ItemArray[3].ToString();
                    thirdString = record.ItemArray[5].ToString();
                    if (char.IsNumber(record.ItemArray[12].ToString(), 0))
                    {
                        fourthString = "    " + record.ItemArray[12].ToString();
                    }
                    else
                        fourthString = record.ItemArray[12].ToString();
                    g.DrawString(firstString, firstFont, firstBrush, firstDrawString, format);
                    g.DrawString(secondString, secondFont, firstBrush, secondDrawString, format);
                    g.DrawString(thirdString, thirdFont, firstBrush, thirdDrawString, format);
                    g.DrawString(fourthString, fourthFont, firstBrush, fourthDrawString, format);
                    e.Handled = true;
                }
            }
        }
        private void sfListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (closeImageRect.Contains(e.Location) && mouseHoverItemData != null)
            {
                if (this.sfListView.SelectedItems.Contains(mouseHoverItemData))
                    this.sfListView.SelectedItems.Remove(mouseHoverItemData);
                if (this.sfListView.View != null && this.sfListView.View.Groups != null)
                    this.sfListView.View.Groups.RemoveItemInGroup(mouseHoverItemData);
                mouseHoverItemData = null;
            }
        }
        #endregion
        /// <summary>
        /// Profile
        /// </summary>
        void drawerMenuItem5_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.profilePanel.Visible = true;
            this.inboxPanel.Visible = false;
            this.label7.Text = "Profile";
            this.navigationDrawer1.ToggleDrawer();
            LockWindowUpdate(IntPtr.Zero);
        }
        /// <summary>
        /// Sent
        /// </summary>
        void drawerMenuItem4_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            dt = ds.Tables[2];
            this.listView1.DataSource = dt;
            listView1.DisplayMember = "Today";
            if (listView1.View.GroupDescriptors.Count <= 0)
            {
                listView1.View.GroupDescriptors.Add(new Syncfusion.DataSource.GroupDescriptor()
                {
                    PropertyName = "Today",
                });
            }
            this.label7.Text = "Outbox";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            LockWindowUpdate(IntPtr.Zero);
        }
        /// <summary>
        /// Drafts
        /// </summary>
        void drawerMenuItem3_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            dt = ds.Tables[1];
            this.listView1.DataSource = dt;
            listView1.DisplayMember = "Today";
            if (listView1.View.GroupDescriptors.Count <= 0)
            {
                listView1.View.GroupDescriptors.Add(new Syncfusion.DataSource.GroupDescriptor()
                {
                    PropertyName = "Today",
                });
            }
            this.label7.Text = "Sent";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            LockWindowUpdate(IntPtr.Zero);
        }
        /// <summary>
        /// Outbox
        /// </summary>
        void drawerMenuItem2_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            dt = ds.Tables[3];
            this.listView1.DataSource = dt;
            listView1.DisplayMember = "Today";
            if (listView1.View.GroupDescriptors.Count <= 0)
            {
                listView1.View.GroupDescriptors.Add(new Syncfusion.DataSource.GroupDescriptor()
                {
                    PropertyName = "Today",
                });
            }
            this.label7.Text = "Drafts";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            LockWindowUpdate(IntPtr.Zero);
        }
        /// <summary>
        /// Inbox
        /// </summary>
        void drawerMenuItem1_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            dt = ds.Tables[0];
            this.listView1.DataSource = dt;
            listView1.DisplayMember = "Today";
            if (listView1.View.GroupDescriptors.Count <= 0)
            {
                listView1.View.GroupDescriptors.Add(new Syncfusion.DataSource.GroupDescriptor()
                {
                    PropertyName = "Today",
                });
            }
            this.label7.Text = "Inbox";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            LockWindowUpdate(IntPtr.Zero);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.navigationDrawer1.ToggleDrawer();
        }
        /// <summary>
        /// Event for applying style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion
        #region Functions
        /// <summary>
        /// To populate Profile Panel
        /// </summary>
        public void AddControlsInProfilePanel()
        {
            profile1.HeaderText = "Anderson";
            profile1.PostionText = "Senior Executive";
            profile1.OrganizatonText = "Custom Service";
            profile1.DOBText = "26/11/1973";
            profile1.LocationText = "NewYork";
            profile1.Height = 300;
            profile1.Dock = DockStyle.Top;
            profilePanel.Controls.Add(profile1);
            profilePanel.AutoScroll = true;
        }
        /// <summary>
        /// Reads xml data
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="xmlFileName">XML file</param>
        void ReadXml(DataSet ds, string xmlFileName)
        {
            for (int n = 0; n < 13; n++)
            {
                if (System.IO.File.Exists(xmlFileName))
                {
                    ds.ReadXml(xmlFileName);
                    break;
                }
                xmlFileName = @"..\" + xmlFileName;
            }
        }
        #endregion
    }
}
