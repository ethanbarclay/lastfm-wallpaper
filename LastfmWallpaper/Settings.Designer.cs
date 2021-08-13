
namespace LastfmWallpaper
{
    partial class Settings
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
            this.apiKeyLabel = new MaterialSkin.Controls.MaterialLabel();
            this.apiKeyField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.apiKeyLabel.Depth = 0;
            this.apiKeyLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.apiKeyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.apiKeyLabel.Location = new System.Drawing.Point(12, 79);
            this.apiKeyLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(115, 19);
            this.apiKeyLabel.TabIndex = 0;
            this.apiKeyLabel.Text = "Lastfm API Key:";
            // 
            // apiKeyField
            // 
            this.apiKeyField.BackColor = System.Drawing.SystemColors.Desktop;
            this.apiKeyField.Depth = 0;
            this.apiKeyField.ForeColor = System.Drawing.SystemColors.Desktop;
            this.apiKeyField.Hint = "";
            this.apiKeyField.Location = new System.Drawing.Point(133, 79);
            this.apiKeyField.MaxLength = 32767;
            this.apiKeyField.MouseState = MaterialSkin.MouseState.HOVER;
            this.apiKeyField.Name = "apiKeyField";
            this.apiKeyField.PasswordChar = '\0';
            this.apiKeyField.SelectedText = "";
            this.apiKeyField.SelectionLength = 0;
            this.apiKeyField.SelectionStart = 0;
            this.apiKeyField.Size = new System.Drawing.Size(267, 23);
            this.apiKeyField.TabIndex = 1;
            this.apiKeyField.TabStop = false;
            this.apiKeyField.UseSystemPasswordChar = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 111);
            this.Controls.Add(this.apiKeyField);
            this.Controls.Add(this.apiKeyLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel apiKeyLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField apiKeyField;
    }
}