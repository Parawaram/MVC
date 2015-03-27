using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace DCMS.BusinessLogic.Cache
{
    public class MemoryCacheManager
    {
        private readonly int _defaultCacheInterval = 30; // min
        private readonly int _longCacheInterval = 24 * 60; // 24h
        private readonly int _veryLongCacheInterval = 24 * 60 * 30;

        private int TimeFromConfig
        {
            get
            {
                int time;
                if (!int.TryParse(ConfigurationSettings.AppSettings["CacheTime"], out time))
                {
                    return _longCacheInterval;
                }
                return time;
            }
        }

        public MemoryCacheManager()
        {
        }

        public MemoryCacheManager(int defaultCacheInterval, int longCacheInterval)
        {
            _defaultCacheInterval = defaultCacheInterval;
            _longCacheInterval = longCacheInterval;
        }

        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// Adds the specified key and object to the cache with a long cache time.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="dependency"></param>
        public void Set(string key, object data, SqlDependency dependency)
        {
            Set(key, data, TimeFromConfig, dependency);
        }

        public void Set(string key, object data)
        {
            Set(key, data, TimeFromConfig);
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        /// <param name="dependency"></param>
        public void Set(string key, object data, int cacheTime, SqlDependency dependency)
        {
            if (data == null)
            {
                return;
            }

            var sqlChangeMonitor = new SqlChangeMonitor(dependency);

            var policy = new CacheItemPolicy();
            policy.ChangeMonitors.Add(sqlChangeMonitor);
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Set(new CacheItem(key, data), policy);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }


        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
            {
                if (regex.IsMatch(item.Key))
                {
                    keysToRemove.Add(item.Key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
