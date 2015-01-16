using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MovieTools.Scraper
{
    class Program
    {
        private static void Main(string[] args)
        {
            DoStuff();
        }

        private static void DoStuff()
        {
            const string dirPath = @"F:\Movies\A - Z";
            var rootDir = new DirectoryInfo(dirPath);
            foreach (var dirInfo in rootDir.GetDirectories())
            {
                foreach (
                    var file in
                        dirInfo.GetFiles().Where(fileInfo => MovieFileData.ValidMovieExtensions.Contains(fileInfo.Extension)))
                {
                    Console.WriteLine(file.Name);
                    var data = MovieFileData.Parse(file.Name);
                    Console.WriteLine(data.ToDirectoryPath());
                    Console.WriteLine(data.ToFilePath());
                }
            }
        }
    }
}
