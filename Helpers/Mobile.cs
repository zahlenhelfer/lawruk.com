using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawrukmvc.Helpers
{
    public class Mobile
    {   
        public static bool ShowMobileSite()
        {
            var request = HttpContext.Current.Request;
            if (GetMobileQuerystring().HasValue)
            {
                return GetMobileQuerystring().Value;
            }
            else if (GetMobileCookie().HasValue)
            {
                return GetMobileCookie().Value;
            }
            else
            {
                return request.Browser.IsMobileDevice;
            }
        }

        public static bool? GetMobileQuerystring()
        {
            var request = HttpContext.Current.Request;
            bool? value = null;
            string mobile = request.QueryString["mobile"];
            if ((mobile != null))
            {
                value = !(mobile == "false");
            }
            else if (request.Url.Query.Contains("?mobile"))
            {
                value = true;
            }
            if (value.HasValue)
            {
                SetMobileCookie(value.Value);
            }
            return value;
        }

        private static bool? GetMobileCookie()
        {
            var request = HttpContext.Current.Request;
            HttpCookie cookie = request.Cookies["mobile"];
            if ((cookie != null))
            {
                return (cookie.Value == "true");
            }
            return null;
        }

        private static void SetMobileCookie(bool value)
        {
            var cookie = new HttpCookie("mobile");
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Value = value ? "true" : "false";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetMobileDeviceModel()
        {
            try
            {
                return HttpContext.Current.Request.Browser.MobileDeviceModel.ToLower();
            }
            catch { }
            return "";
        }

        public static bool IsIPad()
        {
            return GetMobileDeviceModel() == "ipad";
        }

    }    
}