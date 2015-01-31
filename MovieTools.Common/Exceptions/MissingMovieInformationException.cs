using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieTools.Common.Exceptions
{
    [Serializable]
    public class MissingMovieInformationException : Exception
    {

        public MissingMovieInformationException()
        {
        }

        public MissingMovieInformationException(string message) : base(message)
        {
        }

        public MissingMovieInformationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MissingMovieInformationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
