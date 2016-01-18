using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeoutCache
{
    public class TimeoutCacheMissException : Exception
    {
        public TimeoutCacheMissException()
        { }

        public TimeoutCacheMissException(string message)
            : base(message)
        { }
    }

    public class TimeoutCache<K, V>
    {
        class Value
        {
            public DateTime creationTime;
            public V value;

            public Value(DateTime creationTime, V value)
            {
                this.creationTime = creationTime;
                this.value = value;
            }
        }

        private TimeSpan _invalidateTimeout;
        private Dictionary<K, Value> _cache;
        
        public TimeoutCache(TimeSpan invalidateTimeout)
        {
            _invalidateTimeout = invalidateTimeout;
            _cache = new Dictionary<K, Value>();
        }

        public V this[K key]
        {
            get
            {
                if (!_cache.ContainsKey(key))
                    throw new TimeoutCacheMissException();

                Value v = _cache[key];

                if (v.creationTime.Add(_invalidateTimeout) < DateTime.Now)
                {
                    _cache.Remove(key);
                    throw new TimeoutCacheMissException();
                }

                // cache hit
                return v.value;
            }
            set
            {
                _cache.Add(key, new Value(DateTime.Now, value));
            }
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public void Invalidate(K key)
        {
            _cache.Remove(key);
        }
    }
}
