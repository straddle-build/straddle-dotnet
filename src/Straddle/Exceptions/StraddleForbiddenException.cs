using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleForbiddenException : Straddle4xxException
{
    public StraddleForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
