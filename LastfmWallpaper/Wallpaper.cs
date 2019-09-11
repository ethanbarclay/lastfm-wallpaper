using System.Runtime.InteropServices;
using System.IO;

namespace LastfmWallpaper
{
    class Wallpaper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(
        uint action, uint uParam, string vParam, uint winIni);

        private static readonly uint SPI_SETDESKWALLPAPER = 0x14;
        private static readonly uint SPIF_UPDATEINIFILE = 0x01;
        private static readonly uint SPIF_SENDWININICHANGE = 0x02;


        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static void CopyOldWallpaper(string path)
        {
            if (File.Exists("oldwallpaper"))
            {
                File.Delete("oldwallpaper");
            }
            File.Copy(path, "oldwallpaper");
        }
    }
}
