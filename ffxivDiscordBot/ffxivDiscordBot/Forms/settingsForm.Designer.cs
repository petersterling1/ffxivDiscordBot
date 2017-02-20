namespace ffxivDiscordBot
{
    partial class settingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textboxDiscordToken = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textboxUrbanDictionary = new System.Windows.Forms.TextBox();
            this.textBoxFFLogsToken = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textboxBoxTrigger = new System.Windows.Forms.TextBox();
            this.checkboxDisconnect = new System.Windows.Forms.CheckBox();
            this.checkboxSystemTray = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textboxDiscordToken);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discord Bot Token";
            // 
            // textboxDiscordToken
            // 
            this.textboxDiscordToken.Location = new System.Drawing.Point(15, 19);
            this.textboxDiscordToken.Name = "textboxDiscordToken";
            this.textboxDiscordToken.Size = new System.Drawing.Size(499, 20);
            this.textboxDiscordToken.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textboxUrbanDictionary);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Urban Dictionary Auth Token";
            // 
            // textboxUrbanDictionary
            // 
            this.textboxUrbanDictionary.Location = new System.Drawing.Point(15, 19);
            this.textboxUrbanDictionary.Name = "textboxUrbanDictionary";
            this.textboxUrbanDictionary.Size = new System.Drawing.Size(499, 20);
            this.textboxUrbanDictionary.TabIndex = 2;
            // 
            // textBoxFFLogsToken
            // 
            this.textBoxFFLogsToken.Location = new System.Drawing.Point(15, 19);
            this.textBoxFFLogsToken.Name = "textBoxFFLogsToken";
            this.textBoxFFLogsToken.Size = new System.Drawing.Size(499, 20);
            this.textBoxFFLogsToken.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFFLogsToken);
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 54);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FFLogs Auth Token";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textboxBoxTrigger);
            this.groupBox4.Location = new System.Drawing.Point(12, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(125, 75);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Command Trigger";
            // 
            // textboxBoxTrigger
            // 
            this.textboxBoxTrigger.Location = new System.Drawing.Point(34, 30);
            this.textboxBoxTrigger.Name = "textboxBoxTrigger";
            this.textboxBoxTrigger.Size = new System.Drawing.Size(38, 20);
            this.textboxBoxTrigger.TabIndex = 5;
            this.textboxBoxTrigger.TextChanged += new System.EventHandler(this.textboxBoxTrigger_TextChanged);
            // 
            // checkboxDisconnect
            // 
            this.checkboxDisconnect.AutoSize = true;
            this.checkboxDisconnect.Location = new System.Drawing.Point(158, 200);
            this.checkboxDisconnect.Name = "checkboxDisconnect";
            this.checkboxDisconnect.Size = new System.Drawing.Size(216, 17);
            this.checkboxDisconnect.TabIndex = 5;
            this.checkboxDisconnect.Text = "Reconnect if disconnected from Discord";
            this.checkboxDisconnect.UseVisualStyleBackColor = true;
            // 
            // checkboxSystemTray
            // 
            this.checkboxSystemTray.AutoSize = true;
            this.checkboxSystemTray.Location = new System.Drawing.Point(158, 221);
            this.checkboxSystemTray.Name = "checkboxSystemTray";
            this.checkboxSystemTray.Size = new System.Drawing.Size(195, 17);
            this.checkboxSystemTray.TabIndex = 6;
            this.checkboxSystemTray.Text = "Send to system tray when minimized";
            this.checkboxSystemTray.UseVisualStyleBackColor = true;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 279);
            this.Controls.Add(this.checkboxSystemTray);
            this.Controls.Add(this.checkboxDisconnect);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settingsForm_FormClosing);
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textboxDiscordToken;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textboxUrbanDictionary;
        private System.Windows.Forms.TextBox textBoxFFLogsToken;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textboxBoxTrigger;
        private System.Windows.Forms.CheckBox checkboxDisconnect;
        private System.Windows.Forms.CheckBox checkboxSystemTray;
    }
}