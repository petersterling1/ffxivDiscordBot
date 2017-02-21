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
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            textboxDiscordToken.Text = Properties.Settings.Default.discordToken;
            textboxUrbanDictionary.Text = Properties.Settings.Default.urbandictionaryToken;
            textBoxFFLogsToken.Text = Properties.Settings.Default.fflogsToken;
            textboxBoxTrigger.Text = Properties.Settings.Default.botTrigger;

            checkboxDisconnect.Checked = Properties.Settings.Default.reconnect;
            checkboxSystemTray.Checked = Properties.Settings.Default.systemTray;

            pictureBoxNotifications.BackColor = Properties.Settings.Default.notificationColor;
            pictureBoxForeground.BackColor = Properties.Settings.Default.textColor;
            pictureBoxBackground.BackColor = Properties.Settings.Default.textBackgroundColor;
            pictureBoxUsername.BackColor = Properties.Settings.Default.usernameColor;

    }

        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.discordToken = textboxDiscordToken.Text;
            Properties.Settings.Default.urbandictionaryToken = textboxUrbanDictionary.Text;
            Properties.Settings.Default.fflogsToken = textBoxFFLogsToken.Text;
            Properties.Settings.Default.botTrigger = textboxBoxTrigger.Text;

            Properties.Settings.Default.reconnect = checkboxDisconnect.Checked;
            Properties.Settings.Default.systemTray = checkboxSystemTray.Checked;

            Properties.Settings.Default.notificationColor = pictureBoxNotifications.BackColor;
            Properties.Settings.Default.textBackgroundColor = pictureBoxBackground.BackColor;
            Properties.Settings.Default.textColor = pictureBoxForeground.BackColor;
            Properties.Settings.Default.usernameColor = pictureBoxUsername.BackColor;

            Properties.Settings.Default.Save();

            mainForm form = (mainForm) Application.OpenForms["mainForm"];
            form.settingsFormClosed();
        }

        private void textboxBoxTrigger_TextChanged(object sender, EventArgs e)
        {
            if(textboxBoxTrigger.TextLength > 1)
            {
                textboxBoxTrigger.Text = textboxBoxTrigger.Text.Substring(0, 1);
                textboxBoxTrigger.SelectionStart = 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNotificationColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBoxNotifications.BackColor = colorDialog.Color;
            }
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBoxBackground.BackColor = colorDialog.Color;
            }
        }

        private void buttonForeground_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBoxForeground.BackColor = colorDialog.Color;
            }
        }

        private void buttonUsername_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBoxUsername.BackColor = colorDialog.Color;
            }
        }
    }
}
