using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTools.Common.Data;
using MovieTools.Common.Logging;

namespace MovieTools.Scraper
{
    public class DirectoryTreeFormatter
    {
        public string RootDirpath;

        public DirectoryTreeFormatter(string rootPath)
        {
            RootDirpath= rootPath;
        }

        public void Folderize()
        {
            var rootDir = new DirectoryInfo(RootDirpath);
            foreach (var indexDirInfo in rootDir.GetDirectories())
            {
                SortWithinIndexDirectory(indexDirInfo);
            }
        }

        private static void SortWithinIndexDirectory(DirectoryInfo indexDirInfo)
        {
            MovieLog.Info<DirectoryTreeFormatter>(string.Format("Started Working on folder \"{0}\"", indexDirInfo.Name));
            var scraper = new FileScraper();
            foreach (
                var file in
                    indexDirInfo.GetFiles().Where(fileInfo => FileConsts.ValidMovieExtensions.Contains(fileInfo.Extension.ToLowerInvariant())))
            {
                var data = scraper.Scrape(file);
                var newDirInfo = Directory.CreateDirectory(string.Join(@"\", indexDirInfo.FullName, data.ToDirectoryPath()));
                file.MoveTo(string.Join(@"\", newDirInfo.FullName, data.ToFilePath()));
            }
            MovieLog.Info<DirectoryTreeFormatter>(string.Format("Finished Working on folder \"{0}\"", indexDirInfo.Name));
        }
    }
}
