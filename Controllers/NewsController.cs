using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;

namespace lawrukmvc.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index(string tag)
        {
            tag = tag.ToLower();
            var rssFeeds = new List<TagTitleUrl>()
            {             
             { new TagTitleUrl("default", "Latest News", "http://rss.news.yahoo.com/rss/topstories")},             
             { new TagTitleUrl("golf channel","Golf Channel", "http://www.thegolfchannel.com/rss/?FeedID=NewsArchive")},
             
             { new TagTitleUrl("sports","Sports", "http://rss.news.yahoo.com/rss/sports")},
             { new TagTitleUrl("economy","Economy", "http://rss.news.yahoo.com/rss/economy")},
             { new TagTitleUrl("heart","Heart", "http://www.medicalnewstoday.com/rss/heart-disease.xml")},
             { new TagTitleUrl("catholic", "Catholic", "http://www.catholic.org/xml/rss_top_news.xml")}
            };

            var newsViewModel = new NewsViewModel();
            newsViewModel.RSSFeeds = rssFeeds;
            newsViewModel.CurrentRSSFeed = rssFeeds.Find(r => r.Tag == tag);
            return View(newsViewModel);
        }
    }
}