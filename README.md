[![](https://img.shields.io/nuget/v/soenneker.clay.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.clay.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.clay.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.clay.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.clay.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.clay.openapiclientutil/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.clay.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.clay.openapiclientutil/)

# Soenneker.Clay.OpenApiClientUtil

Provides a lazily created Clay client backed by the configured cached `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Clay.OpenApiClientUtil
```

## Configuration

```json
{
  "Clay": {
    "ApiKey": "your-api-key"
  }
}
```

The key is sent in Clay's `clay-api-key` header. Compatible gateways can override the base URL, header name, and value template with `Clay:ClientBaseUrl`, `Clay:AuthHeaderName`, and `Clay:AuthHeaderValueTemplate`.

## Registration and usage

```csharp
using Soenneker.Clay.OpenApiClient;
using Soenneker.Clay.OpenApiClient.Models;
using Soenneker.Clay.OpenApiClientUtil.Abstract;
using Soenneker.Clay.OpenApiClientUtil.Registrars;

services.AddClayOpenApiClientUtilAsScoped();

public sealed class ClayService(IClayOpenApiClientUtil clientUtil)
{
    public async Task<GetPublicApiMe200Response?> GetCurrentAccount(CancellationToken cancellationToken)
    {
        ClayOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Me.GetAsync(cancellationToken: cancellationToken);
    }
}
```

The scoped utility releases its own generated client holder with the consuming scope. Its registered HTTP provider is singleton and remains available until application shutdown. Singleton utility registration is also available.
