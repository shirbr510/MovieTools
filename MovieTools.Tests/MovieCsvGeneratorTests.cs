using System;
using MovieTools.IO;
using NUnit.Framework;

namespace MovieTools.Tests
{
    [TestFixture]
    public class MovieCsvGeneratorTests
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
