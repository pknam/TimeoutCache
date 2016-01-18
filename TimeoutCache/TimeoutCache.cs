using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeoutCache
{
    class TimeoutCache<K, V>
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
                Value v = _cache[key];
                
                // cache miss
                if(v.creationTime.Add(_invalidateTimeout) < DateTime.Now)
                    return default(V);

                // cache hit
                return v.value;
            }
            set
            {
                _cache.Add(key, new Value(DateTime.Now, value));
            }
        }
    }
}
