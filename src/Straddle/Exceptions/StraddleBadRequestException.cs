using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleBadRequestException : Straddle4xxException
{
    public StraddleBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
