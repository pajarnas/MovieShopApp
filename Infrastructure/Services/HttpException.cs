using System;
using System.Runtime.Serialization;

namespace Infrastructure.Services
{
    [Serializable]
    internal class HttpException : Exception
    {
        private object unauthorized;
        private string v;

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException(object unauthorized, string v)
        {
            this.unauthorized = unauthorized;
            this.v = v;
        }

        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}