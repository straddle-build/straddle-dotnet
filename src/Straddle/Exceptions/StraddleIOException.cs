using System;
using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleIOException : StraddleException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public StraddleIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
