using System.Net.Http;

namespace Straddle.Exceptions;

public class Straddle5xxException : StraddleApiException
{
    public Straddle5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
