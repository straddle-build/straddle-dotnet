using System;

namespace Straddle.Exceptions;

public class StraddleInvalidDataException : StraddleException
{
    public StraddleInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
