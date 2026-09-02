using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleUnexpectedStatusCodeException : StraddleApiException
{
    public StraddleUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
