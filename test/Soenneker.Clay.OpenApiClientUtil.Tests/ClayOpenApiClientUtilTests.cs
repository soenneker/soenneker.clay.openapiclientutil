using Soenneker.Clay.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Clay.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ClayOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IClayOpenApiClientUtil _openapiclientutil;

    public ClayOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IClayOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
