using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MovieTools.IO
{
    public class MovieDirectoryProvider
    {
        public string RootDirpath;

        public MovieDirectoryProvider(string rootPath)
        {
            RootDirpath = rootPath;
        }

        public IEnumerable<DirectoryInfo> GetAllSubMovies() 
        {
            var rootDir = new DirectoryInfo(RootDirpath);
            var list = new List<DirectoryInfo>();
            foreach (var indexDirInfo in rootDir.GetDirectories())
            {
                list.AddRange(GetValidDirectories(indexDirInfo));
            }
            return list;
        }

        private static IEnumerable<DirectoryInfo> GetValidDirectories(DirectoryInfo indexDirInfo)
        {
            return indexDirInfo.GetDirectories().Where(dirInfo => Regex.IsMatch(dirInfo.Name, @".*\ \(\d{4}\)"));
        }
    }
}
