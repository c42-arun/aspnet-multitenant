using System;

namespace WebApp
{
    public interface ITCache<T>
    {
        T Get(string cacheName, int cacheTimeoutSeconds, Func<T> func);
    }
}