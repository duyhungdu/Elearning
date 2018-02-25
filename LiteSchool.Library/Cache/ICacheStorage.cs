using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteSchool.Library.Cache
{
    public interface ICacheStorage
    {
        void Remove(string key);
        void Set(string key, object data);
        void Set(string key, object data, TimeSpan timeSpan);
        T Get<T>(string storageKey);

        IEnumerable<KeyValuePair<string, object>> GetAllEntries();
    }
}
