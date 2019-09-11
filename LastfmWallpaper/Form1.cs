using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using IF.Lastfm.Core.Api;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace LastfmWallpaper
{
    public partial class Form1 : MaterialForm
    {
        private string username;
        private string artistName = "";
        private bool active = false;
        private bool minimizeToTray = true;
        //private IF.Lastfm.Core.Objects.LastTrack activeSong;
        private List<IF.Lastfm.Core.Objects.LastTrack> recentTracks = new List<IF.Lastfm.Core.Objects.LastTrack>();
        System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
            // AllocConsole(); // Launch console for debugging
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void MaterialRaisedButton1_Click(object sender, System.EventArgs e)
        {
            // Set bools and ui
            if (!active)
            {
                active = true;
                usernameInput.Enabled = false;
                toggleActive.Text = "STOP";
            }
            else
            {
                active = false;
                usernameInput.Enabled = true;
                toggleActive.Text = "START";
            }

            if (active)
            {
                // Store info
                username = usernameInput.Text;

                // Start running
                RequestManager();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            toggleActive.AutoSize = false;
            Size buttonSize = new Size(64, 56);
            toggleActive.Size = buttonSize;
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            if (minimizeToTray)
            {
                //if the form is minimized  
                //hide it from the task bar  
                //and show the system tray icon (represented by the NotifyIcon control)
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    LastfmWallpaper.Visible = true;
                }
            }
        }

        private void NotifyIcon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            LastfmWallpaper.Visible = false;
        }

        private void MinimizeToTrayToggle_CheckedChanged(object sender, System.EventArgs e)
        {
            if (minimizeToTrayToggle.CheckState == CheckState.Checked)
            {
                minimizeToTray = true;
            }
            else
            {
                minimizeToTray = false;
            }
        }

        private void RequestManager()
        {
            Console.WriteLine("Running");
            Wallpaper.CopyOldWallpaper(Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Themes\TranscodedWallpaper"));
            timer = new System.Timers.Timer(500);
            timer.Elapsed += TimerCall;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void TimerCall(object source, ElapsedEventArgs e)
        {
            if (!active)
            {
                timer.Dispose();
                Wallpaper.SetWallpaper(Path.GetFullPath("oldwallpaper"));
            }

            GetRecentTracks().Wait();

            // If the latest scrobble is not a current scrobble, do not show
            if (recentTracks[0].IsNowPlaying == false || recentTracks[0].IsNowPlaying == null)
            {
                Wallpaper.SetWallpaper(Path.GetFullPath("oldwallpaper"));
                // Erase artistName so artist change is triggered if track is resumed
                artistName = "";
                return;
            }
            
            // Only update wallpaper if artist changes
            if (!(recentTracks[0].ArtistName == artistName))
            {
                artistName = recentTracks[0].ArtistName;

                DateTimeOffset? playTime = recentTracks[0].TimePlayed;
                Console.WriteLine("Artist: " + artistName + "\n");
                //Console.WriteLine("Time played: " + playTime.Value + "\n");
                //activeSong = recentTracks[0];

                // Update UI
                activeSongDisplay.Text = artistName;

                Console.WriteLine("Latest scrobbled artist: " + artistName);
                GoogleImagesDownload.Download(artistName);

                // Create directory object
                DirectoryInfo di = new DirectoryInfo("downloads/" + artistName + " desktop wallpaper");

                // Get name of downloaded image
                string firstFileName = di.GetFiles().Select(fi => fi.Name).FirstOrDefault(name => name != "Thumbs.db");
                Wallpaper.SetWallpaper(Path.GetFullPath("downloads\\" + artistName + " desktop wallpaper\\" + firstFileName));
            }
        }

        private async Task<string> GetRecentTracks()
        {
            recentTracks.Clear();

            var client = new LastfmClient("f129e1e61eec3e59e1730738845abd1f", null);

            var response = await client.User.GetRecentScrobbles(username);

            foreach (IF.Lastfm.Core.Objects.LastTrack i in response)
            {
                recentTracks.Add(i);
            }

            Console.WriteLine("Artist: " + recentTracks[0].ArtistName);
            client.Dispose();
            return recentTracks[0].ArtistName;
        }
    }
}
