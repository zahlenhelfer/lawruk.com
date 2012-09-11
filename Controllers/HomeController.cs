using System;
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
        public ActionResult Index() { 
            
            var buttons = new List<HomeButton>()
            {
                new HomeButton("About","/about", "http://farm8.staticflickr.com/7273/7503083928_a2974e2861_m.jpg", "About Me"),
                new HomeButton("Metro", "/metro", "/content/i/metro.jpg", "Minutes until the train arrives for Metro stops that I care about"),
                //new HomeButton("Resume", "http://careers.stackoverflow.com/lawruk", "http://www.savingthedream.org/_ui/images/persona-millenial.jpg", "Stackoverflow Resume"),
                new HomeButton("Blog", "/blog", "http://farm7.static.flickr.com/6084/6142564278_5573968475_m.jpg", "Boring Blog Posts"),
                new HomeButton("News", "/news", "http://farm4.staticflickr.com/3456/3239806077_373a9b78a1.jpg", "News"),
                new HomeButton("Weather","/weather", "/content/i/sky.jpg", "Weather for where we typically are"),
                
                //new HomeButton("Rome", "/rome", "http://www.savingthedream.org/_ui/images/persona-millenial.jpg", "Rome site from 2002"),
                new HomeButton("Race Results", "/races/results", "http://farm1.staticflickr.com/246/3263516895_4a921506ec_m.jpg", "Race results")

            };

            if (lawrukmvc.Helpers.Mobile.ShowMobileSite()) {
              buttons.Add(new HomeButton("Videos", "/videos","http://farm3.staticflickr.com/2461/3711078629_c9307e6ef4_m.jpg", "Videos"));
            }
            var homeViewModel = new HomeViewModel();
            homeViewModel.HomeButtons = buttons;
            if (Helpers.Mobile.ShowMobileSite())
            {
                return View("Index.Mobile", homeViewModel);
            }
            else
            {
                return View(homeViewModel);
            }
        }
             
        public ActionResult About() {return View(); }
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
            catch (Exception ex)
            {
                
            }
            return View();
            //return Redirect("/");
        }

        public ActionResult Logout() {
            Session["displayName"] = null;
            Session["identifier"] = null;
            return Redirect("/");
        }

        public ActionResult RunBuild()
        {
            ViewData["Title"] = "Run Build";
            string data = "";
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = "C:\\inetpub\\wwwroot\\svnupdate.bat";
                p.StartInfo.WorkingDirectory = "C:\\inetpub\\wwwroot\\";
                p.StartInfo.RedirectStandardOutput = false;

                //p.Start();
                //p.WaitForExit() ;
                //data = "Well, we thik it built.";
                data = "<a href=\"http://www.lawruk.com/runbuild\">click</a> 0" + Request.ServerVariables["X_FORWARDED_FOR"] + " 1" + Request.ServerVariables["HTTP_X_FORWARDED_FOR"] + " 2" + HttpContext.Request.Headers["X-Forwarded-For"] + " 3:" + Request.Headers["HTTP_X_FORWARDED_FOR"];
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }
            ViewData["Data"] = data;
            return View("TitleData");
        }

    }
}
