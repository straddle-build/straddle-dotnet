using System.Net.Http;

namespace Straddle.Exceptions;

public class Straddle4xxException : StraddleApiException
{
    public Straddle4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
