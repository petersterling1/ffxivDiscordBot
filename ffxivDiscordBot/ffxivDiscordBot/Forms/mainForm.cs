using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffxivDiscordBot
{
    public partial class mainForm : Form
    {

        private Discord discord = new Discord();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = false;
            notifyIcon.Text = this.Text;
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && Properties.Settings.Default.systemTray)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else  if(FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
                textboxStatus.Width = this.Width - 40;
                textboxStatus.Height = this.Height - 100;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sf = new settingsForm();
            sf.Show();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
