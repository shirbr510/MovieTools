using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using MovieTools.Common.Exceptions;

namespace MovieTools.Common.Web
{
    public struct MovieRequestData
    {
        public string ImdbId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public static MovieRequestData Parse(string movie)
        {
            if (Regex.IsMatch(movie, @"tt(\d{8})"))
            {
                return new MovieRequestData {ImdbId = movie};
            }
            var match = Regex.Match(movie, @"(?<Name>.*)\ \((?<Year>\d{4})\)");
            if (match.Success)
            {
                return new MovieRequestData
                {
                    Title = match.Groups["Name"].Value,
                    Year = int.Parse(match.Groups["Year"].Value)
                };
            }
            throw new FormatException("The string is not in the correct format.");
        }
        
        public WebRequest ToWebRequest()
        {
            const string omdbUri = @"http://www.omdbapi.com/?r=json&type=movie";
            var stringBuilder = new StringBuilder(omdbUri);
            stringBuilder.Append(GetQueryBase());
            if (Year != 0)
            {
                stringBuilder.AppendFormat("&y={0}", Year);
            }
            return WebRequest.CreateHttp(stringBuilder.ToString());
        }

        private string GetQueryBase()
        {
            if (!string.IsNullOrWhiteSpace(ImdbId))
            {
                return string.Format("&i={0}", ImdbId);
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                return string.Format("&t={0}", Title);
            }
            throw new MissingMovieInformationException("Movie is Lacking Information. Please Provide an Id or a movie title.");
        }
    }
}
