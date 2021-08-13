using IF.Lastfm.Core.Api;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LastfmWallpaper
{
    public partial class Main : MaterialForm
    {
        private string username;
        private string artistName = "";
        private string desktopSizeType;
        private readonly string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsocks\\LastfmWallpaper\\";
        private int primaryX;
        private int primaryY;
        // private int totalX;
        // private int totalY;
        private bool active = false;
        private bool minimizeToTray = true;
        // private IF.Lastfm.Core.Objects.LastTrack activeSong;
        private List<IF.Lastfm.Core.Objects.LastTrack> recentTracks = new List<IF.Lastfm.Core.Objects.LastTrack>();
        System.Timers.Timer timer;

        public Main()
        {
            InitializeComponent();
            // AllocConsole(); // Launch console for debugging
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            active = false;
            usernameInput.Enabled = true;
            toggleActive.Text = "START";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            toggleActive.AutoSize = false;
            Size buttonSize = new Size(64, 56);
            toggleActive.Size = buttonSize;

            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            if (File.Exists(appDataFolder + "username.txt"))
            {
                usernameInput.Text = File.ReadAllText(appDataFolder + "username.txt");
            }
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

        private void MinimizeToTrayToggle_CheckedChanged(object sender, EventArgs e)
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
            File.WriteAllText(appDataFolder + "username.txt", username);

            // Reset stored resolution values
            primaryX = 0;
            primaryY = 0;
            // totalX = 0;
            // totalY = 0;

            primaryX = Screen.PrimaryScreen.Bounds.Width;
            primaryY = Screen.PrimaryScreen.Bounds.Height;
            desktopSizeType = Wallpaper.DesktopSizeType(primaryX, primaryY);
            Console.WriteLine(desktopSizeType);

            /*// Add up resolution of all displays
            foreach (Screen i in Screen.AllScreens)
            {
                totalX += i.Bounds.Width;
                totalY += i.Bounds.Height;
            }

            desktopSizeType = Wallpaper.DesktopSizeType(totalX, totalY);*/

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
                Wallpaper.SetWallpaper(Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Themes\oldwallpaper"));
            }

            GetRecentTracks().Wait();

            // If the latest scrobble is not a current scrobble, do not show
            /*if (recentTracks[0].IsNowPlaying == false || recentTracks[0].IsNowPlaying == null)
            {
                Wallpaper.SetWallpaper(Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Themes\oldwallpaper"));
                // Erase artistName so artist change is triggered if track is resumed
                artistName = "";
                return;
            }*/

            // Only update wallpaper if artist changes
            if (!(recentTracks[0].ArtistName == artistName))
            {
                artistName = recentTracks[0].ArtistName;
                DateTimeOffset? playTime = recentTracks[0].TimePlayed;
                Console.WriteLine("Artist: " + artistName + "\n");
                //Console.WriteLine("Time played: " + playTime.Value + "\n");
                //activeSong = recentTracks[0];

                // Update UI
                updateActiveSongDisplay();

                /*MessageBox.Show(artistName);*/
                Console.WriteLine("Latest scrobbled artist: " + artistName);

                // Download image
                GoogleImagesDownload.Download(artistName, desktopSizeType).Wait();

                // Create directory object
                DirectoryInfo di = new DirectoryInfo("downloads\\" + artistName);

                // Get name of downloaded image
                string firstFileName = di.GetFiles().Select(fi => fi.Name).FirstOrDefault(name => name != "Thumbs.db");

                // Set wallpaper
                Wallpaper.SetWallpaper(Path.GetFullPath("downloads\\" + artistName + "\\" + firstFileName));
            }
        }

        private async Task<string> GetRecentTracks()
        {
            recentTracks.Clear();

            var client = new LastfmClient(Globals.InitVars.apiKey, null);

            var response = await client.User.GetRecentScrobbles(username);

            foreach (IF.Lastfm.Core.Objects.LastTrack i in response)
            {
                recentTracks.Add(i);
            }

            Console.WriteLine("Artist: " + recentTracks[0].ArtistName);
            client.Dispose();
            return recentTracks[0].ArtistName;
        }

        // Called from other thread validate operation
        void updateActiveSongDisplay()
        {
            try
            {
                if (toggleActive.InvokeRequired)
                {
                    toggleActive.Invoke(new Action(updateActiveSongDisplay));
                    return;
                }
                activeSongDisplay.Text = artistName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            // Pause
            active = false;
            usernameInput.Enabled = true;
            toggleActive.Text = "START";

            Form settingsForm = new Settings();
            settingsForm.ShowDialog();
        }
    }
}
