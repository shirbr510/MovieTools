using System;
using System.Collections.Generic;
using System.Globalization;
using MovieTools.Common.Web;
using Newtonsoft.Json.Linq;

namespace MovieTools.Converters
{
    public class MovieConverter
    {
        private readonly Dictionary<Type, Func<string,object>> _dictionary;

        public MovieConverter()
        {
            _dictionary = new Dictionary<Type, Func<string,object>>
            {
                {typeof(IEnumerable<string>),value=>value.Split(',')}
            };
        }

        public MovieResponseData FromJson(JObject jObject)
        {
            var movie = Activator.CreateInstance<MovieResponseData>();
            
            foreach (var property in typeof(MovieResponseData).GetProperties())
            {
                var jValue = (JValue) jObject[property.Name];
                if (jValue != null && jValue.ToString(CultureInfo.InvariantCulture)!= @"N/A")
                {
                    var propType = property.PropertyType;
                    var objValue = _dictionary.ContainsKey(propType)
                        ? _dictionary[propType].Invoke(jValue.ToString(CultureInfo.InvariantCulture))
                        : jValue.ToObject(propType);
                    property.SetValue(movie,objValue);
                }
            }
            return movie;
        }
    }
}
