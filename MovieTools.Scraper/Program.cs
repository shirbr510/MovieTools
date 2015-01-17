using System;
using System.IO;
using System.Linq;
using MovieTools.Common.Data;

namespace MovieTools.Scraper
{
    class Program
    {
        private static void Main()
        {
            DoStuff();
        }

        private static void DoStuff()
        {
            var scraper = new FileScraper();
            const string dirPath = @"F:\Movies\A - Z";
            var rootDir = new DirectoryInfo(dirPath);
            foreach (var dirInfo in rootDir.GetDirectories())
            {
                foreach (
                    var file in
                        dirInfo.GetFiles().Where(fileInfo => FileConsts.ValidMovieExtensions.Contains(fileInfo.Extension)))
                {
                    Console.WriteLine(file.Name);
                    var data = scraper.Scrape(file);
                    Console.WriteLine(data.ToDirectoryPath());
                    Console.WriteLine(data.ToFilePath());
                }
            }
        }
    }
}
