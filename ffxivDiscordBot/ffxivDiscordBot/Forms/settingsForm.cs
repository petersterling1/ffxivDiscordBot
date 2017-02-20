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
    }

        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.discordToken = textboxDiscordToken.Text;
            Properties.Settings.Default.urbandictionaryToken = textboxUrbanDictionary.Text;
            Properties.Settings.Default.fflogsToken = textBoxFFLogsToken.Text;
            Properties.Settings.Default.botTrigger = textboxBoxTrigger.Text;

            Properties.Settings.Default.reconnect = checkboxDisconnect.Checked;
            Properties.Settings.Default.systemTray = checkboxSystemTray.Checked;

            Properties.Settings.Default.Save();
        }

        private void textboxBoxTrigger_TextChanged(object sender, EventArgs e)
        {
            if(textboxBoxTrigger.TextLength > 1)
            {
                textboxBoxTrigger.Text = textboxBoxTrigger.Text.Substring(0, 1);
                textboxBoxTrigger.SelectionStart = 1;
            }
        }
    }
}
