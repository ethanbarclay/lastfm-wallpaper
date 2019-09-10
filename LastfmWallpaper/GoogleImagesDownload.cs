using System;
using System.Diagnostics;
using System.IO;

namespace LastfmWallpaper
{
    class GoogleImagesDownload
    {
        public static void Download(string query)
        {
            // Run python bundled exe
            try
            {
                if (!File.Exists("google_images_download.exe"))
                {
                    throw new ArgumentException("Python binary not found.");
                }
                Console.WriteLine("Using python bundled exe.");
                // Run python bundled exe
                Process proc = new Process();
                proc.StartInfo.FileName = "google_images_download.exe";
                proc.StartInfo.Arguments = " -k \"" + query + " desktop wallpaper\" -l 1";
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                proc.WaitForExit();
                Console.WriteLine("Used python bundled exe.");

            }
            // Fallback to system interpreter
            catch
            {
                Console.WriteLine("Trying with python file.");
                Process proc = new Process();
                // Run with source with python system interpreter
                proc.StartInfo.FileName = "python";
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Arguments = "..\\..\\..\\google_images_download\\google_images_download.py -k \"" + query + " desktop wallpaper\" -l 1";
                proc.Start();
                proc.WaitForExit();
                Console.WriteLine("Used system interpreter.");
            }
        }
    }
}
