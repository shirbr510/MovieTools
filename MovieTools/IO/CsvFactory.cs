using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MovieTools.Common.Web;
using MovieTools.Web;

namespace MovieTools.IO
{
    public static class CsvFactory
    {
        private static readonly OmdbDataProvider OmdbDataProvider = new OmdbDataProvider();

        public static void Create(string rootDirectory,string outputPath)
        {
            var movieProvider = new MovieDirectoryProvider(rootDirectory);
            var allSubMovies = movieProvider.GetAllSubMovies();
            var movieRequests=allSubMovies.Select(dir => MovieRequestData.Parse(dir.Name));
            var movieResponses = movieRequests.Select(request => OmdbDataProvider.GetMovieData(request));
            using (var file = File.Create(outputPath))
            {
                using (var streamWriter = new StreamWriter(file))
                {
                    foreach (
                        var line in
                            movieResponses.Select(
                                responseData =>
                                    String.Format(@"{0},{1},{2},{3}", Regex.Replace(responseData.Title,",",""), responseData.Year,
                                        Regex.Replace(responseData.Plot??"",",",";"), string.Join(";", responseData.Genre))))
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }

    }
}
