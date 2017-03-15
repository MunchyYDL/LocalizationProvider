using System;
using DbLocalizationProvider.Commands;
using DbLocalizationProvider.Queries;
using DbLocalizationProvider.Sync;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DbLocalizationProvider
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddDbLocalization(this IMvcBuilder builder, Action<ConfigurationContext> configCallback)
        {
            // setup default implementations
            ConfigurationContext.Current.TypeFactory.ForQuery<AvailableLanguages.Query>().SetHandler<AvailableLanguages.Handler>();
            ConfigurationContext.Current.TypeFactory.ForQuery<GetTranslation.Query>().SetHandler<GetTranslation.Handler>();
            ConfigurationContext.Current.TypeFactory.ForQuery<GetAllResources.Query>().SetHandler<GetAllResources.Handler>();
            ConfigurationContext.Current.TypeFactory.ForQuery<GetAllTranslations.Query>().SetHandler<GetAllTranslations.Handler>();

            ConfigurationContext.Current.TypeFactory.ForCommand<CreateNewResource.Command>().SetHandler<CreateNewResource.Handler>();
            ConfigurationContext.Current.TypeFactory.ForCommand<DeleteResource.Command>().SetHandler<DeleteResource.Handler>();
            ConfigurationContext.Current.TypeFactory.ForCommand<CreateOrUpdateTranslation.Command>().SetHandler<CreateOrUpdateTranslation.Handler>();
            ConfigurationContext.Current.TypeFactory.ForCommand<ClearCache.Command>().SetHandler<ClearCache.Handler>();

            if(configCallback != null)
                ConfigurationContext.Setup(builder, configCallback);

            var synchronizer = new ResourceSynchronizer();
            synchronizer.DiscoverAndRegister();

            builder.Services.TryAddSingleton<DbLocalizationProviderMarkerService, DbLocalizationProviderMarkerService>();

            return builder;
        }
    }
}
