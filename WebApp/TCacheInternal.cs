using System;
using System.Collections.Generic;
using System.Web;
using WebApp.Models;

namespace WebApp
{
    public class TCacheInternal<T> : ITCache<T>
    {
        internal static readonly object Locker = new object();

        public T Get(string cacheName, int cacheTimeoutSeconds, Func<T> func)
        {
            var obj = HttpContext.Current.Cache.Get(cacheName);
            if (obj != null)
            {
                return (T)obj;
            }

            lock (Locker)
            {
                obj = HttpContext.Current.Cache.Get(cacheName);
                if (obj == null)
                {
                    obj = func();

                    HttpContext.Current.Cache.Insert(cacheName, obj, null,
                        DateTime.Now.Add(new TimeSpan(0, 0, cacheTimeoutSeconds)), TimeSpan.Zero);
                }

                return (T)obj;
            }
        }
    }
}