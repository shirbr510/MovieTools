using System.IO;
using System.Linq;

namespace MovieTools.Common.Extensions
{
    public static class DirectoryInfoExtensions
    {
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
    }
}
