using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieTools.Common.Data;

namespace MovieTools.Common.Extensions
{
    public static class DirectoryInfoExtensions
    {

        public static IEnumerable<FileInfo> GetSpecificMovieTypes(this DirectoryInfo directoryInfo,params string[] extensions)
        {
            var validExtensions=GetValidExtensions(extensions);
            return directoryInfo.GetFiles().Where(fileInfo => validExtensions.Contains(fileInfo.Extension.ToLowerInvariant()));
        }

        private static IEnumerable<string> GetValidExtensions(params string[] extensions)
        {
            foreach (
                var extension in
                    extensions.Where(extension => !string.IsNullOrWhiteSpace(extension))
                        .Select(extension => extension.ToLowerInvariant()))
            {
                if (extension[0] != '.')
                {
                    yield return '.' + extension;
                }
                else
                {
                    yield return extension;
                }
            }
        }

        #region Counters

        public static int FileCount(this DirectoryInfo directoryInfo, bool fullSubTree = false)
        {
            var count = directoryInfo.GetFiles().Count();
            if (fullSubTree)
            {
                count += directoryInfo.GetDirectories().Sum(subDirectory => subDirectory.FileCount(true));
            }
            return count;
        }

        public static int DirectoryCount(this DirectoryInfo directoryInfo, bool fullSubTree = false)
        {
            var count = directoryInfo.GetDirectories().Count();
            if (fullSubTree)
            {
                count += directoryInfo.GetDirectories().Sum(subDirectory => subDirectory.DirectoryCount(true));
            }
            return count;
        }

        public static int ItemCount(this DirectoryInfo directoryInfo, bool fullSubTree = false)
        {
            var filesCount = directoryInfo.GetFiles().Count();
            var directoriesCount = directoryInfo.GetDirectories().Count();
            var count = filesCount + directoriesCount;
            if (fullSubTree)
            {
                count += directoryInfo.GetDirectories().Sum(subDirectory => subDirectory.ItemCount(true));
            }
            return count;
        }

        #endregion

    }
}
