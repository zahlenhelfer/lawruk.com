﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Configuration;
using EngageNet;
using EngageNet.Mvc;

namespace lawrukmvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("test/{*pathInfo}");
            routes.MapRoute("Photos", "photos", new { controller = "Photos", action = "Index", baseUrl = "/photos", consistentTag = "lawruk", otherTags = "jordan" });
            
            routes.MapRoute("Photo Tags", "photos/{otherTags}", new { controller = "Photos", action = "Index", baseUrl = "/photos", consistentTag = "lawruk", otherTags = "jordan" });
            //routes.MapRoute("Weather", "weather/{city}", new { controller = "Home", action = "Weather", city = "" });
            routes.MapRoute("Blog", "blog", new { controller = "Blog", action = "Index" });
            routes.MapRoute("BlogEdit", "blog/edit/{tag}", new { controller = "Blog", action = "Edit", tag = "" });
            routes.MapRoute("BlogDetail", "blog/{id}/{tag}", new { controller = "Blog", action = "Detail", id = 0 });

            routes.MapRoute("CalendarEdit", "calendar/edit/{tag}", new { controller = "Calendar", action = "Edit", tag = "" });
            routes.MapRoute("Calendar", "calendar/{tag}", new { controller = "Calendar", action = "Index", tag = "" });
            routes.MapRoute("Videos", "videos", new { controller = "Video", action = "Index" });
            routes.MapRoute("VideoEdit", "videos/edit/{tag}", new { controller = "Video", action = "Edit", tag = "" });
            routes.MapRoute("VideoDetail", "videos/{id}/{tag}", new { controller = "Video", action = "Detail", id = 0 });

            routes.MapRoute("Tags", "tags", new { controller = "Tag", action = "Index" });
            routes.MapRoute("TagEdit", "tags/edit/{tag}", new { controller = "Tag", action = "Edit", tag = "" });
            routes.MapRoute("TagDetail", "tags/{id}/{tag}", new { controller = "Tag", action = "Detail", id = 0 });

            routes.MapRoute("Data", "data/{tag}", new { controller = "Data", action = "Index", tag = "default" });
            routes.MapRoute("Energy", "energy/{tag}", new { controller = "Energy", action = "Index", tag = "" });
            routes.MapRoute("Famous Developers", "famousdevs/{action}/{p1}/{p2}", new { controller = "FamousDeveloper", action = "Index", p1 = "", p2 = "" });
            routes.MapRoute("Marc", "marc/{tag}", new { controller = "Marc", action = "Index", tag = "" });
            routes.MapRoute("Metro", "metro/{tag}", new { controller = "Metro", action = "Index", tag = "" });
            routes.MapRoute("RachelEmmettPhotos", "rachelemmett/photos/{otherTags}", new { controller = "Photos", action = "Index", baseUrl = "/rachelemmett/photos", consistentTag = "rachelemmett", otherTags = "wedding" });
            routes.MapRoute("RachelEmmett", "rachelemmett/{page}", new { controller = "RachelEmmett", action = "Page", page = "Index" });
            routes.MapRoute("News", "news/{tag}", new { controller = "News", action = "Index", tag = "" });
            routes.MapRoute("RaceResultsEdit", "races/edit/{tag}", new { controller = "Races", action = "Edit", tag = "" });
            routes.MapRoute("RaceResults", "races/results", new { controller = "Races", action = "Results" });
            routes.MapRoute("Races", "races/{urlTitle}/{year}", new { controller = "Races", action = "Race", urlTitle = "", year = "" });
            routes.MapRoute("Olympics", "olympics/{tag}", new { controller = "Olympics", action = "Index", tag = "" });
            
            
            routes.MapRoute("Account", "account/{action}/{filter}", new { controller = "Account", action = "Index", filter = "" });
            routes.MapRoute(
                "Default", // Route name
                "{action}/{filter}", // URL with parameters
                new { controller = "Home", action = "Index", filter = "" } // Parameter defaults
            );



        }

        protected void Application_Start()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine());
            //ViewEngines.Engines.RemoveAt(0);
            //ViewEngines.Engines.Add(new Microsoft.Web.Mvc.MobileCapableRazorViewEngine());
            //ViewEngines.Engines.Add(new Microsoft.Web.Mvc.MobileCapableWebFormViewEngine());
            StartEngage();
        }

        protected void StartEngage()
        {
            //TODO: you should move the setting of the static EngageProvider.Settings to your global.asax or other setup code
            if (EngageProvider.Settings == null)
            {
                EngageProvider.ApplicationDomain = "lawruk.rpxnow.com"; //TODO: set your site's Application Domain
                EngageProvider.Settings = new EngageNetSettings(WebConfigurationManager.AppSettings["RPXKey"]); //TODO: set your API key
            }

           
        }


        //protected void Application_Start(object sender, EventArgs e)
        //{
        //// Enable the mobile detection provider.

        //HttpCapabilitiesBase.BrowserCapabilitiesProvider =
        //new FiftyOne.Foundation.Mobile.Detection.MobileCapabilitiesProvider();
        //}
        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //// Process redirection logic.
        //FiftyOne.Foundation.Mobile.Redirection.RedirectModule.OnPostAcquireRequestState(sender, e);
        //}


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var requestUrl = Request.Url.ToString().ToLower();
            if (requestUrl.Contains(".aspx"))
            {
                requestUrl = requestUrl.Replace("default", "");//homepage
                requestUrl = requestUrl.Replace(".aspx", "");
                requestUrl = requestUrl.Replace("raceresults", "races/results");
                Context.Response.StatusCode = 301;
                Context.Response.Redirect(requestUrl + "?=redirect");
            }
        }
    }
}