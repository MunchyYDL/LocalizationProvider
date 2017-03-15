using DbLocalizationProvider.Cache;

namespace DbLocalizationProvider.Commands
{
    public class ClearCache
    {
        public class Command : ICommand { }

        public class Handler : ICommandHandler<Command>
        {
            private readonly ICacheManager _cache;

            public Handler(ICacheManager cache)
            {
                _cache = cache;
            }

            public void Execute(Command command)
            {
                foreach (var cacheKey in _cache.Keys)
                {
                    ConfigurationContext.Current.CacheManager.Remove(cacheKey);
                }
            }
        }
    }
}
