namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (tabControlMenu.TabMenuVisible)
                tabControlMenu.TabMenuVisible = false;
            else
                tabControlMenu.TabMenuVisible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
