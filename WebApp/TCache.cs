using System;

namespace WebApp
{
    public class TCache<T>
    {
        public T Get(string cacheName, int cacheTimeoutSeconds, Func<T> func)
        {
            return new TCacheInternal<T>().Get(cacheName, cacheTimeoutSeconds, func);
        }
    }
}