using System;
using DbLocalizationProvider.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DbLocalizationProvider
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDbLocalization(this IApplicationBuilder app)
        {
            if(app.ApplicationServices.GetService(typeof(DbLocalizationProviderMarkerService)) == null)
                throw new InvalidOperationException("Use IServiceCollection.AddDbLocalization() method to add localization service.");

            ConfigurationContext.Current.CacheManager = new InMemoryCacheManager(app.ApplicationServices.GetService<IMemoryCache>());

            return app;
        }
    }

    public class DbLocalizationProviderMarkerService { }
}
