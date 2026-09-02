using System.Net.Http;

namespace Straddle.Exceptions;

public class StraddleUnprocessableEntityException : Straddle4xxException
{
    public StraddleUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
