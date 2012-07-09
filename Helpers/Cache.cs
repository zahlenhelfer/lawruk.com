using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Data;
using System.Xml;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;

namespace lawrukmvc.Helpers
{
    public static class Cache
    {
        public static string GetItem(string key)
        {
            object value = HttpRuntime.Cache[key];
            if (value != null)
                return value.ToString();
            else
                return null;
        }

        public static T GetItem<T>(string key)
        {
            object value = HttpRuntime.Cache[key];
            if (value != null)
                return (T)value;
            else
                return default(T);
        }

        public static void InsertItem(string key, object value)
        {
            InsertItem(key, value, DateTime.Now.AddDays(1));
        }

        public static void InsertItem(string key, object value, DateTime absoluteExpiration)
        {
            HttpRuntime.Cache.Insert(key, value, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }    
    }

}