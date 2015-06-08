using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spa.Web.Helpers
{
    public enum CachingStores
    {
        // The SQL cache store
        SqlCacheStore = 0,

        //The memory cache store
        MemoryCacheStore = 1,

        //The memcached cachr store
        MemcachedStore = 2,

        //The mongo database cache store
        MongoDbCacheStore = 3
    }
}