namespace LastfmWallpaper
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toggleActive = new MaterialSkin.Controls.MaterialRaisedButton();
            this.usernameInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.listeningToLabel = new MaterialSkin.Controls.MaterialLabel();
            this.activeSongDisplay = new MaterialSkin.Controls.MaterialLabel();
            this.minimizeToTrayToggle = new MaterialSkin.Controls.MaterialCheckBox();
            this.LastfmWallpaper = new System.Windows.Forms.NotifyIcon(this.components);
            this.settingsButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // toggleActive
            // 
            this.toggleActive.AutoSize = true;
            this.toggleActive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleActive.Depth = 0;
            this.toggleActive.Icon = null;
            this.toggleActive.Location = new System.Drawing.Point(12, 124);
            this.toggleActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toggleActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.toggleActive.Name = "toggleActive";
            this.toggleActive.Primary = true;
            this.toggleActive.Size = new System.Drawing.Size(64, 36);
            this.toggleActive.TabIndex = 1;
            this.toggleActive.Text = "START";
            this.toggleActive.UseVisualStyleBackColor = true;
            this.toggleActive.Click += new System.EventHandler(this.MaterialRaisedButton1_Click);
            // 
            // usernameInput
            // 
            this.usernameInput.Depth = 0;
            this.usernameInput.Hint = "";
            this.usernameInput.Location = new System.Drawing.Point(82, 124);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernameInput.MaxLength = 32767;
            this.usernameInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.PasswordChar = '\0';
            this.usernameInput.SelectedText = "";
            this.usernameInput.SelectionLength = 0;
            this.usernameInput.SelectionStart = 0;
            this.usernameInput.Size = new System.Drawing.Size(130, 23);
            this.usernameInput.TabIndex = 2;
            this.usernameInput.TabStop = false;
            this.usernameInput.Text = "Username";
            this.usernameInput.UseSystemPasswordChar = false;
            // 
            // listeningToLabel
            // 
            this.listeningToLabel.AutoSize = true;
            this.listeningToLabel.Depth = 0;
            this.listeningToLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.listeningToLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listeningToLabel.Location = new System.Drawing.Point(12, 74);
            this.listeningToLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.listeningToLabel.Name = "listeningToLabel";
            this.listeningToLabel.Size = new System.Drawing.Size(96, 19);
            this.listeningToLabel.TabIndex = 3;
            this.listeningToLabel.Text = "Listening To:";
            // 
            // activeSongDisplay
            // 
            this.activeSongDisplay.Depth = 0;
            this.activeSongDisplay.Font = new System.Drawing.Font("Roboto", 11F);
            this.activeSongDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.activeSongDisplay.Location = new System.Drawing.Point(12, 97);
            this.activeSongDisplay.MouseState = MaterialSkin.MouseState.HOVER;
            this.activeSongDisplay.Name = "activeSongDisplay";
            this.activeSongDisplay.Size = new System.Drawing.Size(200, 19);
            this.activeSongDisplay.TabIndex = 4;
            this.activeSongDisplay.Text = "Artist";
            // 
            // minimizeToTrayToggle
            // 
            this.minimizeToTrayToggle.AutoSize = true;
            this.minimizeToTrayToggle.Checked = true;
            this.minimizeToTrayToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeToTrayToggle.Depth = 0;
            this.minimizeToTrayToggle.Font = new System.Drawing.Font("Roboto", 10F);
            this.minimizeToTrayToggle.Location = new System.Drawing.Point(78, 150);
            this.minimizeToTrayToggle.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeToTrayToggle.MouseLocation = new System.Drawing.Point(-1, -1);
            this.minimizeToTrayToggle.MouseState = MaterialSkin.MouseState.HOVER;
            this.minimizeToTrayToggle.Name = "minimizeToTrayToggle";
            this.minimizeToTrayToggle.Ripple = true;
            this.minimizeToTrayToggle.Size = new System.Drawing.Size(133, 30);
            this.minimizeToTrayToggle.TabIndex = 5;
            this.minimizeToTrayToggle.Text = "Minimize to Tray";
            this.minimizeToTrayToggle.UseVisualStyleBackColor = true;
            this.minimizeToTrayToggle.CheckedChanged += new System.EventHandler(this.MinimizeToTrayToggle_CheckedChanged);
            // 
            // LastfmWallpaper
            // 
            this.LastfmWallpaper.Icon = ((System.Drawing.Icon)(resources.GetObject("LastfmWallpaper.Icon")));
            this.LastfmWallpaper.Text = "Lastfm Wallpaper";
            this.LastfmWallpaper.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick_1);
            // 
            // settingsButton
            // 
            this.settingsButton.AutoSize = true;
            this.settingsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.settingsButton.Depth = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Icon = null;
            this.settingsButton.Location = new System.Drawing.Point(179, 26);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.settingsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Primary = false;
            this.settingsButton.Size = new System.Drawing.Size(33, 36);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "⚙";
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 197);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.minimizeToTrayToggle);
            this.Controls.Add(this.activeSongDisplay);
            this.Controls.Add(this.listeningToLabel);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.toggleActive);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.Text = "Lastfm Wallpaper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton toggleActive;
        private MaterialSkin.Controls.MaterialSingleLineTextField usernameInput;
        private MaterialSkin.Controls.MaterialLabel listeningToLabel;
        private MaterialSkin.Controls.MaterialLabel activeSongDisplay;
        private MaterialSkin.Controls.MaterialCheckBox minimizeToTrayToggle;
        private System.Windows.Forms.NotifyIcon LastfmWallpaper;
        private MaterialSkin.Controls.MaterialFlatButton settingsButton;
    }
}

