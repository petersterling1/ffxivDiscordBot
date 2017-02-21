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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonUsername = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxUsername = new System.Windows.Forms.PictureBox();
            this.buttonBackground = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.buttonForeground = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxForeground = new System.Windows.Forms.PictureBox();
            this.buttonNotificationColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxNotifications = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForeground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textboxDiscordToken);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Urban Dictionary Auth Token";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 54);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FFLogs Auth Token";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textboxBoxTrigger);
            this.groupBox4.Location = new System.Drawing.Point(30, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(125, 75);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Command Trigger";
            // 
            // textboxBoxTrigger
            // 
            this.textboxBoxTrigger.Location = new System.Drawing.Point(40, 31);
            this.textboxBoxTrigger.Name = "textboxBoxTrigger";
            this.textboxBoxTrigger.Size = new System.Drawing.Size(38, 20);
            this.textboxBoxTrigger.TabIndex = 5;
            this.textboxBoxTrigger.TextChanged += new System.EventHandler(this.textboxBoxTrigger_TextChanged);
            // 
            // checkboxDisconnect
            // 
            this.checkboxDisconnect.AutoSize = true;
            this.checkboxDisconnect.Location = new System.Drawing.Point(24, 34);
            this.checkboxDisconnect.Name = "checkboxDisconnect";
            this.checkboxDisconnect.Size = new System.Drawing.Size(216, 17);
            this.checkboxDisconnect.TabIndex = 5;
            this.checkboxDisconnect.Text = "Reconnect if disconnected from Discord";
            this.checkboxDisconnect.UseVisualStyleBackColor = true;
            // 
            // checkboxSystemTray
            // 
            this.checkboxSystemTray.AutoSize = true;
            this.checkboxSystemTray.Location = new System.Drawing.Point(24, 58);
            this.checkboxSystemTray.Name = "checkboxSystemTray";
            this.checkboxSystemTray.Size = new System.Drawing.Size(195, 17);
            this.checkboxSystemTray.TabIndex = 6;
            this.checkboxSystemTray.Text = "Send to system tray when minimized";
            this.checkboxSystemTray.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 214);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Auth Tokens";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Behavior";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkboxDisconnect);
            this.groupBox5.Controls.Add(this.checkboxSystemTray);
            this.groupBox5.Location = new System.Drawing.Point(174, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(269, 100);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonUsername);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.pictureBoxUsername);
            this.tabPage3.Controls.Add(this.buttonBackground);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.pictureBoxBackground);
            this.tabPage3.Controls.Add(this.buttonForeground);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.pictureBoxForeground);
            this.tabPage3.Controls.Add(this.buttonNotificationColor);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.pictureBoxNotifications);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(545, 188);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Colors";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonUsername
            // 
            this.buttonUsername.Location = new System.Drawing.Point(181, 108);
            this.buttonUsername.Name = "buttonUsername";
            this.buttonUsername.Size = new System.Drawing.Size(75, 23);
            this.buttonUsername.TabIndex = 11;
            this.buttonUsername.Text = "Change";
            this.buttonUsername.UseVisualStyleBackColor = true;
            this.buttonUsername.Click += new System.EventHandler(this.buttonUsername_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username Color";
            // 
            // pictureBoxUsername
            // 
            this.pictureBoxUsername.BackColor = System.Drawing.Color.Maroon;
            this.pictureBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxUsername.Location = new System.Drawing.Point(138, 113);
            this.pictureBoxUsername.Name = "pictureBoxUsername";
            this.pictureBoxUsername.Size = new System.Drawing.Size(28, 13);
            this.pictureBoxUsername.TabIndex = 9;
            this.pictureBoxUsername.TabStop = false;
            // 
            // buttonBackground
            // 
            this.buttonBackground.Location = new System.Drawing.Point(181, 79);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(75, 23);
            this.buttonBackground.TabIndex = 8;
            this.buttonBackground.Text = "Change";
            this.buttonBackground.UseVisualStyleBackColor = true;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Textbox Background";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackColor = System.Drawing.Color.Maroon;
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackground.Location = new System.Drawing.Point(138, 84);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(28, 13);
            this.pictureBoxBackground.TabIndex = 6;
            this.pictureBoxBackground.TabStop = false;
            // 
            // buttonForeground
            // 
            this.buttonForeground.Location = new System.Drawing.Point(181, 50);
            this.buttonForeground.Name = "buttonForeground";
            this.buttonForeground.Size = new System.Drawing.Size(75, 23);
            this.buttonForeground.TabIndex = 5;
            this.buttonForeground.Text = "Change";
            this.buttonForeground.UseVisualStyleBackColor = true;
            this.buttonForeground.Click += new System.EventHandler(this.buttonForeground_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text Foreground Color";
            // 
            // pictureBoxForeground
            // 
            this.pictureBoxForeground.BackColor = System.Drawing.Color.Maroon;
            this.pictureBoxForeground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxForeground.Location = new System.Drawing.Point(138, 55);
            this.pictureBoxForeground.Name = "pictureBoxForeground";
            this.pictureBoxForeground.Size = new System.Drawing.Size(28, 13);
            this.pictureBoxForeground.TabIndex = 3;
            this.pictureBoxForeground.TabStop = false;
            // 
            // buttonNotificationColor
            // 
            this.buttonNotificationColor.Location = new System.Drawing.Point(181, 21);
            this.buttonNotificationColor.Name = "buttonNotificationColor";
            this.buttonNotificationColor.Size = new System.Drawing.Size(75, 23);
            this.buttonNotificationColor.TabIndex = 2;
            this.buttonNotificationColor.Text = "Change";
            this.buttonNotificationColor.UseVisualStyleBackColor = true;
            this.buttonNotificationColor.Click += new System.EventHandler(this.buttonNotificationColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notification Color";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBoxNotifications
            // 
            this.pictureBoxNotifications.BackColor = System.Drawing.Color.Maroon;
            this.pictureBoxNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNotifications.Location = new System.Drawing.Point(138, 26);
            this.pictureBoxNotifications.Name = "pictureBoxNotifications";
            this.pictureBoxNotifications.Size = new System.Drawing.Size(28, 13);
            this.pictureBoxNotifications.TabIndex = 0;
            this.pictureBoxNotifications.TabStop = false;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 219);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForeground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotifications)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBoxNotifications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNotificationColor;
        private System.Windows.Forms.Button buttonBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Button buttonForeground;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxForeground;
        private System.Windows.Forms.Button buttonUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxUsername;
    }
}