using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using CacheCow.Common;
using CacheCow.Server;
using CacheCow.Server.CacheControlPolicy;
using CacheCow.Server.EntityTagStore.SqlServer;
using Spa.Web.Helpers;

namespace Spa.Web.Infrastructure
{
    public static class CachingFactory
    {
        public static CachingHandler GetCachingHandlerByCacheStore(CachingStores cacheStore, HttpConfiguration config, string conString)
        {
            CachingHandler cachingHandler;
            switch (cacheStore)
            {
                case CachingStores.SqlCacheStore:
                    cachingHandler = WithSqlCacheStore(config, conString);
                    break;

                //TODO implement MemcachedStore

                //TODO implement MongoDbCacheStore

                default:
                    cachingHandler = WithMemoryCacheStore(config);
                    break;
            }
            return cachingHandler;
        }

        //TODO You need to execute script.sql which you can find in the YourProject\packages\CacheCow.Server.EntityTagStore.SqlServer\scripts folder
        private static CachingHandler WithSqlCacheStore(HttpConfiguration config, string conString)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[conString].ConnectionString;
            var eTagStore = new SqlServerEntityTagStore(connectionString);
            var cacheHandler = new CachingHandler(config, eTagStore)
            {
                CacheControlHeaderProvider = new AttributeBasedCacheControlPolicy(new CacheControlHeaderValue()
                {
                    NoStore = true
                }).GetCacheControl
            };

            return cacheHandler;
        }

        private static CachingHandler WithMemoryCacheStore(HttpConfiguration config)
        {
            var eTagStore = new InMemoryEntityTagStore();
            var cacheHandler = new CachingHandler(config, eTagStore);
            return cacheHandler;
        }
    }
}