using System.Runtime.InteropServices;
using System.IO;
using System;

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
            string themesFolderPath = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Themes\");

            if (File.Exists(themesFolderPath + "oldwallpaper"))
            {
                File.Delete(themesFolderPath + "oldwallpaper");
            }
            File.Copy(path, themesFolderPath + "oldwallpaper");
        }

        public static string DesktopSizeType(int x, int y)
        {
            double value = (double)x / y;
            if (value < 1)
            {
                return "tall";
            }
            else if (value == 1)
            {
                return "square";
            }
            else if (value == (double)16 / 9)
            {
                return "wide";
            }
            else if (value > ((double)16 / 9))
            {
                return "panoramic";
            }
            return "wide";
        }

    }
}
