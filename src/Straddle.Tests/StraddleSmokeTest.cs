using Xunit;

namespace Straddle.Tests;

public sealed class StraddleSmokeTest
{
    [Fact]
    public void ConstructsClient()
    {
        Assert.NotNull(new StraddleClient());
    }
}
