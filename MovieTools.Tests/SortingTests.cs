using MovieTools.Scraping;
using NUnit.Framework;

namespace MovieTools.Tests
{
    [TestFixture]
    class SortingTests
    {
        [Test]
        public void SortAll()
        {
            var directoryTreeFormatter = new DirectoryTreeFormatter(@"E:\Video\Movies\A - Z");
            directoryTreeFormatter.Folderize();
        }
    }
}
