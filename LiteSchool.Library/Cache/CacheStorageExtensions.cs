using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Library.Cache
{
    public static class CacheStorageExtensions
    {
        public static T Get<T>(this ICacheStorage cache, string key, Func<T> acquire)
        {
            T result = cache.Get<T>(key);
            if (result == null)
            {
                result = acquire();
                if(result != null)
                    cache.Set(key, result);
            }
            return result;
        }
    }
}
