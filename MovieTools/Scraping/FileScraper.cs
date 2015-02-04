using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MovieTools.Common.Data;

namespace MovieTools.Scraping
{
    public class FileScraper
    {
        public MovieFileData Scrape(FileInfo file)
        {
            return Scrape(file.Name);
        }

        public MovieFileData Scrape(string fileName)
        {
            var data = new MovieFileData();
            var regMatch = Regex.Match(fileName,
                @"^(?<MovieName>.+)\.(?<Year>\d{4})\.(([^\.]*)\.)*(?<Resolution>\d{3,4}p)\.(([^\.]*)\.)*(?<Extension>[^\.]*)$");
            if (regMatch.Success)
            {
                data.Name = PaddingRemover(regMatch.Groups["MovieName"].Value);
                int year;
                data.Year = int.TryParse(regMatch.Groups["Year"].Value, out year) ? year : -1;
                data.Resolution = regMatch.Groups["Resolution"].Value;
                data.Extension = regMatch.Groups["Extension"].Value;
            }
            else
            {
                regMatch = Regex.Match(fileName,
                    @"^(?<MovieName>.+)\.(([^\.]*)\.)*(?<Extension>[^\.]*)$");
                data.Name = PaddingRemover(regMatch.Groups["MovieName"].Value);
                data.Year = -1;
                data.Resolution = "";
                data.Extension = regMatch.Groups["Extension"].Value;
            }
            return data;
        }

        private static string PaddingRemover(string value)
        {
            var str =
                FileConsts.PaddingChars.Select(
                    paddingChar => Regex.Escape(paddingChar.ToString(CultureInfo.InvariantCulture)))
                    .Aggregate(value, (current, escapeCharacter) => Regex.Replace(current, escapeCharacter, " "));
            return string.Join(" ", str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
