using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace LiteSchool.Library.Cache
{
    public class MemoryCacheStorage : ICacheStorage
    {
        protected MemoryCache cache;
        public MemoryCacheStorage(MemoryCache cache)
        {
            this.cache = cache;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void Set(string key, object data)
        {
            cache.Add(key, data, DateTimeOffset.MaxValue);
        }

        public void Set(string key, object data, TimeSpan timeSpan)
        {
            cache.Add(key, data, DateTimeOffset.Now.Add(timeSpan));
        }

        public T Get<T>(string storageKey)
        {            
            return (T)cache.Get(storageKey);
        }
        
        public IEnumerable<KeyValuePair<string, object>> GetAllEntries() {
            return cache.ToList();
        }
    }
}
