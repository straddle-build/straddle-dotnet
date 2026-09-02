using System.Net;
using Straddle.Exceptions;
using Xunit;

namespace Straddle.Tests;

public sealed class StraddleGeneratedBehaviorTest
{
    [Fact]
    public void ExceptionFactoryClassifiesStatusCodes()
    {
        var exception = StraddleExceptionFactory.CreateApiException(
            HttpStatusCode.BadRequest,
            "{\"message\":\"bad request\"}"
        );

        Assert.IsType<StraddleBadRequestException>(exception);
        Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        Assert.Contains("bad request", exception.Message);
    }

    [Fact]
    public void ModelsPreserveWireNames()
    {
        var model = new global::Straddle.Models.CapabilityRequests.Businesses { Enable = true };

        Assert.Contains("enable", model.RawData.Keys);
    }
}
