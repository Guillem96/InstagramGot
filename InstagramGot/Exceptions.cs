
using System;

namespace InstagramGot.Exceptions
{
    /// <summary>
    /// Api call exception
    /// </summary>
    public class InstagramAPICallException : Exception
    {
        public InstagramAPICallException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Non authorizated exception
    /// </summary>
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message)
        {
        }
    }
}