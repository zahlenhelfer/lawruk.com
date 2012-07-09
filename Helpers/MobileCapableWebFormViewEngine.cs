//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace lawrukmvc.Helpers
//{

//    public class MobileCapableWebFormViewEngine : WebFormViewEngine
//    {
//        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
//        {
//            ViewEngineResult result = null;
//            var request = controllerContext.HttpContext.Request;
//            // Avoid unnecessary checks if this device isn't suspected to be a mobile device        
//            if (Mobile.ShowMobileSite())
//            {
//                masterName = masterName.ToLower().Replace("site", "").Replace("_Layout", "") + "mobile";
//                masterName = "site.mobile";
//                result = base.FindView(controllerContext, "Mobile/" + viewName, masterName, useCache);
//            }
//            //Fall back to desktop view if no other view has been selected
//            if (result == null || result.View == null)
//            {
//                result = base.FindView(controllerContext, viewName, masterName, useCache);
//            }
//            return result;
//        }
//    }
//}//namespace

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Helpers;

namespace Microsoft.Web.Mvc
{
    // in Global.asax.cs Application_Start you can insert these into the ViewEngine chain like so:
    //
    // ViewEngines.Engines.Insert(0, new MobileCapableRazorViewEngine());
    //
    // or
    //
    // ViewEngines.Engines.Insert(0, new MobileCapableRazorViewEngine("iPhone")
    // {
    //     ContextCondition = (ctx => ctx.Request.UserAgent.IndexOf(
    //         "iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
    // });

    public class MobileCapableWebFormViewEngine : WebFormViewEngine
    {
        public string ViewModifier { get; set; }
        public Func<HttpContextBase, bool> ContextCondition { get; set; }

        public MobileCapableWebFormViewEngine()
            : this("Mobile", context => Mobile.ShowMobileSite())
        {
        }

        public MobileCapableWebFormViewEngine(string viewModifier)
            : this(viewModifier, context => Mobile.ShowMobileSite())
        {
        }

        public MobileCapableWebFormViewEngine(string viewModifier, Func<HttpContextBase, bool> contextCondition)
        {
            this.ViewModifier = viewModifier;
            this.ContextCondition = contextCondition;
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName,
                                                  string masterName, bool useCache)
        {
            return NewFindView(controllerContext, viewName, masterName, useCache, false);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return NewFindView(controllerContext, partialViewName, "", useCache, true);
        }

        private ViewEngineResult NewFindView(ControllerContext controllerContext, string viewName, string masterName,
                                             bool useCache, bool isPartialView)
        {
            if (Mobile.ShowMobileSite())
            {
                masterName = "Site.Mobile";
            }
            if (!ContextCondition(controllerContext.HttpContext))
            {
                return new ViewEngineResult(new string[] { }); // we found nothing and we pretend we looked nowhere
            }

            // Get the name of the controller from the path
            string controller = controllerContext.RouteData.Values["controller"].ToString();
            string area = "";
            try
            {
                area = controllerContext.RouteData.DataTokens["area"].ToString();
            }
            catch
            {
            }

            // Apply the view modifier
            var newViewName = string.Format("{0}.{1}", viewName, ViewModifier);

            // Create the key for caching purposes          
            string keyPath = Path.Combine(area, controller, newViewName);

            string cacheLocation = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, keyPath);

            // Try the cache          
            if (useCache)
            {
                //If using the cache, check to see if the location is cached.                              
                if (!string.IsNullOrWhiteSpace(cacheLocation))
                {
                    if (isPartialView)
                    {
                        return new ViewEngineResult(CreatePartialView(controllerContext, cacheLocation), this);
                    }
                    else
                    {
                        return new ViewEngineResult(CreateView(controllerContext, cacheLocation, masterName), this);
                    }
                }
            }
            string[] locationFormats = string.IsNullOrEmpty(area) ? ViewLocationFormats : AreaViewLocationFormats;

            // for each of the paths defined, format the string and see if that path exists. When found, cache it.          
            foreach (string rootPath in locationFormats)
            {
                string currentPath = string.IsNullOrEmpty(area)
                                            ? string.Format(rootPath, newViewName, controller)
                                            : string.Format(rootPath, newViewName, controller, area);

                if (FileExists(controllerContext, currentPath))
                {
                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, keyPath, currentPath);

                    if (isPartialView)
                    {
                        return new ViewEngineResult(CreatePartialView(controllerContext, currentPath), this);
                    }
                    else
                    {
                        return new ViewEngineResult(CreateView(controllerContext, currentPath, masterName), this);
                    }
                }                
            }
            if (!isPartialView)
            {
                return base.FindView(controllerContext, viewName, masterName, useCache);
            }
            else
            {
                return new ViewEngineResult(new string[] { }); // we found nothing and we pretend we looked nowhere
            }
            
        }
    }
}