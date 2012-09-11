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
            //TODO Refactor this
            var rssFeeds = new List<TagTitleUrl>()
            {             
             { new TagTitleUrl("latest", "Latest News", "http://rss.news.yahoo.com/rss/topstories")},       
             { new TagTitleUrl("steelers", "Steelers", "http://www.steelersdepot.com/feed/")},
             { new TagTitleUrl("golf channel","Golf Channel", "http://www.thegolfchannel.com/rss/?FeedID=NewsArchive")},
             
             { new TagTitleUrl("sports","Sports", "http://rss.news.yahoo.com/rss/sports")},
             { new TagTitleUrl("economy","Economy", "http://rss.news.yahoo.com/rss/economy")},
             { new TagTitleUrl("heart","Heart", "http://www.medicalnewstoday.com/rss/heart-disease.xml")},
             { new TagTitleUrl("catholic", "Catholic", "http://www.catholic.org/xml/rss_top_news.xml")}
            };

            var newsViewModel = new NewsViewModel();
            newsViewModel.RSSFeeds = rssFeeds;
            string view = "Index";
            if (Helpers.Mobile.ShowMobileSite())
            {
                if (!string.IsNullOrEmpty(tag))
                {
                    view = "Detail";
                }
                else
                {
                    view = "Index.Mobile";
                }
            }
            else
            {
                view = "Index";
                if (string.IsNullOrEmpty(tag))
                {
                    tag = "latest";
                }
            }
            if (!string.IsNullOrEmpty(tag))
            {
                newsViewModel.CurrentRSSFeed = rssFeeds.Find(r => r.Tag == tag);
            }

            var titleUrlList = new TitleUrlListViewModel();
            titleUrlList.Title = "Other News";
            titleUrlList.TitleUrls = new List<ITitleUrl>();
            foreach (var rssFeed in newsViewModel.RSSFeeds)
            {
                var titleUrl = new TitleUrl(rssFeed.Title, "/news/" + rssFeed.Tag);
                titleUrlList.TitleUrls.Add(titleUrl);
            }            
            newsViewModel.TitleUrlListViewModel = titleUrlList;

            return View(view, newsViewModel);
        }
    }
}