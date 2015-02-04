using System.IO;
using System.Linq;
using MovieTools.Common.Data;
using MovieTools.Common.Extensions;
using MovieTools.Common.Logging;

namespace MovieTools.Scraping
{
    public class DirectoryTreeFormatter
    {
        public string RootDirpath;

        public DirectoryTreeFormatter(string rootPath)
        {
            RootDirpath = rootPath;
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
                    indexDirInfo.GetSpecificMovieTypes(FileConsts.ValidMovieExtensions))
            {
                var data = scraper.Scrape(file);
                var newDirInfo = Directory.CreateDirectory(Path.Combine(indexDirInfo.FullName, data.ToDirectoryPath()));
                file.MoveTo(Path.Combine(newDirInfo.FullName, data.ToFilePath()));
            }
            MovieLog.Info<DirectoryTreeFormatter>(string.Format("Finished Working on folder \"{0}\"", indexDirInfo.Name));
        }
    }
}
