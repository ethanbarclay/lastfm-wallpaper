using GScraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LastfmWallpaper
{
    class GoogleImagesDownload
    {
        public static async Task Download(string query, string aspectRatio)
        {
            var scraper = new GoogleScraper();
            IReadOnlyList<ImageResult> images = await scraper.GetImagesAsync(query + " music wallpaper " + aspectRatio, 1).ConfigureAwait(false);
            Console.WriteLine($"Link: {images[0].Link}");
            scraper.Dispose();

            Directory.CreateDirectory("downloads");
            Directory.CreateDirectory("downloads\\" + query);
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(images[0].Link, "downloads\\" + query + "\\image.jpg");
            }
            Console.WriteLine("Downloaded");
        }
    }
}
