using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Clay.HttpClients.Abstract;
using Soenneker.Clay.OpenApiClientUtil.Abstract;
using Soenneker.Clay.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Clay.OpenApiClientUtil;

/// <inheritdoc cref="IClayOpenApiClientUtil" />
public sealed class ClayOpenApiClientUtil : IClayOpenApiClientUtil
{
    private readonly AsyncSingleton<ClayOpenApiClient> _client;

    public ClayOpenApiClientUtil(IClayOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ClayOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Clay:ApiKey");
            string authHeaderName = configuration["Clay:AuthHeaderName"] ?? "clay-api-key";
            string authHeaderValueTemplate = configuration["Clay:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new ClayOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ClayOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
