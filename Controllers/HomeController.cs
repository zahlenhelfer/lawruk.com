﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;
using System.Xml;
using System.Xml.Linq;

namespace lawrukmvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index() 
        {            
            var homeViewModel = new HomeViewModel();
            homeViewModel.HomeButtons = GetHomeButtonsList();
            if (Helpers.Mobile.ShowMobileSite())
            {
                return View("Index.Mobile", homeViewModel);
            }
            else
            {
                return View(homeViewModel);
            }
        }

        private List<HomeButton> GetHomeButtonsList()
        {
            var buttons = new List<HomeButton>()
            {
                new HomeButton("About","/about", "http://farm8.staticflickr.com/7273/7503083928_a2974e2861_m.jpg", "About Me"),
                new HomeButton("Metro", "/metro", "/content/i/metro.jpg", "Minutes until the train arrives for Metro stops that I care about"),               
                new HomeButton("Blog", "/blog", "http://farm7.static.flickr.com/6084/6142564278_5573968475_m.jpg", "Boring Blog Posts"),
                new HomeButton("News", "/news", "http://farm4.staticflickr.com/3456/3239806077_373a9b78a1.jpg", "News"),
                new HomeButton("Weather","/weather", "/content/i/sky.jpg", "Weather for where we typically are"),                
                new HomeButton("Race Results", "/races/results", "http://farm1.staticflickr.com/246/3263516895_4a921506ec_m.jpg", "Race results")
            };

            if (lawrukmvc.Helpers.Mobile.ShowMobileSite())
            {
                buttons.Add(new HomeButton("Videos", "/videos", "http://farm3.staticflickr.com/2461/3711078629_c9307e6ef4_m.jpg", "Videos"));
            }
            return buttons;
        }
             
        public ActionResult About() {return View(); }
        public ActionResult Error() { throw new Exception("test error"); }
        public ActionResult News() { return View(); }
        public ActionResult Weather() { return View(); }
        public ActionResult NotFound() { return View("404"); }
        public ActionResult Calendar() { return View(); }
        public ActionResult Running() { return View(); }
        public ActionResult Rpx()
        {
            try
            {
                var token = Request.Form["token"];
                var rpx = new Helpers.Rpx("a00d4647b32434096f453a4a03358b12f8235eb1", "https://rpxnow.com");
                var authInfo = rpx.AuthInfo(token);
                var doc = XDocument.Load(new XmlNodeReader(authInfo));
                Session["displayName"] = doc.Root.Descendants("displayName").First().Value;
                Session["identifier"] = doc.Root.Descendants("identifier").First().Value;
                Session["verifiedEmail"] = doc.Root.Descendants("verifiedEmail").First().Value;
                Session["preferredUsername"] = doc.Root.Descendants("preferredUsername").First().Value;
                Session["rpxXml"] = authInfo.OuterXml;
            }
            catch { }
            return View();           
        }

        public ActionResult Logout() {
            Session["displayName"] = null;
            Session["identifier"] = null;
            return Redirect("/");
        }      

    }
}
