using Soenneker.Clay.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Clay.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IClayOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<ClayOpenApiClient> Get(CancellationToken cancellationToken = default);
}
