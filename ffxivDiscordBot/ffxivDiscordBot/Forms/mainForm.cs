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

        private Discord discord;

        public mainForm()
        {
            InitializeComponent();
            
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = false;
            notifyIcon.Text = this.Text;

            discord = new Discord(this);

            if (Properties.Settings.Default.notificationColor == Color.Empty) Properties.Settings.Default.notificationColor = Color.DarkGreen;

            if (Properties.Settings.Default.textColor == Color.Empty) Properties.Settings.Default.textColor = SystemColors.WindowText;

            if (Properties.Settings.Default.textBackgroundColor == Color.Empty) Properties.Settings.Default.textBackgroundColor = SystemColors.Window;

            if (Properties.Settings.Default.usernameColor == Color.Empty) Properties.Settings.Default.usernameColor = Color.DarkBlue;

            textboxStatus.ForeColor = Properties.Settings.Default.textColor;
            textboxStatus.BackColor = Properties.Settings.Default.textBackgroundColor;

            Properties.Settings.Default.Save();
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && Properties.Settings.Default.systemTray)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sf = new settingsForm();
            sf.Show();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discord.connect();
        }

        delegate void addTextboxTextCallback(String text, Color? color = null);
        private void addTextboxText(String text, Color? color = null)
        {
            if(textboxStatus.InvokeRequired)
            {
                addTextboxTextCallback d = new addTextboxTextCallback(addTextboxText);
                textboxStatus.Invoke(d, new object[] { text, color });
                return;
            }

            textboxStatus.SelectionStart = textboxStatus.TextLength;
            textboxStatus.SelectionLength = 0;

            if(color != null) textboxStatus.SelectionColor = color ?? textboxStatus.ForeColor;
            textboxStatus.AppendText(text);
            textboxStatus.SelectionColor = textboxStatus.ForeColor;

        }

        public void settingsFormClosed()
        {
            textboxStatus.BackColor = Properties.Settings.Default.textBackgroundColor;
            textboxStatus.ForeColor = Properties.Settings.Default.textColor;
        }

        public void addDiscordChatMessage(string username, string message)
        {
            addTextboxText(username + ": ", Properties.Settings.Default.usernameColor);
            addTextboxText(message + "\n", Properties.Settings.Default.textColor);
        }

        public void changeConnectionStatus(bool status, String message)
        {
            addTextboxText(message + "\n", Properties.Settings.Default.notificationColor);

            if (status)
            {
                connectionStatus.Text = "Connected";
            }else{
                connectionStatus.Text = "Disconnected";
            }
                    
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discord.disconnect();
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            textboxStatus.Width = this.Width - 40;
            textboxStatus.Height = this.Height - 100;
        }
    }
}
