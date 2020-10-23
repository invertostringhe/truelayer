using System;

namespace TrueLayer.WebApi.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException(string message) : base(message)
        {

        }
    }
}
