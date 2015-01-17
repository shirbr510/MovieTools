using System;
using System.IO;
using MovieTools.Common.Extensions;
using NUnit.Framework;

namespace MovieTools.Tests
{
    [TestFixture]
    public class DirecotryExtensionsTests
    {
        [Test]
        public void DirectoryCount()
        {
            var dirInfo = new DirectoryInfo(@"C:\Users\Shir\Desktop\Movies");
            var childCount = dirInfo.DirectoryCount();
            Console.WriteLine(childCount);
            var subtreeCount = dirInfo.DirectoryCount(true);
            Console.WriteLine(subtreeCount);
            Assert.That(subtreeCount,Is.GreaterThanOrEqualTo(childCount));
        }

        [Test]
        public void FileCount()
        {
            var dirInfo = new DirectoryInfo(@"C:\Users\Shir\Desktop\Movies");
            var childCount = dirInfo.FileCount();
            Console.WriteLine(childCount);
            var subtreeCount = dirInfo.FileCount(true);
            Console.WriteLine(subtreeCount);
            Assert.That(subtreeCount, Is.GreaterThanOrEqualTo(childCount));
        }

        [Test]
        public void ItemCount()
        {
            var dirInfo = new DirectoryInfo(@"C:\Users\Shir\Desktop\Movies");
            var childCount = dirInfo.ItemCount();
            Console.WriteLine(childCount);
            var subtreeCount = dirInfo.ItemCount(true);
            Console.WriteLine(subtreeCount);
            Assert.That(subtreeCount, Is.GreaterThanOrEqualTo(childCount));
        }
    }
}
