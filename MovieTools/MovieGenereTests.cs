using System;
using MovieTools.GenreLister.Factories;
using NUnit.Framework;

namespace MovieTools.Tests
{
    [TestFixture]
    public class MovieGenereTests
    {
        [Test]
        public void GenerateCsv()
        {
            const string rootDirectory = @"E:\Video\Movies\A - Z";
            var outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MovieCsv.csv";
            CsvFactory.Create(rootDirectory, outputPath);
        }
    }
}
