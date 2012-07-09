using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace lawrukmvc.Helpers
{
    public class RSS
    {    
        
        public RSS(IList<SyndicationItem> syndicationItems, HttpResponse response, string author, string authorEmailAddress, string rssFeedName, string rssFeedTitle, string baseUri)
        {
            this.CreateRSSFeeds(syndicationItems, response, author, authorEmailAddress, rssFeedName, rssFeedTitle, baseUri);
        }

        public RSS(List<IRSS> itemsPost, HttpResponse response, string author, string authorEmailAddress, string rssFeedName, string rssFeedTitle, string baseUri)
        {
            IList<SyndicationItem> syndicationItems = GetSyndicationItemsFromIRSSList(itemsPost);
            this.CreateRSSFeeds(syndicationItems, response, author, authorEmailAddress, rssFeedName, rssFeedTitle, baseUri);
        }

        public static List<SyndicationItem> GetListFromRSSXmlString(string xml)
        {
            byte[] bytes = System.Text.UTF8Encoding.ASCII.GetBytes(xml);
            XmlReader reader = XmlReader.Create(new MemoryStream(bytes));
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            return feed.Items.ToList();
        }

        public static List<SyndicationItem> GetListFromRSSFeed(string url)
        {
            try
            {
                string xml;
                xml = lawrukmvc.Helpers.Helpers.DownloadString(url);
                xml = xml.Replace("+00:00", "");//Google news    
                //Yahoo weather
                if (url.Contains("weather.yahooapis"))
                {
                    xml = GetYahooWeatherXML(xml);
                }
                return GetListFromRSSXmlString(xml);
            }
            catch
            {
                return new List<SyndicationItem>();
            }
        }

        public static string GetYahooWeatherXML(string xml)
        {
            Match m = Regex.Match(xml, "<pubDate>(.+)</pubDate>");
            if (m.Success)
            {
                string value = m.Value.Replace("<pubDate>", "").Replace("</pubDate>", "");
                DateTime dt = DateTime.Parse(value.Replace("EST", "").Replace("EDT", "").Replace("IST", ""));
                string newDate = dt.ToString("ddd, d MMM yyyy HH:mm:ss") + " GMT";
                xml = xml.Replace(value, newDate);
                xml = Regex.Replace(xml, "<lastBuildDate>(.+)</lastBuildDate>", "<lastBuildDate>" + newDate + "</lastBuildDate>");
                xml = xml.Replace("Conditions for", "");
                xml = xml.Replace("Full Forecast at Yahoo! Weather</a><BR/>", "</a>");
                xml = xml.Replace("(provided by The Weather Channel)<br/>", "");
            }
            return xml;
        }

        public static void CreateRSSFeedFile(string nameOfFeed, IList<IRSS> rssItems)
        {
            IList<SyndicationItem> syndicationItems = GetSyndicationItemsFromIRSSList(rssItems);
            RSS.CreateRSSFeedFile(nameOfFeed, syndicationItems);
        }

        public static void CreateRSSFeedFile(string nameOfFeed, IList<SyndicationItem> syndicationItems)
        {           
            CreateRSSFeedFile(nameOfFeed, nameOfFeed, syndicationItems);
        }

        public static void CreateRSSFeedFile(string titleOfFeed, string fileNameBase, IList<SyndicationItem> syndicationItems)
        {            
            string directoryPath = WebConfigurationManager.AppSettings["RSSDirectory"];
            string fileName = fileNameBase.Replace(" ", "-").ToLower() + ".xml";
            string filePath = directoryPath + "/" + fileName;
            StreamWriter sw = new StreamWriter(filePath);
            string authorEmail = WebConfigurationManager.AppSettings["RSSAuthorEmail"];
            string baseUri = WebConfigurationManager.AppSettings["RSSBaseUri"] + fileName;
            string author = WebConfigurationManager.AppSettings["RSSAuthor"];
            RSS.CreateFeed(syndicationItems, sw.BaseStream, author, authorEmail, titleOfFeed, titleOfFeed, baseUri);
        }       

        private void CreateRSSFeeds(IList<SyndicationItem> syndicationItems, HttpResponse response, string author, string authorEmailAddress, string rssFeedName, string rssFeedTitle, string baseUri)
        {
            // Prepare response
            response.Buffer = false;
            response.Clear();
            response.ContentType = "application/xml";
            RSS.CreateFeed(syndicationItems, response.OutputStream, author, authorEmailAddress, rssFeedName, rssFeedTitle, baseUri);
            response.End();  
        }

        private static void CreateFeed(IList<SyndicationItem> syndicationItems, Stream stream, string author, string authorEmailAddress, string rssFeedDescription, string rssFeedTitle, string baseUri)
        {
            // Create an XmlWriter to write the feed into it
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                // Set the feed properties
                SyndicationFeed feed = new SyndicationFeed
                    (rssFeedTitle, 
                     rssFeedDescription,
                    new Uri(baseUri));

                // Add authors
                feed.Authors.Add(new SyndicationPerson
                    (authorEmailAddress,
                    author,
                    baseUri));

                // Add categories               

                // Set copyright
                feed.Copyright = new TextSyndicationContent
                     ("© Copyright " + DateTime.Now.Year.ToString());

                // Set generator
                feed.Generator = "RSS Generator ";

                // Set language
                feed.Language = "en-US";

                feed.Items = syndicationItems;

                // Write the feed to output
                Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
                rssFormatter.WriteTo(writer);

                writer.Flush();
            }

        }

        private static List<SyndicationItem> GetSyndicationItemsFromIRSSList(IList<IRSS> listOrIRss)
        {
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (var Post in listOrIRss)
            {
                SyndicationItem item = new SyndicationItem();
                item.Id = Post.ID.ToString();
                string linkText = Post.Link;
                item.Title = TextSyndicationContent.CreatePlaintextContent(Post.Title);
                SyndicationLink link = new SyndicationLink(new Uri(linkText), "alternate", Post.Title, "text/html", 1000);

                item.Links.Add(link);
                item.Content = SyndicationContent.CreateXhtmlContent(Post.Body);
                item.PublishDate = Post.PublishDate;

                items.Add(item);
            }
            return items;
        }

    }//class

    public interface IRSS
    {
        string ID { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        DateTime PublishDate { get; set; }
        string Link { get; set; }
    }

}//namespace
