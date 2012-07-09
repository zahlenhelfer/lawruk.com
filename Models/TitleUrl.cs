using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawrukmvc.Models
{
    public class TitleUrl : ITitleUrl
    {        
        public string Title { get; set; }
        public string Url { get; set; }

        public TitleUrl() { }        

        public TitleUrl(string title, string url)
        {
            Title = title; Url = url;
        }

        public static string GetLinkOrTitle(string title, string url)
        {            
            if (!string.IsNullOrEmpty(url))
            {
                return "<a href=\"" +  url + "\">" + title + "</a>";
            }
            else
            { 
                return title;   
            } 
        }
    }
}
