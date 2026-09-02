using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleUnauthorizedException : Straddle4xxException
{
    public StraddleUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
