using MovieTools.Common.Exceptions;
using MovieTools.Common.Extensions;
using MovieTools.Common.Web;
using MovieTools.Converters;
using Newtonsoft.Json.Linq;

namespace MovieTools.Web
{
    public class OmdbDataProvider
    {
        private readonly MovieConverter _converter;

        public OmdbDataProvider()
        {
            _converter=new MovieConverter();
        }

        public MovieResponseData GetMovieData(MovieRequestData movieRequest)
        {
            var webRequest = movieRequest.ToWebRequest();
            using (var webResponse = webRequest.GetResponse())
            {
                var rawJson = webResponse.GetRawResponse();
                var jObject=JObject.Parse(rawJson);
                if (jObject["Response"].ToObject<bool>())
                {
                    return _converter.FromJson(jObject);
                }
                throw new MovieNotFoundException(string.Format("Error: {0} Movie: {1}", jObject["Error"],
                    movieRequest.Title));
            }
        }
    }
}
