
using System;

namespace InstagramGot.Exceptions
{
    public class InstagramAPICallException : Exception
    {
        public InstagramAPICallException(string message) : base(message)
        {
        }
    }
}