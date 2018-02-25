using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSchool.Library.Cache
{
    public class NullCacheStorage : ICacheStorage
    {        
        public void Remove(string key)
        {
        }

        public void Set(string key, object data)
        {
        }

        public void Set(string key, object data, TimeSpan timeSpan)
        {
        }

        public T Get<T>(string storageKey)
        {
            return default(T);
        }

        public IEnumerable<KeyValuePair<string, object>> GetAllEntries()
        {
            return null;
        }
    }
}
