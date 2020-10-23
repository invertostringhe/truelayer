using System;
using System.Net;

namespace TrueLayer.WebApi.Exceptions
{
    public class APIErrorException : Exception
    {
        public HttpStatusCode ErrorCode { get; private set; }

        public APIErrorException(HttpStatusCode errorCode) : base($"An API returned a HTTP Error: {errorCode}.")
        {
            ErrorCode = errorCode;
        }

        public APIErrorException(HttpStatusCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
