using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Clay.HttpClients.Registrars;
using Soenneker.Clay.OpenApiClientUtil.Abstract;

namespace Soenneker.Clay.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ClayOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ClayOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddClayOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddClayOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IClayOpenApiClientUtil, ClayOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ClayOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddClayOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddClayOpenApiHttpClientAsSingleton()
                .TryAddScoped<IClayOpenApiClientUtil, ClayOpenApiClientUtil>();

        return services;
    }
}
