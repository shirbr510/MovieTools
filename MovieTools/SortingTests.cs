using MovieTools.Scraper;
using NUnit.Framework;

namespace MovieTools.Tests
{
    [TestFixture]
    class SortingTests
    {
        [Test]
        public void SortAll()
        {
            var directoryTreeFormatter = new DirectoryTreeFormatter(@"F:\Movies\A - Z");
            directoryTreeFormatter.Folderize();
        }
    }
}
