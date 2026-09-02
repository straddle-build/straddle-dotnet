using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleRateLimitException : Straddle4xxException
{
    public StraddleRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
