using System;
using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleException : Exception
{
    public StraddleException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected StraddleException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
