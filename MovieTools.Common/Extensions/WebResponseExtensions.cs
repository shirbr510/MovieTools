using System.IO;
using System.Net;

namespace MovieTools.Common.Extensions
{
    public static class WebResponseExtensions
    {
        public static string GetRawResponse(this WebResponse webResponse)
        {
            using (var stream = webResponse.GetResponseStream())
            {
                if (stream == null) return string.Empty;
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
