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
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            textboxStatus.Width = this.Width - 40;
            textboxStatus.Height = this.Height - 100;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sf = new settingsForm();
            sf.Show();
        }
    }
}
