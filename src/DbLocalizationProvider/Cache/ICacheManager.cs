using System.Collections.Generic;

namespace DbLocalizationProvider.Cache
{
    public interface ICacheManager
    {
        void Insert(string key, object value);

        object Get(string key);

        void Remove(string key);

        IEnumerable<string> Keys { get; }
    }
}
