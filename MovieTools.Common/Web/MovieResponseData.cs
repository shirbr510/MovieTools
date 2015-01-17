using System;
using System.Collections.Generic;

namespace MovieTools.Common.Web
{
    public class MovieResponseData
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Rated { get; set; }

        public DateTime Released { get; set; }

        public string Runtime { get; set; }

        public IEnumerable<string> Genre { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        public IEnumerable<string> Actors { get; set; }

        public string Plot { get; set; }

        public IEnumerable<string> Language { get; set; }

        public string Country { get; set; }

        public string Awards { get; set; }

        public Uri Poster { get; set; }

        public short Metascore { get; set; }

        public float imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
