using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleNotFoundException : Straddle4xxException
{
    public StraddleNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
