using System;

namespace MovieTools.Common.Exceptions
{
    [Serializable]
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException()
        {
        }

        public MovieNotFoundException(string message) : base(message)
        {
        }

        public MovieNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MovieNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
