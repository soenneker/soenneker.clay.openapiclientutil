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
    /// <summary>Gets the cached Clay client for the current utility instance.</summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the client.</returns>
    ValueTask<ClayOpenApiClient> Get(CancellationToken cancellationToken = default);
}
