using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LastfmWallpaper
{
    public partial class Settings : MaterialForm
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            apiKeyField.Text = Globals.InitVars.apiKey;
        }
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.InitVars.apiKey = apiKeyField.Text;
        }
    }
}
