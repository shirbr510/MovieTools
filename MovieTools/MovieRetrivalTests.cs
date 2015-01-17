using MovieTools.GenreSorter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTools.Tests
{
    [TestFixture]
    public class MovieRetrivalTests
    {
        [Test]
        public void GetAllMovies()
        {
            const string rootDirPath = @"F:\Movies\A - Z";
            var movieDirectoryProvider = new MovieDirectoryProvider(rootDirPath);
            foreach(var dirInfo in movieDirectoryProvider.GetAllSubMovies())
            {
                Console.WriteLine(dirInfo.Name);
            }
        }
    }
}
